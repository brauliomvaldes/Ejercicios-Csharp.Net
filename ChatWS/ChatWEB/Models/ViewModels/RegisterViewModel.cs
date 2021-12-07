using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatWEB.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Confirme Contraseña")]
        [Compare("Password")]
        public string ConfirmacionPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress]
        public string Email { get; set; }
    }
}