namespace MauiBlazorFreezing;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        var navigationPage = new NavigationPage(new MainPage());
        navigationPage.Popped += (sender, args) =>
        {
            if (args.Page is NewPage page)
            {
                page.Dispose();
            }
        };
        MainPage = navigationPage;
    }
}