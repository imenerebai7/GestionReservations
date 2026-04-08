using GestionReservations.Models.Produit;
using GestionReservations.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionReservations.Pages.GestionVoitures
{
    public class ModifierVoitureModel : PageModel
    {
        [BindProperty]
        public Voiture Voiture { get; set; }
        private readonly VoitureService _voitureService;
        public ModifierVoitureModel()
        {
            _voitureService = new VoitureService();
        }
        public void OnGet(int id)
        {
            Voiture = _voitureService.ObtenirVoitureParId(id);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int anneeMax = DateTime.Now.Year;
            if (Voiture.AnneeFabrication < anneeMax - 10)
            {
                ModelState.AddModelError("Voiture.AnneeFabrication",
                    "La voiture ne doit pas avoir plus de 10 ans.");
                return Page();
            }

            _voitureService.ModifierVoiture(Voiture);
            return RedirectToPage("/GestionVoitures/Index");
        }
    }
}
