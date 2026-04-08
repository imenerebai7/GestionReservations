using GestionReservations.Models.Produit;

namespace GestionReservations.Interfaces
{
    public interface IGestionVoiture
    {
        public void AjouterVoiture(string description, int prix, string marque, int anneefabrication);
        public void SupprimerVoiture(Voiture voiture);
        public void ModifierVoiture(Voiture voiture);
        public Voiture? ObtenirVoitureParId(int id);
        public List<Voiture> ObtenirToutesVoitures();
    }
}