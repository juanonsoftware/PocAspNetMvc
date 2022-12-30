using PocAspNetMvc.Resources;
using System.ComponentModel.DataAnnotations;

namespace PocAspNetMvc.Models
{
    public class ProductViewModel
    {
        [Required(ErrorMessageResourceType = typeof(FormValidationResx), ErrorMessageResourceName = nameof(FormValidationResx.Required))]
        [Display(ResourceType = typeof(FormValidationResx), Name = nameof(Name))]
        [MinLength(5, ErrorMessageResourceType = typeof(FormValidationResx), ErrorMessageResourceName = nameof(FormValidationResx.MinLength))]
        [MaxLength(20, ErrorMessageResourceType = typeof(FormValidationResx), ErrorMessageResourceName = nameof(FormValidationResx.MaxLength))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(FormValidationResx), ErrorMessageResourceName = nameof(FormValidationResx.Required))]
        [Display(ResourceType = typeof(FormValidationResx), Name = nameof(Details))]
        public string Details { get; set; }

        [Display(ResourceType = typeof(FormValidationResx), Name = nameof(Price))]
        public int Price { get; set; }
    }
}