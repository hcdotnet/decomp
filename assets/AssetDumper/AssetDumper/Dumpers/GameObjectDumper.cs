using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public class GameObjectEventAction {
    public uint LibId { get; init; }

    public uint Id { get; init; }

    public uint Kind { get; init; }

    public bool UseRelative { get; init; }

    public bool IsQuestion { get; init; }

    public bool UseApplyTo { get; init; }

    public uint ExeType { get; init; }

    public string ActionName { get; init; }

    public string CodeIdName { get; init; }

    public uint ArgumentCount { get; init; }

    public int Who { get; init; }

    public bool Relative { get; init; }

    public bool IsNot { get; init; }

    public uint UnknownAlwaysZero { get; init; }

    public static GameObjectEventAction FromGameMakerObject(UndertaleGameObject.EventAction vertex) {
        return new GameObjectEventAction {
            LibId = vertex.LibID,
            Id = vertex.ID,
            Kind = vertex.Kind,
            UseRelative = vertex.UseRelative,
            IsQuestion = vertex.IsQuestion,
            UseApplyTo = vertex.UseApplyTo,
            ExeType = vertex.ExeType,
            ActionName = vertex.ActionName?.Content ?? "<null>",
            CodeIdName = vertex.CodeId.Name.Content,
            ArgumentCount = vertex.ArgumentCount,
            Who = vertex.Who,
            Relative = vertex.Relative,
            IsNot = vertex.IsNot,
            UnknownAlwaysZero = vertex.UnknownAlwaysZero,
        };
    }
}

public class GameObjectEvent {
    public uint EventSubtype { get; init; }

    public List<GameObjectEventAction> Actions { get; init; }

    public static GameObjectEvent FromGameMakerObject(UndertaleGameObject.Event vertex) {
        return new GameObjectEvent {
            EventSubtype = vertex.EventSubtype,
            Actions = vertex.Actions.Select(GameObjectEventAction.FromGameMakerObject).ToList()
        };
    }
}

public class PhysicsVertex {
    public float X { get; init; }

    public float Y { get; init; }

    public static PhysicsVertex FromGameMakerObject(UndertaleGameObject.UndertalePhysicsVertex vertex) {
        return new PhysicsVertex {
            X = vertex.X,
            Y = vertex.Y
        };
    }
}

public class GameObjectInfo {
    public string Name { get; init; }

    public string SpriteName { get; init; }

    public bool Visible { get; init; }

    // TODO: unused?
    public bool Managed { get; init; }

    public bool Solid { get; init; }

    public int Depth { get; init; }

    public bool Persistent { get; init; }

    public string ParentIdName { get; init; }

    public string TextureMaskIdName { get; init; }

    public bool UsesPhysics { get; init; }

    public bool IsSensor { get; init; }

    public CollisionShapeFlags CollisionShape { get; init; }

    public float Density { get; init; }

    public float Restitution { get; init; } = 0.1f;

    public uint Group { get; init; }

    public float LinearDamping { get; init; }

    public float AngularDamping { get; init; }

    public float Friction { get; init; }

    public bool Awake { get; init; }

    public bool Kinematic { get; init; }

    public List<PhysicsVertex> PhysicsVertices { get; init; }

    public List<List<GameObjectEvent>> Events { get; init; }

    public static GameObjectInfo FromGameMakerObject(UndertaleGameObject gameObject) {
        return new GameObjectInfo {
            Name = gameObject.Name.Content,
            SpriteName = gameObject.Sprite?.Name.Content ?? "<null>",
            Visible = gameObject.Visible,
            Managed = gameObject.Managed,
            Solid = gameObject.Solid,
            Depth = gameObject.Depth,
            Persistent = gameObject.Persistent,
            ParentIdName = gameObject.ParentId?.Name.Content ?? "<null>",
            TextureMaskIdName = gameObject.TextureMaskId?.Name.Content ?? "<null>",
            UsesPhysics = gameObject.UsesPhysics,
            IsSensor = gameObject.IsSensor,
            CollisionShape = gameObject.CollisionShape,
            Density = gameObject.Density,
            Restitution = gameObject.Restitution,
            Group = gameObject.Group,
            LinearDamping = gameObject.LinearDamping,
            AngularDamping = gameObject.AngularDamping,
            Friction = gameObject.Friction,
            Awake = gameObject.Awake,
            Kinematic = gameObject.Kinematic,
            PhysicsVertices = gameObject.PhysicsVertices.Select(PhysicsVertex.FromGameMakerObject).ToList(),
            Events = gameObject.Events.Select(x => x.Select(GameObjectEvent.FromGameMakerObject).ToList()).ToList()
        };
    }
}

[Dumper("game_objects")]
public sealed class GameObjectDumper : AbstractListDumper<UndertaleGameObject> {
    protected override void DumpListItem(UndertaleData data, UndertaleGameObject item, FileWriter w) {
        w.Create(JsonConvert.SerializeObject(GameObjectInfo.FromGameMakerObject(item), Formatting.Indented), item.Name.Content + ".json");
    }

    protected override IList<UndertaleGameObject>? GetList(UndertaleData data) {
        return data.GameObjects;
    }
}
