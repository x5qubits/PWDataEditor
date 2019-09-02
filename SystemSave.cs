using ElementEditor.classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace PWDataEditorPaied
{
    public class SystemCacheManager
    {
        public string Base64Encode(byte[] plainTextBytes)
        {
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private byte[] imageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        IEnumerable<Type> GetSubclasses(Type type)
        {
            return type.Assembly.GetTypes().Where(t => t.IsSubclassOf(type));
        }


        public bool setConfigs(Configs database)
        {
            
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + @"\configs.gsf";
            string b = JsonConvert.SerializeObject(database);
            File.WriteAllBytes(filePath, System.Text.Encoding.UTF8.GetBytes(b));
            
            return true;
        }

        public Configs getConfig()
        {
            
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + @"\configs.gsf";
            Configs database = new Configs();
            if (File.Exists(filePath))
            {
                try
                {
                    database = JsonConvert.DeserializeObject<Configs>(Encoding.UTF8.GetString(File.ReadAllBytes(filePath)));
                    return database;
                }
                catch
                {

                    try
                    {
                        if (System.IO.File.Exists(filePath))
                        {
                            using (Stream file = File.Open(filePath, FileMode.Open))
                            {

                                BinaryFormatter bf = new BinaryFormatter();
                                Configs obj = (Configs)bf.Deserialize(file);
                                Application.DoEvents();
                                database = obj;
                                file.Flush();
                                file.Close();
                                file.Dispose();
                            }
                            if (database != null)
                            {
                                this.setConfigs(database);
                                return database;
                            }
                        }
                    }
                    catch { }
                }
            }
            
            return new Configs();
        }
    }
}
