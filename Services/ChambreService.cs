using GestionReservations.Models.Produit;

namespace GestionReservations.Services
{
    public class ChambreService : Interfaces.IGestionChambre
    {
        // Compteur statique
        private static int compteurId = 0;
        // Propriété
        public string CheminFichier { get; set; } = @".\Fichiers\Chambres.txt";
        // Méthodes 
        void AjouterChambre(Voiture voiture)
        {
        }
        void SupprimerChambre(int id)
        {

        }
        void ModifierChambre(Voiture voiture)
        {

        }
        //Voiture? ObtenirChambreParId(int id)
        //{

        //}
        //List<Voiture> ObtenirTousChambres()
        //{

        //}
        void SauvegarderDansFichier()
        {

        }
    }
}
