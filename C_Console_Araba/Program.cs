// motoru durdurmak için p tuşuna basın diyecek  gidip benzin seçicek ve aldığı litre kadar parasından düşücek motor tekrar çalışması içinse e tuşuna asılıcak ve süre işlemeye devam edicek.
//2 tür benzin

using System.Runtime.CompilerServices;
using System.Timers;
using C_Console_Araba;
using Microsoft.VisualBasic;
using Timer=System.Timers.Timer;

internal class Program
{
    public static void Main(string[] args)
    {
        Sofor sofor = new Sofor();
        sofor.SoforBilgisi();
        Araba araba = new Araba();
        araba = araba.ArabaBilgisi();


        Timer timer= new Timer();
        zamanlanmisgorev(araba,timer,sofor);

        timer.AutoReset=true;
        timer.Enabled = true;

        static void HesaplamaIslemleri(int toplam,Sofor sofor,Araba araba,int benzinlitre)
        {
            string devam;
            if (toplam <= sofor.Parasi)
            { 
                Console.WriteLine(" yeterli paranız vardır.işleminize devam etmek istiyor musunuz?");
                devam  = Console.ReadLine();
                if (devam == "evet")
                {
                    Console.WriteLine("ücret bakiyenizden düştü.");
                    sofor.Parasi = sofor.Parasi - toplam;
                    Console.WriteLine("kalan bakiyeniz:" + sofor.Parasi);
                    araba.DepoMiktari = araba.DepoMiktari + benzinlitre;
                    if (araba.DepoHacmi <= araba.DepoMiktari)
                    {
                        Console.WriteLine("yeni benzin depo miktarınız:" + araba.DepoMiktari);
                    }
                    else
                    {
                        Console.WriteLine("Arabanızın depo hacmi aşılmıltır .Bu kadar benzin alamazsınız paranız size geri iade edilecektir. ");
                        sofor.Parasi = sofor.Parasi + toplam;
                        Console.WriteLine("yeni bakiyeniz:"+sofor.Parasi);
                    }
                }
                else if (devam == "hayır")
                {
                    Console.WriteLine("alışverişiniz bitmiştir benzini alamadınız.");
                }
            }
            else
            {
                Console.WriteLine("pis fakir!!!!!");
            }

        }

        static void zamanlanmisgorev(Araba araba, Timer timer,Sofor sofor)
        {
            Benzin benzin = new Benzin();

            while (araba.DepoMiktari>0)
            {
                Thread.Sleep(1000);
        
                araba.DepoMiktari = araba.DepoMiktari - 1;
                Console.WriteLine(araba.DepoMiktari);
                if (araba.DepoMiktari == 10 || araba.DepoMiktari == 1)
                {
                    Console.WriteLine("Benzini deponuz azalıyor.En yakın benzinliğe gitmenizi öneririz.\nLütfen benzinliğe gitmek için 'e' tuşuna basınız");
                    string benzinlik = Console.ReadLine();
            
                    if (benzinlik == "e")
                    {
                        Console.WriteLine("benzin almak için benzinliğe gidiyorsunuz.");
                        Thread.Sleep(3000);
                        Console.WriteLine("Benzinliğe geldiniz. motorunuzuzu durdurmak için 'p' tuşuna basınız.");
                        string motor = Console.ReadLine();
                        if (motor == "p")
                        {
                            Thread.Sleep(2000);
                            Console.WriteLine("motorunuz durdu.");
                            List<Benzin> benzinler = benzin.BenzinSecimi();
                            Console.WriteLine("BENZİNLERİMİZ:");
                            foreach (var benzinitem in benzinler)
                            {
                                Console.WriteLine("benzin adı:{0} bensin ıd:{1} benzin fiyatı{2}",benzinitem.BenzinTuru,benzinitem.Id,benzinitem.BenzinUcreti);
                            }
                            Console.WriteLine("Benzininizi seçiniz:");
                            int benzinsecim = Convert.ToInt32(Console.ReadLine());
                            int benzinlitre;
                            int toplam = 0;
                            if (benzinsecim == 1) 
                            {
                                Console.WriteLine("1.benzini seçtiniz kaç litre almak istersiniz.");
                                benzinlitre = Convert.ToInt32(Console.ReadLine());
                                toplam = benzinlitre * benzinler.Where(x=>x.Id==1).LastOrDefault().BenzinUcreti;
                                Console.WriteLine("ödemeniz gereken tutar :" + toplam);
                                HesaplamaIslemleri(toplam,sofor,araba,benzinlitre);
                                Console.WriteLine("motorunzu tekrar çalıştırmak için 'e'tuşuna basınız.");
                                motor = Console.ReadLine();

                                
                            }
                            else if (benzinsecim == 2)
                            {
                                Console.WriteLine("2.benzini seçtiniz kaç litre almak istersiniz."); 
                                benzinlitre = Convert.ToInt32(Console.ReadLine());
                                toplam = benzinlitre * benzinler.Where(x=>x.Id==2).LastOrDefault().BenzinUcreti;
                                Console.WriteLine("ödemeniz gereken tutar :" + toplam );
                                HesaplamaIslemleri(toplam,sofor,araba,benzinlitre);
                                Console.WriteLine("motorunzu tekrar çalıştırmak için 'e'tuşuna basınız.");
                                motor = Console.ReadLine();
                            }
                            if (motor == "e")
                            {
                                Console.WriteLine("yola devam ediyorsunuz.İYİ YOLCULUKLAR");
                                timer.Start();
                            }

                        }
                    }

                }
                else if (araba.DepoMiktari == 0)
                {
                    Console.WriteLine("arabanız yolda kalmıştır.");
                    break;
                }
            }


        }
        Console.ReadKey();
    }
}
