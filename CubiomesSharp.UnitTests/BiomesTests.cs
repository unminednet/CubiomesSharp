using CubiomesSharp.LibraryImports;
using FluentAssertions;

namespace CubiomesSharp.UnitTests;

public class BiomesTests
{
    [Fact]
    public void GetMutated_ReturnsAValidValue()
    {
        LibCubiomes.GetMutated(McVersion.MC_1_21_3, BiomeId.Plains).Should().Be(BiomeId.SunflowerPlains);
    }

    [Fact]
    public void IsDeepOcean_ReturnsAValidValue()
    {
        LibCubiomes.IsDeepOcean(BiomeId.DeepColdOcean).Should().Be(true);
        LibCubiomes.IsDeepOcean(BiomeId.ColdOcean).Should().Be(false);
    }
}