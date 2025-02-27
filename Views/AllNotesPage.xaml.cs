using System;
using Notes.ViewModels;

namespace Notes.Views;
    
public partial class AllNotesPage : ContentPage
{
    public AllNotesPage()
{
    this.BindingContext = new AllNotesViewModel();
    InitializeComponent();
}


    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }


}
