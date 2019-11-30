using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Models.Response
{
    public class PagedResponseModel<T> where T : class
    {
        public int TotalItems { get; }
        public int TotalPages { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int PageTotalItems { get; }

        public IEnumerable<T> Items { get; }

        public PagedResponseModel(IEnumerable<T> source, int totalItems, int pageNumber, int pageSize)
        {
            Items = source;
            TotalItems = totalItems;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(TotalItems / (double)PageSize);
            PageTotalItems = Items.Count();
        }
    }
}
