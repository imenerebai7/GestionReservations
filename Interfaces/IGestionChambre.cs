using GestionReservations.Models.Produit;

namespace GestionReservations.Interfaces
{
    public interface IGestionChambre
    {
        public void AjouterChambre(string description, int prix);
        public void SupprimerChambre(Chambre chambre);
        public void ModifierChambre(Chambre chambre);
        public Chambre? ObtenirChambreParId(int id);
        public List<Chambre> ObtenirToutesChambres();
    }
}