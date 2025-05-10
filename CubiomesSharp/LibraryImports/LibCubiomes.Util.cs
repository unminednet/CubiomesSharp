using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CubiomesSharp.LibraryImports;

public static partial class LibCubiomes
{
    [LibraryImport(DllName, EntryPoint = "mc2str")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr NativeMcToStr(McVersion mc);

    public static string? McToStr(McVersion mc)
    {
        return NativeMcToStr(mc).ToUtf8String();
    }

    [LibraryImport(DllName, EntryPoint = "str2mc")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial McVersion StrToMc([MarshalAs(UnmanagedType.LPStr)] string s);

    [LibraryImport(DllName, EntryPoint = "biome2str")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr NativeBiomeToStr(McVersion mc, BiomeId id);

    public static string? BiomeToStr(McVersion mc, BiomeId id)
    {
        return NativeBiomeToStr(mc, id).ToUtf8String();
    }

    [LibraryImport(DllName, EntryPoint = "struct2str")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial IntPtr NativeStructToStr(StructureType stype);

    public static string? StructToStr(StructureType stype)
    {
        return NativeStructToStr(stype).ToUtf8String();
    }

    [LibraryImport(DllName, EntryPoint = "initBiomeColors")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial void NativeInitBiomeColors(Span<byte> biomeColors);

    public static void InitBiomeColors(Span<byte> biomeColors)
    {
        if (biomeColors.Length < 256 * 3)
            throw new ArgumentException("biomeColors must be at least 256 * 3 bytes long", nameof(biomeColors));

        NativeInitBiomeColors(biomeColors);
    }

    [LibraryImport(DllName, EntryPoint = "initBiomeTypeColors")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void NativeInitBiomeTypeColors(Span<byte> biomeColors);

    public static void InitBiomeTypeColors(Span<byte> biomeColors)
    {
        if (biomeColors.Length < 256 * 3)
            throw new ArgumentException("biomeColors must be at least 256 * 3 bytes long", nameof(biomeColors));

        NativeInitBiomeTypeColors(biomeColors);
    }

    [LibraryImport(DllName, EntryPoint = "parseBiomeColors")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int NativeParseBiomeColors(
        Span<byte> biomeColors,
        [MarshalAs(UnmanagedType.LPStr)] string buf);

    public static int ParseBiomeColors(Span<byte> biomeColors, string buf)
    {
        if (biomeColors.Length < 256 * 3)
            throw new ArgumentException("biomeColors must be at least 256 * 3 bytes long", nameof(biomeColors));

        return NativeParseBiomeColors(biomeColors, buf);
    }

    [LibraryImport(DllName, EntryPoint = "biomesToImage")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    private static partial int NativeBiomesToImage(
        Span<byte> pixels,
        ReadOnlySpan<byte> biomeColors,
        ReadOnlySpan<int> biomes,
        int sx, int sy,
        int pixscale, int flip);

    public static int BiomesToImage(
        Span<byte> pixels,
        ReadOnlySpan<byte> biomeColors,
        ReadOnlySpan<int> biomes,
        int sx, int sy,
        int pixscale, int flip)
    {
        if (pixels.Length < sx * sy * 3)
            throw new ArgumentException("pixels must be at least sx * sy * 3 bytes long", nameof(pixels));

        if (biomeColors.Length < 256 * 3)
            throw new ArgumentException("biomeColors must be at least 256 * 3 bytes long", nameof(biomeColors));

        if (biomes.Length < sx * sy)
            throw new ArgumentException("biomes must be at least sx * sy bytes long", nameof(biomes));

        return NativeBiomesToImage(pixels, biomeColors, biomes, sx, sy, pixscale, flip);
    }

    [LibraryImport(DllName, EntryPoint = "savePPM")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int NativeSavePpm([MarshalAs(UnmanagedType.LPStr)] string path, ReadOnlySpan<byte> pixels,
        int sx, int sy);

    public static int SavePpm([MarshalAs(UnmanagedType.LPStr)] string path, ReadOnlySpan<byte> pixels, int sx, int sy)
    {
        if (pixels.Length < sx * sy * 3)
            throw new ArgumentException("pixels must be at least sx * sy * 3 bytes long", nameof(pixels));

        return NativeSavePpm(path, pixels, sx, sy);
    }
}