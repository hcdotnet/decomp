using System.IO;

namespace AssetDumper;

public sealed class FileWriter {
    public string BaseDirectory { get; }

    public FileWriter(string baseDirectory) {
        BaseDirectory = baseDirectory;
        Directory.CreateDirectory(BaseDirectory);
    }

    public void Create(byte[] data, params string[] path) {
        var fullPath = Path.Combine(BaseDirectory, Path.Combine(path));
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllBytes(fullPath, data);
    }

    public void Create(Stream data, params string[] path) {
        var fullPath = Path.Combine(BaseDirectory, Path.Combine(path));
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        using var file = File.OpenWrite(fullPath);
        data.CopyTo(file);
    }

    public void Create(string data, params string[] path) {
        var fullPath = Path.Combine(BaseDirectory, Path.Combine(path));
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
        File.WriteAllText(fullPath, data);
    }

    public void WritePlaceholder() {
        File.Create(Path.Combine(BaseDirectory, "_._")).Dispose();
    }

    public string GetPath(params string[] path) => Path.Combine(BaseDirectory, Path.Combine(path));

    public string GetRelativePath(params string[] path) => Path.Combine(path);
}
