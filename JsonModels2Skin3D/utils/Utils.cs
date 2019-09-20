using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonModels2Skin3D {
    class Utils {

        //读取文件数据加载到Dictionary中  
        public static string ReadFile2String(string path) {
            try {
                if (File.Exists(path)) {
                    FileStream fs = new FileStream(path, FileMode.Open);
                    StreamReader sr = new StreamReader(fs);
                    string readout = sr.ReadToEnd();
                    if (fs != null) {
                        fs.Close();
                    }
                    if (sr != null) {
                        sr.Close();
                    }
                    return readout;
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            } finally {

            }
            return null;
        }

        //将数据保存到本地文件  
        public static void SaveString2File(string path, string content) {
            try {
                FileStream file = new FileStream(path, FileMode.Create);
                byte[] bts = System.Text.Encoding.UTF8.GetBytes(content);
                file.Write(bts, 0, bts.Length);
                if (file != null) {
                    file.Close();
                }
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            } finally {

            }
        }

    }
}
