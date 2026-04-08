using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionChambres
{
    public class SupprimerChambreModel : PageModel
    {
        private readonly ChambreService _serviceChambre;
        [BindProperty]
        public Chambre Chambre { get; set; }
        public SupprimerChambreModel()
        {
            _serviceChambre = new ChambreService();
        }
        public void OnGet(int id)
        {
            Chambre = _serviceChambre.ObtenirChambreParId(id);
        }
        public IActionResult OnPost(int id)
        {
            Chambre chambre = _serviceChambre.ObtenirChambreParId(id);
            _serviceChambre.SupprimerChambre(chambre);
            return RedirectToPage("/GestionChambres/Index");
        }
    }
}
