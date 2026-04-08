namespace GestionReservations.Models.Reservation
{
    public class ReservationChambre : Reservation
    {
        public Produit.Chambre Chambre { get; set; }
        public int Prix => Chambre.PrixJournalier * CalculerDureeReservation();
    }
}