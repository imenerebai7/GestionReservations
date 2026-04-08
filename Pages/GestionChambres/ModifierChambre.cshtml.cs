using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionChambres
{
    public class ModifierChambreModel : PageModel
    {
        [BindProperty]
        public Chambre Chambre { get; set; }
        private readonly ChambreService _chambreService;
        public ModifierChambreModel()
        {
            _chambreService = new ChambreService();
        }
        public void OnGet(int id)
        {
            Chambre = _chambreService.ObtenirChambreParId(id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _chambreService.ModifierChambre(Chambre);
            return RedirectToPage("/GestionChambres/Index");
        }
    }
}
