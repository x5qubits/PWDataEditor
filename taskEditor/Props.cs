
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace sTASKedit
{
    public class Props
    {
        public PropsFields Fields;

        public Props()
        {
            Fields = new PropsFields();
        }

        public String XMLFileName = Path.GetDirectoryName(Application.ExecutablePath) + "\\configs\\settings.xml";

        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
            TextWriter writer = new StreamWriter(XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }

        public void ReadXml()
        {
            if (File.Exists(XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
                TextReader reader = new StreamReader(XMLFileName);
                Fields = ser.Deserialize(reader) as PropsFields;
                reader.Close();
            }
        }
    }

    public class PropsFields
    {
        public Boolean EnableChangeConf = false;
        public Boolean EnableShowTips = true;
        public int PWDBLang = 0;
        public Boolean EnableBackups = true;
        public Boolean EnableToClipboard = true;
        public int Language = 0;
        public Boolean EnableShowDigits = false;
        public Boolean EnableShowPercents = false;
        public Boolean EnableAutoLoadElements = false;
        public string ElementsPath = "";
        public Boolean EnableShowInfo = true;
        public Boolean EnableSetNewID = true;
        public Boolean EnableAutoDetectNewID = true;
        public Size PWDBWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectItemIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectItemIdWindow_dataGridView_Props_Size = new System.Drawing.Size(0, 0);
        public Size SelectMonsterIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectNPCIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectMonsterNPCMineIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectTitleIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectHomeItemIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectBuffIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectWorldIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectSkillIdWindow_Size = new System.Drawing.Size(0, 0);
        public Size SelectRelayStationIdWindow_Size = new System.Drawing.Size(0, 0);
    }
}

