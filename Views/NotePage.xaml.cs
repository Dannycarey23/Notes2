namespace Notes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class NotePage : ContentPage
{
	// string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
	public NotePage()
	{
		InitializeComponent();

	string appDataPath = FileSystem.AppDataDirectory;
	string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";
	
	LoadNote(Path.Combine(appDataPath, randomFileName));
	}
	private async void OnSaveButtonClicked(object sender, EventArgs e)
{
	if (BindingContext is Models.Note note && !string.IsNullOrEmpty(note.Filename))
		File.WriteAllText(note.Filename, TextEditor.Text);

    await Shell.Current.GoToAsync("..");
}

private async void DeleteButton_Clicked(object sender, EventArgs e)
{
    if (BindingContext is Models.Note note)
    {
        // Delete the file.
        if (File.Exists(note.Filename))
            File.Delete(note.Filename);
    }

    await Shell.Current.GoToAsync("..");
}

	private void LoadNote(string filename)
	{
		Models.Note noteModel = new Models.Note();
		noteModel.Filename = filename;

		if (File.Exists(filename))
		{
			noteModel.Text = File.ReadAllText(filename);
			noteModel.Date = File.GetCreationTime(filename);
		}
		BindingContext = noteModel;
	}

	public string ItemId
{
    set { LoadNote(value); }
}


}