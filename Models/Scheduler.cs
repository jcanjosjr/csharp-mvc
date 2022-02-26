using System;
using System.Collections.Generic;

namespace Models
{
    public class Scheduler
    {
        // Attributes of class Scheduler.
        public static int SchedulerId = 0;
        private static List<Scheduler> Schedulers = new List<Scheduler>();
        public int Id { set; get; }
        public int IdPatient { set; get; }
        public Patient Patient { get; }
        public int IdDentist { set; get; }
        public Dentist Dentist { set; get; }
        public int IdRoom { set; get; }
        public Room Room { get; }
        public int IdProcedure { set; get; }
        public Procedure Procedure { get; }
        public DateTime Date { set; get; }
        public bool Confirm { set; get; }

        // The public constructor, will be call when Room will instantiated.
        public Scheduler(
            int IdPatient,
            int IdDentist,
            int IdRoom,
            int IdProcedure,
            DateTime Date
        ) : this(++SchedulerId, IdPatient, IdDentist, IdRoom, IdProcedure, Date)
        { }

        // The private constructor, will be call when Public where called.
        private Scheduler(
            int Id,
            int IdPatient,
            int IdDentist,
            int IdRoom,
            int IdProcedure,
            DateTime Date
        )
        {
            this.Id = Id;
        
            this.IdPatient = IdPatient;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            this.Patient = Patient.GetPatients().Find(Patient => Patient.Id == IdPatient);

            this.IdDentist = IdDentist;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            this.Dentist = Dentist.GetDentists().Find(Dentist => Dentist.Id == IdDentist);

            this.IdRoom = IdRoom;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            this.Room = Room.GetRooms().Find(Room => Room.Id == IdRoom);

            this.IdProcedure = IdProcedure;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            this.Procedure = Procedure.GetProcedures().Find(Procedure => Procedure.Id == IdProcedure);

            this.Date = Date;

            // Add a Scheduler in a List of Schedulers.
            Schedulers.Add(this);
        }

        // The method ToString of Scheduler.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Patient: {this.Patient.Name}"
                + $"\n - Dentist: {this.Dentist.Name}"
                + $"\n - Room: {this.Room.Number}"
                + $"\n - Description of Procedure: {this.Procedure.Description}"
                + $"\n - Price of Procedure: ${this.Procedure.Price}"
                + $"\n - Date: {this.Date}"
                + $"\n - Scheduled: {(this.Confirm ? "Confirm scheduler." : "Don't scheduleded.")}";
        }

        // Method to check equality of two Scheduler Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Scheduler.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Scheduler iterable = (Scheduler) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Schedulers.
        public static List<Scheduler> GetSchedulers()
        {
            return Schedulers;
        }

        // Method remove a Object Scheduler from list of Schedulers.
        public static void RemoveScheduler(Scheduler scheduler)
        {
            Schedulers.Remove(scheduler);
        }
    }
}