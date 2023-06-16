using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ProjectCreator.ProjectCreator.Resources;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace ProjectCreator.ProjectCreator;

partial class GameMakerProject {
    public void ImportAudioGroup(UndertaleAudioGroup audioGroup) {
        if (Project.AudioGroups.Any(x => x.Name == audioGroup.Name.Content)) {
            Console.WriteLine($"Warning: Audio group {audioGroup.Name.Content} already exists.");
            return;
        }

        Project.AudioGroups.Add(new GmAudioGroup {
            ResourceType = "GMAudioGroup",
            ResourceVersion = "1.3",
            Name = audioGroup.Name.Content,
            Targets = TargetPlatforms.AllPlatforms,
        });
    }

    public void ImportSound(UndertaleSound sound) {
        var name = sound.Name.Content;

        var resourceLink = new ResourceLinkTarget {
            Name = name,
            Path = $"sounds/{name}/{name}.yy",
        };
        var resourceWeight = new GmProject.ResourceWeight {
            Id = resourceLink,
        };
        Project.Resources.Add(resourceWeight);

        // TODO: is this correct??
        /*GmSoundCompression AudioEntryFlagsToGmSoundCompression(UndertaleSound.AudioEntryFlags flags) {
            return flags switch {
                UndertaleSound.AudioEntryFlags.IsEmbedded => GmSoundCompression.Uncompressed,
                UndertaleSound.AudioEntryFlags.IsCompressed => GmSoundCompression.Compressed,
                UndertaleSound.AudioEntryFlags.IsDecompressedOnLoad => GmSoundCompression.DecompressOnLoad,
                UndertaleSound.AudioEntryFlags.Regular => GmSoundCompression.CompressedAndStreamed,
                _ => throw new ArgumentOutOfRangeException(nameof(flags), flags, null),
            };
        }*/

        ExpectedVirtualFiles.Add(new VirtualFile($"audiogroup{sound.GroupID}.dat", $"{sound.AudioID} {name}", $"sounds/{name}/{sound.File.Content}", VirtualFileType.Sound));

        // TODO: unused values to pitch from UndertaleSound as well
        Sounds.Add(new GmSound {
            ResourceType = "GMSound",
            ResourceVersion = "1.0",
            Name = name,
            AudioGroupId = new ResourceLinkTarget {
                Name = sound.AudioGroup.Name.Content,
                Path = $"audiogroups/{sound.AudioGroup.Name.Content}",
            },
            BitDepth = (GmSoundBitDepth)1, // TODO
            BitRate = 128, // TODO
            Compression = 0, // TODO
            ConversionMode = 0, // TODO
            Duration = 0,
            Parent = new ResourceLinkTarget {
                Name = "Sounds",
                Path = "folders/Sounds.yy",
            },
            Preload = false,
            SampleRate = 44100,
            SoundFile = sound.File.Content,
            Type = 0, // TODO
            Volume = sound.Volume,
        });
    }

