using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionVoitures
{
    public class ConsulterVoitureModel : PageModel
    {
        [BindProperty]
        public Voiture Voiture { get; set; }
        private readonly VoitureService _voitureService;
        public ConsulterVoitureModel()
        {
            _voitureService = new VoitureService();
        }
        public void OnGet(int id)
        {
            Voiture = _voitureService.ObtenirVoitureParId(id);
        }
    }
}
