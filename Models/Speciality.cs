using System.Collections.Generic;

namespace Models
{
    public class Speciality
    {
        // Attributes for Speciality
        public static int SpecialityId = 0;
        public static List<Speciality> Specialities = new List<Speciality>();
        public int Id { set; get; }
        public string Description { set; get; }
        public string Detail { set; get; }

        // The public constructor, will be call when Procedure will instantiated.
        public Speciality(
            string Description,
            string Detail
        ) : this (++SpecialityId, Description, Detail)
        { }

        // The private constructor, will be call when Public where called.
        private Speciality(
            int Id,
            string Description,
            string Detail
        )
        {
            this.Id = Id;
            this.Description = Description;
            this.Detail = Detail;

            // Add a Speciality in a List of Specialities.
            Specialities.Add(this);
        }

        // The method ToString of Speciality.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Description: {this.Description}."
                + $"\n - Detail: {this.Detail}.";
        }

        // Method to check equality of two Speciality Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Speciality.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Speciality iterable = (Speciality) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Procedures.
        public static List<Speciality> GetSpecialities()
        {
            return Specialities;
        }

        // Method remove a Object Speciality from list of Specialities.
        public static void RemoveSpeciality(Speciality speciality)
        {
            Specialities.Remove(speciality);
        }
    }
}