    public void ImportSprite(UndertaleSprite sprite, UndertaleData data) {
        // TODO: handle collision mask**s**? not just SpriteColKind
        var name = sprite.Name.Content;

        var resourceLink = new ResourceLinkTarget {
            Name = name,
            Path = $"sprites/{name}/{name}.yy",
        };
        var resourceWeight = new GmProject.ResourceWeight {
            Id = resourceLink,
        };
        Project.Resources.Add(resourceWeight);

        // TODO: probably very inaccurate
        SpriteColKind FromSepMaskType(UndertaleSprite.SepMaskType type) {
            return type switch {
                UndertaleSprite.SepMaskType.AxisAlignedRect => SpriteColKind.Rectangle,
                UndertaleSprite.SepMaskType.Precise => SpriteColKind.Precise,
                UndertaleSprite.SepMaskType.RotatedRect => SpriteColKind.RectangleRotation,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
            };
        }

        /* individual frames have images in sprites/Name/
         * random guid name
         * sprites/Name/layers/ directory with frame names are directories
         * png files with guid names, match the layer name
         *
         * └── sprites
         *     └── Name
         *         ├── layers
         *         │   ├── 8221a785-02bc-4e2e-b2f7-f6a1226094c1 (frame 1)
         *         │   │   └── 3253c7fc-4556-46ac-9269-c96d8108a47b.png (layer 1)
         *         │   ├── b96ef1e2-a3a1-4fec-a82e-56292c011c69 (frame 2)
         *         │   │   └── 3253c7fc-4556-46ac-9269-c96d8108a47b.png (layer 1)
         *         ├── 8221a785-02bc-4e2e-b2f7-f6a1226094c1.png (frame 1)
         *         ├── b96ef1e2-a3a1-4fec-a82e-56292c011c69.png (frame 2)
         *         └── Name.yy
         */

        Guid MakeFrameGuid(string spriteName, string textureName) {
            return MakeGuidFromStringHash($"{spriteName} Frame {textureName}");
        }

        Guid MakeLayerGuid(string spriteName, int layerIndex) {
            return MakeGuidFromStringHash($"{spriteName} Layer {layerIndex}");
        }

        Guid MakeKeyframeGuid(string spriteName, string textureName) {
            return MakeGuidFromStringHash($"{spriteName} Keyframe {textureName}");
        }

        // assuming only 1 layer
        var layerGuid = MakeLayerGuid(name, 1);
        var basePath = $"sprites/{name}/";

        for (var i = 0; i < sprite.Textures.Count; i++) {
            var texture = sprite.Textures[i];
            var frameGuid = MakeFrameGuid(name, texture.Texture.Name.Content);
            ExpectedVirtualFiles.Add(new VirtualFile("data.win", $"{i} {name}", basePath + frameGuid + ".png", VirtualFileType.Sprite));

            var layerPath = basePath + "layers/" + frameGuid + "/" + layerGuid + ".png";
            ExpectedVirtualFiles.Add(new VirtualFile("data.win", $"{i} {name}", layerPath, VirtualFileType.Sprite));
        }

        GmSpriteFrame MakeFrame(UndertaleSprite.TextureEntry entry) {
            // 8221a785-02bc-4e2e-b2f7-f6a1226094c1
            // b96ef1e2-a3a1-4fec-a82e-56292c011c69
            return new GmSpriteFrame {
                ResourceType = "GMSpriteFrame",
                ResourceVersion = "1.1",
                Name = MakeFrameGuid(sprite.Name.Content, entry.Texture.Name.Content).ToString(),
            };
        }

        Keyframe<SpriteFrameKeyframe> MakeKeyframe(UndertaleSprite.TextureEntry texture) {
            return new Keyframe<SpriteFrameKeyframe> {
                ResourceType = "Keyframe<SpriteFrameKeyframe>",
                ResourceVersion = "1.0",
                Channels = new Dictionary<int, SpriteFrameKeyframe> {
                    // TODO: ever more than 0?
                    {
                        0, new SpriteFrameKeyframe {
                            ResourceType = "SpriteFrameKeyframe",
                            ResourceVersion = "1.0",
                            Id = new ResourceLinkTarget {
                                Name = MakeFrameGuid(name!, texture.Texture.Name.Content).ToString(),
                                Path = $"sprites/{name}/{name}.yy",
                            },
                        }
                    },
                },
                Disabled = false, // TODO
                Id = MakeKeyframeGuid(name!, texture.Texture.Name.Content),
                IsCreationKey = false, // TODO
                Key = 0, // TODO
                Length = 1, // TODO
                Stretch = false, // TODO
            };
        }

        /*
            // 1
            new Keyframe<SpriteFrameKeyframe> {
                ResourceType = "Keyframe<SpriteFrameKeyframe>",
                ResourceVersion = "1.0",
                Channels = new Dictionary<int, SpriteFrameKeyframe> {
                    {
                        0, new SpriteFrameKeyframe {
                            ResourceType = "SpriteFrameKeyframe",
                            ResourceVersion = "1.0",
                            Id = {
                                Name = "8221a785-02bc-4e2e-b2f7-f6a1226094c1", // sprite name guid
                                Path = "sprites/TestSprite2/TestSprite2.yy",
                            },
                        }
                    },
                },
                Disabled = false, // TODO
                Id = "05cfaffb-68cf-4aa4-9831-69d28c986f30", // doesn't matter
                IsCreationKey = false, // TODO
                Key = 0, // TODO
                Length = 1, // TODO
                Stretch = false, // TODO
            },
            // 2
            new Keyframe<SpriteFrameKeyframe> {
                ResourceType = "Keyframe<SpriteFrameKeyframe>",
                ResourceVersion = "1.0",
                Channels = new Dictionary<int, SpriteFrameKeyframe> {
                    {
                        0, new SpriteFrameKeyframe {
                            ResourceType = "SpriteFrameKeyframe",
                            ResourceVersion = "1.0",
                            Id = {
                                Name = "b96ef1e2-a3a1-4fec-a82e-56292c011c69", // sprite name guid
                                Path = "sprites/TestSprite2/TestSprite2.yy",
                            },
                        }
                    },
                },
                Disabled = false, // TODO
                Id = "84c5c8a6-83ec-47c2-b4a5-8540591e03dc", // doesn't matter
                IsCreationKey = false, // TODO
                Key = 0, // TODO
                Length = 1, // TODO
                Stretch = false, // TODO
            },
         */

        var tgi = data.TextureGroupInfo.First(x => x.Sprites.Any(x => x.Resource.Name.Content == name));

        Sprites.Add(new GmSprite {
            ResourceType = "GMSprite",
            ResourceVersion = "1.0",
            Name = name,
            BboxBottom = sprite.MarginBottom,
            BboxLeft = sprite.MarginLeft,
            BboxRight = sprite.MarginRight,
            BboxTop = sprite.MarginTop,
            BboxMode = (BboxMode)sprite.BBoxMode,
            CollisionKind = FromSepMaskType(sprite.SepMasks),
            CollisionTolerance = 0, // TODO: what
            DynamicTexturePage = false,
            EdgeFiltering = sprite.Smooth,
            For3D = false,
            Frames = sprite.Textures.Select(MakeFrame).ToList(), // TODO: does this work
            GridX = 0, // TODO
            GridY = 0, // TODO
            Height = (int)sprite.Height,
            HTile = false, // TODO
            Layers = new List<GmImageLayer> {
                new()  {
                    ResourceType = "GMImageLayer",
                    ResourceVersion = "1.0",
                    Name = MakeLayerGuid(name, 1).ToString(), // 3253c7fc-4556-46ac-9269-c96d8108a47b
                    BlendMode = 0, // TODO
                    DisplayName = "default",
                    IsLocked = false,
                    Opacity = 100, // TODO
                    Visible = true, // TODO
                },
            }, // TODO: good enough?
            NineSlice = null, // TODO
            Origin = 0, // TODO: how do these translate into OriginX/OriginY?
            Parent = new ResourceLinkTarget {
                Name = "Sprites",
                Path = "folders/Sprites.yy",
            },
            PreMultiplyAlpha = false, // TODO
            Sequence = new GmSequence {
                ResourceType = "GMSequence",
                ResourceVersion = "1.4",
                Name = name,
                AutoRecord = true, // TODO
                BackdropHeight = (int)sprite.Height, // TODO
                BackdropImageOpacity = 0.5f, // TODO
                BackdropImagePath = "", // TODO
                BackdropWidth = (int)sprite.Width, // TODO
                BackdropXOffset = 0f, // TODO
                BackdropYOffset = 0f, // TODO
                Events = new KeyframeStore<MessageEventKeyframe> {
                    // TODO
                    ResourceType = "KeyframeStore<MessageEventKeyframe>",
                    ResourceVersion = "1.0",
                    Keyframes = new List<Keyframe<MessageEventKeyframe>>(),
                },
                EventStubScript = null, // TODO
                EventToFunction = new Dictionary<int, string>(), // TODO
                Length = 2, // TODO
                LockOrigin = false, // TODO
                Moments = new KeyframeStore<MomentsEventKeyframe> {
                    // TODO
                    ResourceType = "KeyframeStore<MomentsEventKeyframe>",
                    ResourceVersion = "1.0",
                    Keyframes = new List<Keyframe<MomentsEventKeyframe>>(),
                },
                Playback = SequencePlayback.Normal, // TODO: don't know where this is stored in data files
                PlaybackSpeed = sprite.GMS2PlaybackSpeed,
                PlaybackSpeedType = (Resources.AnimSpeedType)sprite.GMS2PlaybackSpeedType,
                ShowBackdrop = true, // TODO
                ShowBackdropImage = false, // TODO
                TimeUnits = SequenceTimeUnits.Frames, // TODO: where in data file
                Tracks = new List<GmBaseTrack> {
                    new GmSpriteFramesTrack {
                        ResourceType = "GMSpriteFramesTrack",
                        ResourceVersion = "1.0",
                        Name = "frames",
                        BuiltinName = 0,
                        Events = new List<GmEvent>(), // TODO
                        InheritsTrackColor = true, // TODO
                        Interpolation = InterpolationMode.Linear, // TODO
                        IsCreationTrack = false, // TODO
                        Keyframes = new KeyframeStore<SpriteFrameKeyframe> {
                            ResourceType = "KeyframeStore<SpriteFrameKeyframe>",
                            ResourceVersion = "1.0",
                            Keyframes = sprite.Textures.Select(MakeKeyframe).ToList(), // TODO: review
                        },
                        Modifiers = new List<object>(), // TODO
                        SpriteId = null, // TODO
                        TrackColor = 0, // TODO
                        Tracks = new List<GmBaseTrack>(), // TODO
                        Traits = 0, // TODO
                    },
                },
                VisibleRange = null, // TODO
                XOrigin = sprite.OriginX, // TODO: correct?
                YOrigin = sprite.OriginY, // TODO: correct?
            }, // TODO
            SwatchColors = null, // TODO
            SwfPrecision = (float)2.525, // TODO
            TextureGroupId = new ResourceLinkTarget {
                Name = tgi.Name.Content,
                Path = $"texturegroups/{tgi.Name.Content}",
            },
            Type = 0, // TODO
            VTile = false, // TODO
            Width = (int)sprite.Width,
        });
    }

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
            ExpectedPhysicalFiles.Add(new PhysicalFile(file.Filename.Content, $"extensions/{name}/{file.Filename.Content}"));

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

