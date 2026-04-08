using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionChambres
{
    public class ConsulterChambreModel : PageModel
    {
        [BindProperty]
        public Chambre Chambre { get; set; }
        private readonly ChambreService _chambreService;
        public ConsulterChambreModel()
        {
            _chambreService = new ChambreService();
        }
        public void OnGet(int id)
        {
            Chambre = _chambreService.ObtenirChambreParId(id);
        }
    }
}