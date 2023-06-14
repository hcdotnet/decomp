using System.IO;

namespace ProjectCreator.DumpedAssetHandler;

public class AssetRoot {
    public string Name { get; }

    public AssetRoot(string name) { }

    public static AssetRoot FromDirectory(string directory) {
        var root = new AssetRoot(Path.GetFileName(directory));

        return root;
    }
}
