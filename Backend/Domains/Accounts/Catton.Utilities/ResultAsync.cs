namespace Catton.Utilities;

public struct ResultAsync<T>
{
    public T Value { get; }
    public bool Success { get; private set; }
    
    public ResultAsync(Exception exception)
    {
        
    }

    private ResultAsync(T t)
    {
        Value = t;
    }

    public static implicit operator ResultAsync<T>(T value) => new ResultAsync<T>(value);

    public void Bind(Action<T> next)
    {
        if(!Success)
            return ;
    }
}
