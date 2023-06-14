using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;
using UndertaleModLib.Util;

namespace AssetDumper.Dumpers;

public class GlyphInfo {
    public ushort Character { get; init; }

    public uint SourceX { get; init; }

    public uint SourceY { get; init; }

    public uint SourceWidth { get; init; }

    public uint SourceHeight { get; init; }

    public short Shift { get; init; }

    public short Offset { get; init; }

    public static GlyphInfo FromGameMakerObject(UndertaleFont.Glyph glyph) {
        return new GlyphInfo {
            Character = glyph.Character,
            SourceX = glyph.SourceX,
            SourceY = glyph.SourceY,
            SourceWidth = glyph.SourceWidth,
            SourceHeight = glyph.SourceHeight,
            Shift = glyph.Shift,
            Offset = glyph.Offset,
        };
    }
}

public class FontInfo {
    public string Name { get; init; }

    public string DisplayName { get; init; }

    public bool EmSizeIsFloat { get; init; }

    public uint EmSize { get; init; }

    public bool Bold { get; init; }

    public bool Italic { get; init; }

    public ushort RangeStart { get; init; }

    public byte CharSet { get; init; }

    public byte AntiAliasing { get; init; }

    public uint RangeEnd { get; init; }

    public float ScaleX { get; init; }

    public float ScaleY { get; init; }

    public uint Ascender { get; init; }

    public uint SdfSpread { get; init; }

    public List<GlyphInfo> Glyhps { get; init; }

    public int AscenderOffset { get; init; }

    public static FontInfo FromGameMakerObject(UndertaleFont font) {
        return new FontInfo {
            Name = font.Name.Content,
            DisplayName = font.DisplayName.Content,
            EmSizeIsFloat = font.EmSizeIsFloat,
            EmSize = font.EmSize,
            Bold = font.Bold,
            Italic = font.Italic,
            RangeStart = font.RangeStart,
            CharSet = font.Charset,
            AntiAliasing = font.AntiAliasing,
            RangeEnd = font.RangeEnd,
            ScaleX = font.ScaleX,
            ScaleY = font.ScaleY,
            Ascender = font.Ascender,
            SdfSpread = font.SDFSpread,
            Glyhps = font.Glyphs.Select(GlyphInfo.FromGameMakerObject).ToList(),
            AscenderOffset = font.AscenderOffset,
        };
    }
}

[Dumper("fonts")]
public sealed class FontDumper : AbstractListDumper<UndertaleFont> {
    protected override void DumpListItem(UndertaleData data, UndertaleFont item, FileWriter w) {
        var path = w.GetRelativePath(item.Name.Content);

        w.Create(JsonConvert.SerializeObject(FontInfo.FromGameMakerObject(item), Formatting.Indented), path, "font_info.json");

        var worker = new TextureWorker();
        worker.ExportAsPNG(item.Texture, w.GetPath(path, item.Name.Content + ".png"));
    }

    protected override IList<UndertaleFont>? GetList(UndertaleData data) {
        return data.Fonts;
    }
}
