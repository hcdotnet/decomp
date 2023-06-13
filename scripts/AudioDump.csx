using System;
using System.IO;
using System.Windows.Forms;

EnsureDataLoaded();

var dialog = new FolderBrowserDialog();
var dialogResult = dialog.ShowDialog();

if (dialogResult != DialogResult.OK)
    throw new Exception();

Directory.CreateDirectory(dialog.SelectedPath);

foreach (var audio in Data.EmbeddedAudio) {
    var savePath = Path.Combine(dialog.SelectedPath, audio.Name.Content + ".wav");
    File.WriteAllBytes(savePath, audio.Data);
}