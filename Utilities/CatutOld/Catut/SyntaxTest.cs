using System.Reflection.Metadata.Ecma335;

namespace Catut;


public interface ISyntaxTest
{
    public Task<Result> SomeMethod();
}

public class SyntaxTest : ISyntaxTest
{
    public async Task<Result> SomeMethod()
    {
        var result = await FirstMethod()
            .BindAsync(SecondMethod)
            .BindAsync(ThirdMethod);

        return result;
    }

    private Task<Result> FirstMethod()
    {
        return Result.SuccessTask();
    }
    
    private Result ThirdMethod()
    {
        return Result.Success();
    }

    public async Task<Result> SecondMethod()
    {
        return Result.Success();
    }
}