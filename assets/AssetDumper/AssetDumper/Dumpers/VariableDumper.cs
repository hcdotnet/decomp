using System.Collections.Generic;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public class VariableInfo {
    public string Name { get; init; }

    public UndertaleInstruction.InstanceType InstanceType { get; init; }

    public int VarId { get; init; }

    public uint Occurrences { get; init; }

    // public UndertaleInstruction FirstAddress { get; init; }

    public int NameStringId { get; init; }

    public static VariableInfo FromVariable(UndertaleVariable variable) {
        return new VariableInfo {
            InstanceType = variable.InstanceType,
            VarId = variable.VarID,
            Occurrences = variable.Occurrences,
            // FirstAddress = variable.FirstAddress,
            NameStringId = variable.NameStringID
        };
    }
}

[Dumper("variables")]
public sealed class VariableDumper : AbstractListDumper<UndertaleVariable> {
    public override void Dump(UndertaleData data, FileWriter w) {
        // base.Dump(data, w);

        var list = new List<VariableInfo>();
        foreach (var variable in GetList(data)!)
            list.Add(VariableInfo.FromVariable(variable));

        w.Create(JsonConvert.SerializeObject(list, Formatting.Indented), "variables.json");
    }

    protected override void DumpListItem(UndertaleData data, UndertaleVariable item, FileWriter w) { }

    protected override IList<UndertaleVariable>? GetList(UndertaleData data) {
        return data.Variables;
    }
}
