namespace OnlineStore.Core.RequestResponse.Common;

public class Result
{
    private List<string> _errors = new();
    public bool IsSuccess => !_errors.Any();
    public IReadOnlyList<string> Errors => _errors;
    public void AddError(string error) => _errors.Add(error);
}
public class Result<TData> : Result
{
    public Result(TData data)
    {
        Data = data;
    }
    public TData Data { get; set; }

}
