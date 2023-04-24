using System.Collections.ObjectModel;

namespace MauiApp1.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    public AllNotes() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        string appDataPath = FileSystem.AppDataDirectory;

        IEnumerable<Note> notes = Directory
            .EnumerateFiles(appDataPath, "*.notes.txt")
            .Select(fileName => new Note()
            {
                Filename = fileName,
                Text = File.ReadAllText(fileName),
                Date = File.GetCreationTime(fileName)
            })
            .OrderBy(note => note.Date);

        foreach(Note note in notes)
        {
            Notes.Add(note);
        }

    }


}
