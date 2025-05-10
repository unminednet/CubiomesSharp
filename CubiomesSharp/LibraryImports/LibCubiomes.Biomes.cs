using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace CubiomesSharp.LibraryImports;

public enum McVersion
{
    MC_UNDEF,
    MC_B1_7,
    MC_B1_8,
    MC_1_0_0,
    MC_1_0 = MC_1_0_0,
    MC_1_1_0,
    MC_1_1 = MC_1_1_0,
    MC_1_2_5,
    MC_1_2 = MC_1_2_5,
    MC_1_3_2,
    MC_1_3 = MC_1_3_2,
    MC_1_4_7,
    MC_1_4 = MC_1_4_7,
    MC_1_5_2,
    MC_1_5 = MC_1_5_2,
    MC_1_6_4,
    MC_1_6 = MC_1_6_4,
    MC_1_7_10,
    MC_1_7 = MC_1_7_10,
    MC_1_8_9,
    MC_1_8 = MC_1_8_9,
    MC_1_9_4,
    MC_1_9 = MC_1_9_4,
    MC_1_10_2,
    MC_1_10 = MC_1_10_2,
    MC_1_11_2,
    MC_1_11 = MC_1_11_2,
    MC_1_12_2,
    MC_1_12 = MC_1_12_2,
    MC_1_13_2,
    MC_1_13 = MC_1_13_2,
    MC_1_14_4,
    MC_1_14 = MC_1_14_4,
    MC_1_15_2,
    MC_1_15 = MC_1_15_2,
    MC_1_16_1,
    MC_1_16_5,
    MC_1_16 = MC_1_16_5,
    MC_1_17_1,
    MC_1_17 = MC_1_17_1,
    MC_1_18_2,
    MC_1_18 = MC_1_18_2,
    MC_1_19_2,
    MC_1_19_4,
    MC_1_19 = MC_1_19_4,
    MC_1_20_6,
    MC_1_20 = MC_1_20_6,
    MC_1_21_1,
    MC_1_21_3,
    MC_1_21_WD,
    MC_1_21 = MC_1_21_WD,
    MC_NEWEST = MC_1_21
}

public enum Dimension
{
    Nether = -1,
    Overworld = 0,
    End = 1,
    Undefined = 1000
}

public enum BiomeId
{
    None = -1,

    Ocean = 0,
    Plains = 1,
    Desert = 2,
    Mountains = 3,
    ExtremeHills = Mountains,
    Forest = 4,
    Taiga = 5,
    Swamp = 6,
    Swampland = Swamp,
    River = 7,
    NetherWastes = 8,
    Hell = NetherWastes,
    TheEnd = 9,
    Sky = TheEnd,
    FrozenOcean = 10,
    FrozenRiver = 11,
    SnowyTundra = 12,
    IcePlains = SnowyTundra,
    SnowyMountains = 13,
    IceMountains = SnowyMountains,
    MushroomFields = 14,
    MushroomIsland = MushroomFields,
    MushroomFieldShore = 15,
    MushroomIslandShore = MushroomFieldShore,
    Beach = 16,
    DesertHills = 17,
    WoodedHills = 18,
    ForestHills = WoodedHills,
    TaigaHills = 19,
    MountainEdge = 20,
    ExtremeHillsEdge = MountainEdge,
    Jungle = 21,
    JungleHills = 22,
    JungleEdge = 23,
    DeepOcean = 24,
    StoneShore = 25,
    StoneBeach = StoneShore,
    SnowyBeach = 26,
    ColdBeach = SnowyBeach,
    BirchForest = 27,
    BirchForestHills = 28,
    DarkForest = 29,
    RoofedForest = DarkForest,
    SnowyTaiga = 30,
    ColdTaiga = SnowyTaiga,
    SnowyTaigaHills = 31,
    ColdTaigaHills = SnowyTaigaHills,
    GiantTreeTaiga = 32,
    MegaTaiga = GiantTreeTaiga,
    GiantTreeTaigaHills = 33,
    MegaTaigaHills = GiantTreeTaigaHills,
    WoodedMountains = 34,
    ExtremeHillsPlus = WoodedMountains,
    Savanna = 35,
    SavannaPlateau = 36,
    Badlands = 37,
    Mesa = Badlands,
    WoodedBadlandsPlateau = 38,
    MesaPlateauF = WoodedBadlandsPlateau,
    BadlandsPlateau = 39,
    MesaPlateau = BadlandsPlateau,
    SmallEndIslands = 40,
    EndMidlands = 41,
    EndHighlands = 42,
    EndBarrens = 43,
    WarmOcean = 44,
    LukewarmOcean = 45,
    ColdOcean = 46,
    DeepWarmOcean = 47,
    WarmDeepOcean = DeepWarmOcean,
    DeepLukewarmOcean = 48,
    LukewarmDeepOcean = DeepLukewarmOcean,
    DeepColdOcean = 49,
    ColdDeepOcean = DeepColdOcean,
    DeepFrozenOcean = 50,
    FrozenDeepOcean = DeepFrozenOcean,
    SeasonalForest = 51,
    Rainforest = 52,
    Shrubland = 53,

