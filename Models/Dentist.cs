using System.Collections.Generic;

namespace Models
{
    public class Dentist : Person
    {
        // Attributes from the class os Dentist.
        // DentistId don't have acessors because is resolve only here.
        public static int DentistId = 0;
        private static List<Dentist> Dentists = new List<Dentist>();
        public string Register { set; get; }
        public double Wage { set; get; }
        public int IdSpeciality { set; get; }
        public Speciality Speciality { get; }

        // The public constructor, will be call when Dentist will instantiated.
        public Dentist(
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd,
            string Register,
            double Wage,
            int IdSpeciality
        ) : this(++DentistId, Name, Cpf, Phone, Mail, Passwd, Register, Wage, IdSpeciality)
        { }
        
        // The private constructor, will be call when Public where called.
        private Dentist(
            int Id,
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd,
            string Register,
            double Wave,
            int IdSpeciality

        ) : base(Id, Name, Cpf, Phone, Mail, Passwd)
        {
            this.Register = Register;
            this.Wage = Wage;

            this.IdSpeciality = IdSpeciality;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            this.Speciality = Speciality.GetSpecialities().Find(Speciality => Speciality.Id == IdSpeciality);


            // Add a Dentist in a List of Dentists.
            Dentists.Add(this);
        }

        // The method ToString of Dentist, the base.ToString() is like a Super.
        public override string ToString()
        {
            return base.ToString()
                + $"\n + Register: {this.Register}"
                + $"\n + Wage: {this.Wage}"
                + $"\n * Descript of Speciality: {this.Speciality.Description}"
                + $"\n * Details of Speciality: {this.Speciality.Detail}";
        }

        // Method to check equality of two Dentist Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Dentist.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Dentist iterable = (Dentist) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Dentists.
        public static List<Dentist> GetDentists()
        {
            return Dentists;
        }

        // Method remove a Obeject Dentist from list of Dentists.
        public static void RemoveDentist(Dentist dentist)
        {
            Dentists.Remove(dentist);
        }
    }
}