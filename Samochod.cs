using System;
using System.Collections.Generic;
using System.IO;

class Samochod
{
    private static List<string> DozwoloneMarki = new List<string> { "Toyota", "Audi", "Skoda", "BMW", "Volkswagen" };
    private static List<string> DozwoloneModele = new List<string> { "Corolla", "A5", "Kodiaq", "X5", "Turan" };
    private static List<int> DozwoloneRoczniki = new List<int> { 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023 };
    private static double MaksymalnyPrzebieg = 300000; // Maksymalny przebieg

    public string Marka { get; set; }
    public string Model { get; set; }
    public int RokProdukcji { get; set; }
    public double Przebieg { get; set; }
    public double Paliwo { get; set; }
    public double LicznikPrzegladow { get; set; }
    public double ZuzytePaliwo { get; private set; }

    public Samochod() { }

    public Samochod(string marka, string model, int rokProdukcji, double przebieg)
    {
        if (!DozwoloneMarki.Contains(marka))
            throw new ArgumentException("Niepoprawna marka.");
        if (!DozwoloneModele.Contains(model))
            throw new ArgumentException("Niepoprawny model.");
        if (!DozwoloneRoczniki.Contains(rokProdukcji))
            throw new ArgumentException("Niepoprawny rocznik.");
        if (przebieg < 0 || przebieg > MaksymalnyPrzebieg)
            throw new ArgumentException("Niepoprawny przebieg.");

        Marka = marka;
        Model = model;
        RokProdukcji = rokProdukcji;
        Przebieg = przebieg;

        Paliwo = 50;
        LicznikPrzegladow = 0;
        ZuzytePaliwo = 0;
    }

    public void Jedz(double dystans)
    {
        double potrzebnePaliwo = dystans / 10; // Zakładając zużycie paliwa 10l/100km
        if (Paliwo >= potrzebnePaliwo)
        {
            Przebieg += dystans;
            Paliwo -= potrzebnePaliwo;
            ZuzytePaliwo += potrzebnePaliwo;
            LicznikPrzegladow += dystans;
            Console.WriteLine($"Samochód przejechał {dystans} km. Nowy przebieg: {Przebieg} km. Pozostałe paliwo: {Paliwo} litrów. Zużyte paliwo: {ZuzytePaliwo} litrów.");
        }
        else
        {
            Console.WriteLine("Za mało paliwa, aby przejechać ten dystans.");
        }
    }

    public void WyswietlInformacje()
    {
        Console.WriteLine($"Marka: {Marka}, Model: {Model}, Rok Produkcji: {RokProdukcji}, Przebieg: {Przebieg} km, Paliwo: {Paliwo} litrów, Licznik przeglądów: {LicznikPrzegladow} km, Zużyte paliwo: {ZuzytePaliwo} litrów");
    }

    public void ZapiszDoPliku(string nazwaPliku)
    {
        using (StreamWriter writer = new StreamWriter(nazwaPliku))
        {
            writer.WriteLine(Marka);
            writer.WriteLine(Model);
            writer.WriteLine(RokProdukcji);
            writer.WriteLine(Przebieg);
            writer.WriteLine(Paliwo);
            writer.WriteLine(LicznikPrzegladow);
            writer.WriteLine(ZuzytePaliwo);
        }
    }

    public void OdczytajZPliku(string nazwaPliku)
    {
        using (StreamReader reader = new StreamReader(nazwaPliku))
        {
            Marka = reader.ReadLine();
            Model = reader.ReadLine();
            RokProdukcji = int.Parse(reader.ReadLine());
            Przebieg = double.Parse(reader.ReadLine());
            Paliwo = double.Parse(reader.ReadLine());
            LicznikPrzegladow = double.Parse(reader.ReadLine());
            ZuzytePaliwo = double.Parse(reader.ReadLine());

            // Walidacja po odczytaniu danych
            if (!DozwoloneMarki.Contains(Marka))
                throw new ArgumentException("Niepoprawna marka po odczycie z pliku.");
            if (!DozwoloneModele.Contains(Model))
                throw new ArgumentException("Niepoprawny model po odczycie z pliku.");
            if (!DozwoloneRoczniki.Contains(RokProdukcji))
                throw new ArgumentException("Niepoprawny rocznik po odczycie z pliku.");
            if (Przebieg < 0 || Przebieg > MaksymalnyPrzebieg)
                throw new ArgumentException("Niepoprawny przebieg po odczycie z pliku.");
        }
    }

    public void Tankuj(double litry)
    {
        Paliwo += litry;
        Console.WriteLine($"Samochód zatankowany o {litry} litrów. Aktualny poziom paliwa: {Paliwo} litrów.");
    }

    public void Serwis()
    {
        LicznikPrzegladow = 0;
        Console.WriteLine("Samochód przeszedł serwis. Licznik przeglądów został zresetowany.");
    }

    public void SprawdzStanTechniczny()
    {
        if (LicznikPrzegladow > 10000)
        {
            Console.WriteLine("Samochód wymaga przeglądu technicznego.");
        }
        else
        {
            Console.WriteLine("Samochód jest w dobrym stanie technicznym.");
        }
    }

    // Funkcja obliczająca zużycie paliwa na 100 km
    public void ObliczZuzyciePaliwaNa100km()
    {
        if (Przebieg == 0)
        {
            Console.WriteLine("Samochód jeszcze nie przejechał żadnego dystansu.");
            return;
        }

        double zuzyciePaliwaNa100km = (ZuzytePaliwo / Przebieg) * 100;
        Console.WriteLine($"Średnie zużycie paliwa: {zuzyciePaliwaNa100km:F2} litrów na 100 km.");
    }

    // Funkcja wydająca dźwięk
    public void WydajDzwiek()
    {
        Console.Beep();
        Console.WriteLine("Samochód wydaje dźwięk!");
    }
}

