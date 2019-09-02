
using System;
using System.Collections.Generic;

using System.Text;

namespace sTASKedit
{
	class ModifierTable
	{
        public static int GetModifier(int Lvl)
        {
            int Modifier = 0;
            if (Lvl >= 100)
            {
                Modifier = 4000;
            }
            else
            switch (Lvl)
            {
                case 1:
                    Modifier = 1;
                    break;
                case 2:
                    Modifier = 1;
                    break;
                case 3:
                    Modifier = 2;
                    break;
                case 4:
                    Modifier = 4;
                    break;
                case 5:
                    Modifier = 7;
                    break;
                case 6:
                    Modifier = 9;
                    break;
                case 7:
                    Modifier = 12;
                    break;
                case 8:
                    Modifier = 16;
                    break;
                case 9:
                    Modifier = 20;
                    break;
                case 10:
                    Modifier = 25;
                    break;
                case 11:
                    Modifier = 30;
                    break;
                case 12:
                    Modifier = 35;
                    break;
                case 13:
                    Modifier = 40;
                    break;
                case 14:
                    Modifier = 46;
                    break;
                case 15:
                    Modifier = 52;
                    break;
                case 16:
                    Modifier = 59;
                    break;
                case 17:
                    Modifier = 65;
                    break;
                case 18:
                    Modifier = 72;
                    break;
                case 19:
                    Modifier = 79;
                    break;
                case 20:
                    Modifier = 87;
                    break;
                case 21:
                    Modifier = 95;
                    break;
                case 22:
                    Modifier = 102;
                    break;
                case 23:
                    Modifier = 110;
                    break;
                case 24:
                    Modifier = 118;
                    break;
                case 25:
                    Modifier = 127;
                    break;
                case 26:
                    Modifier = 135;
                    break;
                case 27:
                    Modifier = 143;
                    break;
                case 28:
                    Modifier = 152;
                    break;
                case 29:
                    Modifier = 157;
                    break;
                case 30:
                    Modifier = 158;
                    break;
                case 31:
                    Modifier = 168;
                    break;
                case 32:
                    Modifier = 179;
                    break;
                case 33:
                    Modifier = 190;
                    break;
                case 34:
                    Modifier = 202;
                    break;
                case 35:
                    Modifier = 214;
                    break;
                case 36:
                    Modifier = 227;
                    break;
                case 37:
                    Modifier = 239;
                    break;
                case 38:
                    Modifier = 253;
                    break;
                case 39:
                    Modifier = 267;
                    break;
                case 40:
                    Modifier = 281;
                    break;
                case 41:
                    Modifier = 296;
                    break;
                case 42:
                    Modifier = 311;
                    break;
                case 43:
                    Modifier = 327;
                    break;
                case 44:
                    Modifier = 343;
                    break;
                case 45:
                    Modifier = 360;
                    break;
                case 46:
                    Modifier = 377;
                    break;
                case 47:
                    Modifier = 390;
                    break;
                case 48:
                    Modifier = 402;
                    break;
                case 49:
                    Modifier = 414;
                    break;
                case 50:
                    Modifier = 426;
                    break;
                case 51:
                    Modifier = 438;
                    break;
                case 52:
                    Modifier = 449;
                    break;
                case 53:
                    Modifier = 460;
                    break;
                case 54:
                    Modifier = 471;
                    break;
                case 55:
                    Modifier = 480;
                    break;
                case 56:
                    Modifier = 489;
                    break;
                case 57:
                    Modifier = 497;
                    break;
                case 58:
                    Modifier = 505;
                    break;
                case 59:
                    Modifier = 510;
                    break;
                case 60:
                    Modifier = 515;
                    break;
                case 61:
                    Modifier = 535;
                    break;
                case 62:
                    Modifier = 553;
                    break;
                case 63:
                    Modifier = 588;
                    break;
                case 64:
                    Modifier = 624;
                    break;
                case 65:
                    Modifier = 660;
                    break;
                case 66:
                    Modifier = 698;
                    break;
                case 67:
                    Modifier = 736;
                    break;
                case 68:
                    Modifier = 775;
                    break;
                case 69:
                    Modifier = 814;
                    break;
                case 70:
                    Modifier = 853;
                    break;
                case 71:
                    Modifier = 893;
                    break;
                case 72:
                    Modifier = 978;
                    break;
                case 73:
                    Modifier = 1066;
                    break;
                case 74:
                    Modifier = 1157;
                    break;
                case 75:
                    Modifier = 1250;
                    break;
                case 76:
                    Modifier = 1344;
                    break;
                case 77:
                    Modifier = 1438;
                    break;
                case 78:
                    Modifier = 1530;
                    break;
                case 79:
                    Modifier = 1620;
                    break;
                case 80:
                    Modifier = 1705;
                    break;
                case 81:
                    Modifier = 1784;
                    break;
                case 82:
                    Modifier = 1853;
                    break;
                case 83:
                    Modifier = 1910;
                    break;
                case 84:
                    Modifier = 1953;
                    break;
                case 85:
                    Modifier = 1976;
                    break;
                case 86:
                    Modifier = 1983;
                    break;
                case 87:
                    Modifier = 2116;
                    break;
                case 88:
                    Modifier = 2213;
                    break;
                case 89:
                    Modifier = 2304;
                    break;
                case 90:
                    Modifier = 2455;
                    break;
                case 91:
                    Modifier = 2679;
                    break;
                case 92:
                    Modifier = 2837;
                    break;
                case 93:
                    Modifier = 2990;
                    break;
                case 94:
                    Modifier = 3136;
                    break;
                case 95:
                    Modifier = 3272;
                    break;
                case 96:
                    Modifier = 3282;
                    break;
                case 97:
                    Modifier = 3388;
                    break;
                case 98:
                    Modifier = 3477;
                    break;
                case 99:
                    Modifier = 3543;
                    break;
            }
            return Modifier;
        }
	}
}

