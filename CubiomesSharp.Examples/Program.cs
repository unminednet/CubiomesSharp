using CubiomesSharp.Examples;
using CubiomesSharp.LibraryImports;

Console.WriteLine("Hello, World!");

var version = McVersion.MC_1_18;
var biomeId = BiomeId.Swamp;
var pos = new Pos(0, 0);
var y = 63; // check at surface level

var biomeName = LibCubiomes.BiomeToStr(version, biomeId);
var versionName = LibCubiomes.McToStr(version);
Console.WriteLine($"Searching for a {versionName} seed with \"{biomeName}\" biome at block position {pos}");

var startFromSeed = Random.Shared.NextInt64();
var seed = Examples.FindSeedWithBiomeAt(version, biomeId, pos.x, y, pos.z, startFromSeed);

Console.WriteLine($"Seeds checked: {seed - startFromSeed + 1}");
Console.WriteLine($"Seed found: {seed}");

Console.WriteLine($"Generating an image centered at {pos}");
Examples.SaveBiomeMapImage(version, seed, pos.x, pos.z);
Console.WriteLine("Image saved to map.ppm and map.png");