using GestionReservations.Models.Produit;

namespace GestionReservations.Models.Reservation
{
    public class ReservationVoiture : Reservation
    {
        public Produit.Voiture Voiture { get; set; }
        public int Prix => Voiture.PrixJournalier * CalculerDureeReservation();
    }
}