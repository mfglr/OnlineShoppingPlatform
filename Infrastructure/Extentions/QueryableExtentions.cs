using Core;

namespace Infrastructure.Extentions
{
    internal static class QueryableExtentions
    {

        public static IQueryable<T> ToPage<T>(this IQueryable<T> query, Page page) where T : Entity
        {
            if (page.IsDescending)
                return query
                    .Where(x => page.Offset == null || x.Id < page.Offset)
                    .OrderByDescending(x => x.Id)
                    .Take(page.Take);
            return query
                .Where(x => page.Offset == null || x.Id > page.Offset)
                .OrderBy(x => x.Id)
                .Take(page.Take);
        }
    }
}
