using GestionReservations.Models.Produit;
using GestionReservations.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GestionReservations.Services
{
    public class VoitureService : IGestionVoiture
    {
        private string cheminFichier = @".\Fichiers\Voitures.txt";
        private List<Voiture> _voitures = new List<Voiture>();

        public VoitureService()
        {
            ChargerDepuisFichier();
        }

        // --- CRUD ---

        public void AjouterVoiture(string description, int prix, string marque, int anneefabrication)
        {
            Voiture voiture = new Voiture(description, prix, marque, anneefabrication);
            voiture.Id = GetNextId();
            _voitures.Add(voiture);
            SauvegarderDansFichier();
        }

        public void SupprimerVoiture(Voiture voiture)
        {
            if (voiture != null)
            {
                _voitures.Remove(voiture);
                SauvegarderDansFichier();
            }
        }

        public void ModifierVoiture(Voiture voiture)
        {
            var v = _voitures.FirstOrDefault(x => x.Id == voiture.Id);
            if (v != null)
            {
                v.Description = voiture.Description;
                v.PrixJournalier = voiture.PrixJournalier;
                v.Marque = voiture.Marque;
                v.AnneeFabrication = voiture.AnneeFabrication;
                SauvegarderDansFichier();
            }
        }

        public Voiture? ObtenirVoitureParId(int id)
        {
            return _voitures.FirstOrDefault(v => v.Id == id);
        }

        public List<Voiture> ObtenirToutesVoitures()
        {
            return _voitures;
        }

        // --- Gestion fichier ---

        private int GetNextId()
        {
            if (!_voitures.Any())
                return 1;
            return _voitures.Max(v => v.Id) + 1;
        }

        private void SauvegarderDansFichier()
        {
            try
            {
                string? dossier = Path.GetDirectoryName(cheminFichier);
                if (!string.IsNullOrEmpty(dossier) && !Directory.Exists(dossier))
                    Directory.CreateDirectory(dossier);

                using (StreamWriter sw = new StreamWriter(cheminFichier, false))
                {
                    foreach (var voiture in _voitures)
                    {
                        sw.WriteLine($"{voiture.Id};{voiture.Description};{voiture.PrixJournalier};{voiture.Marque};{voiture.AnneeFabrication}");
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
                    File.WriteAllText(cheminFichier, "");

                _voitures.Clear();

                using (StreamReader sr = new StreamReader(cheminFichier))
                {
                    string? ligne;
                    while ((ligne = sr.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(ligne))
                            continue;

                        string[] champs = ligne.Split(';');
                        if (champs.Length < 5)
                            continue;

                        if (!int.TryParse(champs[0], out int id))
                            continue;
                        if (!int.TryParse(champs[2], out int prix))
                            continue;
                        if (!int.TryParse(champs[4], out int annee))
                            continue;

                        string description = champs[1];
                        string marque = champs[3];

                        Voiture voiture = new Voiture
                        {
                            Id = id,
                            Description = description,
                            PrixJournalier = prix,
                            Marque = marque,
                            AnneeFabrication = annee
                        };

                        _voitures.Add(voiture);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du chargement : {ex.Message}");
            }
        }
        public List<Voiture> ConsulterVoitures()
        {
            ChargerDepuisFichier();
            return _voitures;
        }
    }
}