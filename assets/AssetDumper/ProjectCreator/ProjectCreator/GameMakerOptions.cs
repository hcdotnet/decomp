using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProjectCreator.ProjectCreator.Resources;

namespace ProjectCreator.ProjectCreator;

public class GameMakerOptions {
    // for each option, save as:
    //  ./options/{name}/options_{name}.yy
    public Dictionary<string, GmOptionsBase> Options { get; set; }

    public void WriteToDirectory(string directory) {
        Directory.CreateDirectory(directory);

        foreach (var option in Options) {
            var path = Path.Combine(directory, option.Key);
            Directory.CreateDirectory(path);

            File.WriteAllText(Path.Combine(path, $"options_{option.Key}.yy"), JsonConvert.SerializeObject(option.Value, Formatting.Indented));
        }
    }

    public static GameMakerOptions CreateNew() {
        return new GameMakerOptions {
            // todo: options for platforms? (e.g. operagx, windows)
            Options = new Dictionary<string, GmOptionsBase> {
                {
                    "main", new GmMainOptions {
                        ResourceType = "GMMainOptions",
                        ResourceVersion = "1.4",
                        Name = "Main",
                        OptionAuthor = "",
                        OptionCollisionCompatibility = false,
                        OptionCopyOnWriteEnabled = false,
                        OptionDrawColor = 4294967295, // todo: magic number
                        OptionGameSpeed = 60,
                        OptionGameGuid = Guid.NewGuid().ToString(),
                        OptionGameId = "0",
                        OptionMipsFor3DTextures = false,
                        OptionSciUseSci = false,
                        OptionSpineLicense = false,
                        OptionSteamAppId = "0",
                        OptionTemplateDescription = null,
                        OptionTemplateIcon = "${base_options_dir}/main/template_icon.png",
                        OptionTemplateImage = "${base_options_dir}/main/template_image.png",
                    }
                },
            },
        };
    }
}
