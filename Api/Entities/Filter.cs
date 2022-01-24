using System.Collections.Generic;
using Api.Enums;

namespace Api.Entities
{
    public class Filter
    {
        // Arama yapılacak alan
        public string Field { get; set; }
        // Filtre yapilacak veri
        public List<object> Datas { get; set; }
        // Equal, lessThan,not in gibi sorgulama türleri
        public FilterTypes FilterType { get; set; }

    }
}