using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectCreator.ProjectCreator;
using UndertaleModLib;

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

        foreach (var physicalFile in project.ExpectedPhysicalFiles) {
            var source = Path.Combine(gameDir, physicalFile.GamePath);
            var dest = Path.Combine(projectPath, physicalFile.ProjectPath);
            Console.WriteLine($"  {source} -> {dest}");
            Directory.CreateDirectory(Path.GetDirectoryName(dest)!);
            File.Copy(source, dest, true);
        }

        Console.WriteLine();
        Console.WriteLine("Done copying expected physical files!");

        var virtualDict = new Dictionary<string, List<VirtualFile>>();

        foreach (var virtualFile in project.ExpectedVirtualFiles) {
            if (!virtualDict.TryGetValue(virtualFile.BinaryFileName, out var virtualFileList))
                virtualFileList = virtualDict[virtualFile.BinaryFileName] = new List<VirtualFile>();

            virtualFileList.Add(virtualFile);
        }

        Console.WriteLine();
        Console.WriteLine("Expected virtual files:");

        foreach (var (binaryName, fileList) in virtualDict) {
            Console.WriteLine($"  {binaryName}:");

            foreach (var file in fileList)
                Console.WriteLine($"    {file.Name}: {file.ProjectPath} ({file.FileType})");
        }

        Console.WriteLine();

        Console.WriteLine("Copying expected virtual files...");

        foreach (var (binaryName, fileList) in virtualDict) {
            Console.WriteLine($"  {binaryName}:");

            foreach (var file in fileList) {
                var source = UndertaleIO.Read(File.OpenRead(Path.Combine(gameDir, binaryName)));
                var dest = Path.Combine(projectPath, file.ProjectPath);
                Console.WriteLine($"    {file.Name} -> {dest}");
                Directory.CreateDirectory(Path.GetDirectoryName(dest)!);

                switch (file.FileType) {
                    case VirtualFileType.Sound:
                        var sound = source.EmbeddedAudio.Single(x => x.Name.Content == "EmbeddedSound " + file.Name.Split(' ')[0]);
                        File.WriteAllBytes(dest, sound.Data);
                        break;

                    default:
                        throw new Exception("Unknown file type: " + file.FileType);
                }
            }
        }

        /*MacroExpansion.Initialise();
        Log.Initialise();

        var dataRoot = AssetRoot.FromDirectory(Path.Combine(assetPath, "data"));
        var project = new GameMakerProject(projectPath, "HoloCure");
        project.ImportAssetRoot(dataRoot);
        project.Save();*/
    }
}
