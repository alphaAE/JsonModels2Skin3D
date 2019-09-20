using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JsonModels2Skin3D.model;
using JsonModels2Skin3D.utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static JsonModels2Skin3D.model.McGeometryJson;

namespace JsonModels2Skin3D {
    public partial class JsonModels2Skin3D : Form {

        public string versionText = "v0.0.1";

        public JsonModels2Skin3D() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Versionlabel.Text = versionText;
        }

        private void SelectFileBtn_Click(object sender, EventArgs e) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择模型Json文件";
            fileDialog.Filter = "所有文件(*.json)|*.json";
            if (fileDialog.ShowDialog() == DialogResult.OK) {
                string file = fileDialog.FileName;
                ToSkin3DFile(file);
            }
        }

        private Boolean ToSkin3DFile(string file) {
            string content = File.ReadAllText(file);
            JObject jobj = JObject.Parse(content);

            //遍历最外层识别实体个数
            List<string> modelList = new List<string>();
            foreach (var item in jobj) {
                if (item.Key == "format_version") continue;
                modelList.Add(item.Key);
            }
            MessageBox.Show(string.Join("\n", modelList.ToArray()), "识别到实体", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //挨个取出序列化
            foreach (string key in modelList) {
                try {
                    McGeometryJson personlist = JsonConvert.DeserializeObject<McGeometryJson>(jobj.GetValue(key).ToString());
                    Console.WriteLine(personlist.bones.Length);


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
                    foreach (Bone bone in personlist.bones) {
                        int cubeNum = 0;
                        try {
                            foreach (Cube cube in bone.cubes) {
                                //修复坐标Y反转
                                cube.origin[1] = ((cube.origin[1] + (cube.size[1] / 2)) * -1) - (cube.size[1] / 2);

                                Skin3dModelXml.TechneModelsModelGeometryFolderShape tempShape = new Skin3dModelXml.TechneModelsModelGeometryFolderShape();
                                tempShape.Type = "d9e621f7-957f-4b77-b1ae-20dcd0da7751";
                                tempShape.Name = bone.name + cubeNum++;
                                tempShape.IsDecorative = "False";
                                tempShape.IsFixed = "False";
                                tempShape.IsMirrored = "" + (bone.mirror || cube.mirror);
                                tempShape.IsSolid = "False";
                                tempShape.Offset = "0,0,0"; //暂时使用同一原点
                                tempShape.Position = string.Join(",", cube.origin);
                                tempShape.Rotation = bone.rotation == null ? "0,0,0" : string.Join(",", bone.rotation);
                                tempShape.Size = string.Join(",", cube.size);
                                tempShape.TextureOffset = string.Join(",", cube.uv);
                                tempShape.Scale = (decimal)cube.inflate;
                                tempShape.Part = "Chest";
                                tempShape.Hidden = "False";
                                tempShape.IsArmor = "False";

                                shapelist.Add(tempShape);
                            }
                        } catch (Exception e) {
                            Console.WriteLine(e.ToString());
                            continue;
                        }

                    }

                    xmlObject.Models.Model.Geometry.Folder.Shape = shapelist.ToArray();

                    //反序列化处理后的文件并保存
                    string xmlString = XmlSerializeUtil.Serializer(typeof(Skin3dModelXml.Techne), xmlObject);
                    Utils.SaveString2File(new FileInfo(file).DirectoryName + "/" + key + ".xml", xmlString);

                    //仅测试一个即退出
                    break;
                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }

            }

            return true;
        }
    }
}