    TheVoid = 127,

    SunflowerPlains = 129, // plains + 128
    DesertLakes = 130, // desert + 128
    GravellyMountains = 131, // mountains + 128
    FlowerForest = 132, // forest + 128
    TaigaMountains = 133, // taiga + 128
    SwampHills = 134, // swamp + 128
    IceSpikes = 140, // snowy_tundra + 128
    ModifiedJungle = 149, // jungle + 128
    ModifiedJungleEdge = 151, // jungle_edge + 128
    TallBirchForest = 155, // birch_forest + 128
    TallBirchHills = 156, // birch_forest_hills + 128
    DarkForestHills = 157, // dark_forest + 128
    SnowyTaigaMountains = 158, // snowy_taiga + 128
    GiantSpruceTaiga = 160, // giant_tree_taiga + 128
    GiantSpruceTaigaHills = 161, // giant_tree_taiga_hills + 128
    ModifiedGravellyMountains = 162, // wooded_mountains + 128
    ShatteredSavanna = 163, // savanna + 128
    ShatteredSavannaPlateau = 164, // savanna_plateau + 128
    ErodedBadlands = 165, // badlands + 128
    ModifiedWoodedBadlandsPlateau = 166, // wooded_badlands_plateau + 128
    ModifiedBadlandsPlateau = 167, // badlands_plateau + 128

    BambooJungle = 168,
    BambooJungleHills = 169,

    SoulSandValley = 170,
    CrimsonForest = 171,
    WarpedForest = 172,
    BasaltDeltas = 173,

    DripstoneCaves = 174,
    LushCaves = 175,

    Meadow = 177,
    Grove = 178,
    SnowySlopes = 179,
    JaggedPeaks = 180,
    FrozenPeaks = 181,
    StonyPeaks = 182,

    OldGrowthBirchForest = TallBirchForest,
    OldGrowthPineTaiga = GiantTreeTaiga,
    OldGrowthSpruceTaiga = GiantSpruceTaiga,
    SnowyPlains = SnowyTundra,
    SparseJungle = JungleEdge,
    StonyShore = StoneShore,
    WindsweptHills = Mountains,
    WindsweptForest = WoodedMountains,
    WindsweptGravellyHills = GravellyMountains,
    WindsweptSavanna = ShatteredSavanna,
    WoodedBadlands = WoodedBadlandsPlateau,

    DeepDark = 183,
    MangroveSwamp = 184,
    CherryGrove = 185,
    PaleGarden = 186
}

public static partial class LibCubiomes
{
    [LibraryImport(DllName, EntryPoint = "biomeExists")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool BiomeExists(McVersion mc, BiomeId id);

    [LibraryImport(DllName, EntryPoint = "isOverworld")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsOverworld(McVersion mc, BiomeId id);

    [LibraryImport(DllName, EntryPoint = "getDimension")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial Dimension GetDimension(BiomeId id);

    [LibraryImport(DllName, EntryPoint = "getMutated")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial BiomeId GetMutated(McVersion mc, BiomeId id);

    [LibraryImport(DllName, EntryPoint = "getCategory")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    public static partial BiomeId GetCategory(McVersion mc, BiomeId id);

    [LibraryImport(DllName, EntryPoint = "areSimilar")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool AreSimilar(McVersion mc, BiomeId id1, BiomeId id2);

    [LibraryImport(DllName, EntryPoint = "isMesa")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsMesa(BiomeId id);

    [LibraryImport(DllName, EntryPoint = "isShallowOcean")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsShallowOcean(BiomeId id);

    [LibraryImport(DllName, EntryPoint = "isDeepOcean")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsDeepOcean(BiomeId id);

    [LibraryImport(DllName, EntryPoint = "isOceanic")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsOceanic(BiomeId id);

    [LibraryImport(DllName, EntryPoint = "isSnowy")]
    [UnmanagedCallConv(CallConvs = [typeof(CallConvCdecl)])]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsSnowy(BiomeId id);
}