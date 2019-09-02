using MapEditor.MapEditorClasses;
using MapEditor.MapEditorClasses.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MapEditor
{










    public partial class MapEditorForm : Form
    {
        //public Dictionary<int, b;
        public Dictionary<int,m> c = new Dictionary<int, m>();
        private Dictionary<int,List<b>> k = new Dictionary<int, List<b>> ();
        public ArrayList a = new ArrayList();
        private int l;

        public MapEditorForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog eLoad = new OpenFileDialog();
            eLoad.Filter = "Elements File (*.ecwld)|*.ecwld|All Files (*.*)|*.*";
            eLoad.RestoreDirectory = false;
            if (eLoad.ShowDialog() == System.Windows.Forms.DialogResult.OK && File.Exists(eLoad.FileName))
            {
                FileStream fs = File.OpenRead(eLoad.FileName);
                BinaryReader br = new BinaryReader(fs);
                string ecwldPath = Path.GetDirectoryName(eLoad.FileName) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(eLoad.FileName) + ".ecbsd";
                FileStream fs2 = File.OpenRead(ecwldPath);
                BinaryReader ecbsd = new BinaryReader(fs2);

                try
                {
                   
                    EcwldStructure p = new EcwldStructure();
                    p.version = ecbsd.ReadInt32();
                    p.signature = ecbsd.ReadInt32();
                    p.noint = ecbsd.ReadInt32();
                    p.size = ecbsd.ReadInt32();
                    p.garb = ecbsd.ReadBytes(60);
                    EcwldFiles[] kk = new EcwldFiles[p.size];
                    for (int paramString = 0; paramString < p.size; paramString++)
                    {
                        EcwldFiles k = new EcwldFiles();
                        k.lenght = ecbsd.ReadInt32();
                        k.fileName = Encoding.UTF8.GetString(ecbsd.ReadBytes(k.lenght));// Converter.ToString(br.ReadBytes(k.a));
                        kk[paramString] = k;

                    }
                    EcbsdData f = new EcbsdData();
                    f.a = br.ReadInt32();
                    f.b = br.ReadInt32();
                    f.c = br.ReadSingle();
                    f.d = br.ReadSingle();
                    f.e = br.ReadSingle();
                    f.f = br.ReadInt32();
                    f.g = br.ReadInt32();
                    f.h = br.ReadInt32();
                    f.i = br.ReadInt32();
                    f.j = br.ReadInt32();
                    f.k = br.ReadInt32();
                    f.l = br.ReadInt32();
                    f.m = br.ReadInt32();
                    f.n = br.ReadInt32();
                    f.o = br.ReadBytes(60);
                    int[] g = new int[f.g];
                    for (int i2 = 0; i2 < g.Length; i2++)
                    {
                        g[i2] = br.ReadInt32();
                    }
                    int n3 = 0;
                    while (n3 < f.g)
                    {
                        br.BaseStream.Position = g[n3];
                        int n5 = f.b;
                        MapInterface f2 = n5 >= 9 ? new MapInterface() : null;                     
                        f2.read(br);
                        a.Add(f2);
                            int n4 = 0;
                            if (f2.c > 0)
                            {
                                n4 = 0;
                                while (n4 < f2.c)
                                {

                                    PositionData k3 = new PositionData();
                                    try
                                    {
                                        k3.a = br.ReadInt32();
                                        k3.b.ar(br);
                                    }
                                    catch { }
                                    f2.n.Add(k3);
                                    ++n4;
                                }
                            }
                            if (f2.d > 0)
                            {
                                n4 = 0;
                                while (n4 < f2.d)
                                {
                                    m k2 = new m();
                                    new m().a = br.ReadInt32();
                                    k2.b = br.ReadInt32();
                                    k2.c = "WATER";
                                    f2.j.Add(k2);
                                    ae((m)k2, n3);
                                    ++n4;
                                }
                            }
                            if (f2.f > 0)
                            {
                                n4 = 0;
                                while (n4 < f2.f)
                                {
                                    m k2 = new m();
                                    k2.a = br.ReadInt32();
                                    k2.b = br.ReadInt32();
                                    k2.c = "ORN";
                                    f2.l.Add(k2);
                                    ae((m)k2, n3);
                                    ++n4;
                                }
                            }
                            if (f2.g > 0)
                            {
                                n4 = 0;
                                while (n4 < f2.g)
                                {
                                    m k2 = new m();
                                    k2.a = br.ReadInt32();
                                    k2.b = br.ReadInt32();
                                    k2.c = "BOX";
                                    f2.h.Add(k2);
                                    ae((m)k2, n3);
                                    ++n4;
                                }
                            }
                            if (f2.e > 0)
                            {
                                n4 = 0;
                                while (n4 < f2.e)
                                {
                                    m k2 = new m();
                                    k2.a = br.ReadInt32();
                                    k2.b = br.ReadInt32();
                                    k2.c = "GRASS";
                                    f2.k.Add(k2);
                                    this.ae((m)k2, n3);
                                    ++n4;
                                }
                            }

                        if (f2.r > 0)
                        {                          
                            try
                            {
                                hx h2 = new hx();
                                h2.a = br.ReadInt32();
                                h2.b = br.ReadSingle();
                                h2.c.ar(br);
                                h2.d.ar(br);
                                h2.e.ar(br);
                                h2.f = br.ReadSingle();
                                h2.g = br.ReadInt32();
                                h2.h = br.ReadSingle();
                                h2.i = br.ReadInt32();
                                h2.j = br.ReadInt32();
                                h2.k = br.ReadBytes(h2.j);
                            }
                            catch (IOException v1) { }
                        }
                        if (f2.s > 0)
                        {
                            gx g2 = new gx();
                            try
                            {
                                g2.a = br.ReadInt32();
                                g2.b.ar(br);
                                g2.c.ar(br);
                                g2.d.ar(br);
                                g2.e = br.ReadInt32();
                                g2.f = br.ReadBytes(g2.e);
                                g2.g = br.ReadInt32();
                                g2.h = Encoding.GetEncoding("gb2312").GetString(br.ReadBytes(g2.g));
                            }
                            catch { }
                        }
                        if (f2.t > 0) {
                        n4 = 0;
                        while (n4 < f2.t)
                        {
                            m k2 = new m();
                            new m().a = br.ReadInt32();
                            k2.b = br.ReadInt32();
                            k2.c = "CRITTER";
                            f2.m.Add(k2);
                            ae((m)k2, n3);
                            ++n4;
                        }
                        }
                        if (f2.u > 0) {
                        n4 = 0;
                        while (n4 < f2.u)
                        {
                            m k2 = new m();
                            new m().a = br.ReadInt32();
                            k2.b = br.ReadInt32();
                            k2.c = "BEZIER";
                            f2.i.Add(k2);
                            this.ae((m)k2, n3);
                            ++n4;
                        }
                    }
                        if (f2.v > 0) {
                        n4 = 0;
                        while (n4 < f2.v)
                        {
                            j k2 = new j();
                            try
                            {
                                    k2.a = br.ReadInt32();
                                    k2.b.ar(br);
                                    k2.c = br.ReadSingle();
                                    k2.d = br.ReadSingle();
                                    k2.e = br.ReadInt32();
                                    k2.f = br.ReadInt32();
                                    k2.g = br.ReadInt32();
                                    k2.h = Encoding.GetEncoding("gb2312").GetString(br.ReadBytes(k2.g));//br.ReadBytes(k2.g);
                            }
                            catch (IOException v3) { }
                            f2.q.Add(k2);
                            ++n4;
                        }
                    }
                    ++n3;

                }

                }
                catch(Exception esad) {
                    MessageBox.Show("ERR");

                }
            }
        }

        private void ae(m m2, int n2)
        {
            if (!this.c.ContainsKey(m2.a))
            {
                this.c.Add(m2.a, m2);
                return;
            }
            m data = c[m2.a];
            if (data.b != m2.b || !data.c.Equals(m2.c))
            {
                b b2;
                ++this.l;
                if (!this.k.ContainsKey(m2.a))
                {
                    b b3 = new b(m2);
                    List<b> xx = new List<b>();
                    xx.Add(b3);
                    this.k.Add(m2.a, xx);
                    return;
                }
                List<b> xxxx = this.k[m2.a];
                bool bl = true;
                foreach(b b2x in xxxx)
                {
                    if (!b2x.a.c.Equals(m2.c) || b2x.a.b != m2.b) continue;
                    bl = false;
                }
                if (bl)
                {
                    b2 = new b(m2);
                    xxxx.Add(b2);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
