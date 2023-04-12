using System.Diagnostics.Contracts;
using MediatR;

namespace Catton.Utilities;

public class Result
{
    public override int GetHashCode()
    {
        return HashCode.Combine((int)State, exception);
    }
    
    internal readonly ResultState State;
    private readonly Exception exception;

    internal Exception Exception => this.exception ?? (Exception)BottomException.Default;

    /// <summary>Constructor of a concrete value</summary>
    /// <param name="value"></param>
    public Result()
    {
        this.State = ResultState.Success;
        this.exception = (Exception)null;
    }

    /// <summary>Constructor of an error value</summary>
    /// <param name="e"></param>
    public Result(Exception e)
    {
        this.State = ResultState.Faulted;
        this.exception = e;
    }

    public static Result Default { get; } = new();
    
    public static implicit operator Result(Result<Unit> result)
    {
        if (result.IsFaulted)
            return new Result(result.Exception);
        
        return new Result();
    }
    
    public static implicit operator Result<Unit>(Result result)
    {
        if (result.IsFaulted)
            return new Result<Unit>(result.Exception);
        
        return new Result<Unit>(Unit.Value);
    }

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
    
    /// <summary>True if the struct is in an success</summary>
    [Pure]
    public bool IsSuccess => this.State == ResultState.Success;

    /// <summary>Convert the value to a showable string</summary>
    [Pure]
    public override string ToString()
    {
        if (this.IsFaulted)
            return this.exception?.ToString() ?? "(Bottom)";
        
        return "(Success)";
    }
    
    /// <summary>Equality check</summary>
    [Pure]
    public override bool Equals(object obj) => obj is Result other && this.Equals(other);

    [Pure]
    public R Match<R>(Func<R> Succ, Func<Exception, R> Fail) =>
        !this.IsFaulted ? Succ() : Fail(this.Exception);
    
}
