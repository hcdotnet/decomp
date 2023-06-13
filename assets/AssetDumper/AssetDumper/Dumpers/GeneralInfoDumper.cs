using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UndertaleModLib;
using UndertaleModLib.Models;

namespace AssetDumper.Dumpers;

public class GeneralInfoVersion {
    public uint Major { get; set; }

    public uint Minor { get; set; }

    public uint Release { get; set; }

    public uint Build { get; set; }
}

public class GeneralInfoWindowSize {
    public uint WindowWidth { get; set; }

    public uint WindowHeight { get; set; }
}

public class GeneralInfoFlags {
    public UndertaleGeneralInfo.InfoFlags Flags { get; init; }

    public bool Fullscreen { get; init; }

    public bool SyncVertex1 { get; init; }

    public bool SyncVertex2 { get; init; }

    public bool Interpolate { get; init; }

    public bool Scale { get; init; }

    public bool ShowCursor { get; init; }

    public bool Sizeable { get; init; }

    public bool ScreenKey { get; init; }

    public bool SyncVertex3 { get; init; }

    public bool StudioVersionB1 { get; init; }

    public bool StudioVersionB2 { get; init; }

    public bool StudioVersionB3 { get; init; }

    public bool SteamEnabled { get; init; }

    public bool LocalDataEnabled { get; init; }

    public bool BorderlessWindow { get; init; }

    public bool JavaScriptMode { get; init; }

    public bool LicenseExclusions { get; init; }

    public static GeneralInfoFlags FromGameMakerObject(UndertaleGeneralInfo.InfoFlags flags) {
        return new GeneralInfoFlags {
            Flags = flags,
            Fullscreen = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.Fullscreen),
            SyncVertex1 = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.SyncVertex1),
            SyncVertex2 = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.SyncVertex2),
            Interpolate = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.Interpolate),
            Scale = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.Scale),
            ShowCursor = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.ShowCursor),
            Sizeable = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.Sizeable),
            ScreenKey = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.ScreenKey),
            SyncVertex3 = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.SyncVertex3),
            StudioVersionB1 = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.StudioVersionB1),
            StudioVersionB2 = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.StudioVersionB2),
            StudioVersionB3 = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.StudioVersionB3),
            SteamEnabled = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.SteamEnabled),
            LocalDataEnabled = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.LocalDataEnabled),
            BorderlessWindow = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.BorderlessWindow),
            JavaScriptMode = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.JavaScriptMode),
            LicenseExclusions = flags.HasFlag(UndertaleGeneralInfo.InfoFlags.LicenseExclusions),
        };
    }
}

public class GeneralInfoFunctionClassifications {
    public UndertaleGeneralInfo.FunctionClassification Flags { get; init; }

    public bool None { get; init; }

    public bool Internet { get; init; }

    public bool Joystick { get; init; }

    public bool Gamepad { get; init; }

    public bool Immersion { get; init; }

    public bool Screengrab { get; init; }

    public bool Math { get; init; }

    public bool Action { get; init; }

    public bool MatrixD3D { get; init; }

    public bool D3DModel { get; init; }

    public bool DataStructures { get; init; }

    public bool File { get; init; }

    public bool Ini { get; init; }

    public bool Filename { get; init; }

    public bool Directory { get; init; }

    public bool Environment { get; init; }

    public bool Unused1 { get; init; }

    public bool Http { get; init; }

    public bool Encoding { get; init; }

    public bool UiDialog { get; init; }

    public bool MotionPlanning { get; init; }

    public bool ShapeCollision { get; init; }

    public bool Instance { get; init; }

    public bool Room { get; init; }

    public bool Game { get; init; }

    public bool Display { get; init; }

    public bool Device { get; init; }

    public bool Window { get; init; }

    public bool DrawColor { get; init; }

    public bool Texture { get; init; }

    public bool Layer { get; init; }

    public bool String { get; init; }

    public bool Tiles { get; init; }

    public bool Surface { get; init; }

    public bool Skeleton { get; init; }

    public bool Io { get; init; }

    public bool Variables { get; init; }

    public bool Array { get; init; }

    public bool ExternalCall { get; init; }

    public bool Notification { get; init; }

    public bool Date { get; init; }

    public bool Particle { get; init; }

    public bool Sprite { get; init; }

    public bool Clickable { get; init; }

    public bool LegacySound { get; init; }

    public bool Audio { get; init; }

    public bool Event { get; init; }

    public bool Unused2 { get; init; }

    public bool FreeType { get; init; }

