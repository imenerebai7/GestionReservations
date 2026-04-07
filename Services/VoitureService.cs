using GestionReservations.Models.Produit;

namespace GestionReservations.Services
{
    public class VoitureService : Interfaces.IGestionVoiture
    {
        // Compteur statique
        private static int compteurId = 0;
        // Propriété
        public string CheminFichier { get; set; } = @".\Fichiers\Voitures.txt";
        // Méthodes 
        void AjouterVoiture(Voiture voiture)
        {
        }
        void SupprimerVoiture(int id)
        {

        }
        void ModifierVoiture(Voiture voiture)
        {

        }
        //Voiture? ObtenirVoitureParId(int id)
        //{

        //}
        //List<Voiture> ObtenirTousVoitures()
        //{

        //}
        void SauvegarderDansFichier()
        {

        }
    }
}
