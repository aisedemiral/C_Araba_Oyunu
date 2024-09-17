namespace C_Console_Araba;

public class Araba:Timer
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int Yili { get; set; }
    public int DepoHacmi { get; set; }
    public int DepoMiktari { get; set; }

    public Araba ArabaBilgisi()
    {
        Araba newaraba = new Araba();
        Console.WriteLine("Arabanızın markasını giriniz:");
        Marka = Console.ReadLine();
        newaraba.Marka = Marka;
        Console.WriteLine("Arabanızın modelini giriniz:");
        Model = Console.ReadLine();
        newaraba.Model = Model;
        Console.WriteLine("Arabanızın yılını giriniz: ");
        Yili = Convert.ToInt32(Console.ReadLine());
        newaraba.Yili = Yili;
        Console.WriteLine("Aabanızın deposunun benzin hacmini giriniz:");
        DepoHacmi = Convert.ToInt32(Console.ReadLine());
        newaraba.DepoHacmi = DepoHacmi;
        Console.WriteLine("Arabanızın deposunda kalan benzin depo miktarını giriniz:");
        DepoMiktari = Convert.ToInt32(Console.ReadLine());
        newaraba.DepoMiktari = DepoMiktari;

        Console.WriteLine("Arabanızın Bilgileri\n 1-Arabanızın Markası:{0}\n 2-Arabanızın Modeli:{1}\n 3-Arabanızın Yılı:{2}\n 4-Arabanızın Depo Hacmi:{3}\n 5- Arabanızın Depo Miktarı:{4}",Marka,Model,Yili,DepoHacmi,DepoMiktari);
        return newaraba;
    }
    
}