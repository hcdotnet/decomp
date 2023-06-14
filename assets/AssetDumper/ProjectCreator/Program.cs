using System;
using System.IO;
using ProjectCreator.DumpedAssetHandler;
using ProjectCreator.ProjectCreator;
using YoYoStudio.Core.Utils;

namespace ProjectCreator;

internal static class Program {
    internal static void Main(string[] args) {
        string? projectPath = null;
        string? assetPath = null;

        projectPath ??= Environment.GetEnvironmentVariable("HCDN_ASSET_DUMPER_PROJECT_DIR");
        assetPath ??= Environment.GetEnvironmentVariable("HCDN_ASSET_DUMPER_OUTPUT_DIR");

        if (args.Length >= 1)
            projectPath = args[0];

        if (args.Length >= 2)
            assetPath = args[1];

        while (string.IsNullOrWhiteSpace(projectPath)) {
            Console.Write("Enter the path to the project: ");
            projectPath = Console.ReadLine();
        }

        while (string.IsNullOrWhiteSpace(assetPath) || !Directory.Exists(assetPath)) {
            Console.Write("Enter the path to the dumped game assets (this should include all three folders): ");
            assetPath = Console.ReadLine();
        }

        Console.WriteLine("Using project path: " + projectPath);
        Directory.CreateDirectory(projectPath);
        
        MacroExpansion.Initialise();
        Log.Initialise();

        var dataRoot = AssetRoot.FromDirectory(Path.Combine(assetPath, "data"));
        var project = new GameMakerProject(projectPath, "HoloCure");
        project.ImportAssetRoot(dataRoot);
        project.Save();
    }
}
