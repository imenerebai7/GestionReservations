using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionChambres
{
    public class AjouterChambreModel : PageModel
    {
        private readonly ChambreService _chambreService;

        [BindProperty]
        public Chambre Chambre { get; set; }

        public AjouterChambreModel()
        {
            _chambreService = new ChambreService();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _chambreService.AjouterChambre(Chambre.Description, Chambre.PrixJournalier);

            return RedirectToPage("/GestionChambres/Index");
        }
    }
}