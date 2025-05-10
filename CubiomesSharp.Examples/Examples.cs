using CubiomesSharp.LibraryImports;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace CubiomesSharp.Examples;

public static class Examples
{
    /// <summary>
    ///     Tests seeds for a biome at a given location.
    ///     Based on the "Biome Generator" example from the Getting Started section of the cubiomes README.md
    /// </summary>
    public static long FindSeedWithBiomeAt(McVersion version, BiomeId biomeId, int x, int y, int z, long startFromSeed = 0)
    {
        // Allocate a biome generator
        var g = LibCubiomes.AllocGenerator();
        try
        {
            // Setup the generator with the given Minecraft version
            LibCubiomes.SetupGenerator(g, version, 0);

            for (long seed = startFromSeed; ; seed++)
            {
                // Apply the seed to the generator for the Overworld dimension.
                LibCubiomes.ApplySeed(g, Dimension.Overworld, seed);

                // To get the biome at a single block position, we can use getBiomeAt().
                var scale = 1; // scale=1: block coordinates, scale=4: biome coordinates
                var biomeFound = LibCubiomes.GetBiomeAt(g, scale, x, y, z);
                if (biomeFound == biomeId)
                {
                    return seed;
                }
            }
        }
        finally
        {
            // Clean up
            LibCubiomes.Free(ref g);
        }
    }

    public static void SaveBiomeMapImage(McVersion version, long seed, int centerX, int centerZ)
    {
        // Allocate a biome generator
        var g = LibCubiomes.AllocGenerator();
        try
        {
            // Setup the generator with the given Minecraft version
            LibCubiomes.SetupGenerator(g, version, 0);

            // Apply the seed to the generator for the Overworld dimension.
            LibCubiomes.ApplySeed(g, Dimension.Overworld, seed);

            var r = new CubiomesRange
            {
                scale = 16, // 1:16 scale
                x = centerX - 128,
                z = centerZ - 128,
                sx = 256,
                sz = 256,
                y = 80, // y scale is always 1:4, so y=80 means 320 blocks high
                sy = 1
            };

            // Allocate the necessary cache for this range.
            var biomeIds = new int[LibCubiomes.GetMinCacheSize(g, r)];


            // Generate biomes in the given range.
            LibCubiomes.GenBiomes(g, biomeIds, r);

            // Initialize biome colors
            var biomeColors = new byte[256 * 3];
            LibCubiomes.InitBiomeColors(biomeColors);

            // Generate image from biomes
            var pixels = new byte[r.sx * r.sz * 3];
            LibCubiomes.BiomesToImage(pixels, biomeColors, biomeIds, r.sx, r.sz, 1, 1);

            // Save the RGB buffer to a PPM image file.
            LibCubiomes.SavePpm("map.ppm", pixels, r.sx, r.sz);

            // Save the RGB buffer to a PNG image file using SixLabors.ImageSharp
            using var img = Image.WrapMemory<Rgb24>(pixels, r.sx, r.sz);
            img.SaveAsPng("map.png");
        }
        finally
        {
            // Clean up
            LibCubiomes.Free(ref g);
        }
    }
}