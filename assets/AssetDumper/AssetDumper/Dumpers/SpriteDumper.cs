using System.Collections.Generic;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;
using UndertaleModLib.Util;

namespace AssetDumper.Dumpers;

public class SpriteInfo {
    public uint Width { get; init; }

    public uint Height { get; init; }

    public int MarginLeft { get; init; }

    public int MarginRight { get; init; }

    public int MarginBottom { get; init; }

    public int MarginTop { get; init; }

    public bool Transparent { get; init; }

    public bool Smooth { get; init; }

    public bool Preload { get; init; }

    public uint BBoxMode { get; init; }

    public UndertaleSprite.SepMaskType SepMasks { get; init; }

    public int OriginX { get; init; }

    public int OriginY { get; init; }

    public uint SVersion { get; init; }

    public UndertaleSprite.SpriteType SSpriteType { get; init; }

    public float Gms2PlaybackSpeed { get; init; }

    public AnimSpeedType Gms2PlaybackSpeedType { get; set; }

    public bool IsSpecialType { get; set; }

    // TODO: I don't bother with spines because they aren't in later versions.

    public static SpriteInfo FromGameMakerObject(UndertaleSprite sprite) {
        return new SpriteInfo {
            Width = sprite.Width,
            Height = sprite.Height,
            MarginLeft = sprite.MarginLeft,
            MarginRight = sprite.MarginRight,
            MarginBottom = sprite.MarginBottom,
            MarginTop = sprite.MarginTop,
            Transparent = sprite.Transparent,
            Smooth = sprite.Smooth,
            Preload = sprite.Preload,
            BBoxMode = sprite.BBoxMode,
            SepMasks = sprite.SepMasks,
            OriginX = sprite.OriginX,
            OriginY = sprite.OriginY,
            SVersion = sprite.SVersion,
            SSpriteType = sprite.SSpriteType,
            Gms2PlaybackSpeed = sprite.GMS2PlaybackSpeed,
            Gms2PlaybackSpeedType = sprite.GMS2PlaybackSpeedType,
            IsSpecialType = sprite.IsSpecialType
        };
    }
}

[Dumper("sprites", Large = true)]
public sealed class SpriteDumper : AbstractListDumper<UndertaleSprite> {
    protected override void DumpListItem(UndertaleData data, UndertaleSprite item, FileWriter w) {
        var path = w.GetRelativePath(item.Name.Content);

        w.Create(JsonConvert.SerializeObject(SpriteInfo.FromGameMakerObject(item), Formatting.Indented), path, "sprite_info.json");

        for (var i = 0; i < item.Textures.Count; i++) {
            var worker = new TextureWorker();
            worker.ExportAsPNG(item.Textures[i].Texture, w.GetPath(path, i + ".png"));
        }

        // TODO: Save this to a meaningful format...
        for (var i = 0; i < item.CollisionMasks.Count; i++)
            w.Create(item.CollisionMasks[i].Data, path, i + ".mask");
    }

    protected override IList<UndertaleSprite>? GetList(UndertaleData data) {
        return data.Sprites;
    }
}
