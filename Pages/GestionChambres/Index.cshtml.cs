using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GestionReservations.Models.Produit;
using GestionReservations.Services;
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
            Chambres = _serviceChambre.ConsulterChambres();
        }
    }
}
