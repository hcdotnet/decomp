using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmResourceOrderFile {
    [JsonProperty("ResourceOrderSettings")]
    public List<NameAndPathOrder> ResourceOrderSettings { get; set; }

    [JsonProperty("FolderOrderSettings")]
    public List<NameAndPathOrder> FolderOrderSettings { get; set; }

    public static GmResourceOrderFile CreateNew() {
        var order = 0;
        return new GmResourceOrderFile {
            ResourceOrderSettings = new List<NameAndPathOrder> {
                CreateNameAndPathOrder("Sprites", ++order),
                CreateNameAndPathOrder("Tile Sets", ++order),
                CreateNameAndPathOrder("Sounds", ++order),
                CreateNameAndPathOrder("Paths", ++order),
                CreateNameAndPathOrder("Scripts", ++order),
                CreateNameAndPathOrder("Shaders", ++order),
                CreateNameAndPathOrder("Fonts", ++order),
                CreateNameAndPathOrder("Timelines", ++order),
                CreateNameAndPathOrder("Objects", ++order),
                CreateNameAndPathOrder("Rooms", ++order),
                CreateNameAndPathOrder("Sequences", ++order),
                CreateNameAndPathOrder("Animation Curves", ++order),
                CreateNameAndPathOrder("Notes", ++order),
                CreateNameAndPathOrder("Extensions", ++order),
                CreateNameAndPathOrder("Particle Systems", ++order),
            },
            FolderOrderSettings = new List<NameAndPathOrder> { }
        };
    }

    private static NameAndPathOrder CreateNameAndPathOrder(string name, int order) {
        return new NameAndPathOrder {
            Name = name,
            Path = $"folders/{name}.yy",
            Order = order,
        };
    }
}
