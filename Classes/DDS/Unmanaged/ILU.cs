// Decompiled with JetBrains decompiler
// Type: DevIL.Unmanaged.ILU
// Assembly: DevILNet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 52632D74-10FE-43BD-BAF1-03372C249855
// Assembly location: C:\Users\IcyTeck\Desktop\GShopUtils\GShopUtils\lib\DevILNet.dll

using System;
using System.Runtime.InteropServices;

namespace DevIL.Unmanaged
{
  public static class ILU
  {
    private const string ILUDLL = "ILU.dll";
    private static bool _init;

    public static bool IsInitialized
    {
      get
      {
        return ILU._init;
      }
    }

    public static void Initialize()
    {
      if (ILU._init)
        return;
      ILU.iluInit();
      ILU._init = true;
    }

    [DllImport("ILU.dll", EntryPoint = "iluAlienify", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Alienify();

    public static bool BlurAverage(int iterations)
    {
      return ILU.iluBlurAverage((uint) iterations);
    }

    public static bool BlurGaussian(int iterations)
    {
      return ILU.iluBlurGaussian((uint) iterations);
    }

    public static bool CompareImages(int otherImageID)
    {
      return ILU.iluCompareImages((uint) otherImageID);
    }

    public static bool Crop(int xOffset, int yOffset, int zOffset, int width, int height, int depth)
    {
      return ILU.iluCrop((uint) xOffset, (uint) yOffset, (uint) zOffset, (uint) width, (uint) height, (uint) depth);
    }

    [DllImport("ILU.dll", EntryPoint = "iluContrast", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Contrast(float contrast);

    [DllImport("ILU.dll", EntryPoint = "iluEdgeDetectE", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool EdgeDetectE();

    [DllImport("ILU.dll", EntryPoint = "iluEdgeDetectP", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool EdgeDetectP();

    [DllImport("ILU.dll", EntryPoint = "iluEdgeDetectS", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool EdgeDetectS();

    [DllImport("ILU.dll", EntryPoint = "iluEmboss", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Emboss();

    public static bool EnlargeCanvas(int width, int height, int depth)
    {
      return ILU.iluEnlargeCanvas((uint) width, (uint) height, (uint) depth);
    }

    public static bool EnlargeImage(int xDimension, int yDimension, int zDimension)
    {
      return ILU.iluEnlargeImage((uint) xDimension, (uint) yDimension, (uint) zDimension);
    }

    [DllImport("ILU.dll", EntryPoint = "iluEqualize", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Equalize();

    public static string GetErrorString(ErrorType error)
    {
      return Marshal.PtrToStringAnsi(ILU.iluGetErrorString((uint) error));
    }

    [DllImport("ILU.dll", EntryPoint = "iluConvolution", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Convolution(int[] matrix, int scale, int bias);

    [DllImport("ILU.dll", EntryPoint = "iluFlipImage", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool FlipImage();

    [DllImport("ILU.dll", EntryPoint = "iluBuildMipmaps", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool BuildMipMaps();

    public static int ColorsUsed()
    {
      return (int) ILU.iluColorsUsed();
    }

    public static bool Scale(int width, int height, int depth)
    {
      return ILU.iluScale((uint) width, (uint) height, (uint) depth);
    }

    [DllImport("ILU.dll", EntryPoint = "iluGammaCorrect", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool GammaCorrect(float gamma);

    [DllImport("ILU.dll", EntryPoint = "iluInvertAlpha", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool InvertAlpha();

    [DllImport("ILU.dll", EntryPoint = "iluMirror", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Mirror();

    [DllImport("ILU.dll", EntryPoint = "iluNegative", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Negative();

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluNoisify(float tolerance);

    public static bool Noisify(float tolerance)
    {
      return ILU.iluNoisify(MemoryHelper.Clamp(tolerance, 0.0f, 1f));
    }

    public static bool Pixelize(int pixelSize)
    {
      return ILU.iluPixelize((uint) pixelSize);
    }

    [DllImport("ILU.dll", EntryPoint = "iluReplaceColour", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool ReplaceColor(byte red, byte green, byte blue, float tolerance);

    [DllImport("ILU.dll", EntryPoint = "iluRotate", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Rotate(float angle);

    [DllImport("ILU.dll", EntryPoint = "iluRotate3D", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Rotate3D(float x, float y, float z, float angle);

    [DllImport("ILU.dll", EntryPoint = "iluSaturate1f", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Saturate(float saturation);

    [DllImport("ILU.dll", EntryPoint = "iluSaturate4f", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Saturate(float red, float green, float blue, float saturation);

    [DllImport("ILU.dll", EntryPoint = "iluScaleAlpha", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool ScaleAlpha(float scale);

    [DllImport("ILU.dll", EntryPoint = "iluScaleColours", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool ScaleColors(float red, float green, float blue);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluSetLanguage(uint language);

    public static bool SetLanguage(Language lang)
    {
      return ILU.iluSetLanguage((uint) lang);
    }

    public static bool Sharpen(float factor, int iterations)
    {
      return ILU.iluSharpen(factor, (uint) iterations);
    }

    [DllImport("ILU.dll", EntryPoint = "iluSwapColours", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool SwapColors();

    [DllImport("ILU.dll", EntryPoint = "iluWave", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    public static extern bool Wave(float angle);

    public static string GetVendorName()
    {
      return Marshal.PtrToStringAnsi(ILU.iluGetString(7936U));
    }

    public static string GetVersionNumber()
    {
      return Marshal.PtrToStringAnsi(ILU.iluGetString(3554U));
    }

    public static void SetImagePlacement(Placement placement)
    {
      ILU.iluImageParameter(1792U, (uint) placement);
    }

    public static Placement GetImagePlacement()
    {
      return (Placement) ILU.iluGetInteger(1792U);
    }

    public static void SetSamplingFilter(SamplingFilter filter)
    {
      ILU.iluImageParameter(9728U, (uint) filter);
    }

    public static SamplingFilter GetSamplingFilter()
    {
      return (SamplingFilter) ILU.iluGetInteger(9728U);
    }

    public static void Region(PointF[] points)
    {
      if (points == null || points.Length < 3)
        return;
      ILU.iluRegionf(points, (uint) points.Length);
    }

    public static void Region(PointI[] points)
    {
      if (points == null || points.Length < 3)
        return;
      ILU.iluRegioni(points, (uint) points.Length);
    }

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern void iluInit();

    [DllImport("ILU.dll", EntryPoint = "iluBlurAvg", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluBlurAverage(uint iterations);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluBlurGaussian(uint iterations);

    [DllImport("ILU.dll", EntryPoint = "iluCompareImage", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluCompareImages(uint otherImage);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluCrop(uint offsetX, uint offsetY, uint offsetZ, uint width, uint height, uint depth);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluEnlargeCanvas(uint width, uint height, uint depth);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluEnlargeImage(uint xDim, uint yDim, uint zDim);

    [DllImport("ILU.dll", EntryPoint = "iluErrorString", CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr iluGetErrorString(uint error);

    [DllImport("ILU.dll", EntryPoint = "iluColoursUsed", CallingConvention = CallingConvention.StdCall)]
    private static extern uint iluColorsUsed();

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluScale(uint width, uint height, uint depth);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluPixelize(uint pixelSize);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    [return: MarshalAs(UnmanagedType.U1)]
    private static extern bool iluSharpen(float factor, uint iterations);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern IntPtr iluGetString(uint name);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern void iluImageParameter(uint pName, uint param);

    [DllImport("ILU.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern int iluGetInteger(uint mode);

    [DllImport("ILU.dll", EntryPoint = "iluRegionfv", CallingConvention = CallingConvention.StdCall)]
    private static extern void iluRegionf(PointF[] points, uint num);

    [DllImport("ILU.dll", EntryPoint = "iluRegioniv", CallingConvention = CallingConvention.StdCall)]
    private static extern void iluRegioni(PointI[] points, uint num);
  }
}
