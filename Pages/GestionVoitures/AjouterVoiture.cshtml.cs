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
        public Voiture Voiture { get; set; }

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

            int anneeMax = DateTime.Now.Year;
            if (Voiture.AnneeFabrication < anneeMax - 10)
            {
                ModelState.AddModelError("Voiture.AnneeFabrication",
                    "La voiture ne doit pas avoir plus de 10 ans.");
                return Page();
            }

            _voitureService.AjouterVoiture(Voiture.Description, Voiture.PrixJournalier, Voiture.Marque, Voiture.AnneeFabrication);

            return RedirectToPage("/GestionVoitures/Index");
        }
    }
}