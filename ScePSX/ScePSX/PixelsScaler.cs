using System;
using System.Numerics;
using System.Threading.Tasks;

namespace ScePSX;

internal class PixelsScaler
{
	private const float Threshold = 15f;

	private const int LanczosWindow = 3;

	public static int[] Scale(int[] pixels, int width, int height, int scaleFactor, ScaleMode mode = ScaleMode.Neighbor)
	{
		if ((scaleFactor & (scaleFactor - 1)) != 0 || width < 0 || height < 0)
		{
			return pixels;
		}
		int num = width;
		int num2 = height;
		int[] array = (int[])pixels.Clone();
		if (mode == ScaleMode.Neighbor)
		{
			array = FastScale(array, num, num2, scaleFactor);
			num *= scaleFactor;
			num2 *= scaleFactor;
		}
		if (mode == ScaleMode.Jinc)
		{
			array = JINCScale(array, num, num2, scaleFactor);
			num *= scaleFactor;
			num2 *= scaleFactor;
		}
		if (mode == ScaleMode.xBR)
		{
			while (scaleFactor > 1)
			{
				array = Scale2xBR_Unsafe(array, num, num2);
				num *= 2;
				num2 *= 2;
				scaleFactor /= 2;
			}
		}
		if (mode == ScaleMode.Lanczos)
		{
			array = LanczosScale(pixels, width, height, width * scaleFactor, height * scaleFactor);
		}
		return array;
	}

	private unsafe static int[] Scale2xBR_Unsafe(int[] pixels, int width, int height)
	{
		int outputWidth = width * 2;
		int num = height * 2;
		int[] array = new int[outputWidth * num];
		fixed (int* ptr = pixels)
		{
			fixed (int* ptr2 = array)
			{
				int* localSrcPtr = ptr;
				int* localDstPtr = ptr2;
				Parallel.For(0, height, delegate(int y)
				{
					int* ptr3 = localSrcPtr + y * width;
					int* ptr4 = localDstPtr + y * 2 * outputWidth;
					for (int i = 0; i < width; i++)
					{
						int num2 = ptr3[i];
						int c = ((i > 0 && y > 0) ? (localSrcPtr + (y - 1) * width)[i - 1] : 0);
						int c2 = ((y > 0) ? (localSrcPtr + (y - 1) * width)[i] : 0);
						if (i < width - 1 && y > 0)
						{
							_ = (localSrcPtr + (y - 1) * width)[i + 1];
						}
						int c3 = ((i > 0) ? ptr3[i - 1] : 0);
						int c4 = ((i < width - 1) ? ptr3[i + 1] : 0);
						if (i > 0 && y < height - 1)
						{
							_ = (localSrcPtr + (y + 1) * width)[i - 1];
						}
						int c5 = ((y < height - 1) ? (localSrcPtr + (y + 1) * width)[i] : 0);
						int c6 = ((i < width - 1 && y < height - 1) ? (localSrcPtr + (y + 1) * width)[i + 1] : 0);
						int num3 = num2;
						int num4 = num2;
						int num5 = num2;
						int num6 = num2;
						bool flag = IsSimilarColors(num2, c);
						bool flag2 = IsSimilarColors(num2, c6);
						if (flag && !flag2)
						{
							bool num7 = IsSimilarColors(num2, c2);
							bool flag3 = IsSimilarColors(num2, c3);
							num3 = (num7 ? AverageFast(num2, c2) : num2);
							num4 = (flag3 ? AverageFast(num2, c3) : num2);
						}
						else if (flag2 && !flag)
						{
							bool num8 = IsSimilarColors(num2, c4);
							bool flag4 = IsSimilarColors(num2, c5);
							num5 = (num8 ? AverageFast(num2, c4) : num2);
							num6 = (flag4 ? AverageFast(num2, c5) : num2);
						}
						int num9 = i * 2;
						ptr4[num9] = num3;
						ptr4[num9 + 1] = num4;
						ptr4[num9 + outputWidth] = num5;
						ptr4[num9 + outputWidth + 1] = num6;
					}
				});
			}
		}
		return array;
	}

