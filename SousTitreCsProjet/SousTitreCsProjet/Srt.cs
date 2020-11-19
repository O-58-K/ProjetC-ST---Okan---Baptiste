using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace SousTitreCsProjet
{
    public class Srt
    {
        public string Chemin;
        public List<SousTitre> Tous;
        public List<string> Lignes;
        public enum Stat { nbL1, tmp, STR, Vide }; 

        //----------------------------------------------------//
        //----------------------------------------------------//
        public void Lecture(string Chemin)
        {
            try
            {
                using var Lec = new StreamReader(Chemin);
                string Ligne;
                Lignes = new List<string>();
                while ((Ligne = Lec.ReadLine()) != null)
                {
                    Lignes.Add(Ligne);
                }

                Fichier();
            }
            catch (Exception){}
        }
        
        //----------------------------------------------------//
        //----------------------------------------------------//
        private void Fichier()
        {
            
            string Str1 = "";
            string Tmps = "";
            Tous = new List<SousTitre>();
            Stat StatFct = Stat.nbL1;


            for (int i = 0; i < Lignes.Count; i++)
            {
                string Ligne = Lignes[i];
                if (Ligne == "")
                {
                    StatFct = Stat.Vide;
                }

                int nbStr1 = -1;
                switch (StatFct)
                {
                    //----------------------------------------------------//                 
                    case Stat.nbL1:
                        _ = int.Parse(Ligne);
                        _ = StatFct++;
                        break;
                    //----------------------------------------------------//
                    case Stat.Vide:
                        SousTitre St = new SousTitre(nbStr1, Tmps, Str1);
                        if (!Tous.Contains(St))
                            Tous.Add(St);
                        StatFct = Stat.nbL1;
                        Str1 = "";
                        break;
                    //----------------------------------------------------//
                    case Stat.STR:
                        Str1 += $"{Ligne}\n";
                        break;
                    //----------------------------------------------------//
                    case Stat.tmp:
                        Tmps = Ligne;
                        StatFct++;
                        break;
                }

            }
        }

        //----------------------------------------------------//
        //----------------------------------------------------//
        public void SousTitreObt()
        {
            for (int i = Tous.Count - 1; i >= 0; i--)
            {
                SousTitre St = Tous[i];
                Task _ = St.SousTitreAjouter();
            }
        }

    }
}
