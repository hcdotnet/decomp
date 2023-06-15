using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ProjectCreator.ProjectCreator.Resources;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace ProjectCreator.ProjectCreator;

partial class GameMakerProject {
    public void ImportExtension(UndertaleExtension extension) {
        var name = extension.Name.Content;

        var resourceLink = new ResourceLinkTarget {
            Name = name,
            Path = $"extensions/{name}/{name}.yy",
        };
        var resourceWeight = new GmProject.ResourceWeight {
            Id = resourceLink,
        };
        Project.Resources.Add(resourceWeight);
        Options.AddOptions(
            "extensions",
            name,
            new GmExtensionConfigSet {
                ResourceType = "GMExtensionConfigSet",
                Configurables = null,
                ResourceVersion = "1.0",
            }
        );

        foreach (var file in extension.Files)
            ExpectedPhysicalFiles.Add($"extensions/{name}/{file.Filename.Content}", file.Filename.Content);

        IEnumerable<GmExtensionFile> MakeExtensionFiles() {
            foreach (var file in extension.Files)
                yield return MakeExtensionFile(file);
        }

        GmExtensionFile MakeExtensionFile(UndertaleExtensionFile file) {
            return new GmExtensionFile {
                ResourceType = "GMExtensionFile",
                ResourceVersion = "1.0",
                Name = file.Filename.Content,
                Constants = new List<GmExtensionConstant>(), // TODO
                CopyToTargets = -1,
                FileName = file.Filename.Content,
                Final = "", // TODO
                Functions = file.Functions.Select(MakeExtensionFunction).ToList(),
                Init = "", // TODO
                Kind = (int)file.Kind,
                Order = new List<ResourceLinkTarget>(), // TODO
                OrigName = "", // TODO
                ProxyFiles = new List<GmProxyFile>(),
                Uncompress = false,
                UsesRunnerInterface = false,
            };
        }

        GmExtensionFunction MakeExtensionFunction(UndertaleExtensionFunction function) {
            return new GmExtensionFunction {
                ResourceType = "GMExtensionFunction",
                ResourceVersion = "1.0",
                Name = function.Name.Content,
                ArgCount = 0, // TODO: always 0?
                Args = function.Arguments.Select(x => (int)x.Type).ToList(),
                Documentation = "",
                ExternalName = function.ExtName.Content,
                Help = "",
                Hidden = false,
                Kind = (int)function.Kind,
                ReturnType = (int)function.RetType,
            };
        }

        Extensions.Add(new GmExtension {
            ResourceType = "GMExtension",
            ResourceVersion = "1.2",
            Name = name,
            AndroidActivityInject = "",
            AndroidClassName = "",
            AndroidCodeInjection = "",
            AndroidInject = "",
            AndroidManifestInject = "",
            AndroidPermissions = new List<string>(),
            AndroidProps = false,
            AndroidSourceDir = "",
            Author = "",
            Classname = "",
            CopyToTargets = 64,
            Date = DateTime.Now,
            Description = "",
            ExportToGame = true,
            ExtensionVersion = "0.0.0",
            Files = MakeExtensionFiles().ToList(),
            GradleInject = "",
            HasConvertedCodeInjection = true,
            HelpFile = "",
            Html5CodeInjection = "",
            Html5Props = false,
            IncludedResources = new List<string>(),
            InstallDir = "",
            IosCocoaPodDependencies = "",
            IosCocoaPods = "",
            IosCodeInjection = "",
            IosDelegateName = "",
            IosPListInject = "",
            IosProps = false,
            IosSystemFrameworkEntries = new List<GmExtensionFrameworkEntry>(),
            IosThirdPartyFrameworkEntries = new List<GmExtensionFrameworkEntry>(),
            License = "",
            MacCompilerFlags = "",
            MacLinkerFlags = "",
            // MacSourceDir = "",
            Options = new List<GmExtensionOption>(), // TODO: options support
            OptionsFile = "options.json",
            PackageId = "",
            Parent = new ResourceLinkTarget {
                Name = "Extensions",
                Path = "folders/Extensions.yy",
            },
            ProductId = "",
            SourceDir = "",
            SupportedTargets = -1,
            TvOsClassName = null,
            TvosCocoaPodDependencies = "",
            TvosCocoaPods = "",
            TvOsCodeInjection = "",
            TvOsDelegateName = null,
            TvOsMacCompilerFlags = "",
            TvOsMacLinkerFlags = "",
            TvOsPListInject = "",
            TvosProps = false,
            TvOsSystemFrameworkEntries = new List<GmExtensionFrameworkEntry>(),
            TvOsThirdPartyFrameworkEntries = new List<GmExtensionFrameworkEntry>(),
        });
    }
}

public static class GameMakerProjectExtensions {
    public static void ImportGame(this GameMakerProject project, string gameDirectory) {
        // todo: yes I know this is hardcoded for windows womp womp
        var dataPath = Path.Combine(gameDirectory, "data.win");
        var data = UndertaleIO.Read(File.OpenRead(dataPath));

        project.ImportExtensionsFromGame(data);
    }

    public static void ImportExtensionsFromGame(this GameMakerProject project, UndertaleData data) {
        foreach (var extension in data.Extensions)
            project.ImportExtension(extension);
    }
}