	private static int[] Scale2xBR_Parallel(int[] pixels, int width, int height)
	{
		int outputWidth = width * 2;
		int num = height * 2;
		int[] scaledPixels = new int[outputWidth * num];
		Parallel.For(0, height, delegate(int y)
		{
			int num2 = y * width;
			int num3 = y * 2 * outputWidth;
			for (int i = 0; i < width; i++)
			{
				int num4 = num2 + i;
				int c = ((i > 0 && y > 0) ? pixels[(y - 1) * width + (i - 1)] : 0);
				int c2 = ((y > 0) ? pixels[(y - 1) * width + i] : 0);
				if (i < width - 1 && y > 0)
				{
					_ = pixels[(y - 1) * width + (i + 1)];
				}
				int c3 = ((i > 0) ? pixels[num2 + (i - 1)] : 0);
				int num5 = pixels[num4];
				int c4 = ((i < width - 1) ? pixels[num2 + (i + 1)] : 0);
				if (i > 0 && y < height - 1)
				{
					_ = pixels[(y + 1) * width + (i - 1)];
				}
				int c5 = ((y < height - 1) ? pixels[(y + 1) * width + i] : 0);
				int c6 = ((i < width - 1 && y < height - 1) ? pixels[(y + 1) * width + (i + 1)] : 0);
				int num6 = num5;
				int num7 = num5;
				int num8 = num5;
				int num9 = num5;
				bool flag = IsSimilarColors(num5, c);
				bool flag2 = IsSimilarColors(num5, c6);
				if (flag && !flag2)
				{
					bool num10 = IsSimilarColors(num5, c2);
					bool flag3 = IsSimilarColors(num5, c3);
					num6 = (num10 ? AverageFast(num5, c2) : num5);
					num7 = (flag3 ? AverageFast(num5, c3) : num5);
				}
				else if (flag2 && !flag)
				{
					bool num11 = IsSimilarColors(num5, c4);
					bool flag4 = IsSimilarColors(num5, c5);
					num8 = (num11 ? AverageFast(num5, c4) : num5);
					num9 = (flag4 ? AverageFast(num5, c5) : num5);
				}
				int num12 = num3 + i * 2;
				scaledPixels[num12] = num6;
				scaledPixels[num12 + 1] = num7;
				scaledPixels[num12 + outputWidth] = num8;
				scaledPixels[num12 + outputWidth + 1] = num9;
			}
		});
		return scaledPixels;
	}

	private static bool IsSimilarColors(int c1, int c2)
	{
		int num = (c1 >> 16) & 0xFF;
		int num2 = (c1 >> 8) & 0xFF;
		int num3 = c1 & 0xFF;
		int num4 = (c2 >> 16) & 0xFF;
		int num5 = (c2 >> 8) & 0xFF;
		int num6 = c2 & 0xFF;
		int num7 = num - num4;
		int num8 = num2 - num5;
		int num9 = num3 - num6;
		return num7 * num7 + num8 * num8 + num9 * num9 < 225;
	}

	private static int[] Scale2xBR(int[] pixels, int width, int height)
	{
		int num = width * 2;
		int num2 = height * 2;
		int[] array = new int[num * num2];
		for (int i = 0; i < height; i++)
		{
			for (int j = 0; j < width; j++)
			{
				int pixel = GetPixel(pixels, j, i, width, height);
				int pixel2 = GetPixel(pixels, j - 1, i - 1, width, height);
				int pixel3 = GetPixel(pixels, j, i - 1, width, height);
				GetPixel(pixels, j + 1, i - 1, width, height);
				int pixel4 = GetPixel(pixels, j - 1, i, width, height);
				int num3 = pixel;
				int pixel5 = GetPixel(pixels, j + 1, i, width, height);
				GetPixel(pixels, j - 1, i + 1, width, height);
				int pixel6 = GetPixel(pixels, j, i + 1, width, height);
				int pixel7 = GetPixel(pixels, j + 1, i + 1, width, height);
				Vector3 vector = GetVector(num3);
				int color = num3;
				int color2 = num3;
				int color3 = num3;
				int color4 = num3;
				if (IsSimilar(vector, pixel2) && !IsSimilar(vector, pixel7))
				{
					color = (IsSimilar(vector, pixel3) ? AverageFast(num3, pixel3) : num3);
					color2 = (IsSimilar(vector, pixel4) ? AverageFast(num3, pixel4) : num3);
				}
				else if (IsSimilar(vector, pixel7) && !IsSimilar(vector, pixel2))
				{
					color3 = (IsSimilar(vector, pixel5) ? AverageFast(num3, pixel5) : num3);
					color4 = (IsSimilar(vector, pixel6) ? AverageFast(num3, pixel6) : num3);
				}
				SetPixel(array, j * 2, i * 2, color, num);
				SetPixel(array, j * 2 + 1, i * 2, color2, num);
				SetPixel(array, j * 2, i * 2 + 1, color3, num);
				SetPixel(array, j * 2 + 1, i * 2 + 1, color4, num);
			}
		}
		return array;
	}

	private static Vector3 GetVector(int color)
	{
		return new Vector3((color >> 16) & 0xFF, (color >> 8) & 0xFF, color & 0xFF);
	}

	private static bool IsSimilar(Vector3 v1, int color)
	{
		Vector3 vector = GetVector(color);
		return Vector3.Distance(v1, vector) < 15f;
	}

	private static int AverageFast(int c1, int c2)
	{
		return (c1 & 0xFEFEFE) + (c2 & 0xFEFEFE) >> 1;
	}

	private static int GetPixel(int[] pixels, int x, int y, int width, int height)
	{
		if (x < 0 || x >= width || y < 0 || y >= height)
		{
			return 0;
		}
		return pixels[y * width + x];
	}

