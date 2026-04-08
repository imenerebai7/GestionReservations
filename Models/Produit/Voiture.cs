using System.ComponentModel.DataAnnotations;

namespace GestionReservations.Models.Produit
{
    public class Voiture : Produit
    {
        [AllowedValues("Kia", "Ford", "Mazda", "Toyota", "Hyundai", "Honda", ErrorMessage = "Les marques disponibles sont Kia,Ford,Mazda,Toyota,Hyundai et Honda !")]
        public string Marque { get; set; }
        public int AnneeFabrication { get; set; }
        public Voiture()
        {
        }
        public Voiture(string description, int prix, string marque, int anneefabrication)
        {
            Description = description;
            PrixJournalier = prix;
            Marque = marque;
            AnneeFabrication = anneefabrication;
        }
    }
}