using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CubiomesSharp.LibraryImports;

public enum StructureType
{
    Feature,
    DesertPyramid,
    JungleTemple,
    JunglePyramid = JungleTemple,
    SwampHut,
    Igloo,
    Village,
    OceanRuin,
    Shipwreck,
    Monument,
    Mansion,
    Outpost,
    RuinedPortal,
    RuinedPortalN,
    AncientCity,
    Treasure,
    Mineshaft,
    DesertWell,
    Geode,
    Fortress,
    Bastion,
    EndCity,
    EndGateway,
    EndIsland,
    TrailRuins,
    TrialChambers,
    FeatureNum
}

[StructLayout(LayoutKind.Sequential)]
public struct StructureConfig
{
    public int salt;
    public sbyte regionSize;
    public sbyte chunkRange;
    public byte structType;
    public sbyte dim;
    public float rarity;
}

[StructLayout(LayoutKind.Sequential)]
public struct Pos : IEquatable<Pos>
{
    public int x, z;

    public override string ToString()
    {
        return $"({x}, {z})";
    }

    public Pos(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public bool Equals(Pos other)
    {
        return x == other.x && z == other.z;
    }

    public override bool Equals(object? obj)
    {
        return obj is Pos other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public static bool operator ==(Pos left, Pos right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Pos left, Pos right)
    {
        return !left.Equals(right);
    }
}

[StructLayout(LayoutKind.Sequential)]
public struct Pos3
{
    public int x, y, z;
}

[StructLayout(LayoutKind.Sequential)]
public struct StrongholdIter
{
    public Pos pos;
    public Pos nextapprox;
    public int index;
    public int ringnum;
    public int ringmax;
    public int ringidx;
    public double angle;
    public double dist;
    public ulong rnds;
    public McVersion mc;
}

[StructLayout(LayoutKind.Sequential)]
public struct StructureVariant
{
    public byte flags; // Combine all bitfields
    public byte size;
    public byte start;
    public short biome;
    public byte rotation;
    public byte mirror;
    public short x, y, z;
    public short sx, sy, sz;
}

[StructLayout(LayoutKind.Sequential)]
public struct Piece
{
    public IntPtr name;
    public Pos3 pos, bb0, bb1;
    public byte rot;
    public sbyte depth;
    public sbyte type;
    public IntPtr next; // Pointer to next Piece
}

[StructLayout(LayoutKind.Sequential)]
public struct EndIsland
{
    public int x, y, z;
    public int r;
}

[StructLayout(LayoutKind.Sequential)]
public struct BiomeFilter
{
    public ulong tempsToFind;
    public ulong otempToFind;
    public ulong majorToFind;
    public ulong edgesToFind;
    public ulong raresToFind, raresToFindM;
    public ulong shoreToFind, shoreToFindM;
    public ulong riverToFind, riverToFindM;
    public ulong oceanToFind;

    public int specialCnt;
    public uint flags;

    public ulong tempsToExcl;
    public ulong majorToExcl;
    public ulong edgesToExcl;
    public ulong raresToExcl, raresToExclM;
    public ulong shoreToExcl, shoreToExclM;
    public ulong riverToExcl, riverToExclM;

    public ulong biomeToExcl, biomeToExclM;
    public ulong biomeToFind, biomeToFindM;
    public ulong biomeToPick, biomeToPickM;
}

public static partial class LibCubiomes
{
    [LibraryImport(DllName, EntryPoint = "getStructureConfig")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GetStructureConfig(StructureType structureType, McVersion mc, out StructureConfig sconf);

    [LibraryImport(DllName, EntryPoint = "getStructurePos")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GetStructurePos(StructureType structureType, McVersion mc, long seed, int regX, int regZ,
        out Pos pos);

    [LibraryImport(DllName, EntryPoint = "getMineshafts")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetMineshafts(McVersion mc, long seed, int chunkX, int chunkZ, int chunkW, int chunkH,
        Span<Pos> outPositions, int nout);

    [LibraryImport(DllName, EntryPoint = "getEndIslands")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetEndIslands(Span<EndIsland> islands, McVersion mc, long seed, int chunkX, int chunkZ);

    [LibraryImport(DllName, EntryPoint = "mapEndIslandHeight")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MapEndIslandHeight(Span<float> y, EndNoise en, long seed, int x, int z, int w, int h,
        int scale);

    [LibraryImport(DllName, EntryPoint = "isEndChunkEmpty")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int IsEndChunkEmpty(EndNoise en, SurfaceNoise sn, long seed, int chunkX, int chunkZ);

    [LibraryImport(DllName, EntryPoint = "initFirstStronghold")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Pos InitFirstStronghold(ref StrongholdIter sh, McVersion mc, ulong s48);

    [LibraryImport(DllName, EntryPoint = "nextStronghold")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int NextStronghold(ref StrongholdIter sh, Generator g);

    [LibraryImport(DllName, EntryPoint = "estimateSpawn")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Pos EstimateSpawn(Generator g, ref ulong rng);

    [LibraryImport(DllName, EntryPoint = "getSpawn")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Pos GetSpawn(Generator g);

    [LibraryImport(DllName, EntryPoint = "locateBiome")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Pos LocateBiome(Generator g, int x, int y, int z, int radius, ulong validB, ulong validM,
        ref ulong rng, out int passes);

    [LibraryImport(DllName, EntryPoint = "isViableStructurePos")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsViableStructurePos(int structType, Generator g, int blockX, int blockZ, uint flags);

    [LibraryImport(DllName, EntryPoint = "isViableFeatureBiome")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsViableFeatureBiome(McVersion mc, StructureType structureType, BiomeId biomeID);

    [LibraryImport(DllName, EntryPoint = "isViableStructureTerrain")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsViableStructureTerrain(int structType, Generator g, int blockX, int blockZ);

    [LibraryImport(DllName, EntryPoint = "isViableEndCityTerrain")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsViableEndCityTerrain(Generator g, SurfaceNoise sn, int blockX, int blockZ);

    [LibraryImport(DllName, EntryPoint = "getVariant")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetVariant(out StructureVariant sv, int structType, McVersion mc, long seed, int blockX,
        int blockZ, BiomeId biomeID);

    [LibraryImport(DllName, EntryPoint = "getEndCityPieces")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetEndCityPieces(Span<Piece> pieces, long seed, int chunkX, int chunkZ);

    [LibraryImport(DllName, EntryPoint = "getFortressPieces")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetFortressPieces(Span<Piece> pieces, int n, McVersion mc, long seed, int chunkX,
        int chunkZ);

    [LibraryImport(DllName, EntryPoint = "getFixedEndGateways")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetFixedEndGateways(McVersion mc, long seed, Span<Pos> src);

    [LibraryImport(DllName, EntryPoint = "getLinkedGatewayChunk")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Pos GetLinkedGatewayChunk(EndNoise en, SurfaceNoise sn, long seed, Pos src, out Pos dst);

    [LibraryImport(DllName, EntryPoint = "getLinkedGatewayPos")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Pos GetLinkedGatewayPos(EndNoise en, SurfaceNoise sn, long seed, Pos src);

    [LibraryImport(DllName, EntryPoint = "getHouseList")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial ulong GetHouseList(Span<int> houses, long seed, int chunkX, int chunkZ);

    [LibraryImport(DllName, EntryPoint = "monteCarloBiomes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int MonteCarloBiomes(Generator g, CubiomesRange r, ref long rng, double coverage,
        double confidence, IntPtr eval, IntPtr data);

    [LibraryImport(DllName, EntryPoint = "setupBiomeFilter")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void SetupBiomeFilter(ref BiomeFilter bf, McVersion mc, uint flags,
        ReadOnlySpan<int> required, int requiredLen, ReadOnlySpan<int> excluded, int excludedLen,
        ReadOnlySpan<int> matchany, int matchanyLen);

    [LibraryImport(DllName, EntryPoint = "checkForBiomes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int CheckForBiomes(Generator g, Span<int> cache, CubiomesRange r, Dimension dim, long seed,
        ref BiomeFilter filter, IntPtr stop);

    [LibraryImport(DllName, EntryPoint = "checkForBiomesAtLayer")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int CheckForBiomesAtLayer(LayerStack ls, Layer entry, Span<int> cache, long seed, int x,
        int z, uint w, uint h, ref BiomeFilter filter);

    [LibraryImport(DllName, EntryPoint = "checkForTemps")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int CheckForTemps(Generator g, long seed, int x, int z, int w, int h, ReadOnlySpan<int> tc);

    [LibraryImport(DllName, EntryPoint = "getBiomeCenters")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetBiomeCenters(Span<Pos> pos, Span<int> siz, int nmax, Generator g, CubiomesRange r,
        int match, int minsiz, int tol, IntPtr stop);

    [LibraryImport(DllName, EntryPoint = "canBiomeGenerate")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int CanBiomeGenerate(int layerId, McVersion mc, uint flags, BiomeId biomeID);

    [LibraryImport(DllName, EntryPoint = "genPotential")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GenPotential(out ulong mL, out ulong mM, int layerId, McVersion mc, uint flags,
        BiomeId biomeID);

    [LibraryImport(DllName, EntryPoint = "getAvailableBiomes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetAvailableBiomes(out ulong mL, out ulong mM, int layerId, McVersion mc, uint flags);

    [LibraryImport(DllName, EntryPoint = "getParaDescent")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial double GetParaDescent(DoublePerlinNoise para, double factor, int x, int z, int w, int h,
        int i0, int j0, int maxrad, int maxiter, double alpha, IntPtr data, IntPtr func);

    [LibraryImport(DllName, EntryPoint = "getParaRange")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetParaRange(DoublePerlinNoise para, out double pmin, out double pmax, int x, int z,
        int w, int h, IntPtr data, IntPtr func);

    [LibraryImport(DllName, EntryPoint = "getBiomeParaExtremes")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Generator GetBiomeParaExtremes(McVersion mc);

    [LibraryImport(DllName, EntryPoint = "getBiomeParaLimits")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Generator GetBiomeParaLimits(McVersion mc, BiomeId id);

    [LibraryImport(DllName, EntryPoint = "getPossibleBiomesForLimits")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial void GetPossibleBiomesForLimits(Span<byte> ids, McVersion mc, Span<int> limits);

    [LibraryImport(DllName, EntryPoint = "getLargestRec")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial int GetLargestRec(int match, ReadOnlySpan<int> ids, int sx, int sz, out Pos p0, out Pos p1);
}