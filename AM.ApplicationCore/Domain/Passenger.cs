using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public Passenger(DateTime birthDate, string emailAddress, string firstName, string lastName, int telNumber, int passportNumber)
        {
            BirthDate = birthDate;
            EmailAddress = emailAddress;
            //FirstName = firstName;
            //LastName = lastName;
            TelNumber = telNumber;
            PassportNumber = passportNumber;
        }
        [Display(Name ="Date of birth"),DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public  int Id { get; set; }
        [EmailAddress]
        //ou [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        //[MinLength(3,ErrorMessage ="Ce xhamps doit contenir au moins 3 catractéres"),MaxLength(27,ErrorMessage = "Ce champs doit contenir 27 catractéres au maximum")]
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        [MinLength(8),MaxLength(8)]
        // cas ou TelNumber est d e type string [RegualarExpression("[0-9]"{8}]
        public int TelNumber { get; set; }
        [Key, MaxLength(7)]
        public int PassportNumber { get; set; }
        //public ICollection<Flight> Flights { get; set; }
        public ICollection<Ticket> tickets { get; set; }
        public FullName FullName { get; set; }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}
        //public override string ToString()
        //{
        //    return "Passenger : FirstName= " + FirstName + " , LastName= " + LastName + "  " + BirthDate +
        //        "  " + TelNumber + "  " + EmailAddress + " " + "\n";
        //}
        ////public bool checkProfil(string nom, string prenom) {

        //    return FirstName==nom && LastName==prenom;
        //}
        //public bool checkProfil(string nom, string prenom,string email)
        //{

        //    return FirstName == nom && LastName == prenom && EmailAddress==email;
        //}
        //public bool checkProfil(string nom, string prenom, string email = null)
        //{
        //    if (email == null)
        //    {
        //        return FirstName == nom && LastName == prenom;
        //    }
        //    return FirstName == nom && LastName == prenom && EmailAddress == email;
        //}

        public Passenger()
        {
                
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
