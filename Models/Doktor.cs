using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace udemyWeb1.Models
{
    public class Doktor
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string DoktorAdi { get; set; }

        [Required]
        public string Bolum { get; set;}

        [Required]
        public string Unvan {  get; set; }

        [Required]
        [Range(1900, 2005)]
        public int DogumYili {  get; set; }

        public int PoliklinikTuruId { get; set; }
        [ForeignKey("PoliklinikTuruId")]

        public PoliklinikTuru PoliklinikTuru { get; set; }

        public string ResimUrl { get; set; }

    }
}
