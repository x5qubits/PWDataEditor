using JHUI;
using JHUI.Forms;
using PWDataEditorPaied.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static PWDataEditorPaied.Classes.InconPacker;

namespace ElementEditor
{
    public partial class ImageChange : JForm
    {
        private int _id = -1;
        private InconPacker packer = null;
        private GeneralIcon icon;
        public ImageChange(int id, string path)
        {
            InitializeComponent();
            
            packer = InconPacker.Instance;
            pictureBox1.Image = packer.sourceBitmap;
            icon = packer.getIcon(Path.GetFileName(path));
            _id = id;
        }

        private double y, x, a = 0;
        private bool Dragging;
        private int xPos;
        private int yPos;
        private Point mouseDownLoc;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e) { Dragging = false; }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            showContext = false;
            if (e.Button == MouseButtons.Left)
            {
                mouseDownLoc = e.Location;        
                xPos = e.X - 16;
                yPos = e.Y - 16;
                y = 0;
                x = 0;
                a = 0;
                x = Math.Round(xPos / (double)32);
                y = Math.Round(yPos / (double)32);
                a = y * packer.cols + x;
                int row = (int)(x * 32);
                int column = (int)(y * 32);
               
                icon = packer.GetIconAtPoint(new Point((int)row, (int)column));
                if (icon != null)
                {
                    locked = true;
                    jTextBox1.Text = icon.name;
                    locked = false;
                }
                else
                {
                    locked = true;
                    jTextBox1.Text = "Unknown";
                    locked = false;
                }
                pictureBox1.Refresh();
            }
            else if(e.Button == MouseButtons.Right)
            {
                mouseDownLoc = e.Location;
                Dragging = true;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging)
            {
                Point currentMousePos = e.Location;
                int distanceX = currentMousePos.X - mouseDownLoc.X;
                int distanceY = currentMousePos.Y - mouseDownLoc.Y;
                int newX = pictureBox1.Location.X + distanceX;
                int newY = pictureBox1.Location.Y + distanceY;

                if (newX + pictureBox1.Image.Width < pictureBox1.Image.Width && pictureBox1.Image.Width + newX > panel1.Width)
                    pictureBox1.Location = new Point(newX, pictureBox1.Location.Y);
                if (newY + pictureBox1.Image.Height < pictureBox1.Image.Height && pictureBox1.Image.Height + newY > panel1.Height)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, newY);
            }

        }
        bool locked = false;
        private void ImageChange_Shown(object sender, EventArgs e)
        {
            //632, 467
            if (icon != null)
            {
                int newX = ~(icon.Location.X - 16);
                int newY = ~(icon.Location.Y - 16);
                x = Math.Round(icon.Location.X / (double)32);
                y = Math.Round(icon.Location.Y / (double)32);
                a = y * packer.cols + x;
                pictureBox1.Location = new Point(newX, newY);
                if (icon != null)
                {
                    locked = true;
                    jTextBox1.Text = icon.name;
                    locked = false;
                }
                else
                {
                    locked = true;
                    jTextBox1.Text = "Unknown";
                    locked = false;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (icon != null)
            {
                e.Graphics.DrawRectangle(new Pen(Brushes.Red, 2), new Rectangle(new Point((int)icon.Location.X, (int)icon.Location.Y), new Size(32, 32)));
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (icon != null)
                {
                    ElementsEditor.selectedImage = icon.name;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please select an icon!");
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                showContext = true;
                jContextMenu1.Show(this, new Point(e.X + ((Control)sender).Left + 20, e.Y + ((Control)sender).Top + 20));
            }
        }
        private bool showContext = false;

        private void jPictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog eSave = new SaveFileDialog();
            eSave.RestoreDirectory = false;
            eSave.FileName = Path.GetFileName(packer.currentImagePath);
            if (eSave.ShowDialog() == System.Windows.Forms.DialogResult.OK && eSave.FileName != "")
            {
                try
                {
                    bool saved = false;
                    saved = packer.saveImage(eSave.FileName);
                    if (saved)
                    {
                        MessageBox.Show("Pack Saved!");
                        pictureBox1.Image = packer.sourceBitmap;
                    }
                    else
                        MessageBox.Show("Pack not Saved!");
                }
                catch (Exception eas)
                {
                    MessageBox.Show("Save error:" + eas.ToString());
                }
            }
        }

        private void jPictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "Icon Pack (*.dds)|*.dds|All files (*.*)|*.*";
            load.DefaultExt = "dds";
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
            {
                DialogResult dia = JMessageBox.Show(this, "Do you want to mearge the icon pack?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(dia == DialogResult.Yes)
                {
                    if (packer.LoadFiles(load.FileName, true))
                    {
                        pictureBox1.Image = packer.sourceBitmap;
                        pictureBox1.Refresh();
                    }
                }
                else
                {
                    if (packer.LoadFiles(load.FileName, false))
                    {
                        pictureBox1.Image = packer.sourceBitmap;
                        pictureBox1.Refresh();
                    }
                }
            }
        }

        private void jTextBox1_ButtonClick(object sender, EventArgs e)
        {
            if (!locked)
            {
                packer.setName(icon, jTextBox1.Text);
            }
        }

        private void jTextBox2_ButtonClick(object sender, EventArgs e)
        {
            GeneralIcon iconx = packer.getByAproximation(jTextBox2.Text);
            if(iconx != null)
            {
                icon = iconx;
                if (icon != null)
                {

                    int newX = ~(icon.Location.X - 16);
                    int newY = ~(icon.Location.Y - 16);
                    x = Math.Round(icon.Location.X / (double)32);
                    y = Math.Round(icon.Location.Y / (double)32);
                    a = y * packer.cols + x;
                    int row = (int)(x * 32);
                    int column = (int)(y * 32);
                    pictureBox1.Location = new Point(newX, newY);
                    pictureBox1.Refresh();
                    if (icon != null)
                    {
                        locked = true;
                        jTextBox1.Text = icon.name;
                        locked = false;
                    }
                    else
                    {
                        locked = true;
                        jTextBox1.Text = "Unknown";
                        locked = false;
                    }
                }
            }
        }

        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(icon != null)
            {
                packer.Delete(icon);
                pictureBox1.Refresh();
                pictureBox1.Image = packer.sourceBitmap;
            }
        }

        private void addImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog();
            load.Filter = "Icon (*.png)|*.png|Icon (*.jpg)|*.jpg|All files (*.*)|*.*";
            load.DefaultExt = "dds";
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(load.FileName))
            {
                icon = packer.addFile(load.FileName);
                pictureBox1.Refresh();
                pictureBox1.Image = packer.sourceBitmap;

                int newX = ~(icon.Location.X - 16);
                int newY = ~(icon.Location.Y - 16);
                x = Math.Round(icon.Location.X / (double)32);
                y = Math.Round(icon.Location.Y / (double)32);
                a = y * packer.cols + x;
                int row = (int)(x * 32);
                int column = (int)(y * 32);
                pictureBox1.Location = new Point(newX, newY);
                pictureBox1.Refresh();
                if (icon != null)
                {
                    locked = true;
                    jTextBox1.Text = icon.name;
                    locked = false;
                }
                else
                {
                    locked = true;
                    jTextBox1.Text = "Unknown";
                    locked = false;
                }

            }
        }

        private void jContextMenu1_Opening(object sender, CancelEventArgs e)
        {
            if(!showContext)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog eSave = new SaveFileDialog();
            eSave.RestoreDirectory = false;
            eSave.Filter = "Bmp(*.png)|*.png|Bmp(*.bmp)|*.bmp|Jpg(*.jpg)|*.jpg";
            eSave.FileName = _id.ToString();
            if (eSave.ShowDialog() == System.Windows.Forms.DialogResult.OK && eSave.FileName != "")
            {
                try
                {
                    if (icon != null)
                    {
                        String name = icon.name;
                        switch (Path.GetExtension(eSave.FileName))
                        {
                            case ".png":
                                icon.icon.Save(eSave.FileName, ImageFormat.Png);
                                break;
                            case ".jpg":
                                icon.icon.Save(eSave.FileName, ImageFormat.Jpeg);
                                break;
                            case ".bmp":
                                icon.icon.Save(eSave.FileName, ImageFormat.Bmp);
                                break;
                            default:
                                icon.icon.Save(eSave.FileName, ImageFormat.Bmp);
                                break;

                        }
                        
                    }
                    
                    MessageBox.Show("File Saved!");
                }
                catch (Exception eas)
                {
                    MessageBox.Show("Save error:" + eas.ToString());
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (icon != null)
            {
                ElementsEditor.selectedImage = icon.name;
                this.Close();
            }else
            {
                MessageBox.Show("Please select an icon!");
            }
        }
    }
}
