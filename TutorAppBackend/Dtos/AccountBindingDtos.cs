using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TutorAppBackend.Dtos
{
    public class AccountBindingDtos
    {
        // Modelos usados como parámetros para las acciones de AccountController.

        public class AddExternalLoginBindingDto
        {
            [Required]
            [Display(Name = "Token de acceso externo")]
            public string ExternalAccessToken { get; set; }
        }

        public class ChangePasswordBindingDto
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña actual")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nueva contraseña")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar la nueva contraseña")]
            [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        public class RegisterBindingDto
        {
            [Required]
            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        public class RegisterExternalBindingDto
        {
            [Required]
            [Display(Name = "Correo electrónico")]
            public string Email { get; set; }
        }

        public class RemoveLoginBindingDto
        {
            [Required]
            [Display(Name = "Proveedor de inicio de sesión")]
            public string LoginProvider { get; set; }

            [Required]
            [Display(Name = "Clave de proveedor")]
            public string ProviderKey { get; set; }
        }

        public class SetPasswordBindingDto
        {
            [Required]
            [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nueva contraseña")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirmar la nueva contraseña")]
            [Compare("NewPassword", ErrorMessage = "La nueva contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
        }
    }
}