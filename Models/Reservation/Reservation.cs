namespace GestionReservations.Models.Reservation
{
    public abstract class Reservation
    {
        // Propriétés
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin {  get; set; }
        // Méthodes 
        public int CalculerDureeReservation()
        {
            return (DateFin - DateDebut).Days + 1;
        }
    }
}