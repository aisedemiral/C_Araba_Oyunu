namespace C_Console_Araba;

public class Sofor
{
    public string Adi { get; set; }
    public string Soyadi { get; set; }
    public long TCNo { get; set; }
    public int Parasi { get; set; }

    public Sofor SoforBilgisi()
    {
        Sofor newSofor = new Sofor();//nesne olusturduk
        Console.WriteLine("Lütfen soforun adını giriniz.");
        Adi = Console.ReadLine();
        newSofor.Adi = Adi;
        Console.WriteLine("Lütfen şöförünüzün soyadını giriniz.");
        Soyadi = Console.ReadLine();
        newSofor.Soyadi = Soyadi;
        Console.WriteLine("Lütfen şöförün TC kimlik numarasını giriniz.");
        TCNo = long.Parse(Console.ReadLine());
        newSofor.TCNo = TCNo;
        Console.WriteLine("Lütfen şöförün toplam bakiyesini giriniz:");
        Parasi = Convert.ToInt32(Console.ReadLine());
        newSofor.Parasi = Parasi;
        
        Console.WriteLine("Şöförünüzün Bilgileri\n1-ADI:{0}\n2-SOYADI:{1}\n3-TCNO:{2}\n4-BAKİYE{3}",Adi,Soyadi,TCNo,Parasi);
        return newSofor;
    }
    
    
}