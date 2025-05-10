using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CubiomesSharp.LibraryImports;

public static partial class LibCubiomes
{
    [LibraryImport(DllName, EntryPoint = "setupGenerator")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetupGenerator(Generator g, McVersion mc, uint flags);

    [LibraryImport(DllName, EntryPoint = "applySeed")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void ApplySeed(Generator g, Dimension dim, long seed);


    [LibraryImport(DllName, EntryPoint = "getMinCacheSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetMinCacheSize(Generator g, int scale, int sx, int sy, int sz);

    public static int GetMinCacheSize(Generator g, CubiomesRange range)
    {
        return GetMinCacheSize(g, range.scale, range.sx, range.sy, range.sz);
    }


    [LibraryImport(DllName, EntryPoint = "allocCache")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial IntPtr AllocCache(Generator g, CubiomesRange r);


    [LibraryImport(DllName, EntryPoint = "genBiomes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GenBiomes(Generator g, IntPtr cache, CubiomesRange r);

    [LibraryImport(DllName, EntryPoint = "genBiomes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GenBiomes(Generator g, Span<int> cache, CubiomesRange r);


    [LibraryImport(DllName, EntryPoint = "getBiomeAt")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial BiomeId GetBiomeAt(Generator g, int scale, int x, int y, int z);


    [LibraryImport(DllName, EntryPoint = "getLayerForScale")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Layer GetLayerForScale(Generator g, int scale);


    [LibraryImport(DllName, EntryPoint = "setupLayerStack")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetupLayerStack(LayerStack ls, McVersion mc,
        [MarshalAs(UnmanagedType.Bool)] bool largeBiomes);


    [LibraryImport(DllName, EntryPoint = "getMinLayerCacheSize")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial nint GetMinLayerCacheSize(Layer layer, int sizeX, int sizeZ);


    [LibraryImport(DllName, EntryPoint = "genArea")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GenArea(Layer layer, Span<int> outBuffer, int areaX, int areaZ, int areaWidth,
        int areaHeight);


    [LibraryImport(DllName, EntryPoint = "mapApproxHeight")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MapApproxHeight(Span<float> y, Span<int> ids, Generator g, SurfaceNoise sn, int x, int z,
        int w, int h);
}