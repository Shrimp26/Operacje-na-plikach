using System;
using System.IO;

//Napisz program, który wczytuje z klawiatury tytuł książki oraz nazwisko autora, zapisuje te dane do pliku tekstowego library.txt,
//a następnie odczytuje je z pliku library.txt i wyświetla.

class OperacjeNaPlikach
{
    static void Main(string[] args)
    {
        Console.WriteLine("Podaj tytuł książki: ");
        string tytul = Console.ReadLine();

        Console.WriteLine("Podaj nazwisko autora: ");
        string autor = Console.ReadLine();

        string filePath = "library.txt";
        SaveDataToFile(filePath, tytul, autor);
    }

    static void SaveDataToFile(string filePath, string tytul, string autor)
    {
        try
        {
            using(StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"Tytuł: {tytul}. Autor: {autor}");
            }
            Console.WriteLine("Dane zostały zapisane do pliku");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas zapisywania danych pliku: {ex.Message}");
        }
    }

    static void ReadDataFromFile(string filePath)
    {
        try
        {
            using(StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik nie istnieje");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas odczytywania danych z pliku: {ex.Message}");
        }
    }
}
