using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

EnsureDataLoaded();

var dialog = new FolderBrowserDialog();
var dialogResult = dialog.ShowDialog();

if (dialogResult != DialogResult.OK)
    throw new Exception();

Directory.CreateDirectory(dialog.SelectedPath);

void DoDumpOperation<T>(string folderName, Func<IList<T>?> assetList, Action<T, Action<string, byte[]>> dumpAction) {
    var path = Path.Combine(dialog.SelectedPath, folderName);
    if (Directory.Exists(path))
        Directory.Delete(path, true);
    Directory.CreateDirectory(path);
    
    var list = assetList();
    if (list is not null && list.Count != 0) {
        foreach (var item in list) {
            dumpAction(item, (name, data) => {
                var savePath = Path.Combine(path, name);
                Directory.CreateDirectory(Path.GetDirectoryName(savePath));
                File.WriteAllBytes(savePath, data);
            });
        }
    }
    else {
        File.Create(Path.Combine(path, "_._"));
    }
}

DoDumpOperation("embedded_audio", () => Data.EmbeddedAudio, (audio, c) => {
    c(audio.Name.Content + ".wav", audio.Data);
});

DoDumpOperation("shaders", () => Data.Shaders, (shader, c) => {
    var sb = new StringBuilder();
    sb.AppendLine("type: " + shader.Type);
    sb.AppendLine("version: " + shader.Version);
    sb.AppendLine("vertex shader attributes:");
    foreach (var attribute in shader.VertexShaderAttributes)
        sb.AppendLine("  " + attribute.Name.Content);

    c(Path.Combine(shader.Name.Content, "shdader_info.txt"), Encoding.UTF8.GetBytes(sb.ToString()));
    c(Path.Combine(shader.Name.Content, "glsl_es_vertex.glsl"), Encoding.UTF8.GetBytes(shader.GLSL_ES_Vertex.Content));
    c(Path.Combine(shader.Name.Content, "glsl_es_fragment.glsl"), Encoding.UTF8.GetBytes(shader.GLSL_ES_Fragment.Content));
    c(Path.Combine(shader.Name.Content, "glsl_vertex.glsl"), Encoding.UTF8.GetBytes(shader.GLSL_Vertex.Content));
    c(Path.Combine(shader.Name.Content, "glsl_fragment.glsl"), Encoding.UTF8.GetBytes(shader.GLSL_Fragment.Content));
    c(Path.Combine(shader.Name.Content, "hlsl_vertex.hlsl"), Encoding.UTF8.GetBytes(shader.HLSL9_Vertex.Content));
    c(Path.Combine(shader.Name.Content, "hlsl_fragment.hlsl"), Encoding.UTF8.GetBytes(shader.HLSL9_Fragment.Content));
});
