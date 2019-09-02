using System;
using System.Collections.Generic;
using System.Text;

namespace PWnpcEditor.classes
{
    public class Offset
    {
	    public int RoleId;
        public int TargetID;
        public string name;
        public int GAME;
        public int COORD;
        public int TARGET;
        public int X;
        public int Y;
        public int Z;
        public int RotX;
        public int RotY;
        public int RotZ;
        public int SELX;
        public int SELY;
        public int SELZ;
        public int SELRotX;
        public int SELRotY;
        public int SELRotZ;

        public Offset(string[] values)
        {
            this.name = values[0];
            this.GAME = ParseString(values[1]);
            this.COORD = ParseString(values[2]);
            this.TARGET = ParseString(values[3]);
            this.X = ParseString(values[4]);
            this.Y = ParseString(values[5]);
            this.Z = ParseString(values[6]);
            this.RotX = ParseString(values[7]);
            this.RotY = ParseString(values[8]);
            this.RotZ = ParseString(values[9]);
            this.SELX = ParseString(values[10]);
            this.SELY = ParseString(values[11]);
            this.SELZ = ParseString(values[12]);
            this.SELRotX = ParseString(values[13]);
            this.SELRotY = ParseString(values[14]);
            this.SELRotZ = ParseString(values[15]);
            this.RoleId = ParseString(values[16]);
            this.TargetID = ParseString(values[17]);
        }

        private int ParseString(string str)
        {
            int lenght = str.Length - 1;
            int loops = 8 - lenght;
            string replaceWith = "";
            int count = 0;
            while (count < loops)
            {
                replaceWith += "0";
                count++;
            }

            string final = str.Replace("$", "0X");
            return (int)new System.ComponentModel.Int32Converter().ConvertFromString(final);
        }
    }
}
