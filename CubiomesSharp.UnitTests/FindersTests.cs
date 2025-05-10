using CubiomesSharp.LibraryImports;
using FluentAssertions;

namespace CubiomesSharp.UnitTests;

public class FindersTests : IDisposable
{
    private Generator _generator;

    public FindersTests()
    {
        _generator = LibCubiomes.AllocGenerator();
        LibCubiomes.SetupGenerator(_generator, CommonParams.Version, 0);
        LibCubiomes.ApplySeed(_generator, Dimension.Overworld, CommonParams.Seed);
    }

    public void Dispose()
    {
        LibCubiomes.Free(ref _generator);
    }

    [Fact]
    public void GetSpawn_ReturnsAValidValue()
    {
        LibCubiomes.GetSpawn(_generator).Should().Be(new Pos(32, -16));
    }

    [Fact]
    public void GetStructurePos_ReturnsAValidValue()
    {
        LibCubiomes.GetStructurePos(StructureType.Village, CommonParams.Version, CommonParams.Seed, -2, -1, out var pos)
            .Should().Be(true);
        pos.Should().Be(new Pos(-800, -320));
    }
}