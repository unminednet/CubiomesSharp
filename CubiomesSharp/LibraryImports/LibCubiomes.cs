using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CubiomesSharp.LibraryImports;

public static partial class LibCubiomes
{
    private const string DllName = "libcubiomes";

    [LibraryImport(DllName, EntryPoint = "allocGenerator")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Generator AllocGenerator();

    [LibraryImport(DllName, EntryPoint = "allocSurfaceNoise")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial SurfaceNoise AllocSurfaceNoise();

    [LibraryImport(DllName, EntryPoint = "allocEndNoise")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial EndNoise AllocEndNoise();

    [LibraryImport(DllName, EntryPoint = "allocNetherNoise")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial NetherNoise AllocNetherNoise();

    [LibraryImport(DllName, EntryPoint = "freeMem")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void Free(ref Generator g);

    [LibraryImport(DllName, EntryPoint = "freeMem")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void Free(ref SurfaceNoise sn);

    [LibraryImport(DllName, EntryPoint = "freeMem")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void Free(ref EndNoise en);

    [LibraryImport(DllName, EntryPoint = "freeMem")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void Free(ref NetherNoise nn);
}