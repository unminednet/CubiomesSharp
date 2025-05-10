using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CubiomesSharp.LibraryImports;

[StructLayout(LayoutKind.Sequential)]
public struct CubiomesRange
{
    public int scale;
    public int x, z, sx, sz;
    public int y, sy;
}

public static partial class LibCubiomes
{
    [LibraryImport(DllName, EntryPoint = "initSurfaceNoise")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void InitSurfaceNoise(SurfaceNoise sn, Dimension dim, long seed);

    [LibraryImport(DllName, EntryPoint = "initSurfaceNoiseBeta")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void InitSurfaceNoiseBeta(SurfaceNoiseBeta snb, long seed);

    [LibraryImport(DllName, EntryPoint = "sampleSurfaceNoise")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double SampleSurfaceNoise(SurfaceNoise sn, int x, int y, int z);

    [LibraryImport(DllName, EntryPoint = "sampleSurfaceNoiseBetween")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double SampleSurfaceNoiseBetween(SurfaceNoise sn, int x, int y, int z, double noiseMin,
        double noiseMax);

    [LibraryImport(DllName, EntryPoint = "setNetherSeed")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetNetherSeed(NetherNoise nn, long seed);

    [LibraryImport(DllName, EntryPoint = "getNetherBiome")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetNetherBiome(NetherNoise nn, int x, int y, int z, ref float ndel);

    [LibraryImport(DllName, EntryPoint = "mapNether2D")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MapNether2D(NetherNoise nn, Span<int> output, int x, int z, int w, int h);

    [LibraryImport(DllName, EntryPoint = "mapNether3D")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MapNether3D(NetherNoise nn, Span<int> output, CubiomesRange r, float confidence);

    [LibraryImport(DllName, EntryPoint = "genNetherScaled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GenNetherScaled(NetherNoise nn, Span<int> output, CubiomesRange r, McVersion mc,
        ulong sha);

    [LibraryImport(DllName, EntryPoint = "setEndSeed")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetEndSeed(EndNoise en, McVersion mc, long seed);

    [LibraryImport(DllName, EntryPoint = "mapEndBiome")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MapEndBiome(EndNoise en, Span<int> output, int x, int z, int w, int h);

    [LibraryImport(DllName, EntryPoint = "mapEnd")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MapEnd(EndNoise en, Span<int> output, int x, int z, int w, int h);

    [LibraryImport(DllName, EntryPoint = "getEndSurfaceHeight")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetEndSurfaceHeight(McVersion mc, long seed, int x, int z);

    [LibraryImport(DllName, EntryPoint = "mapEndSurfaceHeight")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MapEndSurfaceHeight(Span<float> y, EndNoise en, SurfaceNoise sn, int x, int z, int w,
        int h, int scale, int ymin);

    [LibraryImport(DllName, EntryPoint = "genEndScaled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GenEndScaled(EndNoise en, Span<int> output, CubiomesRange r, McVersion mc, ulong sha);

    [LibraryImport(DllName, EntryPoint = "initBiomeNoise")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void InitBiomeNoise(BiomeNoise bn, McVersion mc);

    [LibraryImport(DllName, EntryPoint = "setBiomeSeed")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetBiomeSeed(BiomeNoise bn, long seed, int large);

    [LibraryImport(DllName, EntryPoint = "setBetaBiomeSeed")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetBetaBiomeSeed(BiomeNoiseBeta bnb, long seed);

    [LibraryImport(DllName, EntryPoint = "sampleBiomeNoise")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SampleBiomeNoise(BiomeNoise bn, Span<long> np, int x, int y, int z, ref long dat,
        uint sampleFlags);

    [LibraryImport(DllName, EntryPoint = "sampleBiomeNoiseBeta")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int SampleBiomeNoiseBeta(BiomeNoiseBeta bnb, Span<long> np, Span<double> nv, int x, int z);

    [LibraryImport(DllName, EntryPoint = "approxSurfaceBeta")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double ApproxSurfaceBeta(BiomeNoiseBeta bnb, SurfaceNoiseBeta snb, int x, int z);

    [LibraryImport(DllName, EntryPoint = "getOldBetaBiome")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetOldBetaBiome(float t, float h);

    [LibraryImport(DllName, EntryPoint = "climateToBiome")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int ClimateToBiome(McVersion mc, ulong[] np, ref long dat);

    [LibraryImport(DllName, EntryPoint = "setClimateParaSeed")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetClimateParaSeed(BiomeNoise bn, long seed, int large, int nptype, int nmax);

    [LibraryImport(DllName, EntryPoint = "sampleClimatePara")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double SampleClimatePara(BiomeNoise bn, Span<long> np, double x, double z);

    [LibraryImport(DllName, EntryPoint = "genBiomeNoiseChunkSection")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GenBiomeNoiseChunkSection(BiomeNoise bn, Span<int> output, int cx, int cy, int cz,
        ref long dat);

    [LibraryImport(DllName, EntryPoint = "genBiomeNoiseScaled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GenBiomeNoiseScaled(BiomeNoise bn, Span<int> output, CubiomesRange r, ulong sha);

    [LibraryImport(DllName, EntryPoint = "genBiomeNoiseBetaScaled")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GenBiomeNoiseBetaScaled(BiomeNoiseBeta bnb, SurfaceNoiseBeta snb, Span<int> output,
        CubiomesRange r);

    [LibraryImport(DllName, EntryPoint = "getBiomeDepthAndScale")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetBiomeDepthAndScale(int id, Span<double> depth, Span<double> scale, Span<int> grass);

    [LibraryImport(DllName, EntryPoint = "getVoronoiSrcCubiomesRange")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial CubiomesRange GetVoronoiSrcCubiomesRange(CubiomesRange r);
}