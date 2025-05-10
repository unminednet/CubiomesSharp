using System.Runtime.InteropServices;

namespace CubiomesSharp;

[StructLayout(LayoutKind.Sequential)]
public struct Generator
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct Layer
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct LayerStack
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct SurfaceNoise
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct NetherNoise
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct EndNoise
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct BiomeNoise
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct BiomeNoiseBeta
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct SurfaceNoiseBeta
{
    public IntPtr Ptr;
}

[StructLayout(LayoutKind.Sequential)]
public struct DoublePerlinNoise
{
    public IntPtr Ptr;
}