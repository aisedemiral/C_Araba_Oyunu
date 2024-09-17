namespace C_Console_Araba;

public class Benzin
{
    public int Id { get; set; }

    public string BenzinTuru { get; set; }
    public int BenzinUcreti { get; set; }

    public List<Benzin>  BenzinSecimi()
    {
        List<Benzin> BenzinListesi = new List<Benzin>();
        
        BenzinListesi.Add(new Benzin() {Id = 1,BenzinTuru = "Kurşunsuz Benzin(95 Oktan)",BenzinUcreti = 27});
        Benzin benzin1 = new Benzin();
        benzin1.BenzinTuru = " Kurşunsuz Benzin(97 Oktan)";
        benzin1.Id = 2;
        benzin1.BenzinUcreti = 29;
        BenzinListesi.Add(benzin1);
        return BenzinListesi;
    }
    
}