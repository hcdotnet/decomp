using System.Collections.Generic;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public class SoundInfoFlags {
    public UndertaleSound.AudioEntryFlags Flags { get; init; }

    public bool IsEmbedded { get; init; }

    public bool IsCompressed { get; init; }

    public bool IsDecompressedOnLoad { get; init; }

    public bool Regular { get; init; }

    public static SoundInfoFlags FromGameMakerObject(UndertaleSound.AudioEntryFlags flags) {
        return new SoundInfoFlags {
            Flags = flags,
            IsEmbedded = flags.HasFlag(UndertaleSound.AudioEntryFlags.IsEmbedded),
            IsCompressed = flags.HasFlag(UndertaleSound.AudioEntryFlags.IsCompressed),
            IsDecompressedOnLoad = flags.HasFlag(UndertaleSound.AudioEntryFlags.IsDecompressedOnLoad),
            Regular = flags.HasFlag(UndertaleSound.AudioEntryFlags.Regular)
        };
    }
}

public class SoundInfo {
    public string Name { get; init; }

    public SoundInfoFlags Flags { get; init; }

    public string Type { get; init; }

    public string File { get; init; }

    public uint Effects { get; init; }

    public float Volume { get; init; }

    public bool Preload { get; init; }

    public float Pitch { get; init; }

    // Decided to use this for directories.
    // public string AudioGroup { get; init; }

    // Just use an ID pointing to the audio asset in another audio group.
    public int AudioId { get; init; }

    public static SoundInfo FromGameMakerObject(UndertaleSound sound) {
        return new SoundInfo {
            Name = sound.Name.Content,
            Flags = SoundInfoFlags.FromGameMakerObject(sound.Flags),
            Type = sound.Type?.Content ?? "<null>",
            File = sound.File.Content,
            Effects = sound.Effects,
            Volume = sound.Volume,
            Preload = sound.Preload,
            Pitch = sound.Pitch,
            AudioId = sound.AudioID,
        };
    }
}

[Dumper("sounds")]
public sealed class SoundDumper : AbstractListDumper<UndertaleSound> {
    protected override void DumpListItem(UndertaleData data, UndertaleSound item, FileWriter w) {
        var path = w.GetRelativePath(item.AudioGroup.Name.Content, item.Name.Content + ".json");

        w.Create(JsonConvert.SerializeObject(SoundInfo.FromGameMakerObject(item), Formatting.Indented), path);
        // w.Create(item.AudioFile.Data, path, item.AudioFile.Name.Content + ".wav");
    }

    protected override IList<UndertaleSound>? GetList(UndertaleData data) {
        return data.Sounds;
    }
}
