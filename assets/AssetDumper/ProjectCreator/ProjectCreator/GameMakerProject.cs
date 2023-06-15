using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProjectCreator.ProjectCreator.Resources;
using UndertaleModLib.Models;

namespace ProjectCreator.ProjectCreator;

public sealed partial class GameMakerProject {
    // {name}.yyp
    public GmProject Project { get; set; }

    // {name}.resource_order
    public GmResourceOrderFile OrderFile { get; set; }

    // see comments in class for how to save
    public GameMakerOptions Options { get; set; }

    public Dictionary<string, string> ExpectedPhysicalFiles { get; set; } = new();

    public List<GmExtension> Extensions { get; set; } = new();

    public void WriteToDirectory(string directory) {
        Directory.CreateDirectory(directory);

        var projectPath = Path.Combine(directory, $"{Project.Name}.yyp");
        File.WriteAllText(projectPath, JsonConvert.SerializeObject(Project, Formatting.Indented));

        var orderFilePath = Path.Combine(directory, $"{Project.Name}.resource_order");
        File.WriteAllText(orderFilePath, JsonConvert.SerializeObject(OrderFile, Formatting.Indented));

        Options.WriteToDirectory(Path.Combine(directory, "options"));

        foreach (var extension in Extensions)
            WriteExtension(directory, extension);

        var expectedPhysicalFilesPath = Path.Combine(directory, "expectedPhysicalFiles.json");
        File.WriteAllText(expectedPhysicalFilesPath, JsonConvert.SerializeObject(ExpectedPhysicalFiles, Formatting.Indented));
    }

    private void WriteExtension(string directory, GmExtension extension) {
        var path = Path.Combine(directory, "extensions", extension.Name, extension.Name + ".yy");
        Directory.CreateDirectory(Path.GetDirectoryName(path)!);
        File.WriteAllText(path, JsonConvert.SerializeObject(extension, Formatting.Indented));
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
