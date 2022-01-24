using System;
namespace Api.Entities
{
    public class PagingResponse<T> where T : class
    {
        // Sayfadaki kayıt sayısı
        public int PageSize { get; set; }
        // Hangi sayfayı istediğimizi belirtiyoruz
        public int Page { get; set; }
        // Toplam data sayısı
        public long TotalSize { get; set; }
        public T Data { get; set; }

    }
}