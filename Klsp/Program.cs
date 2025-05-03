using System.ComponentModel.DataAnnotations;
namespace Klsp
{
    //Dette er bare forslag til klasser. De er ikke færdige. 
    //Kun bolig og salgskvitering indeholder forignkeys.
    //Ejendomsmæglere, Sælgere og Købere har ikke et boligID eller nogen anden form for forignkey
    //Da det vil skabe data redundancy hvis de alle referer til hindanden.
        //I sql vil der være en tabel for sælgere. Den vil indeholde deres info (navn, tlfnummer osv.) og et ID.
        //Så vil der være en tabel for købere der også indeholder deres info og ID
        //og det samme med ejendomsmæglere.
        //Bolig tabellen vil indeholde boligens info og ID samt sælgerens ID og ejendomsmæglerens ID.
           //bolig og køber tabeller kan evt. begge opdeles i 2 tabeller (bolig + boligdetails) (køber + køberdetails)
        //salgs tabellen vil indeholde info på salget (dato, beløb osv.) og ID samt et boligID og køberID. 
    public abstract class Kunde
    {
        public string Navn { get; set; }
        public string Efternavn { get; set; }
        public int TlfNummer { get; set; }
        public string Email { get; set; }
        public Kunde(string navn, string efternavn, int tlfNummer,string email)
        {
            Navn = navn;
            Efternavn = efternavn;
            TlfNummer = tlfNummer;
            Email = email;
        }
    }

    public class Køber : Kunde
    {
        //køber vil ha sin egen tabel (en tabel for alle køberer der har købt et hus)
        public int KøberID { get; set; }
        //Køberns ID, (dette skulle gerne gives af sql med identity markatet)
        public int PrisKlasse { get; set; } 
        //Prisområdet de ligger i
        public string SøgeOmråde { get; set; } 
        //region, kommune, by.
        public string BoligType { get; set; }
        //hvad leder de efter? villa? landejendom?
        public string KøberInfo { get; set; } //optional
        //info om købernes omstændigheder (børn? dyr? job? Hvis det kan hjælpe med at finde noget)
        public int GrundStørrelse { get; set; }//optional 
        //Hvis de har en fornemmelse af hvor stor grunden gerne skulle være
        public int Boligstørrelse { get; set; } //optional
        //Hvis de har en fornemmelse af hvor stor boligen gerne skulle være
        public int Værelser { get; set; } //optional
        //Hvor mange værelser vil de have som minimum.
        public Køber(string navn, string efternavn, int tlfNummer, string email, int prisKlasse, string søgeOmråde, string boligType, Ejendomsmægler kontaktPerson) :base(navn,efternavn,tlfNummer,email)
        {
            SøgeOmråde = søgeOmråde;
            PrisKlasse = prisKlasse;
            BoligType = boligType;
            KøberInfo = "";
        }
    }

    public class Sælger : Kunde
    {
        //sælgere vil have sin egen tabel (altså tabel over alle sælgere)
        public int SælgerID { get; set; }
        //Sælgerens ID, (dette skulle gerne gives af sql med identity markatet)
        public Sælger(string navn, string efternavn, int tlfNummer, string email):base(navn,efternavn,tlfNummer,email)
        {

        }
    }

    public class Ejendomsmægler : Kunde
    {
        //Ejendomsmægler vil have deres egen tabel (altså en tabel for alle ejendoms mæglere)
        //Den arver fra kunde klassen da en ejendomsmægler vel også kan være en kunde
        //hvis den ikke arvede så skulle de genregistres som en kunde hvis de ville købe eller sælge en ejendom
        //hvilket vil give data redundancy.
        public int EjendomsmæglerID { get; set; }
        //Ejendomsmæglerns ID, (dette skulle gerne gives af sql med identity markatet)
        public Ejendomsmægler(string navn, string efternavn, int tlfNummer, string email) : base(navn, efternavn, tlfNummer, email)
        {

        }
    }
    public class Bolig
    {
        //bolig vil være en seperat tabel (altså en tabel for alle boligere)
        public int BoligID { get; set; }
        //Bolgiens ID (dette skulle gerne gives af sql med identity markatet)
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
        public int EjendomsmæglerID { get; set; }
        //Ejendomsmægleren der administreret boligen
        public int SælgerID { get; set; }
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
            EjendomsmæglerID = ejendomsmægler.EjendomsmæglerID;
            SælgerID = sælger.SælgerID;
            EnergiMærke = "";
            Status = false;
        }
    }
    
    public class SalgsKvitering
    {
        //salg vil have sit eget table.
        public int KøberID {  get; set; }
        //hvem købte boligen
        public int BoligID { get; set; }
        //boligen (som indeholder forign keys for sælgeren og Ejendomsmægleren)
        public string Dato { get; set; }
        public int Beløb {  get; set; }
        public SalgsKvitering(Køber køber, Bolig bolig, string dato, int beløb)
        {
            KøberID = køber.KøberID;
            BoligID = bolig.BoligID;
            Dato = dato;
            Beløb = beløb;
        }
    }
}



