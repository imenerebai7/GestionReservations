using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionVoitures
{
    public class SupprimerVoitureModel : PageModel
    {
        private readonly VoitureService _serviceVoiture;
        [BindProperty]
        public Voiture Voiture { get; set; }
        public SupprimerVoitureModel()
        {
            _serviceVoiture = new VoitureService();
        }
        public void OnGet(int id)
        {
            Voiture = _serviceVoiture.ObtenirVoitureParId(id);
        }
        public IActionResult OnPost(int id)
        {
            Voiture voiture = _serviceVoiture.ObtenirVoitureParId(id);
            _serviceVoiture.SupprimerVoiture(voiture);
            return RedirectToPage("/GestionVoitures/Index");
        }
    }
}