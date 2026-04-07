namespace GestionReservations.Models.Produit
{
    public abstract class Produit
    {
        // Propriétés
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal PrixJournalier { get; set; }
    }
}