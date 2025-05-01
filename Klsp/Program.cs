using System.ComponentModel.DataAnnotations;

namespace Klsp
{
    public abstract class Kunde
    {
        public string Name { get; set; }
        public string MiddleNames { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public Kunde(string name, string middleNames, string lastName, int phoneNumber,string email)
        {
            Name = name;
            MiddleNames = middleNames;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    public class Køber : Kunde
    {
        public Køber(string name, string middleNames, string lastName, int phoneNumber, string email):base(name,middleNames,lastName,phoneNumber,email)
        {

        }
    }

    public class Sælger : Kunde
    {
        public Sælger(string name, string middleNames, string lastName, int phoneNumber, string email):base(name,middleNames,lastName,phoneNumber,email)
        {

        }
    }
}
