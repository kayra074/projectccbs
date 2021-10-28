using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projectccbs.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Text)]
        [Display(Name = "Voorletter")]
        public string Voorletter { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Text)]
        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Middelnaam")]
        public string Middelnaam { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Text)]
        [Display(Name = "Achternaam")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Text)]
        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postcode")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Text)]
        [Display(Name = "Woonplaats")]
        public string Woonplaats { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public string Geboortedatum { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefoonnummer")]
        public string Telefoonnummer { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Text)]
        [Display(Name = "IBAN")]
        public string Bankrekening { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [DataType(DataType.Password)]
        [Display(Name = "Herhaalwachtwoord")]
        [Compare("Password", ErrorMessage = "Die wachtwoorden komen niet overeen. Probeer het opnieuw.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} is een verplicht veld")]
        [Display(Name = "Rol")]
        public string RoleName { get; set; }


    }
}
