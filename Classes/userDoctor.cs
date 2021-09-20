using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class userDoctor
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Speciality { get; set; }
        public List<Appointment> Appointments { get; set; }

        public string NameAndSpecialty
        {
            get
            {
                return $"{Name} - {Speciality}";
            }
        } 
    }

}
