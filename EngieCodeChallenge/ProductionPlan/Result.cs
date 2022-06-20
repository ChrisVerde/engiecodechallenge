using System.Collections;

namespace EngieCodeChallenge.ProductionPlan;

public abstract record Result<T> : IEnumerable<T>
{
    private Result() { }

    public sealed record Success(T Result) : Result<T>;
    public sealed record Failure(string Reason) : Result<T>;

    public IEnumerator<T> GetEnumerator()
    {
        if (this is Success(var result))
            yield return result;
    }

    IEnumerator IEnumerable.GetEnumerator() 
        => GetEnumerator();
}
public class Result
{
    public static Result<T> Success<T>(T result)
        => new Result<T>.Success(result);
    public static Result<T> Failure<T>(string reason)
        => new Result<T>.Failure(reason);
}