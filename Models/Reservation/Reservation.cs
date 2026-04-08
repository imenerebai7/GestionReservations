namespace GestionReservations.Models.Reservation
{
    public abstract class Reservation
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        private static int compteurId = 0;
        public Reservation()
        {
            compteurId++;
            Id = compteurId;
        }
        public int CalculerDureeReservation()
        {
            return (DateFin - DateDebut).Days + 1;
        }
        public void ValiderDates()
        {
            if (DateDebut < DateTime.Today)
            {
                throw new InvalidOperationException("La date de début doit être aujourd'hui ou ultérieure.");
            }

            if (DateFin < DateDebut)
            {
                throw new InvalidOperationException("La date de fin doit être supérieure ou égale à la date de début.");
            }
        }
    }
}