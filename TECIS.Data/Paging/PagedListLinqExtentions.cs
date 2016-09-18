using System.Linq;

namespace TECIS.Data.Paging
{
    public static class PagedListLinqExtentions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> allItems, int currentPageNumber, int pageSize)
        {
            if (currentPageNumber < 1)
                currentPageNumber = 1;

            var totalNumberOfItems = allItems.Count();
            var totalNumberOfPages = totalNumberOfItems == 0 ? 1 : (totalNumberOfItems / pageSize + (totalNumberOfItems % pageSize > 0 ? 1 : 0));
            if (currentPageNumber > totalNumberOfPages)
                currentPageNumber = totalNumberOfPages;

            var itemsToSkip = (currentPageNumber - 1) * pageSize;
            var pagedItems = allItems.Skip(itemsToSkip).Take(pageSize).ToList();

            return new PagedList<T>(pagedItems, currentPageNumber, pageSize, totalNumberOfItems);
        }
    }
}