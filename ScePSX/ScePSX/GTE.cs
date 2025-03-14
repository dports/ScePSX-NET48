using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ScePSX;

[Serializable]
public class GTE
{
	[Serializable]
	private struct Matrix
	{
		public Vector3 v1;

		public Vector3 v2;

		public Vector3 v3;
	}

	[Serializable]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	private struct Vector3
	{
		[FieldOffset(0)]
		public uint XY;

		[FieldOffset(0)]
		public short x;

		[FieldOffset(2)]
		public short y;

		[FieldOffset(4)]
		public short z;
	}

	[Serializable]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	private struct Vector2
	{
		[FieldOffset(0)]
		public uint val;

		[FieldOffset(0)]
		public short x;

		[FieldOffset(2)]
		public short y;
	}

	[Serializable]
	[StructLayout(LayoutKind.Explicit, Size = 16)]
	private struct Color
	{
		[FieldOffset(0)]
		public uint val;

		[FieldOffset(0)]
		public byte r;

		[FieldOffset(1)]
		public byte g;

		[FieldOffset(2)]
		public byte b;

		[FieldOffset(3)]
		public byte c;
	}

	private Vector3[] V = new Vector3[3];

	private Color RGBC;

	private ushort OTZ;

	private short[] IR = new short[4];

	private Vector2[] SXY = new Vector2[4];

	private ushort[] SZ = new ushort[4];

	private Color[] RGB = new Color[3];

	private uint RES1;

	private int MAC0;

	private int MAC1;

	private int MAC2;

	private int MAC3;

	private ushort IRGB;

	private int LZCS;

	private int LZCR;

	private Matrix RT;

	private Matrix LM;

	private Matrix LRGB;

	private int TRX;

	private int TRY;

	private int TRZ;

	private int RBK;

	private int GBK;

	private int BBK;

	private int RFC;

	private int GFC;

	private int BFC;

	private int OFX;

	private int OFY;

	private int DQB;

	private ushort H;

	private short ZSF3;

	private short ZSF4;

	private short DQA;

	private uint FLAG;

	private int sf;

	private bool lm;

	private uint currentCommand;

	private static ReadOnlySpan<byte> unrTable => new byte[257]
	{
		255, 253, 251, 249, 247, 245, 243, 241, 239, 238,
		236, 234, 232, 230, 228, 227, 225, 223, 221, 220,
		218, 216, 214, 213, 211, 209, 208, 206, 205, 203,
		201, 200, 198, 197, 195, 193, 192, 190, 189, 187,
		186, 184, 183, 181, 180, 178, 177, 176, 174, 173,
		171, 170, 169, 167, 166, 164, 163, 162, 160, 159,
		158, 156, 155, 154, 153, 151, 150, 149, 148, 146,
		145, 144, 143, 141, 140, 139, 138, 137, 135, 134,
		133, 132, 131, 130, 129, 127, 126, 125, 124, 123,
		122, 121, 120, 119, 117, 116, 115, 114, 113, 112,
		111, 110, 109, 108, 107, 106, 105, 104, 103, 102,
		101, 100, 99, 98, 97, 96, 95, 94, 93, 93,
		92, 91, 90, 89, 88, 87, 86, 85, 84, 83,
		83, 82, 81, 80, 79, 78, 77, 77, 76, 75,
		74, 73, 72, 72, 71, 70, 69, 68, 67, 67,
		66, 65, 64, 63, 63, 62, 61, 60, 60, 59,
		58, 57, 57, 56, 55, 54, 54, 53, 52, 51,
		51, 50, 49, 49, 48, 47, 46, 46, 45, 44,
		44, 43, 42, 42, 41, 40, 40, 39, 38, 38,
		37, 36, 36, 35, 34, 34, 33, 32, 32, 31,
		30, 30, 29, 29, 28, 27, 27, 26, 25, 25,
		24, 24, 23, 22, 22, 21, 21, 20, 20, 19,
		18, 18, 17, 17, 16, 15, 15, 14, 14, 13,
		13, 12, 12, 11, 10, 10, 9, 9, 8, 8,
		7, 7, 6, 6, 5, 5, 4, 4, 3, 3,
		2, 2, 1, 1, 0, 0, 0
	};

	public void execute(uint command)
	{
		currentCommand = command;
		sf = (int)(((command & 0x80000) >> 19) * 12);
		lm = ((command >> 10) & 1) != 0;
		FLAG = 0u;
		switch (command & 0x3F)
		{
		case 1u:
			RTPS(0, setMac0: true);
			break;
		case 6u:
			NCLIP();
			break;
		case 12u:
			OP();
			break;
		case 16u:
			DPCS(dpct: false);
			break;
		case 17u:
			INTPL();
			break;
		case 18u:
			MVMVA();
			break;
		case 19u:
			NCDS(0);
			break;
		case 20u:
			CDP();
			break;
		case 22u:
			NCDT();
			break;
		case 27u:
			NCCS(0);
			break;
		case 28u:
			CC();
			break;
		case 30u:
			NCS(0);
			break;
		case 32u:
			NCT();
			break;
		case 40u:
			SQR();
			break;
		case 41u:
			DCPL();
			break;
		case 42u:
			DCPT();
			break;
		case 45u:
			AVSZ3();
			break;
		case 46u:
			AVSZ4();
			break;
		case 48u:
			RTPT();
			break;
		case 61u:
			GPF();
			break;
		case 62u:
			GPL();
			break;
		case 63u:
			NCCT();
			break;
		default:
			Console.WriteLine($"UNIMPLEMENTED GTE COMMAND {command & 0x3F:x2}");
			break;
		}
		if ((FLAG & 0x7F87E000) != 0)
		{
			FLAG |= 2147483648u;
		}
	}

