using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("scripts")]
public sealed class ScriptDumper : AbstractListDumper<UndertaleScript> {
    public override void Dump(UndertaleData data, FileWriter w) {
        // base.Dump(data, w);

        var scripts = new Dictionary<string, string>();

        foreach (var script in GetList(data)!) {
            if (scripts.TryGetValue(script.Name.Content, out var value)) {
                if (scripts[script.Name.Content] != script.Code.Name.Content)
                    throw new Exception($"Duplicate script name '{script.Name.Content}' with different code names '{value}' and '{script.Code.Name.Content}'.");

                Console.WriteLine($"Duplicate script name '{script.Name.Content}' with same code name '{value}'.");
                continue;
            }

            scripts.Add(script.Name.Content, script.Code.Name.Content);
        }

        // I would have written to individual files but script names are too
        // long for platforms like Windows.
        w.Create(JsonConvert.SerializeObject(scripts, Formatting.Indented), "scripts.json");
    }

    protected override void DumpListItem(UndertaleData data, UndertaleScript item, FileWriter w) { }

    protected override IList<UndertaleScript>? GetList(UndertaleData data) {
        return data.Scripts;
    }
}
