using GestionReservations.Models.Produit;

namespace GestionReservations.Interfaces
{
    public interface IGestionVoiture
    {
        void AjouterVoiture(Voiture voiture);
        void SupprimerVoiture(int id);
        void ModifierVoiture(Voiture voiture);
        Voiture? ObtenirVoitureParId(int id);
        List<Voiture> ObtenirTousVoitures();
        void SauvegarderDansFichier();
    }
}