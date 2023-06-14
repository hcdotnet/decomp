using System;

namespace AssetDumper.Dumpers;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
public sealed class DumperAttribute : Attribute {
    public string Name { get; }

    public bool Large { get; set; } = false;

    public DumperAttribute(string name) {
        Name = name;
    }
}
