using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

EnsureDataLoaded();

var dialog = new FolderBrowserDialog();
var dialogResult = dialog.ShowDialog();

if (dialogResult != DialogResult.OK)
    throw new Exception();

Directory.CreateDirectory(dialog.SelectedPath);

void DoDumpOperation<T>(string folderName, Func<IList<T>?> assetList, Func<T, (byte[], string)> dumpAction) {
    var path = Path.Combine(dialog.SelectedPath, folderName);
    Directory.CreateDirectory(path);
    
    var list = assetList();
    if (list is not null) {
        foreach (var item in list) {
            var (data, name) = dumpAction(item);
            File.WriteAllBytes(Path.Combine(path, name), data);
        }
    }
    else {
        File.Create(Path.Combine(path, "_._"));
    }
}

DoDumpOperation("embedded_audio", () => Data.EmbeddedAudio, (audio) => {
    return (audio.Data, audio.Name.Content + ".wav");
});
