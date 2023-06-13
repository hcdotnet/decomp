using System.Collections.Generic;
using System.Text;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public sealed class ShaderDumper : AbstractListDumper<UndertaleShader> {
    public override string Name => "shaders";

    protected override void DumpListItem(UndertaleData data, UndertaleShader item, FileWriter w) {
        var sb = new StringBuilder();
        sb.AppendLine("Name: " + item.Name.Content);
        sb.AppendLine("Type: " + item.Type);
        sb.AppendLine("Attributes:");
        foreach (var attribute in item.VertexShaderAttributes)
            sb.AppendLine("    " + attribute.Name.Content);
        w.Create(sb.ToString(), item.Name.Content, "shader_info.txt");

        w.Create(item.GLSL_ES_Vertex.Content, item.Name.Content, "GLSL_ES_Vertex.glsl");
        w.Create(item.GLSL_ES_Fragment.Content, item.Name.Content, "GLSL_ES_Fragment.glsl");
        w.Create(item.GLSL_Vertex.Content, item.Name.Content, "GLSL_Vertex.glsl");
        w.Create(item.GLSL_Fragment.Content, item.Name.Content, "GLSL_Fragment.glsl");
        w.Create(item.HLSL9_Vertex.Content, item.Name.Content, "HLSL9_Vertex.glsl");
        w.Create(item.HLSL9_Fragment.Content, item.Name.Content, "HLSL9_Fragment.glsl");
    }

    protected override IList<UndertaleShader>? GetList(UndertaleData data) {
        return data.Shaders;
    }
}
