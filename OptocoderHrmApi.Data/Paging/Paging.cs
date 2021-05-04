using System;
using System.Collections.Generic;
using System.Text;

namespace OptocoderHrmApi.Data.Paging
{
    public class Paging
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Paging()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public Paging(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