    public bool Analytics { get; init; }

    public bool Unused3 { get; init; }

    public bool Unused4 { get; init; }

    public bool Achievement { get; init; }

    public bool CloudSaving { get; init; }

    public bool Ads { get; init; }

    public bool Os { get; init; }

    public bool Iap { get; init; }

    public bool Facebook { get; init; }

    public bool Physics { get; init; }

    public bool FlashAa { get; init; }

    public bool Console { get; init; }

    public bool Buffer { get; init; }

    public bool Steam { get; init; }

    public bool Unused5 { get; init; }

    public bool Shaders { get; init; }

    public bool VertexBuffers { get; init; }

    public static GeneralInfoFunctionClassifications FromGameMakerObject(UndertaleGeneralInfo.FunctionClassification flags) {
        return new GeneralInfoFunctionClassifications {
            Flags = flags,
            None = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.None),
            Internet = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Internet),
            Joystick = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Joystick),
            Gamepad = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Gamepad),
            Immersion = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Immersion),
            Screengrab = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Screengrab),
            Math = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Math),
            Action = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Action),
            MatrixD3D = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.MatrixD3D),
            D3DModel = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.D3DModel),
            DataStructures = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.DataStructures),
            File = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.File),
            Ini = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.INI),
            Filename = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Filename),
            Directory = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Directory),
            Environment = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Environment),
            Unused1 = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.UNUSED1),
            Http = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.HTTP),
            Encoding = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Encoding),
            UiDialog = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.UIDialog),
            MotionPlanning = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.MotionPlanning),
            ShapeCollision = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.ShapeCollision),
            Instance = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Instance),
            Room = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Room),
            Game = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Game),
            Display = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Display),
            Device = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Device),
            Window = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Window),
            DrawColor = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.DrawColor),
            Texture = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Texture),
            Layer = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Layer),
            String = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.String),
            Tiles = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Tiles),
            Surface = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Surface),
            Skeleton = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Skeleton),
            Io = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.IO),
            Variables = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Variables),
            Array = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Array),
            ExternalCall = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.ExternalCall),
            Notification = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Notification),
            Date = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Date),
            Particle = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Particle),
            Sprite = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Sprite),
            Clickable = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Clickable),
            LegacySound = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.LegacySound),
            Audio = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Audio),
            Event = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Event),
            Unused2 = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.UNUSED2),
            FreeType = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.FreeType),
            Analytics = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Analytics),
            Unused3 = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.UNUSED3),
            Unused4 = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.UNUSED4),
            Achievement = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Achievement),
            CloudSaving = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.CloudSaving),
            Ads = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Ads),
            Os = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.OS),
            Iap = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.IAP),
            Facebook = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Facebook),
            Physics = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Physics),
            FlashAa = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.FlashAA),
            Console = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Console),
            Buffer = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Buffer),
            Steam = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Steam),
            Unused5 = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.UNUSED5),
            Shaders = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.Shaders),
            VertexBuffers = flags.HasFlag(UndertaleGeneralInfo.FunctionClassification.VertexBuffers),
        };
    }
}

public class GeneralInfoOptions {
    public uint Unknown1 { get; init; }

    public uint Unknown2 { get; init; }

    public GeneralInfoOptionsFlags Info { get; init; }

    public int Scale { get; init; }

    public uint WindowColor { get; init; }

    public uint ColorDepth { get; init; }

    public uint Resolution { get; init; }

    public uint Frequency { get; init; } = 0;

    public uint VertexSync { get; init; } = 0;

    public uint Priority { get; init; } = 0;

    public bool HasBackImage { get; init; }

    public bool HasFrontImage { get; init; }

    public bool HasLoadImage { get; init; }

    public uint LoadAlpha { get; init; }

    public Dictionary<string, string> Constants { get; init; }

    public bool NewFormat { get; init; }

    public static GeneralInfoOptions FromGameMakerObject(UndertaleOptions options) {
        return new GeneralInfoOptions {
            Unknown1 = options.Unknown1,
            Unknown2 = options.Unknown2,
            Info = GeneralInfoOptionsFlags.FromGameMakerObject(options.Info),
            Scale = options.Scale,
            WindowColor = options.WindowColor,
            ColorDepth = options.ColorDepth,
            Resolution = options.Resolution,
            Frequency = options.Frequency,
            VertexSync = options.VertexSync,
            Priority = options.Priority,
            HasBackImage = options.BackImage.Texture is not null,
            HasFrontImage = options.FrontImage.Texture is not null,
            HasLoadImage = options.LoadImage.Texture is not null,
            LoadAlpha = options.LoadAlpha,
            Constants = options.Constants.ToDictionary(x => x.Name.Content, x => x.Value.Content),
            NewFormat = options.NewFormat,
        };
    }
}

