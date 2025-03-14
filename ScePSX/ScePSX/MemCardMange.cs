using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace ScePSX;

public class MemCardMange
{
	public class SlotData
	{
		public byte[] Head = new byte[128];

		public byte[] Data = new byte[8192];

		public SlotTypes type;

		public int IconFrames;

		public Color[] IconPalette = new Color[16];

		public Color[][] IconData = new Color[3][];

		public string ProdCode;

		public string Identifier;

		public string Region;

		public string RegionRaw;

		public int Size;

		public string Name;

		public SlotData()
		{
			IconData[0] = new Color[256];
			IconData[1] = new Color[256];
			IconData[2] = new Color[256];
		}

		public Bitmap GetIconBitmap(int idx)
		{
			int num = 16;
			int num2 = 16;
			Bitmap bitmap = new Bitmap(num, num2);
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					int num3 = i * num + j;
					Color color = IconData[idx][num3];
					bitmap.SetPixel(j, i, color);
				}
			}
			return bitmap;
		}
	}

	public enum SlotTypes : byte
	{
		formatted,
		initial,
		corrupted
	}

	public const int MaxSlot = 15;

	private byte[] RawData = new byte[131072];

	public SlotData[] Slots = new SlotData[15];

	public MemCardMange()
	{
		Slots = new SlotData[15];
		for (int i = 0; i < 15; i++)
		{
			Slots[i] = new SlotData();
		}
	}

	public MemCardMange(string fn)
		: this()
	{
		OpenCard(fn);
	}

	private void LoadCard()
	{
		for (int i = 0; i < 15; i++)
		{
			for (int j = 0; j < 128; j++)
			{
				Slots[i].Head[j] = RawData[128 + i * 128 + j];
			}
			for (int k = 0; k < 8192; k++)
			{
				Slots[i].Data[k] = RawData[8192 + i * 8192 + k];
			}
		}
	}

	private void loadSlotTypes()
	{
		for (int i = 0; i < 15; i++)
		{
			switch (Slots[i].Head[0])
			{
			default:
				Slots[i].type = SlotTypes.corrupted;
				break;
			case 160:
				Slots[i].type = SlotTypes.formatted;
				break;
			case 81:
				Slots[i].type = SlotTypes.initial;
				break;
			}
		}
	}

	private void loadStringData()
	{
		for (int i = 0; i < 15; i++)
		{
			Slots[i].ProdCode = "";
			Slots[i].Identifier = "";
			Slots[i].Name = "";
			if (Slots[i].type != SlotTypes.initial)
			{
				continue;
			}
			byte[] bytes = new byte[2]
			{
				Slots[i].Head[10],
				Slots[i].Head[11]
			};
			Slots[i].RegionRaw = Encoding.Default.GetString(bytes);
			switch (Slots[i].RegionRaw)
			{
			default:
				Slots[i].Region = Slots[i].RegionRaw;
				break;
			case "BA":
				Slots[i].Region = "US";
				break;
			case "BE":
				Slots[i].Region = "EU";
				break;
			case "BI":
				Slots[i].Region = "JP";
				break;
			}
			bytes = new byte[10];
			for (int j = 0; j < 10; j++)
			{
				bytes[j] = Slots[i].Head[j + 12];
			}
			Slots[i].ProdCode = Encoding.Default.GetString(bytes);
			Slots[i].ProdCode = Slots[i].ProdCode.Replace("\0", string.Empty);
			bytes = new byte[8];
			for (int k = 0; k < 8; k++)
			{
				bytes[k] = Slots[i].Head[k + 22];
			}
			Slots[i].Identifier = Encoding.Default.GetString(bytes);
			Slots[i].Identifier = Slots[i].Identifier.Replace("\0", string.Empty);
			bytes = new byte[64];
			for (int l = 0; l < 64; l++)
			{
				byte b = Slots[i].Data[l + 4];
				if (l % 2 == 0 && b == 0)
				{
					break;
				}
				bytes[l] = b;
			}
            Encoding encoding = Encoding.GetEncoding(932);
            if (encoding != null)
			{
				Slots[i].Name = encoding.GetString(bytes).Normalize(NormalizationForm.FormKC);
			}
			if (Slots[i].Name == "")
			{
				Slots[i].Name = Encoding.Default.GetString(bytes, 0, 32);
			}
		}
	}

	private void loadSaveSize()
	{
		for (int i = 0; i < 15; i++)
		{
			Slots[i].Size = (Slots[i].Head[4] | (Slots[i].Head[5] << 8) | (Slots[i].Head[6] << 16)) / 1024;
		}
	}

	private int[] FindFreeSlots(int slotNumber, int requiredSlots)
	{
		List<int> list = new List<int>();
		int num = 0;
		for (int i = 0; i < 15; i++)
		{
			num = (i + slotNumber) % 15;
			if (Slots[num].type == SlotTypes.formatted)
			{
				list.Add(num);
			}
			if (list.Count == requiredSlots)
			{
				break;
			}
		}
		return list.ToArray();
	}

	public byte[] GetSaveBytes(int slotNumber)
	{
		byte[] array = new byte[8320];
		for (int i = 0; i < 128; i++)
		{
			array[i] = Slots[slotNumber].Head[i];
		}
		for (int j = 0; j < 8192; j++)
		{
			array[128 + j] = Slots[slotNumber].Data[j];
		}
		return array;
	}

	public void ReplaceSaveBytes(int slotNumber, byte[] saveBytes)
	{
		for (int i = 0; i < 128; i++)
		{
			Slots[slotNumber].Head[i] = saveBytes[i];
		}
		for (int j = 0; j < 8192; j++)
		{
			Slots[slotNumber].Data[j] = saveBytes[128 + j];
		}
		calculateXOR();
		LoadData();
	}

	public bool AddSaveBytes(int slotNumber, byte[] saveBytes)
	{
		int num = (saveBytes.Length - 128) / 8192;
		int[] array = FindFreeSlots(slotNumber, num);
		int num2 = num * 8192;
		if (array.Length < num)
		{
			return false;
		}
		for (int i = 0; i < 128; i++)
		{
			Slots[array[0]].Head[i] = saveBytes[i];
		}
		Slots[array[0]].Head[4] = (byte)(num2 & 0xFF);
		Slots[array[0]].Head[5] = (byte)((num2 & 0xFF00) >> 8);
		Slots[array[0]].Head[6] = (byte)((num2 & 0xFF0000) >> 16);
		for (int j = 0; j < num; j++)
		{
			for (int k = 0; k < 8192; k++)
			{
				Slots[array[j]].Data[k] = saveBytes[128 + j * 8192 + k];
			}
		}
		for (int l = 0; l < array.Length - 1; l++)
		{
			Slots[array[l]].Head[0] = 82;
			Slots[array[l]].Head[8] = (byte)array[l + 1];
			Slots[array[l]].Head[9] = 0;
		}
        Slots[array[array.Length - 1]].Head[0] = 83;
        Slots[array[array.Length - 1]].Head[8] = byte.MaxValue;
		Slots[array[array.Length - 1]].Head[9] = byte.MaxValue;
		Slots[array[0]].Head[0] = 81;
		calculateXOR();
		LoadData();
		return true;
	}

	private void loadPalette()
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		for (int i = 0; i < 15; i++)
		{
			if (Slots[i].type != SlotTypes.initial)
			{
				continue;
			}
			num4 = 0;
			for (int j = 0; j < 32; j += 2)
			{
				num = (Slots[i].Data[j + 96] & 0x1F) << 3;
				num2 = ((Slots[i].Data[j + 97] & 3) << 6) | ((Slots[i].Data[j + 96] & 0xE0) >> 2);
				num3 = (Slots[i].Data[j + 97] & 0x7C) << 1;
				num5 = Slots[i].Data[j + 97] & 0x80;
				if ((num | num2 | num3 | num5) == 0)
				{
					Slots[i].IconPalette[num4] = Color.Transparent;
				}
				else
				{
					Slots[i].IconPalette[num4] = Color.FromArgb(num, num2, num3);
				}
				num4++;
			}
		}
	}

	private void loadIcons()
	{
		int num = 0;
		for (int i = 0; i < 15; i++)
		{
			if (Slots[i].type != SlotTypes.initial)
			{
				continue;
			}
			for (int j = 0; j < 3; j++)
			{
				num = 128 + 128 * j;
				for (int k = 0; k < 16; k++)
				{
					for (int l = 0; l < 16; l += 2)
					{
						Slots[i].IconData[j][l + k * 16] = Slots[i].IconPalette[Slots[i].Data[num] & 0xF];
						Slots[i].IconData[j][l + k * 16 + 1] = Slots[i].IconPalette[Slots[i].Data[num] >> 4];
						num++;
					}
				}
			}
		}
	}

	public byte[] GetIconBytes(int slotNumber)
	{
		byte[] array = new byte[416];
		for (int i = 0; i < 416; i++)
		{
			array[i] = Slots[slotNumber].Data[i + 96];
		}
		return array;
	}

	public void SetIconBytes(int slotNumber, byte[] iconBytes)
	{
		for (int i = 0; i < 416; i++)
		{
			Slots[slotNumber].Data[i + 96] = iconBytes[i];
		}
		loadPalette();
		loadIcons();
	}

	private void loadIconFrames()
	{
		for (int i = 0; i < 15; i++)
		{
			if (Slots[i].type == SlotTypes.initial)
			{
				switch (Slots[i].Data[2])
				{
				case 17:
					Slots[i].IconFrames = 1;
					break;
				case 18:
					Slots[i].IconFrames = 2;
					break;
				case 19:
					Slots[i].IconFrames = 3;
					break;
				}
			}
		}
	}

	private void calculateXOR()
	{
		byte b = 0;
		for (int i = 0; i < 15; i++)
		{
			b = 0;
			for (int j = 0; j < 127; j++)
			{
				b ^= Slots[i].Head[j];
			}
			Slots[i].Head[127] = b;
		}
	}

	public void DeleteSlot(int slotNumber)
	{
		for (int i = 0; i < 128; i++)
		{
			Slots[slotNumber].Head[i] = 0;
		}
		for (int j = 0; j < 8192; j++)
		{
			Slots[slotNumber].Data[j] = 0;
		}
		Slots[slotNumber].Head[0] = 160;
		Slots[slotNumber].Head[8] = byte.MaxValue;
		Slots[slotNumber].Head[9] = byte.MaxValue;
		calculateXOR();
		LoadData();
	}

	public void FormatCard()
	{
		for (int i = 0; i < 15; i++)
		{
			DeleteSlot(i);
		}
		calculateXOR();
		loadStringData();
		loadSlotTypes();
		loadSaveSize();
		loadPalette();
		loadIcons();
		loadIconFrames();
	}

	public bool SaveSingleSave(string fileName, int slotNumber)
	{
		byte[] saveBytes = GetSaveBytes(slotNumber);
		BinaryWriter binaryWriter;
		try
		{
			binaryWriter = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None));
		}
		catch (Exception)
		{
			return false;
		}
		byte[] array = new byte[54];
		byte[] array2 = null;
		for (int i = 0; i < 22; i++)
		{
			array[i] = Slots[slotNumber].Head[i + 10];
		}
		array2 = Encoding.Default.GetBytes(Slots[slotNumber].Name);
		for (int j = 0; j < array2.Length; j++)
		{
			array[j + 21] = array2[j];
		}
		binaryWriter.Write(array);
		binaryWriter.Write(saveBytes);
		binaryWriter.Close();
		return true;
	}

	public bool OpenSingleSave(string fileName, int slotNumber)
	{
		_ = new byte[54];
		byte[] array = new byte[8320];
		BinaryReader binaryReader;
		try
		{
			binaryReader = new BinaryReader(File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
		}
		catch (Exception)
		{
			return false;
		}
		if (binaryReader.BaseStream.Length != 8374)
		{
			binaryReader.Close();
			return false;
		}
		binaryReader.ReadBytes(54);
		array = binaryReader.ReadBytes(8320);
		binaryReader.Close();
		if (AddSaveBytes(slotNumber, array))
		{
			return true;
		}
		return false;
	}

	private void BuildCardData()
	{
		RawData = new byte[131072];
		RawData[0] = 77;
		RawData[1] = 67;
		RawData[127] = 14;
		RawData[8064] = 77;
		RawData[8065] = 67;
		RawData[8191] = 14;
		for (int i = 0; i < 15; i++)
		{
			for (int j = 0; j < 128; j++)
			{
				RawData[128 + i * 128 + j] = Slots[i].Head[j];
			}
			for (int k = 0; k < 8192; k++)
			{
				RawData[8192 + i * 8192 + k] = Slots[i].Data[k];
			}
		}
	}

	public bool SaveCard(string fileName)
	{
		BinaryWriter binaryWriter = null;
		try
		{
			binaryWriter = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None));
		}
		catch (Exception)
		{
			return false;
		}
		calculateXOR();
		BuildCardData();
		binaryWriter.Write(RawData);
		binaryWriter.Close();
		binaryWriter = null;
		LoadCard();
		return true;
	}

	public void OpenCard(byte[] memCardData)
	{
		Array.Copy(memCardData, RawData, memCardData.Length);
		LoadCard();
		LoadData();
	}

	private void LoadData()
	{
		loadSlotTypes();
		loadStringData();
		loadSaveSize();
		loadPalette();
		loadIcons();
		loadIconFrames();
	}

	public string OpenCard(string FileName)
	{
		BinaryReader binaryReader;
		try
		{
			binaryReader = new BinaryReader(File.Open(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
		}
		catch (Exception ex)
		{
			return ex.Message;
		}
		if (binaryReader.BaseStream.Length < 131072)
		{
			return "bad data";
		}
		binaryReader.BaseStream.Read(RawData, 0, 131072);
		binaryReader.Close();
		binaryReader = null;
		LoadCard();
		LoadData();
		return null;
	}
}
