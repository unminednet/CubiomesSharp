using CubiomesSharp.LibraryImports;
using FluentAssertions;

namespace CubiomesSharp.UnitTests;

public class GeneratorTests : IDisposable
{
    protected Generator Generator;

    public GeneratorTests()
    {
        Generator = LibCubiomes.AllocGenerator();
        LibCubiomes.SetupGenerator(Generator, CommonParams.Version, 0);
        LibCubiomes.ApplySeed(Generator, Dimension.Overworld, CommonParams.Seed);
    }

    public void Dispose()
    {
        LibCubiomes.Free(ref Generator);
    }


    [Fact]
    public void GetBiomeAt_ReturnsAValidValue()
    {
        LibCubiomes.GetBiomeAt(Generator, 4, 0, 320, 0).Should().Be(BiomeId.River);
    }

    [Fact]
    public void GenBiomes_ReturnsAValidValue()
    {
        var range = CommonParams.Range1;

        var cache = new int[LibCubiomes.GetMinCacheSize(Generator, range.scale, range.sx, range.sy, range.sz)];

        LibCubiomes.GenBiomes(Generator, cache, range).Should().Be(0);

        cache[0].Should().Be((int)BiomeId.River);
    }

    [Fact]
    public void MapApproxHeight_ReturnsAValidValue()
    {
        var range = CommonParams.Range1;

        var ids = new int[LibCubiomes.GetMinCacheSize(Generator, range.scale, range.sx, range.sy, range.sz)];
        var y = new float[1];
        var sn = LibCubiomes.AllocSurfaceNoise();
        try
        {
            LibCubiomes.InitSurfaceNoise(sn, Dimension.Overworld, CommonParams.Seed);
            LibCubiomes.MapApproxHeight(y, ids, Generator, sn, 0, 0, 1, 1).Should().Be(0);
        }
        finally
        {
            LibCubiomes.Free(ref sn);
        }

        ids[0].Should().Be((int)BiomeId.River);
        y[0].Should().Be(36.07895f);
    }

    [Fact]
    public void BiomesToImage_MatchesReference()
    {
        var range = CommonParams.Range256;
        var cache = new int[LibCubiomes.GetMinCacheSize(Generator, range)];
        var biomeColors = new byte[256 * 3];
        LibCubiomes.InitBiomeColors(biomeColors);

        LibCubiomes.GenBiomes(Generator, cache, range).Should().Be(0);

        var pixels = new byte[range.sx * range.sz * 3];
        LibCubiomes.BiomesToImage(pixels, biomeColors, cache, range.sx, range.sz, 1, 1);

        Assert.Equal(pixels, File.ReadAllBytes("ReferenceData/image256.dat"));
    }
}