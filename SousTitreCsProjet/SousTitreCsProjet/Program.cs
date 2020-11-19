using System;

namespace SousTitreCsProjet
{
    class Program
    {
        static void Main(string[] args)
        {
            Srt ST2 = new Srt();
            string Nom = "file"; //Nom du fichier de sous-titre
            string Ext = ".srt"; //Extension du fichier de sous-titre
            Console.WriteLine("Hokage, bienvenue dans le village tenebreux du sous-titre ! \n");

            ST2.Lecture(Chemin: Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SousTitreCsProjet\" + Nom + Ext);
            ST2.SousTitreObt();
            Console.Read();
        }
    }
}
