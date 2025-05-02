using System.ComponentModel.DataAnnotations;
namespace Klsp
{
    public abstract class Kunde
    {
        public string Navn { get; set; }
        public string Efternavn { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Kunde(string name, string efternavn, int phoneNumber,string email)
        {
            Navn = name;
            Efternavn = efternavn;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    public class Køber : Kunde
    {
        //køber vil ha sin egen tabel (en tabel for alle købere/køber der har købt et hus)
        public int PrisKlasse { get; set; } 
        //max pris
        public string SøgeOmråde { get; set; } 
        //region, kommune, by.
        public string BoligType { get; set; }
        //villa? landejendom?
        public string KøberInfo { get; set; } //optional
        //info om købernes omstændigheder (børn? dyr? job? Hvis det kan hjælpe med at finde noget)
        public int[] GrundstørrelseRange { get; set; }//optional 
        //arr = [min, max]
        public int[] BoligstørrelseRange { get; set; } //optional
        //arr = [min, max]
        public int Værelser { get; set; } //optional
        //Hvor mange værelser vil de have som minimum.
        public Køber(string name, string efternavn, int phoneNumber, string email, int prisKlasse, string søgeOmråde, string boligType, Ejendomsmægler kontaktPerson) :base(name,efternavn,phoneNumber,email)
        {
            SøgeOmråde = søgeOmråde;
            PrisKlasse = prisKlasse;
            BoligType = boligType;
            GrundstørrelseRange = new int[2];
            BoligstørrelseRange = new int[2];
            KøberInfo = "";
        }
    }

    public class Sælger : Kunde
    {
        //sælgere vil have sin egen tabel (altså tabel over alle sælgere)
        public Sælger(string name, string efternavn, int phoneNumber, string email):base(name,efternavn,phoneNumber,email)
        {

        }
    }

    public class Ejendomsmægler : Kunde
    {
        //Ejendomsmægler vil have deres egen tabel (altså en tabel for alle ejendoms mæglere)
        public Ejendomsmægler(string name, string efternavn, int phoneNumber, string email) : base(name, efternavn, phoneNumber, email)
        {

        }
    }
    public class Bolig
    {
        //bolig vil være en seperat tabel (altså en tabel for alle boligere)
        public int Pris { get; set; }
        //pris på boligen
        public string Adresse { get; set; }
        //boligens adresse
        public string Type {  get; set; }
        //boligtypen
        public int BoligAreal { get; set; }
        //boligens areal
        public int Værelser { get; set; }
        //antal af værelser/rum
        public int ByggeDato { get; set; }
        //hvornår var den bygget/renoveret
        public int GrundStørrelse { get; set; }
        //det samlet areal af bolig og land
        public string EnergiMærke { get; set; } //optional
        //boligens energimærke
        public Ejendomsmægler Ejendomsmægler { get; set; }
        //Ejendomsmægleren der administreret boligen
        public Sælger Sælger { get; set; }
        //sælgeren der vil sælge boligen
        public bool Status {  get; set; }
        //false = ikke solgt. true = solgt
        public Bolig(int pris, string adresse, string type, int boligAreal, int værelser, int byggeDato, int grundStørrelse, Ejendomsmægler ejendomsmægler, Sælger sælger)
        {
            Pris = pris;
            Adresse = adresse;
            Type = type;
            BoligAreal = boligAreal;
            Værelser = værelser;
            ByggeDato = byggeDato;
            GrundStørrelse = grundStørrelse;
            Ejendomsmægler = ejendomsmægler;
            EnergiMærke = "";
            Sælger = sælger;
            Status = false;
        }
    }
    
    public class SalgsKvitering
    {
        //salg vil have sin egen table.
        public Køber Køber {  get; set; }
        //hvem købte boligen
        public Bolig Bolig { get; set; }
        //boligen (som indeholder forign keys for sælgeren og Ejendomsmægleren)
        public string Dato { get; set; }
        public int Beløb {  get; set; }
        public SalgsKvitering(Køber køber, Bolig bolig, string dato, int beløb)
        {
            Køber = køber;
            Bolig = bolig;
            Dato = dato;
            Beløb = beløb;
        }
    }
}



