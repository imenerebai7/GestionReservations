using System.ComponentModel.DataAnnotations;

namespace GestionReservations.Models.Produit
{
    public abstract class Produit
    {
        // Propriétés
        public int Id { get; set; }
        [StringLength(500, ErrorMessage = "Lz description doit au maximum avoir 500 caractères ! ")]
        [Required(ErrorMessage = "La description est obligatoire ! ")]
        public string Description { get; set; }
        [Range(0, 500, ErrorMessage = "Le prix doit être entre 0 et 500 ! ")]
        public int PrixJournalier { get; set; }
    }
}