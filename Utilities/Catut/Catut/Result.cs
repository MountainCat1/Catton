using System.Diagnostics.Contracts;
using MediatR;

namespace Catut;

public enum ResultState : byte
{
    Faulted,
    Success,
}

public class Result<T>
{
    public override int GetHashCode()
    {
        return HashCode.Combine((int)State, Value, exception);
    }

    public static readonly Result<T> Bottom;
    internal readonly ResultState State;
    internal readonly T Value;
    private readonly Exception exception;

    internal Exception Exception => this.exception ?? (Exception)BottomException.Default;

    /// <summary>Constructor of a concrete value</summary>
    /// <param name="value"></param>
    private Result(T value)
    {
        this.State = ResultState.Success;
        this.Value = value;
        this.exception = (Exception)null;
    }

    /// <summary>Constructor of an error value</summary>
    /// <param name="e"></param>
    private Result(Exception e)
    {
        this.State = ResultState.Faulted;
        this.exception = e;
        this.Value = default(T);
    }
    
    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }
    
    
    public static Result<T> Failure(Exception exception)
    {
        return new Result<T>(exception);
    }

    public static Result<Unit> Default { get; } = new(MediatR.Unit.Value);

    [Pure]
    public static implicit operator Result<T>(T value) => new Result<T>(value);

    /// <summary>True if the result is faulted</summary>
    [Pure]
    public bool IsFaulted => this.State == ResultState.Faulted;

    /// <summary>True if the struct is in an invalid state</summary>
    [Pure]
    public bool IsBottom
    {
        get
        {
            if (this.State != ResultState.Faulted)
                return false;
            return this.exception == null || this.exception is BottomException;
        }
    }
    
    public bool Equals(Result<T> other)
    {
        return State == other.State && EqualityComparer<T>.Default.Equals(Value, other.Value) && exception.Equals(other.exception);
    }
    
    /// <summary>True if the struct is in an success</summary>
    [Pure]
    public bool IsSuccess => this.State == ResultState.Success;

    /// <summary>Convert the value to a showable string</summary>
    [Pure]
    public override string ToString()
    {
        if (this.IsFaulted)
            return this.exception?.ToString() ?? "(Bottom)";
        T a = this.Value;
        ref T local = ref a;
        return ((object)local != null ? local.ToString() : (string)null) ?? "(null)";
    }
    
    /// <summary>Equality check</summary>
    [Pure]
    public override bool Equals(object obj) => obj is Result<T> other && this.Equals(other);

    [Pure]
    public static bool operator ==(Result<T> a, Result<T> b) =>  a.Equals(b);

    [Pure]
    public static bool operator !=(Result<T> a, Result<T> b) => !(a == b);

    [Pure]
    public R Match<R>(Func<T, R> Succ, Func<Exception, R> Fail) =>
        !this.IsFaulted ? Succ(this.Value) : Fail(this.Exception);
    

    [Pure]
    public Result<B> Map<B>(Func<T, B> f) =>
        !this.IsFaulted ? new Result<B>(f(this.Value)) : new Result<B>(this.Exception);

    [Pure]
    public async Task<Result<B>> MapAsync<B>(Func<T, Task<B>> f)
    {
        Result<B> result;
        if (this.IsFaulted)
            result = new Result<B>(this.Exception);
        else
            result = new Result<B>(await f(this.Value));
        return result;
    }

    public Result<TU> Bind<TU>(Func<T, TU> next)
    {
        if(IsFaulted)
            return new Result<TU>(exception);

        return next(Value);
    }
}



public class BottomException : Exception
{
    public static BottomException Default { get; } = new();
}