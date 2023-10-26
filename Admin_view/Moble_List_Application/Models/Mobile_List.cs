using System.ComponentModel.DataAnnotations;

namespace Moble_List_Application.Models
{
    public class Mobile_List
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Mobile Name")]
        public string Mobile_name { get; set; }
        [Display(Name ="Mobile Brand")]
        public string Mobile_Brand { get; set; }
        [Display(Name = "Mobile Descripton")]
        public string Mobile_description { get; set;}

        [Display(Name = "Mobile Logo")]
        public string? Mobile_logo { get; set;}
    }
}
