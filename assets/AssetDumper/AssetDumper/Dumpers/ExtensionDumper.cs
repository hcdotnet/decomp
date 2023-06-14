using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public class ExtensionFunctionArgumentInfo {
    public UndertaleExtensionVarType Type { get; init; }

    public static ExtensionFunctionArgumentInfo FromGameMakerObject(UndertaleExtensionFunctionArg argument) {
        return new ExtensionFunctionArgumentInfo {
            Type = argument.Type,
        };
    }
}

public class ExtensionFunctionInfo {
    public string Name { get; init; }

    public uint Id { get; init; }

    public uint Kind { get; init; }

    public UndertaleExtensionVarType RetType { get; init; }

    public string ExtName { get; init; }

    public List<ExtensionFunctionArgumentInfo> Arguments { get; init; }

    public static ExtensionFunctionInfo FromGameMakerObject(UndertaleExtensionFunction function) {
        return new ExtensionFunctionInfo {
            Name = function.Name.Content,
            Id = function.ID,
            Kind = function.Kind,
            RetType = function.RetType,
            ExtName = function.ExtName.Content,
            Arguments = function.Arguments.Select(ExtensionFunctionArgumentInfo.FromGameMakerObject).ToList(),
        };
    }
}

public class ExtensionFileInfo {
    public string FileName { get; init; }

    public string CleanupScript { get; init; }

    public string InitScript { get; init; }

    public UndertaleExtensionKind Kind { get; init; }

    public List<ExtensionFunctionInfo> Functions { get; init; }

    public static ExtensionFileInfo FromGameMakerObject(UndertaleExtensionFile file) {
        return new ExtensionFileInfo {
            FileName = file.Filename.Content,
            CleanupScript = file.CleanupScript.Content,
            InitScript = file.InitScript.Content,
            Kind = file.Kind,
            Functions = file.Functions.Select(ExtensionFunctionInfo.FromGameMakerObject).ToList(),
        };
    }
}

public class ExtensionOptionInfo {
    public string Name { get; init; }

    public string Value { get; init; }

    public UndertaleExtensionOption.OptionKind Kind { get; init; }

    public static ExtensionOptionInfo FromGameMakerObject(UndertaleExtensionOption option) {
        return new ExtensionOptionInfo {
            Name = option.Name.Content,
            Value = option.Value.Content,
            Kind = option.Kind,
        };
    }
}

public class ExtensionInfo {
    // Useless.
    // public string FolderName { get; init; }

    public string Name { get; init; }

    public string ClassName { get; init; }

    public string Version { get; init; }

    public List<ExtensionFileInfo> Files { get; init; }

    public List<ExtensionOptionInfo> Options { get; init; }

    public static ExtensionInfo FromGameMakerObject(UndertaleExtension extension) {
        return new ExtensionInfo {
            Name = extension.Name.Content,
            ClassName = extension.ClassName.Content,
            Version = extension.Version?.Content ?? "<null>",
            Files = extension.Files.Select(ExtensionFileInfo.FromGameMakerObject).ToList(),
            Options = extension.Options.Select(ExtensionOptionInfo.FromGameMakerObject).ToList(),
        };
    }
}

[Dumper("extensions")]
public sealed class ExtensionDumper : AbstractListDumper<UndertaleExtension> {
    protected override void DumpListItem(UndertaleData data, UndertaleExtension item, FileWriter w) {
        w.Create(JsonConvert.SerializeObject(ExtensionInfo.FromGameMakerObject(item), Formatting.Indented), item.Name.Content + ".json");
    }

    protected override IList<UndertaleExtension>? GetList(UndertaleData data) {
        return data.Extensions;
    }
}
