using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProjectCreator.ProjectCreator.Resources;

namespace ProjectCreator.ProjectCreator;

public class GameMakerOptions {
    // for each option, save as:
    //  ./options/{name}/options_{name}.yy
    public Dictionary<string, List<(string name, object options)>> OptionDict { get; set; }

    public void AddOptions(string folderName, string optionName, object options) {
        if (!OptionDict.TryGetValue(folderName, out var optionList))
            optionList = OptionDict[folderName] = new List<(string, object)>();

        optionList.Add((optionName, options));
    }

    public void WriteToDirectory(string directory) {
        Directory.CreateDirectory(directory);

        foreach (var (folderName, optionList) in OptionDict) {
            var path = Path.Combine(directory, folderName);
            Directory.CreateDirectory(path);

            foreach (var (optionName, options) in optionList)
                File.WriteAllText(Path.Combine(path, $"{optionName}.yy"), JsonConvert.SerializeObject(options, Formatting.Indented));
        }
    }

    public static GameMakerOptions CreateNew() {
        return new GameMakerOptions {
            // todo: options for platforms? (e.g. operagx, windows)
            OptionDict = new Dictionary<string, List<(string, object)>> {
                {
                    "main", new List<(string, object)> {
                        ("options_main", new GmMainOptions {
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
                        }),
                    }
                },
            },
        };
    }
}
