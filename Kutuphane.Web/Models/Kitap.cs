using System.ComponentModel.DataAnnotations.Schema;

namespace Kutuphane.Web.Models
{
    [Table("Kitaplar")]
    public class Kitap:ModelBase
    {
        
        public string ISBN { get; set; }
        public string Ozet { get; set; }
        public Guid KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        
    }
}
