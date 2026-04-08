namespace GestionReservations.Models.Produit
{
    public class Chambre : Produit
    {
        // Propriété
        public string NomHotel { get; set; }
        // Constructeurs
        public Chambre()
        {
        }
        public Chambre(string description, int prix, string nomHotel) 
        {
            Description = description;
            PrixJournalier = prix;
            NomHotel = nomHotel;
        }
    }
}
