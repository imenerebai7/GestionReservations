using GestionReservations.Models.Produit;

namespace GestionReservations.Interfaces
{
    public interface IGestionChambre
    {
        void AjouterChambre(Chambre chambre);
        void ModifierChambre(Chambre chambre);
        void SupprimerChambre(int id);
        Chambre? ObtenirChambreParId(int id);
        List<Chambre> ObtenirTousChambres();
    }
}