	private void CDP()
	{
		Vector<int> vector = new Vector<int>(new int[3]
		{
			RBK * 4096,
			GBK * 4096,
			BBK * 4096
		});
		Vector<int> vector2 = new Vector<int>(new int[3]
		{
			IR[1],
			IR[2],
			IR[3]
		});
		Vector<int> vector3 = new Vector<int>(new int[3]
		{
			LRGB.v1.x,
			LRGB.v2.y,
			LRGB.v3.z
		});
		Vector<int> vector4 = vector + vector3 * vector2;
		MAC1 = (int)setMAC(1, vector4[0] >> sf);
		MAC2 = (int)setMAC(2, vector4[1] >> sf);
		MAC3 = (int)setMAC(3, vector4[2] >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
	}

	private void CC()
	{
		Vector<int> vector = new Vector<int>(new int[3] { RGBC.r, RGBC.g, RGBC.b });
		Vector<int> vector2 = new Vector<int>(new int[3]
		{
			IR[1],
			IR[2],
			IR[3]
		});

        Vector<int> temp = vector * vector2;
        Vector<int> vector3 = VectorHelpers.ShiftLeft(temp, 4);
		MAC1 = (int)setMAC(1, vector3[0]);
		MAC2 = (int)setMAC(2, vector3[1]);
		MAC3 = (int)setMAC(3, vector3[2]);
		interpolateColor(MAC1, MAC2, MAC3);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
        Vector<int> vector4 = VectorHelpers.ShiftRight(vector3, 4);
        RGB[2].r = setRGB(1, vector4[0]);
		RGB[2].g = setRGB(2, vector4[1]);
		RGB[2].b = setRGB(3, vector4[2]);
		RGB[2].c = RGBC.c;
	}

	private void DCPT()
	{
		DPCS(dpct: true);
		DPCS(dpct: true);
		DPCS(dpct: true);
	}

	private void DCPL()
	{
		MAC1 = (int)(setMAC(1, RGBC.r * IR[1]) << 4);
		MAC2 = (int)(setMAC(2, RGBC.g * IR[2]) << 4);
		MAC3 = (int)(setMAC(3, RGBC.b * IR[3]) << 4);
		interpolateColor(MAC1, MAC2, MAC3);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
		RGB[2].r = setRGB(1, MAC1 >> 4);
		RGB[2].g = setRGB(2, MAC2 >> 4);
		RGB[2].b = setRGB(3, MAC3 >> 4);
		RGB[2].c = RGBC.c;
	}

	private void NCCS_2(int r)
	{
		Vector<int> vector = new Vector<int>(new int[3]
		{
			V[r].x,
			V[r].y,
			V[r].z
		});
		Vector<int> vector2 = new Vector<int>(new int[3]
		{
			LM.v1.x,
			LM.v1.y,
			LM.v1.z
		});
		Vector<int> vector3 = new Vector<int>(new int[3]
		{
			LM.v2.x,
			LM.v2.y,
			LM.v2.z
		});
		Vector<int> vector4 = new Vector<int>(new int[3]
		{
			LM.v3.x,
			LM.v3.y,
			LM.v3.z
		});
		long value = (long)(vector2 * vector).Sum() >> sf;
		long value2 = (long)(vector3 * vector).Sum() >> sf;
		long value3 = (long)(vector4 * vector).Sum() >> sf;
		MAC1 = (int)setMAC(1, value);
		MAC2 = (int)setMAC(2, value2);
		MAC3 = (int)setMAC(3, value3);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		Vector<int> vector5 = new Vector<int>(new int[3]
		{
			RBK * 4096,
			GBK * 4096,
			BBK * 4096
		});
		Vector<int> vector6 = new Vector<int>(new int[3]
		{
			IR[1],
			IR[2],
			IR[3]
		});
		Vector<int> vector7 = new Vector<int>(new int[3]
		{
			LRGB.v1.x,
			LRGB.v1.y,
			LRGB.v1.z
		});
		Vector<int> vector8 = new Vector<int>(new int[3]
		{
			LRGB.v2.x,
			LRGB.v2.y,
			LRGB.v2.z
		});
		Vector<int> vector9 = new Vector<int>(new int[3]
		{
			LRGB.v3.x,
			LRGB.v3.y,
			LRGB.v3.z
		});
		Vector<int> vector10 = vector5 + vector7 * vector6;
		Vector<int> vector11 = vector5 + vector8 * vector6;
		Vector<int> vector12 = vector5 + vector9 * vector6;
		MAC1 = (int)setMAC(1, vector10[0] >> sf);
		MAC2 = (int)setMAC(2, vector11[1] >> sf);
		MAC3 = (int)setMAC(3, vector12[2] >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
        Vector<int> temp13 = new Vector<int>(new int[3] { RGBC.r, RGBC.g, RGBC.b }) * vector6;
        Vector<int> vector13 = VectorHelpers.ShiftLeft(temp13, 4);
		MAC1 = (int)setMAC(1, vector13[0] >> sf);
		MAC2 = (int)setMAC(2, vector13[1] >> sf);
		MAC3 = (int)setMAC(3, vector13[2] >> sf);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
        Vector<int> vector14 = VectorHelpers.ShiftRight(vector13, 4);
        RGB[2].r = setRGB(1, vector14[0]);
		RGB[2].g = setRGB(2, vector14[1]);
		RGB[2].b = setRGB(3, vector14[2]);
		RGB[2].c = RGBC.c;
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
	}

	private void NCCS(int r)
	{
		MAC1 = (int)(setMAC(1, (long)LM.v1.x * (long)V[r].x + LM.v1.y * V[r].y + LM.v1.z * V[r].z) >> sf);
		MAC2 = (int)(setMAC(2, (long)LM.v2.x * (long)V[r].x + LM.v2.y * V[r].y + LM.v2.z * V[r].z) >> sf);
		MAC3 = (int)(setMAC(3, (long)LM.v3.x * (long)V[r].x + LM.v3.y * V[r].y + LM.v3.z * V[r].z) >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		MAC1 = (int)(setMAC(1, setMAC(1, setMAC(1, (long)RBK * 4096L + LRGB.v1.x * IR[1]) + (long)LRGB.v1.y * (long)IR[2]) + (long)LRGB.v1.z * (long)IR[3]) >> sf);
		MAC2 = (int)(setMAC(2, setMAC(2, setMAC(2, (long)GBK * 4096L + LRGB.v2.x * IR[1]) + (long)LRGB.v2.y * (long)IR[2]) + (long)LRGB.v2.z * (long)IR[3]) >> sf);
		MAC3 = (int)(setMAC(3, setMAC(3, setMAC(3, (long)BBK * 4096L + LRGB.v3.x * IR[1]) + (long)LRGB.v3.y * (long)IR[2]) + (long)LRGB.v3.z * (long)IR[3]) >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		MAC1 = (int)setMAC(1, RGBC.r * IR[1] << 4);
		MAC2 = (int)setMAC(2, RGBC.g * IR[2] << 4);
		MAC3 = (int)setMAC(3, RGBC.b * IR[3] << 4);
		MAC1 = (int)setMAC(1, MAC1 >> sf);
		MAC2 = (int)setMAC(2, MAC2 >> sf);
		MAC3 = (int)setMAC(3, MAC3 >> sf);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
		RGB[2].r = setRGB(1, MAC1 >> 4);
		RGB[2].g = setRGB(2, MAC2 >> 4);
		RGB[2].b = setRGB(3, MAC3 >> 4);
		RGB[2].c = RGBC.c;
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
	}

	private void NCCT()
	{
		NCCS(0);
		NCCS(1);
		NCCS(2);
	}

	private void DPCS(bool dpct)
	{
		byte r = RGBC.r;
		byte g = RGBC.g;
		byte b = RGBC.b;
		if (dpct)
		{
			r = RGB[0].r;
			g = RGB[0].g;
			b = RGB[0].b;
		}
		MAC1 = (int)(setMAC(1, r) << 16);
		MAC2 = (int)(setMAC(2, g) << 16);
		MAC3 = (int)(setMAC(3, b) << 16);
		interpolateColor(MAC1, MAC2, MAC3);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
		RGB[2].r = setRGB(1, MAC1 >> 4);
		RGB[2].g = setRGB(2, MAC2 >> 4);
		RGB[2].b = setRGB(3, MAC3 >> 4);
		RGB[2].c = RGBC.c;
	}

	private void INTPL()
	{
		MAC1 = (int)setMAC(1, (long)IR[1] << 12);
		MAC2 = (int)setMAC(2, (long)IR[2] << 12);
		MAC3 = (int)setMAC(3, (long)IR[3] << 12);
		interpolateColor(MAC1, MAC2, MAC3);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
		RGB[2].r = setRGB(1, MAC1 >> 4);
		RGB[2].g = setRGB(2, MAC2 >> 4);
		RGB[2].b = setRGB(3, MAC3 >> 4);
		RGB[2].c = RGBC.c;
	}

	private void NCT()
	{
		NCS(0);
		NCS(1);
		NCS(2);
	}

	private void NCS(int r)
	{
		Vector<int> vector = new Vector<int>(new int[3]
		{
			V[r].x,
			V[r].y,
			V[r].z
		});
		Vector<int> vector2 = new Vector<int>(new int[3]
		{
			LM.v1.x,
			LM.v1.y,
			LM.v1.z
		});
		Vector<int> vector3 = new Vector<int>(new int[3]
		{
			LM.v2.x,
			LM.v2.y,
			LM.v2.z
		});
		Vector<int> vector4 = new Vector<int>(new int[3]
		{
			LM.v3.x,
			LM.v3.y,
			LM.v3.z
		});
		long value = (long)(vector2 * vector).Sum() >> sf;
		long value2 = (long)(vector3 * vector).Sum() >> sf;
		long value3 = (long)(vector4 * vector).Sum() >> sf;
		MAC1 = (int)setMAC(1, value);
		MAC2 = (int)setMAC(2, value2);
		MAC3 = (int)setMAC(3, value3);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		Vector<int> vector5 = new Vector<int>(new int[3]
		{
			RBK * 4096,
			GBK * 4096,
			BBK * 4096
		});
		Vector<int> vector6 = new Vector<int>(new int[3]
		{
			IR[1],
			IR[2],
			IR[3]
		});
		Vector<int> vector7 = new Vector<int>(new int[3]
		{
			LRGB.v1.x,
			LRGB.v1.y,
			LRGB.v1.z
		});
		Vector<int> vector8 = new Vector<int>(new int[3]
		{
			LRGB.v2.x,
			LRGB.v2.y,
			LRGB.v2.z
		});
		Vector<int> vector9 = new Vector<int>(new int[3]
		{
			LRGB.v3.x,
			LRGB.v3.y,
			LRGB.v3.z
		});
		Vector<int> vector10 = vector5 + vector7 * vector6;
		Vector<int> vector11 = vector5 + vector8 * vector6;
		Vector<int> vector12 = vector5 + vector9 * vector6;
		MAC1 = (int)setMAC(1, vector10[0] >> sf);
		MAC2 = (int)setMAC(2, vector11[1] >> sf);
		MAC3 = (int)setMAC(3, vector12[2] >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
		Vector<int> vector13 = new Vector<int>(new int[3]
		{
			MAC1 >> 4,
			MAC2 >> 4,
			MAC3 >> 4
		});
		RGB[2].r = setRGB(1, vector13[0]);
		RGB[2].g = setRGB(2, vector13[1]);
		RGB[2].b = setRGB(3, vector13[2]);
		RGB[2].c = RGBC.c;
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
	}

	private void MVMVA()
	{
		uint num = (currentCommand >> 17) & 3;
		uint num2 = (currentCommand >> 15) & 3;
		uint num3 = (currentCommand >> 13) & 3;
		Matrix matrix2;
		switch (num)
		{
		case 0u:
			matrix2 = RT;
			break;
		case 1u:
			matrix2 = LM;
			break;
		case 2u:
			matrix2 = LRGB;
			break;
		default:
		{
			Matrix matrix = default(Matrix);
			matrix.v1 = new Vector3
			{
				x = (short)(-(RGBC.r << 4)),
				y = (short)(RGBC.r << 4),
				z = IR[0]
			};
			matrix.v2 = new Vector3
			{
				x = RT.v1.z,
				y = RT.v1.z,
				z = RT.v1.z
			};
			matrix.v3 = new Vector3
			{
				x = RT.v2.y,
				y = RT.v2.y,
				z = RT.v2.y
			};
			matrix2 = matrix;
			break;
		}
		}
		Matrix matrix3 = matrix2;
		Vector3 vector2;
		switch (num2)
		{
		case 0u:
			vector2 = V[0];
			break;
		case 1u:
			vector2 = V[1];
			break;
		case 2u:
			vector2 = V[2];
			break;
		default:
		{
			Vector3 vector = default(Vector3);
			vector.x = IR[1];
			vector.y = IR[2];
			vector.z = IR[3];
			vector2 = vector;
			break;
		}
		}
		Vector3 vector3 = vector2;
		long num6;
		long num5;
		long num4;
		switch (num3)
		{
		case 2u:
		{
			num6 = RFC;
			num5 = GFC;
			num4 = BFC;
			Vector4 vector4 = new Vector4(num6 * 4096 + matrix3.v1.x * vector3.x, num5 * 4096 + matrix3.v2.x * vector3.x, num4 * 4096 + matrix3.v3.x * vector3.x, 0f);
			vector4 /= (float)(1 << sf);
			setIR(1, (int)vector4.X, lm: false);
			setIR(2, (int)vector4.Y, lm: false);
			setIR(3, (int)vector4.Z, lm: false);
			Vector4 vector5 = new Vector4(matrix3.v1.y * vector3.y + matrix3.v1.z * vector3.z, matrix3.v2.y * vector3.y + matrix3.v2.z * vector3.z, matrix3.v3.y * vector3.y + matrix3.v3.z * vector3.z, 0f);
			vector5 /= (float)(1 << sf);
			MAC1 = (int)vector5.X;
			MAC2 = (int)vector5.Y;
			MAC3 = (int)vector5.Z;
			IR[1] = setIR(1, MAC1, lm);
			IR[2] = setIR(2, MAC2, lm);
			IR[3] = setIR(3, MAC3, lm);
			return;
		}
		case 0u:
			num6 = TRX;
			num5 = TRY;
			num4 = TRZ;
			break;
		case 1u:
			num6 = RBK;
			num5 = GBK;
			num4 = BBK;
			break;
		default:
			num6 = (num5 = (num4 = 0L));
			break;
		}
		Vector4 vector6 = new Vector4(num6 * 4096 + matrix3.v1.x * vector3.x, num5 * 4096 + matrix3.v2.x * vector3.x, num4 * 4096 + matrix3.v3.x * vector3.x, 0f);
		vector6 += new Vector4(matrix3.v1.y * vector3.y + matrix3.v1.z * vector3.z, matrix3.v2.y * vector3.y + matrix3.v2.z * vector3.z, matrix3.v3.y * vector3.y + matrix3.v3.z * vector3.z, 0f);
		vector6 /= (float)(1 << sf);
		MAC1 = (int)vector6.X;
		MAC2 = (int)vector6.Y;
		MAC3 = (int)vector6.Z;
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
	}

	private void GPL()
	{
		long num = (long)MAC1 << sf;
		long num2 = (long)MAC2 << sf;
		long num3 = (long)MAC3 << sf;
		MAC1 = (int)(setMAC(1, IR[1] * IR[0] + num) >> sf);
		MAC2 = (int)(setMAC(2, IR[2] * IR[0] + num2) >> sf);
		MAC3 = (int)(setMAC(3, IR[3] * IR[0] + num3) >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
		RGB[2].r = setRGB(1, MAC1 >> 4);
		RGB[2].g = setRGB(2, MAC2 >> 4);
		RGB[2].b = setRGB(3, MAC3 >> 4);
		RGB[2].c = RGBC.c;
	}

	private void GPF()
	{
		MAC1 = (int)setMAC(1, IR[1] * IR[0]) >> sf;
		MAC2 = (int)setMAC(2, IR[2] * IR[0]) >> sf;
		MAC3 = (int)setMAC(3, IR[3] * IR[0]) >> sf;
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
		RGB[2].r = setRGB(1, MAC1 >> 4);
		RGB[2].g = setRGB(2, MAC2 >> 4);
		RGB[2].b = setRGB(3, MAC3 >> 4);
		RGB[2].c = RGBC.c;
	}

	private void NCDT()
	{
		NCDS(0);
		NCDS(1);
		NCDS(2);
	}

	private void OP()
	{
		short x = RT.v1.x;
		short y = RT.v2.y;
		short z = RT.v3.z;
		int num = IR[3] * y - IR[2] * z >> sf;
		int num2 = IR[1] * z - IR[3] * x >> sf;
		int num3 = IR[2] * x - IR[1] * y >> sf;
		MAC1 = (int)setMAC(1, num);
		MAC2 = (int)setMAC(2, num2);
		MAC3 = (int)setMAC(3, num3);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
	}

	private void SQR()
	{
		MAC1 = (int)setMAC(1, IR[1] * IR[1] >> sf);
		MAC2 = (int)setMAC(2, IR[2] * IR[2] >> sf);
		MAC3 = (int)setMAC(3, IR[3] * IR[3] >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
	}

	private void AVSZ3()
	{
		long num = (long)ZSF3 * (long)(SZ[1] + SZ[2] + SZ[3]);
		MAC0 = (int)setMAC0(num);
		OTZ = setSZ3(num >> 12);
	}

	private void AVSZ4()
	{
		long num = (long)ZSF4 * (long)(SZ[0] + SZ[1] + SZ[2] + SZ[3]);
		MAC0 = (int)setMAC0(num);
		OTZ = setSZ3(num >> 12);
	}

	private void NCDS(int r)
	{
		int count = Vector<int>.Count;
		int[] array = new int[count];
		array[0] = V[r].x;
		array[1] = V[r].y;
		array[2] = V[r].z;
		Vector<int> right = new Vector<int>(array);
		int[] array2 = new int[count];
		array2[0] = LM.v1.x;
		array2[1] = LM.v1.y;
		array2[2] = LM.v1.z;
		Vector<int> left = new Vector<int>(array2);
		int[] array3 = new int[count];
		array3[0] = LM.v2.x;
		array3[1] = LM.v2.y;
		array3[2] = LM.v2.z;
		Vector<int> left2 = new Vector<int>(array3);
		int[] array4 = new int[count];
		array4[0] = LM.v3.x;
		array4[1] = LM.v3.y;
		array4[2] = LM.v3.z;
		Vector<int> left3 = new Vector<int>(array4);
		long num = setMAC(1, Vector.Dot(left, right));
		long num2 = setMAC(2, Vector.Dot(left2, right));
		long num3 = setMAC(3, Vector.Dot(left3, right));
		MAC1 = (int)(num >> sf);
		MAC2 = (int)(num2 >> sf);
		MAC3 = (int)(num3 >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		MAC1 = (int)(ChainMAC(1, (long)RBK * 4096L, new long[3]
		{
			LRGB.v1.x * IR[1],
			LRGB.v1.y * IR[2],
			LRGB.v1.z * IR[3]
		}) >> sf);
		MAC2 = (int)(ChainMAC(2, (long)GBK * 4096L, new long[3]
		{
			LRGB.v2.x * IR[1],
			LRGB.v2.y * IR[2],
			LRGB.v2.z * IR[3]
		}) >> sf);
		MAC3 = (int)(ChainMAC(3, (long)BBK * 4096L, new long[3]
		{
			LRGB.v3.x * IR[1],
			LRGB.v3.y * IR[2],
			LRGB.v3.z * IR[3]
		}) >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
		MAC1 = (int)setMAC(1, (long)RGBC.r * (long)IR[1] << 4);
		MAC2 = (int)setMAC(2, (long)RGBC.g * (long)IR[2] << 4);
		MAC3 = (int)setMAC(3, (long)RGBC.b * (long)IR[3] << 4);
		interpolateColor(MAC1, MAC2, MAC3);
		RGB[0] = RGB[1];
		RGB[1] = RGB[2];
		RGB[2].r = setRGB(1, MAC1 >> 4);
		RGB[2].g = setRGB(2, MAC2 >> 4);
		RGB[2].b = setRGB(3, MAC3 >> 4);
		RGB[2].c = RGBC.c;
		long ChainMAC(int index, long initial, long[] values)
		{
			long num4 = setMAC(index, initial);
			foreach (long num5 in values)
			{
				num4 = setMAC(index, num4 + num5);
			}
			return num4;
		}
	}

	private void interpolateColor(int mac1, int mac2, int mac3)
	{
		Vector4 vector = new Vector4(mac1, mac2, mac3, 0f);
		Vector4 value = (new Vector4(RFC, GFC, BFC, 0f) * 4096f - vector) / (1 << sf);
		Vector4 min = new Vector4(-32768f, -32768f, -32768f, 0f);
		Vector4 max = new Vector4(32767f, 32767f, 32767f, 0f);
		vector = Vector4.Clamp(value, min, max) * IR[0] + vector;
		vector /= (float)(1 << sf);
		MAC1 = (int)vector.X;
		MAC2 = (int)vector.Y;
		MAC3 = (int)vector.Z;
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		IR[3] = setIR(3, MAC3, lm);
	}

	private void NCLIP()
	{
		MAC0 = (int)setMAC0((long)SXY[0].x * (long)SXY[1].y + SXY[1].x * SXY[2].y + SXY[2].x * SXY[0].y - SXY[0].x * SXY[2].y - SXY[1].x * SXY[0].y - SXY[2].x * SXY[1].y);
	}

	private void RTPT()
	{
		RTPS(0, setMac0: false);
		RTPS(1, setMac0: false);
		RTPS(2, setMac0: true);
	}

	private void RTPS(int r, bool setMac0)
	{
		long value = (long)TRX * 4096L + RT.v1.x * V[r].x + RT.v1.y * V[r].y + RT.v1.z * V[r].z;
		MAC1 = (int)(setMAC(1, value) >> sf);
		long value2 = (long)TRY * 4096L + RT.v2.x * V[r].x + RT.v2.y * V[r].y + RT.v2.z * V[r].z;
		MAC2 = (int)(setMAC(2, value2) >> sf);
		long num = (long)TRZ * 4096L + RT.v3.x * V[r].x + RT.v3.y * V[r].y + RT.v3.z * V[r].z;
		MAC3 = (int)(setMAC(3, num) >> sf);
		IR[1] = setIR(1, MAC1, lm);
		IR[2] = setIR(2, MAC2, lm);
		int value3 = (int)(num >> 12);
		setIR(3, value3, lm: false);
		IR[3] = (short)MathHelper.Clamp(MAC3, (!lm) ? (-32768) : 0, 32767);
		SZ[0] = SZ[1];
		SZ[1] = SZ[2];
		SZ[2] = SZ[3];
		SZ[3] = setSZ3(num >> 12);
		long num3;
		if (H < SZ[3] * 2)
		{
			int num2 = BitOperations.LeadingZeroCount(SZ[3]) - 16;
			num3 = H << num2;
			uint num4 = (uint)(SZ[3] << num2);
			ushort num5 = (ushort)(unrTable[(int)(num4 - 32704) >> 7] + 257);
			num4 = 33554560 - num4 * num5 >> 8;
			num4 = 128 + num4 * num5 >> 8;
			num3 = (int)Math.Min(131071L, num3 * num4 + 32768 >> 16);
		}
		else
		{
			FLAG |= 131072u;
			num3 = 131071L;
		}
		int value4 = (int)(setMAC0(num3 * IR[1] + OFX) >> 16);
		int value5 = (int)(setMAC0(num3 * IR[2] + OFY) >> 16);
		SXY[0] = SXY[1];
		SXY[1] = SXY[2];
		SXY[2].x = setSXY(1, value4);
		SXY[2].y = setSXY(2, value5);
		if (setMac0)
		{
			long num6 = setMAC0(num3 * DQA + DQB);
			MAC0 = (int)num6;
			IR[0] = setIR0(num6 >> 12);
		}
	}

	private short setIR0(long value)
	{
		if (value < 0)
		{
			FLAG |= 4096u;
			return 0;
		}
		if (value > 4096)
		{
			FLAG |= 4096u;
			return 4096;
		}
		return (short)value;
	}

	private short setSXY(int i, int value)
	{
		if (value < -1024)
		{
			FLAG |= (uint)(16384 >> i - 1);
			return -1024;
		}
		if (value > 1023)
		{
			FLAG |= (uint)(16384 >> i - 1);
			return 1023;
		}
		return (short)value;
	}

	private ushort setSZ3(long value)
	{
		if (value < 0)
		{
			FLAG |= 262144u;
			return 0;
		}
		if (value > 65535)
		{
			FLAG |= 262144u;
			return ushort.MaxValue;
		}
		return (ushort)value;
	}

	private byte setRGB(int i, int value)
	{
		if (value < 0)
		{
			FLAG |= (uint)(2097152 >>> i - 1);
			return 0;
		}
		if (value > 255)
		{
			FLAG |= (uint)(2097152 >>> i - 1);
			return byte.MaxValue;
		}
		return (byte)value;
	}

	private short setIR(int i, int value, bool lm)
	{
		if (lm && value < 0)
		{
			FLAG |= (uint)(16777216 >> i - 1);
			return 0;
		}
		if (!lm && value < -32768)
		{
			FLAG |= (uint)(16777216 >> i - 1);
			return short.MinValue;
		}
		if (value > 32767)
		{
			FLAG |= (uint)(16777216 >> i - 1);
			return short.MaxValue;
		}
		return (short)value;
	}

	private long setMAC0(long value)
	{
		if (value < int.MinValue)
		{
			FLAG |= 32768u;
		}
		else if (value > int.MaxValue)
		{
			FLAG |= 65536u;
		}
		return value;
	}

	private long setMAC(int i, long value)
	{
		if (value < -8796093022208L)
		{
			FLAG |= (uint)(134217728 >> i - 1);
		}
		else if (value > 8796093022207L)
		{
			FLAG |= (uint)(1073741824 >> i - 1);
		}
		return value << 20 >> 20;
	}

	private static byte saturateRGB(int value)
	{
		if (value < 0)
		{
			return 0;
		}
		if (value > 31)
		{
			return 31;
		}
		return (byte)value;
	}

	private static int leadingCount(uint v)
	{
		uint num = v >> 31;
		int num2 = 0;
		for (int i = 0; i < 32; i++)
		{
			if (v >> 31 != num)
			{
				break;
			}
			num2++;
			v <<= 1;
		}
		return num2;
	}

	public uint readData(uint fs)
	{
		switch (fs)
		{
		case 0u:
			return V[0].XY;
		case 1u:
			return (uint)V[0].z;
		case 2u:
			return V[1].XY;
		case 3u:
			return (uint)V[1].z;
		case 4u:
			return V[2].XY;
		case 5u:
			return (uint)V[2].z;
		case 6u:
			return RGBC.val;
		case 7u:
			return OTZ;
		case 8u:
			return (uint)IR[0];
		case 9u:
			return (uint)IR[1];
		case 10u:
			return (uint)IR[2];
		case 11u:
			return (uint)IR[3];
		case 12u:
			return SXY[0].val;
		case 13u:
			return SXY[1].val;
		case 14u:
		case 15u:
			return SXY[2].val;
		case 16u:
			return SZ[0];
		case 17u:
			return SZ[1];
		case 18u:
			return SZ[2];
		case 19u:
			return SZ[3];
		case 20u:
			return RGB[0].val;
		case 21u:
			return RGB[1].val;
		case 22u:
			return RGB[2].val;
		case 23u:
			return RES1;
		case 24u:
			return (uint)MAC0;
		case 25u:
			return (uint)MAC1;
		case 26u:
			return (uint)MAC2;
		case 27u:
			return (uint)MAC3;
		case 28u:
		case 29u:
			return IRGB = (ushort)((saturateRGB(IR[3] / 128) << 10) | (saturateRGB(IR[2] / 128) << 5) | saturateRGB(IR[1] / 128));
		case 30u:
			return (uint)LZCS;
		case 31u:
			return (uint)LZCR;
		default:
			return uint.MaxValue;
		}
	}

	public void writeData(uint fs, uint v)
	{
		switch (fs)
		{
		case 0u:
			V[0].XY = v;
			break;
		case 1u:
			V[0].z = (short)v;
			break;
		case 2u:
			V[1].XY = v;
			break;
		case 3u:
			V[1].z = (short)v;
			break;
		case 4u:
			V[2].XY = v;
			break;
		case 5u:
			V[2].z = (short)v;
			break;
		case 6u:
			RGBC.val = v;
			break;
		case 7u:
			OTZ = (ushort)v;
			break;
		case 8u:
			IR[0] = (short)v;
			break;
		case 9u:
			IR[1] = (short)v;
			break;
		case 10u:
			IR[2] = (short)v;
			break;
		case 11u:
			IR[3] = (short)v;
			break;
		case 12u:
			SXY[0].val = v;
			break;
		case 13u:
			SXY[1].val = v;
			break;
		case 14u:
			SXY[2].val = v;
			break;
		case 15u:
			SXY[0] = SXY[1];
			SXY[1] = SXY[2];
			SXY[2].val = v;
			break;
		case 16u:
			SZ[0] = (ushort)v;
			break;
		case 17u:
			SZ[1] = (ushort)v;
			break;
		case 18u:
			SZ[2] = (ushort)v;
			break;
		case 19u:
			SZ[3] = (ushort)v;
			break;
		case 20u:
			RGB[0].val = v;
			break;
		case 21u:
			RGB[1].val = v;
			break;
		case 22u:
			RGB[2].val = v;
			break;
		case 23u:
			RES1 = v;
			break;
		case 24u:
			MAC0 = (int)v;
			break;
		case 25u:
			MAC1 = (int)v;
			break;
		case 26u:
			MAC2 = (int)v;
			break;
		case 27u:
			MAC3 = (int)v;
			break;
		case 28u:
			IRGB = (ushort)(v & 0x7FFF);
			IR[1] = (short)((v & 0x1F) * 128);
			IR[2] = (short)(((v >> 5) & 0x1F) * 128);
			IR[3] = (short)(((v >> 10) & 0x1F) * 128);
			break;
		case 30u:
			LZCS = (int)v;
			LZCR = leadingCount(v);
			break;
		case 29u:
		case 31u:
			break;
		}
	}

	public uint readControl(uint fs)
	{
		return fs switch
		{
			0u => RT.v1.XY, 
			1u => (uint)((ushort)RT.v1.z | (RT.v2.x << 16)), 
			2u => (uint)((ushort)RT.v2.y | (RT.v2.z << 16)), 
			3u => RT.v3.XY, 
			4u => (uint)RT.v3.z, 
			5u => (uint)TRX, 
			6u => (uint)TRY, 
			7u => (uint)TRZ, 
			8u => LM.v1.XY, 
			9u => (uint)((ushort)LM.v1.z | (LM.v2.x << 16)), 
			10u => (uint)((ushort)LM.v2.y | (LM.v2.z << 16)), 
			11u => LM.v3.XY, 
			12u => (uint)LM.v3.z, 
			13u => (uint)RBK, 
			14u => (uint)GBK, 
			15u => (uint)BBK, 
			16u => LRGB.v1.XY, 
			17u => (uint)((ushort)LRGB.v1.z | (LRGB.v2.x << 16)), 
			18u => (uint)((ushort)LRGB.v2.y | (LRGB.v2.z << 16)), 
			19u => LRGB.v3.XY, 
			20u => (uint)LRGB.v3.z, 
			21u => (uint)RFC, 
			22u => (uint)GFC, 
			23u => (uint)BFC, 
			24u => (uint)OFX, 
			25u => (uint)OFY, 
			26u => (uint)(short)H, 
			27u => (uint)DQA, 
			28u => (uint)DQB, 
			29u => (uint)ZSF3, 
			30u => (uint)ZSF4, 
			31u => FLAG, 
			_ => uint.MaxValue, 
		};
	}

	public void writeControl(uint fs, uint v)
	{
		switch (fs)
		{
		case 0u:
			RT.v1.XY = v;
			break;
		case 1u:
			RT.v1.z = (short)v;
			RT.v2.x = (short)(v >> 16);
			break;
		case 2u:
			RT.v2.y = (short)v;
			RT.v2.z = (short)(v >> 16);
			break;
		case 3u:
			RT.v3.XY = v;
			break;
		case 4u:
			RT.v3.z = (short)v;
			break;
		case 5u:
			TRX = (int)v;
			break;
		case 6u:
			TRY = (int)v;
			break;
		case 7u:
			TRZ = (int)v;
			break;
		case 8u:
			LM.v1.XY = v;
			break;
		case 9u:
			LM.v1.z = (short)v;
			LM.v2.x = (short)(v >> 16);
			break;
		case 10u:
			LM.v2.y = (short)v;
			LM.v2.z = (short)(v >> 16);
			break;
		case 11u:
			LM.v3.XY = v;
			break;
		case 12u:
			LM.v3.z = (short)v;
			break;
		case 13u:
			RBK = (int)v;
			break;
		case 14u:
			GBK = (int)v;
			break;
		case 15u:
			BBK = (int)v;
			break;
		case 16u:
			LRGB.v1.XY = v;
			break;
		case 17u:
			LRGB.v1.z = (short)v;
			LRGB.v2.x = (short)(v >> 16);
			break;
		case 18u:
			LRGB.v2.y = (short)v;
			LRGB.v2.z = (short)(v >> 16);
			break;
		case 19u:
			LRGB.v3.XY = v;
			break;
		case 20u:
			LRGB.v3.z = (short)v;
			break;
		case 21u:
			RFC = (int)v;
			break;
		case 22u:
			GFC = (int)v;
			break;
		case 23u:
			BFC = (int)v;
			break;
		case 24u:
			OFX = (int)v;
			break;
		case 25u:
			OFY = (int)v;
			break;
		case 26u:
			H = (ushort)v;
			break;
		case 27u:
			DQA = (short)v;
			break;
		case 28u:
			DQB = (int)v;
			break;
		case 29u:
			ZSF3 = (short)v;
			break;
		case 30u:
			ZSF4 = (short)v;
			break;
		case 31u:
			FLAG = v & 0x7FFFF000;
			if ((FLAG & 0x7F87E000) != 0)
			{
				FLAG |= 2147483648u;
			}
			break;
		}
	}

	private void debug()
	{
		string text = "GTE CONTROL\n";
		for (uint num = 0u; num < 32; num++)
		{
			text += $" {num:00}: {readControl(num):x8}";
			if ((num + 1) % 4 == 0)
			{
				text += "\n";
			}
		}
		text += "GTE DATA\n";
		for (uint num2 = 0u; num2 < 32; num2++)
		{
			text += $" {num2:00}: {readData(num2):x8}";
			if ((num2 + 1) % 4 == 0)
			{
				text += "\n";
			}
		}
		Console.WriteLine(text);
		Console.ReadLine();
	}
}
