using System.IO;

namespace AssetDumper;

public sealed class FileWriter {
    public string BaseDirectory { get; }

    public FileWriter(string baseDirectory) {
        BaseDirectory = baseDirectory;
    }

    public void Create(byte[] data, params string[] path) {
        File.WriteAllBytes(Path.Combine(BaseDirectory, Path.Combine(path)), data);
    }

    public void Create(Stream data, params string[] path) {
        using var file = File.OpenWrite(Path.Combine(BaseDirectory, Path.Combine(path)));
        data.CopyTo(file);
    }

    public void Create(string data, params string[] path) {
        File.WriteAllText(Path.Combine(BaseDirectory, Path.Combine(path)), data);
    }

    public void WritePlaceholder() {
        File.Create(Path.Combine(BaseDirectory, "_._")).Dispose();
    }
}
