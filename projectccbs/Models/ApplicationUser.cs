using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectccbs.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Voorletter { get; set; }
        public string Voornaam { get; set; }
        public string Middelnaam { get; set; }
        public string Achternaam { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public string Geboortedatum { get; set; }
        public string Telefoonnummer { get; set; }
        public string Bankrekening { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }

        public string VolledigeNaam
        {
            get
            {
                if (string.IsNullOrEmpty(Middelnaam))
                {
                    return Voornaam + " " + Achternaam;
                }
                else
                {
                    return Voornaam + " " + Middelnaam + " " + Achternaam;
                }
            }
        }
    }
}
