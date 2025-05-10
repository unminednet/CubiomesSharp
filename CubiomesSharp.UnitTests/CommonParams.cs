using CubiomesSharp.LibraryImports;

namespace CubiomesSharp.UnitTests;

public static class CommonParams
{
    public static McVersion Version = McVersion.MC_1_21_3;

    public static long Seed = -1234;

    public static CubiomesRange Range1 = new()
    {
        scale = 4,
        sx = 1,
        sy = 1,
        sz = 1,
        x = 0,
        y = 320,
        z = 0
    };

    public static CubiomesRange Range256 = new()
    {
        scale = 4,
        sx = 256,
        sy = 1,
        sz = 256,
        x = 0,
        y = 320,
        z = 0
    };
}