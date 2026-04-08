using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionVoitures
{
    public class AjouterVoitureModel : PageModel
    {
        private readonly VoitureService _voitureService;

        [BindProperty]
        public Voiture voiture { get; set; }

        public AjouterVoitureModel()
        {
            _voitureService = new VoitureService();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _voitureService.AjouterVoiture(voiture.Description, voiture.PrixJournalier, voiture.Marque, voiture.AnneeFabrication);

            return RedirectToPage("/GestionVoitures/Index");
        }
    }
}