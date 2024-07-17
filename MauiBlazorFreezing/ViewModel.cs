namespace MauiBlazorFreezing;

public class ViewModel : IDisposable
{
    public string Id { get; }

    private int[]? _objects;
    public ViewModel(string id)
    {
        Id = id;
        _objects = new int[100000000];
    }
    
    public void Dispose()
    {
        _objects = null;
    }

    ~ViewModel()
    {
        Console.Write("~ViewModel" + Id);
    }
}