public class GeneralInfoOptionsFlags {
    public UndertaleOptions.OptionsFlags Flags { get; init; }

    public bool FullScreen { get; init; }

    public bool InterpolatePixels { get; init; }

    public bool UseNewAudio { get; init; }

    public bool NoBorder { get; init; }

    public bool ShowCursor { get; init; }

    public bool Sizeable { get; init; }

    public bool StayOnTop { get; init; }

    public bool ChangeResolution { get; init; }

    public bool NoButtons { get; init; }

    public bool ScreenKey { get; init; }

    public bool HelpKey { get; init; }

    public bool QuitKey { get; init; }

    public bool SaveKey { get; init; }

    public bool ScreenShotKey { get; init; }

    public bool CloseSec { get; init; }

    public bool Freeze { get; init; }

    public bool ShowProgress { get; init; }

    public bool LoadTransparent { get; init; }

    public bool ScaleProgress { get; init; }

    public bool DisplayErrors { get; init; }

    public bool WriteErrors { get; init; }

    public bool AbortErrors { get; init; }

    public bool VariableErrors { get; init; }

    public bool CreationEventOrder { get; init; }

    public bool UseFrontTouch { get; init; }

    public bool UseRearTouch { get; init; }

    public bool UseFastCollision { get; init; }

    public bool FastCollisionCompatibility { get; init; }

    public bool DisableSandbox { get; init; }

    public static GeneralInfoOptionsFlags FromGameMakerObject(UndertaleOptions.OptionsFlags flags) {
        return new GeneralInfoOptionsFlags {
            Flags = flags,
            FullScreen = flags.HasFlag(UndertaleOptions.OptionsFlags.FullScreen),
            InterpolatePixels = flags.HasFlag(UndertaleOptions.OptionsFlags.InterpolatePixels),
            UseNewAudio = flags.HasFlag(UndertaleOptions.OptionsFlags.UseNewAudio),
            NoBorder = flags.HasFlag(UndertaleOptions.OptionsFlags.NoBorder),
            ShowCursor = flags.HasFlag(UndertaleOptions.OptionsFlags.ShowCursor),
            Sizeable = flags.HasFlag(UndertaleOptions.OptionsFlags.Sizeable),
            StayOnTop = flags.HasFlag(UndertaleOptions.OptionsFlags.StayOnTop),
            ChangeResolution = flags.HasFlag(UndertaleOptions.OptionsFlags.ChangeResolution),
            NoButtons = flags.HasFlag(UndertaleOptions.OptionsFlags.NoButtons),
            ScreenKey = flags.HasFlag(UndertaleOptions.OptionsFlags.ScreenKey),
            HelpKey = flags.HasFlag(UndertaleOptions.OptionsFlags.HelpKey),
            QuitKey = flags.HasFlag(UndertaleOptions.OptionsFlags.QuitKey),
            SaveKey = flags.HasFlag(UndertaleOptions.OptionsFlags.SaveKey),
            ScreenShotKey = flags.HasFlag(UndertaleOptions.OptionsFlags.ScreenShotKey),
            CloseSec = flags.HasFlag(UndertaleOptions.OptionsFlags.CloseSec),
            Freeze = flags.HasFlag(UndertaleOptions.OptionsFlags.Freeze),
            ShowProgress = flags.HasFlag(UndertaleOptions.OptionsFlags.ShowProgress),
            LoadTransparent = flags.HasFlag(UndertaleOptions.OptionsFlags.LoadTransparent),
            ScaleProgress = flags.HasFlag(UndertaleOptions.OptionsFlags.ScaleProgress),
            DisplayErrors = flags.HasFlag(UndertaleOptions.OptionsFlags.DisplayErrors),
            WriteErrors = flags.HasFlag(UndertaleOptions.OptionsFlags.WriteErrors),
            AbortErrors = flags.HasFlag(UndertaleOptions.OptionsFlags.AbortErrors),
            VariableErrors = flags.HasFlag(UndertaleOptions.OptionsFlags.VariableErrors),
            CreationEventOrder = flags.HasFlag(UndertaleOptions.OptionsFlags.CreationEventOrder),
            UseFrontTouch = flags.HasFlag(UndertaleOptions.OptionsFlags.UseFrontTouch),
            UseRearTouch = flags.HasFlag(UndertaleOptions.OptionsFlags.UseRearTouch),
            UseFastCollision = flags.HasFlag(UndertaleOptions.OptionsFlags.UseFastCollision),
            FastCollisionCompatibility = flags.HasFlag(UndertaleOptions.OptionsFlags.FastCollisionCompatibility),
            DisableSandbox = flags.HasFlag(UndertaleOptions.OptionsFlags.DisableSandbox),
        };
    }
}

