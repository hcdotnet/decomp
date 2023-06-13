using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

[Dumper("audio_groups")]
public sealed class AudioGroupDumper : AbstractListDumper<UndertaleAudioGroup> {
    public override void Dump(UndertaleData data, FileWriter w) {
        // base.Dump(data, w);
        
        w.Create(JsonConvert.SerializeObject(data.AudioGroups.Select(x => x.Name.Content), Formatting.Indented), "audio_groups.json");
    }

    protected override void DumpListItem(UndertaleData data, UndertaleAudioGroup item, FileWriter w) { }

    protected override IList<UndertaleAudioGroup>? GetList(UndertaleData data) {
        return data.AudioGroups;
    }
}
