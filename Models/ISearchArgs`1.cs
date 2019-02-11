namespace Atbash.Helpers.Models
{
    public interface ISearchArgs<TFilter> : ISearchArgs
    {
        TFilter Filter { get; set; }
    }
}
