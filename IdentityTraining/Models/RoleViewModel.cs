using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTraining.Models
{
    public class RoleViewModel //Rol ekleme modelimiz hazır
    {
        [Required(ErrorMessage ="Ad Alanı gereklidir")]
        [Display(Name="Ad")]
        public string Name { get; set; }
    }
}
