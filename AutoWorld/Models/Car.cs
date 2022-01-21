using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoWorld.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Display(Name = "Car brand")]
        [Required, StringLength(30, MinimumLength = 2)]
        public string brand { get; set; }

        [Required, StringLength(20, MinimumLength = 2)]
        [Display(Name = "Car model")]
        public string model { get; set; }
        public string fuel { get; set; }
        public int year { get; set; }
        public double price { get; set; }
        public int DealerID { get; set; }
        public DealerAuto DealerAuto { get; set; }
        public ICollection<CarCategory> CarCategories { get; set; }

    }
}
