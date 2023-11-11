namespace Catut.Application.Abstractions;

public interface IApplicationErrorMapper
{
    public Exception Map(Exception ex); 
}