using System.Collections.Generic;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public class RoomInfo {
    public string Name { get; init; }

    public string Caption { get; init; }

    public uint Width { get; init; }

    public uint Height { get; init; }

    public uint Speed { get; init; }

    public bool Persistent { get; init; }

    public uint BackgroundColor { get; init; }

    public bool DrawBackgroundColor { get; init; }

    public string CreationCodeIdName { get; init; }

    // public RoomEntryFlagsInfo Flags { get; init; }

    public bool World { get; init; }

    public uint Top { get; init; }

    public uint Left { get; init; }

    public uint Right { get; init; }

    public uint Bottom { get; init; }

    public float GravityX { get; init; }

    public float GravityY { get; init; }

    public float MetersPerPixel { get; init; }

    public double GridWidth { get; init; }

    public double GridHeight { get; init; }

    public double GridThicknessPx { get; init; }
}

[Dumper("rooms")]
public sealed class RoomDumper : AbstractListDumper<UndertaleRoom> {
    protected override void DumpListItem(UndertaleData data, UndertaleRoom item, FileWriter w) {
        // TODO
    }

    protected override IList<UndertaleRoom>? GetList(UndertaleData data) {
        return data.Rooms;
    }
}