public class GeneralInfo {
    public bool IsDebuggerDisabled { get; init; }

    public byte BytecodeVersion { get; init; }

    public ushort Unknown { get; init; }

    public string FileName { get; init; }

    public string Config { get; init; }

    public uint LastObj { get; init; }

    public uint LastTile { get; init; }

    public uint GameID { get; init; }

    public Guid DirectPlayGuid { get; init; }

    public string Name { get; init; }

    public GeneralInfoVersion Version { get; init; }

    public GeneralInfoWindowSize WindowSize { get; init; }

    public GeneralInfoFlags Info { get; init; }

    public byte[] LicenseMd5 { get; init; }

    public uint LicenseCrc32 { get; init; }

    public ulong Timestamp { get; init; }

    public string DisplayName { get; init; }

    public ulong ActiveTargets { get; init; }

    public GeneralInfoFunctionClassifications FunctionClassifications { get; init; }

    public int SteamAppId { get; init; }

    public uint DebuggerPort { get; init; }

    public List<string> RoomOrder { get; init; }

    public List<long> Gms2RandomUid { get; init; }

    public float Gms2Fps { get; init; }

    public bool Gms2AllowStatistics { get; init; }

    public bool InfoTimestampOffset { get; init; }

    public static GeneralInfo FromGameMakerObject(UndertaleGeneralInfo generalInfo) {
        return new GeneralInfo {
            IsDebuggerDisabled = generalInfo.IsDebuggerDisabled,
            BytecodeVersion = generalInfo.BytecodeVersion,
            Unknown = generalInfo.Unknown,
            FileName = generalInfo.FileName.Content,
            Config = generalInfo.Config.Content,
            LastObj = generalInfo.LastObj,
            LastTile = generalInfo.LastTile,
            GameID = generalInfo.GameID,
            DirectPlayGuid = generalInfo.DirectPlayGuid,
            Name = generalInfo.Name.Content,
            Version = new GeneralInfoVersion {
                Major = generalInfo.Major,
                Minor = generalInfo.Minor,
                Release = generalInfo.Release,
                Build = generalInfo.Build,
            },
            WindowSize = new GeneralInfoWindowSize {
                WindowWidth = generalInfo.DefaultWindowWidth,
                WindowHeight = generalInfo.DefaultWindowHeight,
            },
            Info = GeneralInfoFlags.FromGameMakerObject(generalInfo.Info),
            LicenseMd5 = generalInfo.LicenseMD5,
            LicenseCrc32 = generalInfo.LicenseCRC32,
            Timestamp = generalInfo.Timestamp,
            DisplayName = generalInfo.DisplayName.Content,
            ActiveTargets = generalInfo.ActiveTargets,
            FunctionClassifications = GeneralInfoFunctionClassifications.FromGameMakerObject(generalInfo.FunctionClassifications),
            SteamAppId = generalInfo.SteamAppID,
            DebuggerPort = generalInfo.DebuggerPort,
            RoomOrder = generalInfo.RoomOrder.Select(x => x.Resource.Name.Content).ToList(),
            Gms2RandomUid = generalInfo.GMS2RandomUID,
            Gms2Fps = generalInfo.GMS2FPS,
            Gms2AllowStatistics = generalInfo.GMS2AllowStatistics,
            InfoTimestampOffset = generalInfo.InfoTimestampOffset,
        };
    }
}

[Dumper("general_info")]
public sealed class GeneralInfoDumper : IAssetDumper {
    public bool ShouldDump(UndertaleData data) {
        return data.GeneralInfo is not null && data.Options is not null; // should always be true
    }

    public void Dump(UndertaleData data, FileWriter w) {
        w.Create(JsonConvert.SerializeObject(GeneralInfo.FromGameMakerObject(data.GeneralInfo), Formatting.Indented), "general_info.json");
        w.Create(JsonConvert.SerializeObject(GeneralInfoOptions.FromGameMakerObject(data.Options), Formatting.Indented), "options.json");
    }
}
