﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonModels2Skin3D.model;
using JsonModels2Skin3D.utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static JsonModels2Skin3D.model.McGeometryJson;

namespace JsonModels2Skin3D
{
    public partial class JsonModels2Skin3D : Form
    {
        public string authorText = "alphaAE";
        public string versionText = "v0.0.2";
        public string descriptionText = "选择基岩版Json实体模型，将在同一文件夹内生成Xml格式的Skin3D模型文件\n\n" +
            "注意事项：\n" +
            "\t目前仅支持低于1.12老版本Json实体模型文件\n";

        public JsonModels2Skin3D()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Versionlabel.Text = authorText + " " + versionText;
            this.Descriptionlabel.Text = descriptionText;
        }

        private void SelectFileBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择模型Json文件";
            fileDialog.Filter = "所有文件(*.json)|*.json";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.selectFileBtn.Enabled = false;
                this.selectFileBtn.Text = "处理中...";
                string file = fileDialog.FileName;
                ToSkin3DFile(file);

                ThreadPool.QueueUserWorkItem(state =>
                {
                    Thread.Sleep(400);
                    selectFileBtn.BeginInvoke(new Action(() =>
                    {
                        this.selectFileBtn.Enabled = true;
                        this.selectFileBtn.Text = "选择文件";
                    }));
                });

                
            }

        }

        private Boolean ToSkin3DFile(string file)
        {
            string content = File.ReadAllText(file);
            JObject jobj = JObject.Parse(content);

            //遍历最外层识别实体个数
            List<string> modelList = new List<string>();
            foreach (var item in jobj)
            {
                if (item.Key == "format_version") continue;
                modelList.Add(item.Key);
            }

            //挨个取出序列化
            foreach (string key in modelList)
            {
                try
                {
                    McGeometryJson personlist = JsonConvert.DeserializeObject<McGeometryJson>(jobj.GetValue(key).ToString());

                    //Skin3DXml init
                    List<Skin3dModelXml.TechneModelsModelGeometryFolderShape> shapelist = new List<Skin3dModelXml.TechneModelsModelGeometryFolderShape>();


                    //序列化默认Xml文件等候处理
                    string thisPath = System.Environment.CurrentDirectory;
                    string contentXml = File.ReadAllText(thisPath + "/assets/dafault.xml");
                    Skin3dModelXml.Techne xmlObject = XmlSerializeUtil.Deserialize(typeof(Skin3dModelXml.Techne), contentXml) as Skin3dModelXml.Techne;

                    //通过Json模型数据构造Xml 内容
                    xmlObject.Name = key;
                    xmlObject.Models.Model.Name = key;
                    xmlObject.Models.Model.TextureSize = "" + personlist.texturewidth + "," + personlist.textureheight;

                    //
                    foreach (Bone bone in personlist.bones)
                    {
                        try
                        {

                            foreach (Cube cube in bone.cubes)
                            {
                                //验证旋转值，防止null
                                float[] rotation = bone.rotation == null ? new float[] { 0, 0, 0 } : bone.rotation;

                                Console.WriteLine(String.Format("原点:[{0},{1},{2}]  点1:[{3},{4},{5}]", bone.pivot[0], bone.pivot[1], bone.pivot[2], cube.origin[0], cube.origin[1], cube.origin[2]));

                                //修复坐标Y反转
                                cube.origin[1] = ((cube.origin[1] + (cube.size[1] / 2)) * -1) - (cube.size[1] / 2);

                                //构造Shape
                                Skin3dModelXml.TechneModelsModelGeometryFolderShape tempShape = new Skin3dModelXml.TechneModelsModelGeometryFolderShape();
                                tempShape.Type = "d9e621f7-957f-4b77-b1ae-20dcd0da7751";
                                tempShape.Name = bone.name + "-" + Guid.NewGuid().ToString("N");    //去重
                                tempShape.IsDecorative = "False";
                                tempShape.IsFixed = "False";
                                tempShape.IsMirrored = "" + (bone.mirror || cube.mirror);
                                tempShape.IsSolid = "False";

                                //BB中实际坐标不受原点影响 Skin3D中受，此处进行补正
                                for (int index = 0; index < cube.origin.Length; index++)
                                {
                                    cube.origin[index] -= bone.pivot[index];
                                }
                                tempShape.Offset = string.Join(",", cube.origin);
                                tempShape.Position = string.Join(",", bone.pivot);

                                //继承父级旋转
                                if (bone.parent != null)
                                {
                                    foreach (Bone findParentBone in personlist.bones)
                                    {
                                        if (findParentBone.name == bone.parent)
                                        {
                                            try
                                            {

                                                float[] parentRotation = findParentBone.rotation == null ? new float[] { 0, 0, 0 } : findParentBone.rotation;
                                                Console.WriteLine(bone.parent + ":" + bone.name + "=>" + rotation.Length + " =>" + parentRotation.Length);
                                                rotation[0] += parentRotation[0];
                                                rotation[1] += parentRotation[1];
                                                rotation[2] += parentRotation[2];
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.ToString());
                                            }

                                        }
                                    }
                                }

                                tempShape.Rotation = string.Join(",", rotation);
                                tempShape.Size = string.Join(",", cube.size);
                                tempShape.TextureOffset = string.Join(",", cube.uv);
                                tempShape.Scale = (decimal)cube.inflate;
                                tempShape.Part = "Chest";
                                tempShape.Hidden = "False";
                                tempShape.IsArmor = "False";

                                shapelist.Add(tempShape);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            continue;
                        }

                    }

                    xmlObject.Models.Model.Geometry.Folder.Shape = shapelist.ToArray();

                    //反序列化处理后的文件并保存
                    string xmlString = XmlSerializeUtil.Serializer(typeof(Skin3dModelXml.Techne), xmlObject);
                    Utils.SaveString2File(new FileInfo(file).DirectoryName + "/" + key + ".xml", xmlString);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    MessageBox.Show(e.ToString(), "出现错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            MessageBox.Show("成功处理下列实体：\n\n" + string.Join("\n", modelList.ToArray()), "处理完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

    }
}
