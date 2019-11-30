using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Models.Search
{
    public class PagedSearchModel
    {
        private int pageNumber = 1;
        private int pageSize = 12;
        private readonly int pageSizeMax = 100;
        private readonly int pageNumberMax = 100000;

        public int PageNumber
        {
            get
            {
                return pageNumber;
            }
            set
            {
                if (value > 0 && value <= pageNumberMax)
                {
                    pageNumber = value;
                }
            }
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                if (value > 0 && value <= pageSizeMax)
                {
                    pageSize = value;
                }
            }
        }
    }
}
