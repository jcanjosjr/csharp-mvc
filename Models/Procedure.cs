using System.Collections.Generic;

namespace Models
{
    public class Procedure
    {
        // Attributes from procedure.
        public static int ProcedureId = 0;
        private static List<Procedure> Procedures = new List<Procedure>();
        public int Id { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }

        // The public constructor, will be call when Procedure will instantiated.
        public Procedure(
            string Description,
            double Price
        ) : this(++ProcedureId, Description, Price)
        { }

        // The private constructor, will be call when Public where called.
        private Procedure(
            int Id,
            string Description,
            double Price
        )
        {
            this.Id = Id;
            this.Description = Description;
            this.Price = Price;

            // Add a Procedure in a List of Procedures.
            Procedures.Add(this);
        }

        // The method ToString of Procedure.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Description: {this.Description}."
                + $"\n - Price: ${this.Price}";
        }

        // Method to check equality of two Procedure Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Procedure.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Procedure iterable = (Procedure) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Procedures.
        public static List<Procedure> GetProcedures()
        {
            return Procedures;
        }

        // Method remove a Object Procedure from list of Procedures.
        public static void RemoveProcedure(Procedure procedure)
        {
            Procedures.Remove(procedure);
        }
    }
}