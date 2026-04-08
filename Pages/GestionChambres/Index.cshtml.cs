using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace GestionReservations.Pages.GestionChambres
{
    public class IndexModel : PageModel
    {
        private readonly ChambreService _serviceChambre;
        public List<Chambre> Chambres { get; set; }
        public IndexModel()
        {
            _serviceChambre = new ChambreService();
        }
        public void OnGet()
        {
            Chambres = _serviceChambre.ObtenirToutesChambres();
        }
    }
}
