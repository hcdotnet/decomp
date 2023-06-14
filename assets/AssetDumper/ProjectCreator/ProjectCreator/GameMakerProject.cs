using System;
using System.IO;
using ProjectCreator.DumpedAssetHandler;
using YoYoStudio;
using YoYoStudio.Resources;

namespace ProjectCreator.ProjectCreator;

public sealed class GameMakerProject {
    public string Directory { get; }

    public string Name { get; }

    public GMProject Project { get; set; }

    public GameMakerProject(string directory, string name) {
        Directory = directory;
        Name = name;

        IDE.NewProject2(Path.Combine(directory, name + ".yyp"), eDefaultScriptType.GML, _sendAnalytic: false);
        Project = ProjectInfo.Current;
        Console.WriteLine(Project);
    }

    public void ImportAssetRoot(AssetRoot root) {
        // TODO
    }

    public void Save() {
        Project.Save(null, null, null);
    }
}
