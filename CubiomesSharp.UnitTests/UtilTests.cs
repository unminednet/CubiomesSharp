using CubiomesSharp.LibraryImports;
using FluentAssertions;

namespace CubiomesSharp.UnitTests;

public class UtilTests
{
    [Fact]
    public void McToStr_ReturnsAValidValue()
    {
        LibCubiomes.McToStr(McVersion.MC_1_21_3).Should().Be("1.21.3");
    }

    [Fact]
    public void StrToMc_ReturnsAValidValue()
    {
        LibCubiomes.StrToMc("1.21.3").Should().Be(McVersion.MC_1_21_3);
    }

    [Fact]
    public void StructToStr_ReturnsAValidValue()
    {
        LibCubiomes.StructToStr(StructureType.TrialChambers).Should().Be("trial_chambers");
    }

    [Fact]
    public void InitBiomeColors_ReturnsAValidValue()
    {
        var arr = new byte[256 * 3];
        LibCubiomes.InitBiomeColors(arr);
        arr.Should().StartWith([0, 0, 112, 141, 179, 96]);
    }
}