using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ProjectCreator.ProjectCreator.Resources;

namespace ProjectCreator.ProjectCreator;

public record PhysicalFile(string GamePath, string ProjectPath);

public enum VirtualFileType {
    Sound,
}

public record VirtualFile(string BinaryFileName, string Name, string ProjectPath, VirtualFileType FileType);

public sealed partial class GameMakerProject {
    // {name}.yyp
    public GmProject Project { get; set; }

    // {name}.resource_order
    public GmResourceOrderFile OrderFile { get; set; }

    // see comments in class for how to save
    public GameMakerOptions Options { get; set; }

    public List<PhysicalFile> ExpectedPhysicalFiles { get; set; } = new();

    public List<VirtualFile> ExpectedVirtualFiles { get; set; } = new();

    public List<GmSound> Sounds { get; set; } = new();

    public List<GmExtension> Extensions { get; set; } = new();

    public void WriteToDirectory(string directory) {
        Directory.CreateDirectory(directory);

        var projectPath = Path.Combine(directory, $"{Project.Name}.yyp");
        File.WriteAllText(projectPath, JsonConvert.SerializeObject(Project, Formatting.Indented));

        var orderFilePath = Path.Combine(directory, $"{Project.Name}.resource_order");
        File.WriteAllText(orderFilePath, JsonConvert.SerializeObject(OrderFile, Formatting.Indented));

        Options.WriteToDirectory(Path.Combine(directory, "options"));

        foreach (var sound in Sounds)
            WriteSounds(directory, sound);

        foreach (var extension in Extensions)
            WriteExtension(directory, extension);

        var expectedPhysicalFilesPath = Path.Combine(directory, "expectedPhysicalFiles.json");
        File.WriteAllText(expectedPhysicalFilesPath, JsonConvert.SerializeObject(ExpectedPhysicalFiles, Formatting.Indented));

        var expectedVirtualFilesPath = Path.Combine(directory, "expectedVirtualFiles.json");
        File.WriteAllText(expectedVirtualFilesPath, JsonConvert.SerializeObject(ExpectedVirtualFiles, Formatting.Indented));

        var sb = new StringBuilder();
        sb.AppendLine("# Physical files");

        foreach (var physicalFile in ExpectedPhysicalFiles)
            sb.AppendLine(physicalFile.ProjectPath);

        sb.AppendLine();
        sb.AppendLine("# Virtual files");

        foreach (var virtualFile in ExpectedVirtualFiles)
            sb.AppendLine(virtualFile.ProjectPath);

        var gitignorePath = Path.Combine(directory, ".gitignore");
        File.WriteAllText(gitignorePath, sb.ToString());
    }

    private void WriteExtension(string directory, GmExtension extension) {
        var path = Path.Combine(directory, "extensions", extension.Name, extension.Name + ".yy");
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonConvert.SerializeObject(extension, Formatting.Indented));
    }

    private void WriteSounds(string directory, GmSound sound) {
        var path = Path.Combine(directory, "sounds", sound.Name, sound.Name + ".yy");
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonConvert.SerializeObject(sound, Formatting.Indented));
    }

    public static GameMakerProject CreateNew(string name) {
        var project = new GameMakerProject {
            Project = GmProject.CreateNew(name),
            OrderFile = GmResourceOrderFile.CreateNew(),
            Options = GameMakerOptions.CreateNew(),
        };

        return project;
    }
}
