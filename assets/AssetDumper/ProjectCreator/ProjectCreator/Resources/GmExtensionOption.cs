using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjectCreator.ProjectCreator.Resources;

public sealed class GmExtensionOption : ResourceBase {
    [JsonProperty("extensionId")]
    public ResourceLinkTarget ExtensionId { get; set; }

    [JsonProperty("guid")]
    public Guid Guid { get; set; }

    [JsonProperty("displayName")]
    public string DisplayName { get; set; }

    [JsonProperty("listItems")]
    public List<string> ListItems { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("defaultValue")]
    public string DefaultValue { get; set; }

    [JsonProperty("ExportToINI")]
    public bool ExportToIni { get; set; }

    [JsonProperty("hidden")]
    public bool Hidden { get; set; }

    [JsonProperty("optType")]
    public ExtensionOptionType OptType { get; set; }
}
