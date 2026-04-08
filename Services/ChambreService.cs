using GestionReservations.Models.Produit;
using GestionReservations.Interfaces;

namespace GestionReservations.Services
{
    public class ChambreService : IGestionChambre
    {
        private string cheminFichier = "Fichiers/Chambres.txt";
        private List<Chambre> _chambres = new List<Chambre>();

        public ChambreService()
        {
            ChargerDepuisFichier();
        }

        // --- CRUD ---

        public  void AjouterChambre(string description, int prix, string nomhotel)
        {
            Chambre chambre = new Chambre(description, prix, nomhotel);
            chambre.Id = GetNextId();
            _chambres.Add(chambre);
            SauvegarderDansFichier();
        }

        public void SupprimerChambre(Chambre chambre)
        {
            if (chambre != null)
            {
                _chambres.Remove(chambre);
                SauvegarderDansFichier();
            }
        }

        public void ModifierChambre(Chambre chambre)
        {
            var c = _chambres.FirstOrDefault(x => x.Id == chambre.Id);
            if (c != null)
            {
                c.Description = chambre.Description;
                c.PrixJournalier = chambre.PrixJournalier;
                c.NomHotel = chambre.NomHotel;
                SauvegarderDansFichier();
            }
        }

        public Chambre? ObtenirChambreParId(int id)
        {
            return _chambres.FirstOrDefault(c => c.Id == id);
        }

        public List<Chambre> ObtenirToutesChambres()
        {
            return new List<Chambre>(_chambres);
        }

        // --- Gestion fichier ---

        private int GetNextId()
        {
            if (!_chambres.Any())
                return 1;
            return _chambres.Max(c => c.Id) + 1;
        }

        private void SauvegarderDansFichier()
        {
            try
            {
                string? dossier = Path.GetDirectoryName(cheminFichier);
                if (!string.IsNullOrEmpty(dossier) && !Directory.Exists(dossier))
                {
                    Directory.CreateDirectory(dossier);
                }

                using (StreamWriter sw = new StreamWriter(cheminFichier, false))
                {
                    foreach (var chambre in _chambres)
                    {
                        sw.WriteLine($"{chambre.Id};{chambre.Description};{chambre.PrixJournalier};{chambre.NomHotel}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la sauvegarde : {ex.Message}");
            }
        }

        private void ChargerDepuisFichier()
        {
            try
            {
                if (!File.Exists(cheminFichier))
                {
                    File.WriteAllText(cheminFichier, "");
                }

                _chambres.Clear();

                using (StreamReader sr = new StreamReader(cheminFichier))
                {
                    string? ligne;
                    while ((ligne = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(ligne))
                            continue;

                        string[] champs = ligne.Split(';');
                        if (champs.Length < 4)
                            continue;

                        if (!int.TryParse(champs[0], out int id))
                            continue;
                        if (!int.TryParse(champs[2], out int prix))
                            continue;

                        string description = champs[1];
                        string nomHotel = champs[3];

                        Chambre chambre = new Chambre(description, prix, nomHotel)
                        {
                            Id = id
                        };

                        _chambres.Add(chambre);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement : {ex.Message}");
            }
        }
        public List<Chambre> ConsulterChambres()
        {
            ChargerDepuisFichier();
            return _chambres;
        }
    }
}