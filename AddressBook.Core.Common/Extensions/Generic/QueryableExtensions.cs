//using AddressBook.Models.Response;
//using Microsoft.EntityFrameworkCore;
using AddressBook.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AddressBook.Core.Common.Extensions.Generic
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            return source
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize);
        }

        public static PagedResponseModel<T> ToPagedResponseModel<T>(this IQueryable<T> source, int pageNumber, int pageSize) where T : class
        {
            var totalItems = source.Count();
            var list = new List<T>();

            if (totalItems > 0)
            {
                list = source
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .ToList();
            }

            var page = new PagedResponseModel<T>(list, totalItems, pageNumber, pageSize);

            return page;
        }


    }
}
