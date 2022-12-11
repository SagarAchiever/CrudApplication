using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models.ViewModel
{
    public class ImageCreateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="plz enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "plz choose image")]
        [Display(Name = "choose img")]
        public IFormFile ImagePath { get; set; }
    }
}
