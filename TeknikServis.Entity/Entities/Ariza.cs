using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.Entity.Entities
{
    [Table("Arizalar")]
    public class Ariza:BaseEntity<int>
    {
        [Required]
        [Display(Name ="Kategori")]
        public int KategoriID { get; set; }
        [Required]
        [Display(Name ="Açıklama")]
        [StringLength(400, MinimumLength = 3, ErrorMessage ="Açıklama bölümü boş geçilemez!")]
        public string Aciklama { get; set; }
        public string UserID { get; set; }
        public string OperatorID { get; set; }
        public string TeknisyenID { get; set; }
        [Required]
        [Display(Name = "Başlık")]
        [StringLength(90, MinimumLength = 3, ErrorMessage = "Başlık bölümü boş geçilemez!")]
        public string Baslik { get; set; }
        public string Rapor { get; set; }
        [Display(Name = "Adres")]
        public string AdresAciklamasi { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public List<ArizaDurum> Durumlar { get; set; } = new List<ArizaDurum>();
        public List<Fotograf> Fotograflar { get; set; } = new List<Fotograf>();
        [ForeignKey("KategoriID")]
        public Kategori Kategori { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }
        [ForeignKey("OperatorID")]
        public ApplicationUser Operator { get; set; }
        [ForeignKey("TeknisyenID")]
        public ApplicationUser Teknisyen { get; set; }
        public bool sonuclandiMi { get; set; }
    }
}
