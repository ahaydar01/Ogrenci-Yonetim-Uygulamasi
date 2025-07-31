using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Ogrenci> ogrenciler = new List<Ogrenci>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nÖğrenci Yönetim Uygulamasına Hoş Geldiniz!");
            Console.WriteLine("Lütfen bir işlem seçiniz:");
            Console.WriteLine("1-  Öğrenci Ekle  (E)");
            Console.WriteLine("2-  Öğrenci Sil   (S)");
            Console.WriteLine("3-  Öğrenci Listele (L)");
            Console.WriteLine("4-  Çıkış         (X)");

            string secim = SecimAl();

            switch (secim)
            {
                case "1":
                case "E":
                    OgrenciEkle();
                    break;

                case "2":
                case "S":
                    OgrenciSil();
                    break;

                case "3":
                case "L":
                    OgrenciListele();
                    break;

                case "4":
                case "X":
                    Console.WriteLine("Programdan çıkılıyor. İyi günler!");
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static string SecimAl()
    {
        string[] gecerliSecimler = { "1", "2", "3", "4", "E", "S", "L", "X" };
        int deneme = 0;

        while (deneme < 10)
        {
            Console.Write("Seçiminiz: ");
            string giris = Console.ReadLine().ToUpper();

            if (gecerliSecimler.Contains(giris))
                return giris;

            Console.WriteLine("Hatalı giriş yapıldı.");
            deneme++;
        }

        Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
        Environment.Exit(0);
        return null; 
    }

    static void OgrenciEkle()
    {
        Console.WriteLine("\n" + (ogrenciler.Count + 1) + ". Öğrenci Ekleme İşlemi:");

        Ogrenci o = new Ogrenci();

        Console.Write("Öğrenci Adı: ");
        string ad = Console.ReadLine();
        o.Ad = char.ToUpper(ad[0]) + ad.Substring(1).ToLower();

        Console.Write("Öğrenci Soyadı: ");
        string soyad = Console.ReadLine();
        o.Soyad = char.ToUpper(soyad[0]) + soyad.Substring(1).ToLower();

        int no;
        do
        {
            Console.Write("Öğrenci Numarası: ");
            while (!int.TryParse(Console.ReadLine(), out no))
            {
                Console.Write("Geçerli bir numara girin: ");
            }

            if (ogrenciler.Any(x => x.OgrenciNo == no))
            {
                Console.WriteLine("Bu numara zaten kayıtlı. Lütfen farklı bir numara giriniz.");
            }

        } while (ogrenciler.Any(x => x.OgrenciNo == no));

        o.OgrenciNo = no;

        Console.Write("Öğrenci Şubesi: ");
        o.Sube = Console.ReadLine();

        Console.Write("Öğrenciyi eklemek istediğinize emin misiniz? (E/H): ");
        string onay = Console.ReadLine().ToUpper();

        if (onay == "E")
        {
            ogrenciler.Add(o);
            Console.WriteLine(" Öğrenci başarıyla eklendi!");
        }
        else
        {
            Console.WriteLine(" Ekleme iptal edildi.");
        }
    }

    static void OgrenciSil()
    {
        if (ogrenciler.Count == 0)
        {
            Console.WriteLine("Listede silinecek öğrenci yok.");
            return;
        }

        Console.Write("Silmek istediğiniz öğrencinin numarasını girin: ");
        if (!int.TryParse(Console.ReadLine(), out int no))
        {
            Console.WriteLine("Geçersiz numara girdiniz.");
            return;
        }

        var ogr = ogrenciler.FirstOrDefault(x => x.OgrenciNo == no);

        if (ogr == null)
        {
            Console.WriteLine("Numarası " + no + " olan öğrenci bulunamadı.");
        }
        else
        {
            Console.WriteLine("\n Öğrenci Bilgileri:");
            Console.WriteLine("Ad       : " + ogr.Ad);
            Console.WriteLine("Soyad    : " + ogr.Soyad);
            Console.WriteLine("Numara   : " + ogr.OgrenciNo);
            Console.WriteLine("Şube     : " + ogr.Sube);

            Console.Write("\nSilmek istediğinize emin misiniz? (E/H): ");
            string onay = Console.ReadLine().ToUpper();

            if (onay == "E")
            {
                ogrenciler.Remove(ogr);
                Console.WriteLine(" Öğrenci başarıyla silindi.");
            }
            else
            {
                Console.WriteLine(" Silme işlemi iptal edildi.");
            }
        }
    }

    static void OgrenciListele()
    {
        if (ogrenciler.Count == 0)
        {
            Console.WriteLine("Gösterilecek öğrenci yok.");
            return;
        }

        Console.WriteLine("\n Öğrenci Listesi:\n");

        Console.WriteLine(
            "No".PadLeft(2) +
            " | " + "Ad".PadRight(15) +
            " | " + "Soyad".PadRight(15) +
            " | " + "Numara".PadRight(10) +
            " | " + "Şube".PadRight(6)
        );

        Console.WriteLine(new string('-', 60));

        int index = 1;
        foreach (var ogr in ogrenciler)
        {
            Console.WriteLine(
                index.ToString().PadLeft(2) +
                " | " + ogr.Ad.PadRight(15) +
                " | " + ogr.Soyad.PadRight(15) +
                " | " + ogr.OgrenciNo.ToString().PadRight(10) +
                " | " + ogr.Sube.PadRight(6)
            );
            index++;
        }
    }
}

class Ogrenci
{
    public string Ad;
    public string Soyad;
    public int OgrenciNo;
    public string Sube;
}
