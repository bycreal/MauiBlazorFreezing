namespace MauiBlazorFreezing;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    
    private async void NewPage_Clicked(object sender, EventArgs e)
    {
        var page = new NewPage();
        await App.Current.MainPage.Navigation.PushAsync(page);
    }
}