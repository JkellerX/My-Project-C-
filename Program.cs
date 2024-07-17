class Program
{
    static void Main(string[] args)
    {
        try
        {
            Samochod mojSamochod = new Samochod();

            Console.WriteLine("Podaj markę samochodu (np.Toyota, Audi, Skoda, BMW, Volkswagen");
            mojSamochod.Marka = Console.ReadLine();

            Console.WriteLine("Podaj model samochodu (np. Corolla, A5, Kodiaq, X5, Turan");
            mojSamochod.Model = Console.ReadLine();

            Console.WriteLine("Podaj rok produkcji samochodu (np. 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023):");
            mojSamochod.RokProdukcji = int.Parse(Console.ReadLine());

            Console.WriteLine("Podaj przebieg samochodu:");
            mojSamochod.Przebieg = double.Parse(Console.ReadLine());

            // Sprawdzenie poprawności danych
            try
            {
                mojSamochod = new Samochod(mojSamochod.Marka, mojSamochod.Model, mojSamochod.RokProdukcji, mojSamochod.Przebieg);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            mojSamochod.WyswietlInformacje();

            Console.WriteLine("Podaj dystans do przejechania:");
            double dystans = double.Parse(Console.ReadLine());

            mojSamochod.Jedz(dystans);
            mojSamochod.WyswietlInformacje();

            mojSamochod.WydajDzwiek();

            // Obliczanie zużycia paliwa na 100 km
            mojSamochod.ObliczZuzyciePaliwaNa100km();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Wystąpił błąd: {e.Message}");
        }
    }
}