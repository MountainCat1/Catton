using LanguageExt;
using LanguageExt.Common;

namespace Account.Service.Extensions;

public static class ResultExtensions
{
    public static Either<T, Exception> Match<T>(this Result<T> result)
        where T : class
    {
        return result.Match<Either<T, Exception>>(x => x, x => x);
    }
    

}