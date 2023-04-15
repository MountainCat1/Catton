using MediatR;

namespace Catut;

public static class TaskExtensions
{
    public static async Task<Result<TU>> BindAsync<T, TU>(this Task<Result<T>> task, Func<T, Task<Result<TU>>> next)
    {
        Result<TU> nextResult;
        try
        {
            var result = await task;

            nextResult = result.IsSuccess
                ? await next(result.Value)
                : Result<TU>.Failure(result.Exception);
        }
        catch (Exception e)
        {
            return Result<TU>.Failure(e);
        }

        return nextResult;
    }

    public static async Task<Result<TU>> BindAsync<TU>(this Task<Result<Unit>> task, Func<Task<Result<TU>>> next)
    {
        Result<TU> nextResult;
        try
        {
            var result = await task;

            nextResult = result.IsSuccess
                ? await next()
                : Result<TU>.Failure(result.Exception);
        }
        catch (Exception e)
        {
            return Result<TU>.Failure(e);
        }

        return nextResult;
    }


    public static async Task<Result> BindAsync<T>(this Task<Result<T>> task, Func<T, Task<Result>> next)
    {
        Result nextResult;
        try
        {
            var result = await task;

            nextResult = result.IsSuccess
                ? await next(result.Value)
                : Result.Failure(result.Exception);
        }
        catch (Exception e)
        {
            return Result.Failure(e);
        }

        return nextResult;
    }

    public static async Task<Result> BindAsync(this Task<Result> task, Func<Task<Result>> next)
    {
        Result nextResult;
        try
        {
            var result = await task;

            nextResult = result.IsSuccess
                ? await next()
                : Result.Failure(result.Exception);
        }
        catch (Exception e)
        {
            return Result.Failure(e);
        }

        return nextResult;
    }

    public static async Task<Result> BindAsync<T>(this Task<Result<T>> task, Func<T, Task> next)
    {
        try
        {
            var result = await task;

            if (result.IsFaulted)
            {
                return Result.Failure(result.Exception);
            }

            await next(result.Value);

            return Result.Default;
        }
        catch (Exception e)
        {
            return Result.Failure(e);
        }
    }

    public static async Task<Result> BindAsync(this Task<Result> task, Func<Task> next)
    {
        try
        {
            var result = await task;

            if (result.IsFaulted)
            {
                return Result.Failure(result.Exception);
            }

            await next();

            return Result.Default;
        }
        catch (Exception e)
        {
            return Result.Failure(e);
        }
    }
    
    public static async Task<T> HandleAsync<T>(this Task<Result<T>> task, Action<Exception> handler)
    {
        var result = await task;

        if (result.IsFaulted)
        {
            handler(task.Exception!);
            return default(T);
        }

        return result.Value;
    }
    
    public static Task<T> HandleAsync<T>(this Task<Result<T>> task)
    {
        return task.HandleAsync(ex => throw ex);
    }
    
    public static async Task HandleAsync(this Task<Result> task, Action<Exception> handler)
    {
        var result = await task;

        if (result.IsFaulted)
        {
            handler(task.Exception!);
        }
    }
    
    public static Task HandleAsync<T>(this Task<Result> task)
    {
        return task.HandleAsync(ex => throw ex);
    }
}
