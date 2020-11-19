using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace SousTitreCsProjet
{
    public class SousTitre
    {
        private const string Val = @"\d{2}:\d{2}:\d{1,2},\d{3} ?--> ?\d{2}:\d{2}:\d{1,2},\d{3}";
        public int NumST;
            public TimeSpan TempsDebut;
            public TimeSpan TempsFin;
            public string SousTitres;

            //----------------------------------------------------//
            //----------------------------------------------------//
            public SousTitre(int nb, string Tmp, string soustitres)
            {
                NumST = nb;
                SousTitres = soustitres;
                TmpE(Tmp);
            }

            //----------------------------------------------------//
            //----------------------------------------------------//
            private TimeSpan TmpA(string Tmp)
            {
                char[] Div1 = { ':', ',' };
                string[] DivTmp1 = Tmp.Split(Div1);


                return new TimeSpan(0,
                    int.Parse(DivTmp1[0]),
                    int.Parse(DivTmp1[1]),
                    int.Parse(DivTmp1[2]),
                    int.Parse(DivTmp1[3]));
            }

            //----------------------------------------------------//
            //----------------------------------------------------//
            private void TmpE(string Tmp)
            {
                Regex ST = new Regex(Val);

                if (ST.IsMatch(Tmp))
                {
                    string[] Div = { "-->", " --> " };
                TempsDebut = TmpA(Tmp.Split(Div, StringSplitOptions.None)[0]);
                TempsFin = TmpA(Tmp.Split(Div, StringSplitOptions.None)[1]);
                }
            }

        //----------------------------------------------------//
        //----------------------------------------------------//
        public async Task TmpFin() => await Task.Delay(TempsFin);

        //----------------------------------------------------//
        //----------------------------------------------------//
        public async Task Ajout() => await Task.Delay(TempsDebut);

        //----------------------------------------------------//
        //----------------------------------------------------//
        public async Task AffichageT() => await Task.Delay(TempsFin - TempsDebut);

        //----------------------------------------------------//
        //----------------------------------------------------//
        public async Task SousTitreAjouter()
            {
                await Ajout();
                Console.WriteLine(SousTitres);
                await AffichageT();   
                Console.Clear();
            }       
    }
}
