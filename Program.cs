using System;

namespace Kurnik
{
    class Program
    {
        static void Main(string[] args)
        {
            int il_kur = 200;
            double cena_paszy = 1.9; //1.9 zl/kg
            double kura_zjada = 0.2; //kg/dz
            int czas_hodowli = 180; //dni
            double cena_jajka = 0.9; //zl/szt
            double cena_kury = 18;//zl/1 kurę


            int lis_zjada = 2; //2 kury w dni nieparzyste
            int zakupy_kur = 0;
            double koszty_zak_skum = 0;
            double koszt_paszy_skum = 0;
            double koszt_paszy_dziennie = 0;
            double koszty_zakupu_kur_dziennie = 0;
            int il_jaj = 0;
            double zysk_skum = 0;
            double zysk_dzienne = 0;

            for (int i = 1; i <= czas_hodowli; i++)
            {
                zysk_dzienne = 0;

                if (i % 30 == 0)
                {
                    zakupy_kur = (int)Math.Floor((il_kur / 100.0) * 20);

                    koszty_zakupu_kur_dziennie = zakupy_kur * cena_kury;
                    koszty_zak_skum += koszty_zakupu_kur_dziennie;

                    il_kur += zakupy_kur;

                    zysk_dzienne -= koszty_zakupu_kur_dziennie;
                }

                koszt_paszy_dziennie = cena_paszy * (il_kur * kura_zjada);
                koszt_paszy_skum += koszt_paszy_dziennie;

                zysk_dzienne -= koszt_paszy_dziennie;

                if (i % 7 != 0)
                {
                    il_jaj = il_kur * 1;
                    zysk_dzienne += il_jaj * cena_jajka;
                }


                if (i % 2 == 1)
                {
                    il_kur = il_kur - lis_zjada;
                }

                if (il_kur == 200)
                {
                    Console.WriteLine("Kur znów 200 na " + i + " dzien");
                }
                
                zysk_skum += zysk_dzienne;
                if (zysk_skum > 1500 && zysk_skum < 1600)
                {
                    Console.WriteLine("Dzień: " + i + " Zysk: " + Math.Floor(zysk_skum));
                }
            }
            Console.WriteLine("Zysk po 180 dniach: " + Math.Floor(zysk_skum));
            Console.WriteLine("Skumulowany koszt paszy: " + Math.Floor(koszt_paszy_skum));
        }
    }
}
