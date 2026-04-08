using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionVoitures
{
    public class IndexModel : PageModel
    {
        private readonly VoitureService _serviceVoiture;
        public List<Voiture> Voitures { get; set; }
        public IndexModel()
        {
            _serviceVoiture = new VoitureService();
        }
        public void OnGet()
        {
            Voitures = _serviceVoiture.ConsulterVoitures();
        }
    }
}
