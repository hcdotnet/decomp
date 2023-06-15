using System.IO;
using Newtonsoft.Json;
using ProjectCreator.ProjectCreator.Resources;

namespace ProjectCreator.ProjectCreator;

public sealed class GameMakerProject {
    // {name}.yyp
    public GmProject Project { get; set; }

    // {name}.resource_order
    public GmResourceOrderFile OrderFile { get; set; }

    // see comments in class for how to save
    public GameMakerOptions Options { get; set; }

    public void WriteToDirectory(string directory) {
        Directory.CreateDirectory(directory);

        var projectPath = Path.Combine(directory, $"{Project.Name}.yyp");
        File.WriteAllText(projectPath, JsonConvert.SerializeObject(Project, Formatting.Indented));

        var orderFilePath = Path.Combine(directory, $"{Project.Name}.resource_order");
        File.WriteAllText(orderFilePath, JsonConvert.SerializeObject(OrderFile, Formatting.Indented));

        Options.WriteToDirectory(Path.Combine(directory, "options"));
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
