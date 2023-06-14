using System;
using System.IO;
using ProjectCreator.DumpedAssetHandler;
using ProjectCreator.ProjectSystem;

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

        Directory.CreateDirectory(projectPath);

        var dataRoot = AssetRoot.FromDirectory(Path.Combine(assetPath, "data"));
        var project = new GameMakerProject("HoloCure");
        project.ImportAssetRoot(dataRoot);
        project.WriteToDirectory(projectPath);
    }
}
