using PacketCripto;
using PWDataEditorPaied;
using Shield.classes.net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lecence_Activator
{
    public partial class Form1 : Form
    {
        private int[] arx = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private string password;
        private bool isUpdate;

        public Form1()
        {
            InitializeComponent();
        }

        public void checking(int input)
        {
            try
            {
                CheckBox checkbox = (CheckBox)this.Controls.Find("box_" + input.ToString(), true)[0];
                if (checkbox != null && checkbox.Checked)
                {
                    this.arx[input] = 1;
                }
                if (checkbox != null && !checkbox.Checked)
                {
                    this.arx[input] = 0;
                }
            }
            catch { }
        }

        private void init()
        {
            
            for (int i = 0; i < this.arx.Length; i++)
            {
                this.checking(i);
            }
            
        }

        /*
        bax.writeInt(0); //hasFileEncription 0
        bax.writeInt(1); //Enable Admin 1
        bax.writeInt(1); //Enable ElementEditor 2
        bax.writeInt(1); //Enable Task 3
        bax.writeInt(1); //Enable Gshop 4
        bax.writeInt(1); //Enable Npc 5
        bax.writeInt(1); //Enable Ai 6
        bax.writeInt(1); //Enable pck 7
        bax.writeInt(1); //Enable Domain 8
        */

        private void Form1_Shown(object sender, EventArgs e)
        {
            isUpdate = true;
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "/lic_pre.bin";
            HashMap<string, Object> hx = new HashMap<string, object>();
            if (File.Exists(path))
            {
                byte[] file = File.ReadAllBytes(path);
                ByteArray bax = new ByteArray();
                ByteArray bax2 = new ByteArray();
                bax.Write(file, 0, file.Length);
                int a1 = bax.ReadInt32(); //Read bytearry position
                for (int i = 0; i < this.arx.Length; i++)
                {
                     bax.ReadInt32(); // Read futures
                }
                bax.Position(a1);
                int a2 = bax.ReadInt32(); //Read bytearray lenght
                bax.readBytes3(bax2, a1, a2, true, 50); //Read from position to lenght
                int a3 = bax2.ReadInt32();//Read key lenght
                String data = Encoding.ASCII.GetString((bax2.readBytes4(0, a3)));
                Dictionary<string, object> a23 = bax2.readObject(0);
                a23.Add("20", this.arx);
                hx.Addall(a23);
                PlainTexter pk = new PlainTexter(Encoding.ASCII.GetBytes("o680664zxcxzc2kbM7c5"));
                hwKey.Text = pk.Deside(data, "pweditorheX#822443");
                versionBox.Text = hx["0"].ToString();
                username.Text = hx["2"].ToString();
                password = "pweditorheX#" + username.Text.Trim().Replace(" ", string.Empty);
                textBox1.Text = password;
                box_0.Checked = true;
                box_2.Checked = true;
                box_1.Checked = true;
            }
            init();
            isUpdate = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "/lic.bin";
            HashMap<string, Object> hx = new HashMap<string, object>();
            PlainTexter pk = new PlainTexter(Encoding.ASCII.GetBytes(hwKey.Text));
            byte[] win32 = Encoding.ASCII.GetBytes(pk.Eside(hwKey.Text, password));
            byte[] pass = Encoding.ASCII.GetBytes(password);
            ByteArray ba = new ByteArray();
            ba.writeInt(win32.Length); //Write key lenght
            ba.writeInt(pass.Length); //Write password lenght
            
            ba.writeBytes(win32); //Write key            
            ba.writeBytes(pass); //Write password
            ByteArray bax = new ByteArray();
            bax.writeInt(0); //Write Position for packet
            hx.Add("0", versionBox.Text);
            hx.Add("1", true);
            hx.Add("2", username.Text);
            ba.writeObject(hx);
            byte[] all = ba.Consume();
            for (int i = 0; i < this.arx.Length; i++)
            {
                bax.writeInt(this.arx[i]); //Write futures
            }
            int cursor = bax.Position(); //Save cursor position
            bax.Position(0);
            bax.writeInt(cursor);//Wrie bytearray position at the begining
            bax.Position(cursor);
             
            bax.writeInt(all.Length);// Write bytearray lenght
            bax.writeInt(int.Parse(textBox2.Text)); //Write xor
            bax.writeBytes(all, true, int.Parse(textBox2.Text)); //Encrypt all bytearry
            bax.writeBytes(new byte[1024]); //Write fake bytes
            bax.writeBytes(Encoding.ASCII.GetBytes("Games Shark Licence key! Copyright @ 2016 all Rights Reserved!"));
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "LickFile (lic.bin)|lic.bin|All Files (*.*)|*.*";
            save.FileName = "lic.bin";
            if (save.ShowDialog() == DialogResult.OK && save.FileName != "")
            {
                File.WriteAllBytes(save.FileName, bax.Consume());
            }
        }

        private void username_TextChanged(object sender, EventArgs e)
        {
            password = "pweditorheX#" + username.Text.Trim().Replace(" ", string.Empty);
            textBox1.Text = password;
        }

        private void domainBox_8_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdate) return;
            if(sender is CheckBox)
            {
                CheckBox box = (CheckBox)sender;
                int id = int.Parse(box.Name.Split('_')[1]);
                this.arx[id] = box.Checked ? 1 : 0;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string path in paths)
            {
                HashMap<string, Object> hx = new HashMap<string, object>();
                if (File.Exists(path))
                {
                    try
                    {
                        byte[] file = File.ReadAllBytes(path);
                        ByteArray bax = new ByteArray();
                        ByteArray bax2 = new ByteArray();
                        bax.Write(file, 0, file.Length);
                        int a1 = bax.ReadInt32(); //Read bytearry position
                        for (int i = 0; i < this.arx.Length; i++)
                        {
                             bax.ReadInt32(); // Read futures
                        }
                        bax.Position(a1);
                        int a2 = bax.ReadInt32(); //Read bytearray lenght
                        bax.readBytes3(bax2, a1, a2, true, 50); //Read from position to lenght
                        int a3 = bax2.ReadInt32();//Read key lenght
                        String data = Encoding.ASCII.GetString((bax2.readBytes4(0, a3)));
                        Dictionary<string, object> a23 = bax2.readObject(0);
                        a23.Add("20", this.arx);
                        hx.Addall(a23);
                        PlainTexter pk = new PlainTexter(Encoding.ASCII.GetBytes("o680664zxcxzc2kbM7c5"));
                        hwKey.Text = pk.Deside(data, "pweditorheX#822443");
                        versionBox.Text = hx["0"].ToString();
                        username.Text = hx["2"].ToString();
                        password = "pweditorheX#" + username.Text.Trim().Replace(" ", string.Empty);
                        textBox1.Text = password;
                        box_0.Checked = true;
                        box_2.Checked = true;
                        box_1.Checked = true;
                    }
                    catch {
                        box_0.Checked = true;
                        box_2.Checked = true;
                        box_1.Checked = true;
                        versionBox.Text = hwKey.Text = username.Text = textBox1.Text = "";

                    }
                }
            }

        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
    }
}
