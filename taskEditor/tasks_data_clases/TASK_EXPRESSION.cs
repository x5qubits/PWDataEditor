
using System;
using System.IO;
namespace sTASKedit
{
    [Serializable]
    public class TASK_EXPRESSION
	{
		public int[] type;
		public float[] value;

        internal static TASK_EXPRESSION Read(int version, BinaryReader br)
        {
            TASK_EXPRESSION TASK_EXPRESSION = new TASK_EXPRESSION();
            TASK_EXPRESSION.type = new int[64];
            TASK_EXPRESSION.value = new float[64];
            for (int i = 0; i < 64; ++i)
            {
                TASK_EXPRESSION.type[i] = br.ReadInt32();
                TASK_EXPRESSION.value[i] = br.ReadSingle();
            }
            return TASK_EXPRESSION;
        }

        internal static void Write(int version, BinaryWriter bw, TASK_EXPRESSION TASK_EXPRESSION)
        {
            for (int i = 0; i < 64; ++i)
            {
                bw.Write(TASK_EXPRESSION.type[i]);
                bw.Write(TASK_EXPRESSION.value[i]);
            }
        }
	}
}

