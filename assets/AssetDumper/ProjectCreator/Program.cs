using System;
using System.IO;
using ProjectCreator.ProjectCreator;

namespace ProjectCreator;

internal static class Program {
    internal static void Main(string[] args) {
        string? projectPath = null;
        string? gameDir = null;

        projectPath ??= Environment.GetEnvironmentVariable("HCDN_PROJECT_CREATOR_PROJECT_DIR");
        gameDir ??= Environment.GetEnvironmentVariable("HCDN_PROJECT_CREATOR_GAME_DIR");

        if (args.Length >= 1)
            projectPath = args[0];

        if (args.Length >= 2)
            gameDir = args[1];

        while (string.IsNullOrWhiteSpace(projectPath)) {
            Console.Write("Enter the path to the project: ");
            projectPath = Console.ReadLine();
        }

        while (string.IsNullOrWhiteSpace(gameDir) || !Directory.Exists(gameDir)) {
            Console.Write("Enter the root directory of the production-ready GameMaker game: ");
            gameDir = Console.ReadLine();
        }

        Console.WriteLine("Using project path: " + projectPath);
        Directory.CreateDirectory(projectPath);

        Console.WriteLine("Creating project... (HoloCure)");
        var project = GameMakerProject.CreateNew("HoloCure");

        Console.WriteLine($"Importing game... ({gameDir})");
        project.ImportGame(gameDir);

        Console.WriteLine($"Saving project... ({projectPath})");
        project.WriteToDirectory(projectPath);

        Console.WriteLine();
        Console.WriteLine("Expected physical files:");
        foreach (var (key, value) in project.ExpectedPhysicalFiles)
            Console.WriteLine($"  {key}: {value}");
        Console.WriteLine();

        Console.WriteLine("Copying expected physical files...");

        foreach (var (key, value) in project.ExpectedPhysicalFiles) {
            var source = Path.Combine(gameDir, value);
            var dest = Path.Combine(projectPath, key);
            Console.WriteLine($"  {source} -> {dest}");
            Directory.CreateDirectory(Path.GetDirectoryName(dest)!);
            File.Copy(source, dest, true);
        }

        Console.WriteLine();

        Console.WriteLine("Done!");

        /*MacroExpansion.Initialise();
        Log.Initialise();

        var dataRoot = AssetRoot.FromDirectory(Path.Combine(assetPath, "data"));
        var project = new GameMakerProject(projectPath, "HoloCure");
        project.ImportAssetRoot(dataRoot);
        project.Save();*/
    }
}
