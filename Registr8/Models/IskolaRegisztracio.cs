using Registr8;
using System.ComponentModel.DataAnnotations;

namespace Registr8.Models
{

    public class IskolaRegisztracioModel : AuthReq
    {
        [Required(ErrorMessage = "Az iskola neve nem lehet üres!")]
        public string IskolaNev { get; set; }
        [Required(ErrorMessage = "Az irányítószám nem lehet üres!")]
        public int Iranyitoszam { get; set; }
        [Required(ErrorMessage = "A városnév mező nem lehet üres!")]
        public string VarosNev { get; set; }
        [Required(ErrorMessage = "A közterület mező nem lehet üres!")]
        public string KozteruletNev { get; set; }
        [Required(ErrorMessage = "A házszám mező nem lehet üres!")]
        public string Szam { get; set; }
        [Required(ErrorMessage = "A kapcsolattartó neve nem lehet üres!")]
        public string KapcsolatTartoNev { get; set; }
        [Required(ErrorMessage = "A kapcsolattartó email címe nem lehet üres!")]
        [EmailAddress(ErrorMessage = "Az email cím nem megfelelő!")]
        public string KapcsolatTartoEmail { get; set; }
    }
}
