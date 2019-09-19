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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            foreach (var item in jobj)
            {
                if (item.Key == "format_version") continue;
                modelList.Add(item.Key);
            }
            MessageBox.Show(string.Join("\n", modelList.ToArray()), "识别到实体", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //挨个取出序列化
            foreach (string key in modelList) {
                try {
                    //Console.WriteLine(jobj.GetValue(key) + "\n\n///////////////////////\n");
                    McGeometryJson personlist = JsonConvert.DeserializeObject<McGeometryJson>(jobj.GetValue(key).ToString());
                    Console.WriteLine(personlist.bones.Length);



                } catch (Exception e) {
                    Console.WriteLine(e.ToString());
                }

            }



            return false;
        }
    }
}
