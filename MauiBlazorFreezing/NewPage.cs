using MauiBlazorFreezing.Components;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace MauiBlazorFreezing;

public class NewPage : ContentPage, IDisposable
{
    private BlazorWebView BlazorWebView { get; }
    
    public ViewModel? Vm { get; set; }
    
    public ViewModel? Vm2 { get; set; }
    public NewPage()
    {
        Vm = new ViewModel("ViewModel referenced by razor");
        Vm2 = new ViewModel("ViewModel referenced by Page");
        BlazorWebView = new BlazorWebView {
            HostPage = "wwwroot/index.html"
        };
        BlazorWebView.RootComponents.Add(new RootComponent() {
                Selector = "#app",
                ComponentType = typeof(New),
                Parameters = new Dictionary<string, object>
                {
                    { "Vm", Vm }
                }!
            }
        );
        Content = BlazorWebView;
    }
    
    public void Dispose()
    {
        // if run this, freezing.
        /*if (BlazorWebView.Handler != null) {
            BlazorWebView.Handler.DisconnectHandler();
            BlazorWebView.Handler = null;
        }*/
        Vm?.Dispose();
        Vm = null;
        Vm2?.Dispose();
        Vm2 = null;
        
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
    }

    ~NewPage()
    {
        Console.Write("~NewPage");
    }
}