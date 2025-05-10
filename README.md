# CubiomesSharp ![License](https://img.shields.io/badge/license-MIT-blue.svg)

   

CubiomesSharp is for developers who want to use the [cubiomes](https://github.com/Cubitect/cubiomes) library in their C# applications. 

Cubiomes is a standalone library, written in C, that mimics the biome and feature generation of Minecraft Java Edition. It is intended as a powerful tool to devise very fast, custom seed-finding applications and large-scale map viewers with minimal memory usage.

CubiomesSharp provides type definitions and LibraryImports for cubiomes.

#### Native binaries

CubiomesSharp depends on the [CubiomesSharp.Native](https://github.com/unminednet/CubiomesSharp.Native) NuGet package, which contains the pre-built native binaries of cubiomes for various platforms.

#### State of development

CubiomesSharp is in early development and not fully tested.

## Documentation

See the cubiomes repository for documentation on the imported functions.

## Getting started

#### Add the NuGet source

> [!NOTE] 
> CubiomesSharp NuGet packages are hosted on GitHub. You will need a GitHub account and a personal access token with the `read:packages` scope for accessing the NuGet package registry.

Add `https://nuget.pkg.github.com/unminednet/index.json` to your NuGet sources.

The easiest way to do this is to create a `NuGet.config` file in your solution folder (or in any parent folder) with the following content:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="unminednet" value="https://nuget.pkg.github.com/unminednet/index.json" protocolVersion="3" />
  </packageSources>
  <packageSourceCredentials>
    <unminednet>
      <add key="Username" value="YOUR-GITHUB-USER-NAME" />
      <add key="ClearTextPassword" value="YOUR-GITHUB-PERSONAL-ACCESS-TOKEN" />
    </unminednet>
  </packageSourceCredentials>
</configuration>
```

Replace `YOUR-GITHUB-USER-NAME` and `YOUR-GITHUB-PERSONAL-ACCESS-TOKEN` with your GitHub username and personal access token, respectively.

#### Add the NuGet package to your project

Execute the following command in your project root:

```bash
dotnet package add CubiomesSharp
```

This will add the latest CubiomesSharp NuGet package to your csproj:

```xml
  <ItemGroup>
    <PackageReference Include="CubiomesSharp" Version="0.1.0" />
  </ItemGroup>
```

#### Biome Generation in a Range

The following code snippet shows how to generate biomes in a range and save it as an image in PPM format.


```c#
var version = McVersion.MC_1_18;
var seed = -1234;

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
        x = 0,
        z = 0,
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
    
    // Allocate a buffer for the RGB image (3 bytes per pixel)
    var pixels = new byte[r.sx * r.sz * 3];

    // Generate image from biomes
    LibCubiomes.BiomesToImage(pixels, biomeColors, biomeIds, r.sx, r.sz, 1, 1);

    // Save the RGB buffer to a PPM image file.
    LibCubiomes.SavePpm("map.ppm", pixels, r.sx, r.sz);    
}
finally
{
    // Clean up
    LibCubiomes.Free(ref g);
}

```

## TODO

* Tests for more functions
* Buffer length checks where possible and necessary
* Implement callbacks (GetParaDescent, GetParaRange)
* Imports for noise.h?
* IDisposable wrapper for generators and other structures?
* Unsafe imports (no marshalling) for speed?
* Publish to NuGet.org?

## Credits

Cubiomes is created by [Cubitect](https://github.com/Cubitect).

CubiomesSharp is created by Balázs Farkas ([megasys](https://github.com/megazyz)).

## License

CubiomesSharp is released under the MIT license.

## Contributing

Pull requests are welcome.

## Legal notes

CubiomesSharp is not an official Minecraft product, and is not approved by or associated with Mojang.
