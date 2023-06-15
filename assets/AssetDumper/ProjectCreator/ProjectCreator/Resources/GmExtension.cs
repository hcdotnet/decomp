using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmExtension : ResourceBase {
    [JsonProperty("optionsFile")]
    public string OptionsFile { get; set; }

    [JsonProperty("options")]
    public List<GmExtensionOption> Options { get; set; }

    [JsonProperty("exportToGame")]
    public bool ExportToGame { get; set; }

    [JsonProperty("supportedTargets")]
    public long SupportedTargets { get; set; }

    [JsonProperty("extensionVersion")]
    public string ExtensionVersion { get; set; }

    [JsonProperty("packageId")]
    public string PackageId { get; set; }

    [JsonProperty("productId")]
    public string ProductId { get; set; }

    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("license")]
    public string License { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("helpfile")]
    public string HelpFile { get; set; }

    [JsonProperty("iosProps")]
    public bool IosProps { get; set; }

    [JsonProperty("tvosProps")]
    public bool TvosProps { get; set; }

    [JsonProperty("androidProps")]
    public bool AndroidProps { get; set; }

    [JsonProperty("html5Props")]
    public bool Html5Props { get; set; }

    [JsonProperty("installdir")]
    public string InstallDir { get; set; }

    [JsonProperty("files")]
    public List<GmExtensionFile> Files { get; set; }

    [JsonProperty("HTML5CodeInjection")]
    public string Html5CodeInjection { get; set; }

    [JsonProperty("classname")]
    public string Classname { get; set; }

    [JsonProperty("tvosclassname")]
    public string? TvOsClassName { get; set; }

    [JsonProperty("tvosdelegatename")]
    public string? TvOsDelegateName { get; set; }

    [JsonProperty("iosdelegatename")]
    public string IosDelegateName { get; set; }

    [JsonProperty("androidclassname")]
    public string AndroidClassName { get; set; }

    [JsonProperty("sourcedir")]
    public string SourceDir { get; set; }

    [JsonProperty("androidsourcedir")]
    public string AndroidSourceDir { get; set; }

    [JsonProperty("maccompilerflags")]
    public string MacCompilerFlags { get; set; }

    [JsonProperty("tvosmaccompilerflags")]
    public string TvOsMacCompilerFlags { get; set; }

    [JsonProperty("maclinkerflags")]
    public string MacLinkerFlags { get; set; }

    [JsonProperty("tvosmaclinkerflags")]
    public string TvOsMacLinkerFlags { get; set; }

    [JsonProperty("iosplistinject")]
    public string IosPListInject { get; set; }

    [JsonProperty("tvosplistinject")]
    public string TvOsPListInject { get; set; }

    [JsonProperty("androidinject")]
    public string AndroidInject { get; set; }

    [JsonProperty("androidmanifestinject")]
    public string AndroidManifestInject { get; set; }

    [JsonProperty("androidactivityinject")]
    public string AndroidActivityInject { get; set; }

    [JsonProperty("gradleinject")]
    public string GradleInject { get; set; }

    [JsonProperty("androidcodeinjection")]
    public string AndroidCodeInjection { get; set; }

    [JsonProperty("hasConvertedCodeInjection")]
    public bool HasConvertedCodeInjection { get; set; }

    [JsonProperty("ioscodeinjection")]
    public string IosCodeInjection { get; set; }

    [JsonProperty("tvoscodeinjection")]
    public string TvOsCodeInjection { get; set; }

    [JsonProperty("iosSystemFrameworkEntries")]
    public List<GmExtensionFrameworkEntry> IosSystemFrameworkEntries { get; set; }

    [JsonProperty("tvosSystemFrameworkEntries")]
    public List<GmExtensionFrameworkEntry> TvOsSystemFrameworkEntries { get; set; }

    [JsonProperty("iosThirdPartyFrameworkEntries")]
    public List<GmExtensionFrameworkEntry> IosThirdPartyFrameworkEntries { get; set; }

    [JsonProperty("tvosThirdPartyFrameworkEntries")]
    public List<GmExtensionFrameworkEntry> TvOsThirdPartyFrameworkEntries { get; set; }

    [JsonProperty("IncludedResources")]
    public List<string> IncludedResources { get; set; }

    [JsonProperty("androidPermissions")]
    public List<string> AndroidPermissions { get; set; }

    [JsonProperty("copyToTargets")]
    public long CopyToTargets { get; set; }

    [JsonProperty("iosCocoaPods")]
    public string IosCocoaPods { get; set; }

    [JsonProperty("tvosCocoaPods")]
    public string TvosCocoaPods { get; set; }

    [JsonProperty("iosCocoaPodDependencies")]
    public string IosCocoaPodDependencies { get; set; }

    [JsonProperty("tvosCocoaPodDependencies")]
    public string TvosCocoaPodDependencies { get; set; }
}