    public void ImportTextureGroup(UndertaleTextureGroupInfo textureGroupInfo) {
        var name = textureGroupInfo.Name.Content;

        // TODO: bother dumping associated pages, sprites, spine sprites, fonts,
        // and tilesets? or should their associated importers handle it?
        Project.TextureGroups.Add(new GmTextureGroup {
            ResourceType = "GMTextureGroup",
            ResourceVersion = "1.3",
            Name = name,
            AutoCrop = true, // TODO
            Border = 2, // TODO
            CompressFormat = "bz2", // TODO
            Directory = "", // TODO
            GroupParent = null,
            IsScaled = true, // TODO
            LoadType = "default", // TODO
            MipsToGenerate = 0, // TODO,
            Targets = TargetPlatforms.AllPlatforms,
        });
    }

    // so we can generate guids consistently yawn
    private static Guid MakeGuidFromStringHash(string value) {
        var hash = MD5.HashData(Encoding.UTF8.GetBytes(value));
        return new Guid(hash);
    }
}

public static class GameMakerProjectExtensions {
    public static void ImportGame(this GameMakerProject project, string gameDirectory) {
        // todo: yes I know this is hardcoded for windows womp womp
        var dataPath = Path.Combine(gameDirectory, "data.win");
        var data = UndertaleIO.Read(File.OpenRead(dataPath));

        project.ImportAudioGroupsFromGame(data);
        project.ImportSoundsFromGame(data);
        project.ImportSpritesFromGame(data);
        project.ImportExtensionsFromGame(data);
        project.ImportTextureGroupsFromGame(data);
    }

    public static void ImportAudioGroupsFromGame(this GameMakerProject project, UndertaleData data) {
        foreach (var audioGroup in data.AudioGroups)
            project.ImportAudioGroup(audioGroup);
    }

    public static void ImportSoundsFromGame(this GameMakerProject project, UndertaleData data) {
        foreach (var sound in data.Sounds)
            project.ImportSound(sound);
    }

    public static void ImportSpritesFromGame(this GameMakerProject project, UndertaleData data) {
        foreach (var sprite in data.Sprites)
            project.ImportSprite(sprite, data);
    }

    public static void ImportExtensionsFromGame(this GameMakerProject project, UndertaleData data) {
        foreach (var extension in data.Extensions)
            project.ImportExtension(extension);
    }

    public static void ImportTextureGroupsFromGame(this GameMakerProject project, UndertaleData data) {
        foreach (var textureGroupInfo in data.TextureGroupInfo)
            project.ImportTextureGroup(textureGroupInfo);
    }
}
