namespace GestionReservations.Models.Produit
{
    public class Chambre : Produit
    {
        public Chambre()
        {
        }
        public Chambre(string description, int prix)
        {
            Description = description;
            PrixJournalier = prix;
        }
    }
}
