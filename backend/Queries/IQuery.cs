namespace Backend.Queries
{
    public interface IQuery<TResponse>
    {
        TResponse Resolve();
    }
}
