using System;
using System.IO;
using AssetDumper.Dumpers;
using UndertaleModLib;

namespace AssetDumper;

internal static class Program {
    internal static void Main(string[] args) {
        string? gameDir = null;
        string? outputDir = null;

        switch (args.Length) {
            case 1:
                gameDir = args[0];
                break;

            case 2:
                gameDir = args[0];
                outputDir = args[1];
                break;
        }

        gameDir ??= Environment.GetEnvironmentVariable("HCDN_ASSET_DUMPER_GAME_DIR");
        outputDir ??= Environment.GetEnvironmentVariable("HCDN_ASSET_DUMPER_OUTPUT_DIR");
        var varsUnset = gameDir is null || outputDir is null;

        while (gameDir is null || !Directory.Exists(gameDir)) {
            Console.WriteLine("Please enter a valid game directory:");
            gameDir = Console.ReadLine();
        }

        while (outputDir is null || !Directory.Exists(outputDir)) {
            Console.WriteLine("Please enter a valid output directory:");
            outputDir = Console.ReadLine();
        }

        Console.WriteLine("Using game directory: " + gameDir);
        Console.WriteLine("Using output directory: " + outputDir);

        var assetDumpers = new IAssetDumper[] { new EmbeddedAudioDumper() };

        var (audioGroup1, audioGroup1Name) = GetDataFile("audiogroup1.dat", gameDir);
        DumpData(audioGroup1, audioGroup1Name, outputDir, assetDumpers);

        var (audioGroup2, audioGroup2Name) = GetDataFile("audiogroup2.dat", gameDir);
        DumpData(audioGroup2, audioGroup2Name, outputDir, assetDumpers);

        var (data, dataName) = GetDataFile("data.win", gameDir);
        DumpData(data, dataName, outputDir, assetDumpers);
    }

    private static (UndertaleData data, string name) GetDataFile(string fileName, string gameDirectory) {
        var path = Path.Combine(gameDirectory, fileName);
        if (!File.Exists(path))
            throw new FileNotFoundException($"Could not find file {fileName} in {gameDirectory}");

        Console.WriteLine("Loading data file from path: " + path);
        using var stream = File.OpenRead(path);
        return (UndertaleIO.Read(stream), Path.GetFileNameWithoutExtension(fileName));
    }

    private static void DumpData(UndertaleData data, string dataName, string outputDir, params IAssetDumper[] assetDumpers) {
        var directory = Path.Combine(outputDir, dataName);
        Directory.CreateDirectory(directory);
        Console.WriteLine("Dumping data file to directory: " + directory);

        foreach (var assetDumper in assetDumpers) {
            Console.WriteLine($"Running asset dumper: {assetDumper.Name} ({assetDumper.GetType().Name})");
            var fileWriter = new FileWriter(Path.Combine(directory, assetDumper.Name));

            if (assetDumper.ShouldDump(data))
                assetDumper.Dump(data, fileWriter);
            else
                fileWriter.WritePlaceholder();
        }

        Console.WriteLine("Finished dumping data file to directory: " + directory);
    }
}
