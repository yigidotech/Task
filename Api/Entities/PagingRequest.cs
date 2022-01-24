using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.Entities
{
    public class PagingRequest
    {
        // Sayfadaki kayıt sayısı
        public int PageSize { get; set; }
        // Hangi sayfayı istediğimizi belirtiyoruz
        public int Page { get; set; }
        public List<Filter> Filters { get; set; }

    }
}