	private static void SetPixel(int[] pixels, int x, int y, int color, int width)
	{
		pixels[y * width + x] = color;
	}

	public static int[] FastScale(int[] pixels, int width, int height, int scaleFactor)
	{
		int scaledWidth = width * scaleFactor;
		int num = height * scaleFactor;
		int[] scaledPixels = new int[scaledWidth * num];
		Parallel.For(0, height, delegate(int y)
		{
			int num2 = y * width;
			int num3 = y * scaleFactor * scaledWidth;
			for (int i = 0; i < width; i++)
			{
				int num4 = pixels[num2 + i];
				for (int j = 0; j < scaleFactor; j++)
				{
					int num5 = num3 + j * scaledWidth + i * scaleFactor;
					for (int k = 0; k < scaleFactor; k++)
					{
						scaledPixels[num5 + k] = num4;
					}
				}
			}
		});
		return scaledPixels;
	}

	public static int[] JINCScale(int[] pixels, int width, int height, int scaleFactor)
	{
		int newWidth = width * scaleFactor;
		int num = height * scaleFactor;
		int[] scaledPixels = new int[newWidth * num];
		Parallel.For(0, num, delegate(int y)
		{
			int num2 = y / scaleFactor * width;
			for (int i = 0; i < newWidth; i++)
			{
				int num3 = i / scaleFactor;
				int num4 = num2 + num3;
				scaledPixels[y * newWidth + i] = pixels[num4];
			}
		});
		return scaledPixels;
	}

	public static int[] LanczosScale(int[] pixels, int width, int height, int newWidth, int newHeight)
	{
		int[] scaledPixels = new int[newWidth * newHeight];
		double scaleX = (double)width / (double)newWidth;
		double scaleY = (double)height / (double)newHeight;
		Parallel.For(0, newHeight, delegate(int y)
		{
			for (int i = 0; i < newWidth; i++)
			{
				double srcX = ((double)i + 0.5) * scaleX - 0.5;
				double srcY = ((double)y + 0.5) * scaleY - 0.5;
				int num = LanczosInterpolate(pixels, width, height, srcX, srcY);
				scaledPixels[y * newWidth + i] = num;
			}
		});
		return scaledPixels;
	}

	private static int LanczosInterpolate(int[] pixels, int width, int height, double srcX, double srcY)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		for (int i = -2; i < 3; i++)
		{
			for (int j = -2; j < 3; j++)
			{
				int num5 = (int)Math.Floor(srcX) + j;
				int num6 = (int)Math.Floor(srcY) + i;
				if (num5 >= 0 && num5 < width && num6 >= 0 && num6 < height)
				{
					int num7 = pixels[num6 * width + num5];
					int num8 = num7 & 0xFF;
					int num9 = (num7 >> 8) & 0xFF;
					int num10 = (num7 >> 16) & 0xFF;
					double num11 = LanczosKernel((srcX - (double)num5) / 3.0);
					double num12 = LanczosKernel((srcY - (double)num6) / 3.0);
					double num13 = num11 * num12;
					num += (double)num10 * num13;
					num2 += (double)num9 * num13;
					num3 += (double)num8 * num13;
					num4 += num13;
				}
			}
		}
		num /= num4;
		num2 /= num4;
		num3 /= num4;
		return ((int)num << 16) | ((int)num2 << 8) | (int)num3;
	}

	private static double LanczosKernel(double x)
	{
		if (x == 0.0)
		{
			return 1.0;
		}
		if (Math.Abs(x) > 1.0)
		{
			return 0.0;
		}
		double num = Math.PI * x;
		return Math.Sin(num) / num * Math.Sin(num / 3.0) / (num / 3.0);
	}

	public unsafe static int CutBlackLine(int[] In, int[] Out, int width, int height)
	{
		int num = -1;
		int num2 = -1;
		for (int i = 0; i < height; i++)
		{
			bool flag = true;
			for (int j = 0; j < width; j++)
			{
				if (In[i * width + j] != 0)
				{
					flag = false;
					break;
				}
			}
			if (!flag)
			{
				num = i;
				break;
			}
		}
		for (int num3 = height - 1; num3 >= 0; num3--)
		{
			bool flag2 = true;
			for (int k = 0; k < width; k++)
			{
				if (In[num3 * width + k] != 0)
				{
					flag2 = false;
					break;
				}
			}
			if (!flag2)
			{
				num2 = num3;
				break;
			}
		}
		if (num == -1 || num2 == -1 || num > num2)
		{
			return 0;
		}
		if (num > 20 || height - num2 > 20)
		{
			return 0;
		}
		int num4 = num2 - num + 1;
		fixed (int* ptr = In)
		{
			fixed (int* ptr2 = Out)
			{
				for (int l = 0; l < num4; l++)
				{
					int num5 = (num + l) * width;
					int num6 = l * width;
					Buffer.MemoryCopy(ptr + num5, ptr2 + num6, width * 4, width * 4);
				}
			}
		}
		return num4;
	}
}
