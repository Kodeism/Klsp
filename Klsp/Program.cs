using System.ComponentModel.DataAnnotations;
namespace Klsp
{
    //når der skrives optional er det fordi parameren ikke behøves men kan gives.
    //id lader vi sql tage sig af tænker jeg
    public abstract class Person
    {
        public string Name { get; set; }
        public string MiddleNames { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Person(string name, string middleNames, string lastName, int phoneNumber,string email)
        {
            Name = name;
            MiddleNames = middleNames;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    public class Køber : Person
    {
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
        public Køber(string name, string middleNames, string lastName, int phoneNumber, string email, int prisKlasse, string søgeOmråde, string boligType):base(name,middleNames,lastName,phoneNumber,email)
        {
            SøgeOmråde = søgeOmråde;
            PrisKlasse = prisKlasse;
            BoligType = boligType;
            GrundstørrelseRange = new int[2];
            BoligstørrelseRange = new int[2];
        }
    }

    public class Sælger : Person
    {
        public List<Bolig> Boliger {  get; set; }
        //liste af boligere de har til salg
        public List<Bolig> SolgteBoliger { get; set; }
        //liste af boligere i deres salgs historik
        public Sælger(string name, string middleNames, string lastName, int phoneNumber, string email):base(name,middleNames,lastName,phoneNumber,email)
        {
            Boliger = new List<Bolig>();
            SolgteBoliger = new List<Bolig>();
        }
    }

    public class Ejendomsmægler : Person
    {
        public List<Bolig> Boliger { get; set; }
        //liste af boligere der er til salg som de er kontakt person for
        public List<Bolig> SolgteBoliger { get; set; }
        //liste af boligere i deres salgs historik
        public Ejendomsmægler(string name, string middleNames, string lastName, int phoneNumber, string email) : base(name, middleNames, lastName, phoneNumber, email)
        {
            Boliger = new List<Bolig>();
            SolgteBoliger = new List<Bolig>();
        }
    }
    public class Bolig
    {
        public int Pris { get; set; }
        //pris på boligen
        public string Beskrivelse { get; set; }
        //beskrivelse af boligen og dens beliggenhed
        public string Adresse { get; set; }
        //boligens adresse
        public string Type {  get; set; }
        //boligtypen
        public int BoligAreal { get; set; }
        //boligens areal
        public int Værelser { get; set; }
        //antal af værelser/rum
        public int 
    }
}

