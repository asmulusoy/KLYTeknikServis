using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TeknikServis.Entity.Entities;

namespace TeknikServis.Entity.ViewsModel
{
    public class ArizaViewModel:BaseEntity<int>
    {
        [Required(ErrorMessage ="Kategori belirlenmesi zorunludur!")]
        [Display(Name = "Kategori")]
        public int KategoriID { get; set; }
        [Required(ErrorMessage ="Arıza ile ilgili açıklama girilmesi zorunludur!")]
        [Display(Name ="Açıklama")]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "Açıklama bölümü boş geçilemez!")]
        public string Aciklama { get; set; }
        public string UserID { get; set; }
        [Required(ErrorMessage ="Başlık alanının girilmesi zorunludur!")]
        [Display(Name ="Başlık")]
        [StringLength(90, MinimumLength = 3, ErrorMessage = "Başlık bölümü boş geçilemez!")]
        public string Baslik { get; set; }
        public string Rapor { get; set; }
        [Display(Name ="Firma Adı")]
        public string FirmaAdi { get; set; }
        [Display(Name = "Rezervasyon")]
        [Required(ErrorMessage ="Rezervasyon tarihi alanının girilmesi zorunludur!")]
        public DateTime IslemTarihi { get; set; }
       
        [Display(Name ="Adres")]
        public string AdresAciklamasi { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public List<ArizaDurum> Durumlar { get; set; } = new List<ArizaDurum>();
        public List<HttpPostedFileBase> Fotograflar { get; set; } = new List<HttpPostedFileBase>();

    }
}
