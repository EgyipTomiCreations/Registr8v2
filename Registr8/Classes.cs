using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registr8
{
    public class Dokumentum
    {
        public int ID { get; set; }
        public string FajlNev { get; set; }
        public string ContentType { get; set; }
        public byte[] bytes { get; set; }
        public int ForeignKey { get; set; }
        public string base64 { get; set; }
        public string Tipus { get; set; }
        public string Leiras { get; set; }
    }

    public class EvfolyamStat
    {
        public int kilencdb { get; set; }
        public int tizdb { get; set; }
        public int tizenegydb { get; set; }
        public int tizenkettodb { get; set; }
        public int tizenharomdb { get; set; }
    }

    public class Uzenet : UzenetRegReq
    {
        public int ID { get; set; }
    }

    public class UzenetRegReq
    {
        public string SzervezoNev { get; set; }
        public int? CsapatID { get; set; }
        public string Targy { get; set; }
        public string Tartalom { get; set; }
    }
    public class Token
    {
        public Guid Guid { get; set; }
        public Auth.FelhKategoria FelhKategoria { get; set; }
        public DateTime CreationDate { get; set; }
    }

    public class TokenWithPasswd : Token
    {
        public string FelhasznaloNev { get; set; }
        public string Jelszo { get; set; }
    }
    public class Kategoria
    {
        public int ID { get; set; }
        public string? Nev { get; set; }
    }

    public class Csapattag
    {
        public int ID { get; set; }

        public enum CsapattagTipus
        {
            Csapattag,
            Pottag
        }

        public string? Nev { get; set; }
        public int Evfolyam { get; set; }
        public CsapattagTipus Tipus { get; set; }
    }

    public class Tanar
    {
        public int ID { get; set; }
        public string? Nev { get; set; }
    }

    public class ProgramNyelv
    {
        public int ID { get; set; }
        public string? Nev { get; set; }
    }

    public class HelyrajziAdatok
    {
        public int ID { get; set; }
        public int? IranyitoSzam { get; set; }
        public string? VarosNev { get; set; }
        public string? KozteruletNev { get; set; }
        public string? Szam { get; set; }
    }

    public class KapcsolatTarto
    {
        public int ID { get; set; }
        public string? Nev { get; set; }
        public string? Email { get; set; }
    }

    public class Iskola
    {
        public int ID { get; set; }
        public string? Nev { get; set; }
        public KapcsolatTarto? KapcsolatTarto { get; set; }
        public HelyrajziAdatok? HelyrajziAdatok { get; set; }
        public int AuthID { get; set; }
    }

    public class IskolaRegReq : AuthReq
    {
        public string? IskolaNev { get; set; }
        public KapcsolatTarto? KapcsolatTarto { get; set; } = new KapcsolatTarto();
        public HelyrajziAdatok? HelyrajziAdatok { get; set; } = new HelyrajziAdatok();
    }

    public class PickerItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }


    public class Szervezo
    {
        public int ID { get; set; }
        public string? FelhaszanloNev { get; set; }
        public string? Jelszo { get; set; }
    }

    public class CsapatRegReq : AuthReq
    {
        public string? CsapatNev { get; set; }
        public int? IskolaId { get; set; }
        public List<Csapattag>? CsapatTagok { get; set; }
        public List<Tanar>? FelkeszitoTanarok { get; set; }
        public int? ProgramNyelvId { get; set; }
        public int? KategoriaId { get; set; }
    }

    public class Csapat : CsapatRegReq
    {
        public int ID { get; set; }

        public enum RegisztracioAllapot
        {
            Regisztralt,
            IskolaJovahagyta,
            SzervezokJovahagytak,
            ElutasitvaIskola,
            ElutasitvaSzervezo
        }

        public RegisztracioAllapot Allapot { get; set; } = RegisztracioAllapot.Regisztralt;
    }

    public class CsapatDto
    {
        public int ID { get; set; }
        public string CsapatNev { get; set; }
        public Iskola Iskola { get; set; }
        public List<Csapattag> Csapattagok { get; set; }
        public List<Tanar> FelkeszitoTanarok { get; set; }
        public List<ProgramNyelv> ProgramNyelvek { get; set; }
        public Kategoria Kategoria { get; set; }
        private Csapat.RegisztracioAllapot allapot;
        public Csapat.RegisztracioAllapot Allapot
        {
            get => allapot;
            set
            {
                allapot = value;
                AllapotSzoveg = value switch
                {
                    Csapat.RegisztracioAllapot.Regisztralt => "Regisztrált",
                    Csapat.RegisztracioAllapot.IskolaJovahagyta => "Iskola jóváhagyta",
                    Csapat.RegisztracioAllapot.SzervezokJovahagytak => "Szervező jóváhagyta",
                    Csapat.RegisztracioAllapot.ElutasitvaIskola => "Iskola által elutasítva",
                    Csapat.RegisztracioAllapot.ElutasitvaSzervezo => "Szervező által elutasítva",
                    _ => "Ismeretlen állapot"
                };
            }
        }

        public string AllapotSzoveg { get; private set; }
    }


    public class AuthReq
    {
        [Required(ErrorMessage = "A felhasználónév mező nem lehet üres!")]
        public string FelhasznaloNev { get; set; }
        [Required(ErrorMessage = "A jelszó mező nem lehet üres!")]
        public string Jelszo { get; set; }
    }

    public class RegReq
    {
        public string FelhasznaloNev { get; set; }
        public string Jelszo { get; set; }
        public Auth.FelhKategoria FelhasznaloiKategoria { get; set; }
    }

    public class Auth : AuthReq
    {
        public int ID { get; set; }

        public enum FelhKategoria
        {
            Szervezo,
            Iskola,
            Versenyzo,
            UnAuth
        }

        public FelhKategoria FelhasznaloiKategoria { get; set; }
    }

    public class Hatarido
    {
        public int ID { get; set; }
        public DateTime hatarido { get; set; }
        public bool lezart { get; set; }
    }
}
