using Atbash.Helpers.Models;

namespace Atbash.Helpers.Misc
{
    public class PagingBuilder
    {
        public static IPaging<T, TFilter> Build<T, TFilter>(IPaging<T, TFilter> paging) where TFilter : new()
        {
            IPaging<T, TFilter> paging1 = paging;
            if (paging1 == null)
                paging1 = (IPaging<T, TFilter>)new Paging<T, TFilter>()
                {
                    Filter = new TFilter()
                };
            paging = paging1;
            if ((object)paging.Filter == null)
                paging.Filter = new TFilter();
            return paging;
        }
    }
}
