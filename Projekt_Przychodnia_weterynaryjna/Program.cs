using System;
using System.Collections.Generic;

namespace Projekt_Przychodnia_weterynaryjna
{
    class Program
    {
        /// <summary>Defines the entry point of the application.</summary>
        static void Main()
        {
            
            //Testowanie poprawności działania programu


            //Stworzenie obiektów
            Klient klient1 = new Klient("Jan", "Kowalski", "09.06.1989", "00389674590", Osoba.Plcie.M, "508974466", "jk@gmail.com", "Basztowa 42, Kraków", "Zwierzątka");
            Klient klient2 = new Klient("Janina", "Kowalska", "09.05.1992", "00389789590", Osoba.Plcie.K, "513574409", "janinak@gmail.com", "Basztowa 42, Kraków", "Zwierzątka");

            Lekarz lekarz1 = new Lekarz("Dawid", "Nowak", "09.12.1986", "00178956435", Osoba.Plcie.M, "509678999", "dn@interia.eu", "Koty", "dr. weterynarz", 8);
            Lekarz lekarz2 = new Lekarz("Krzysztof", "Ambasada", "07.10.1983", "00178956732", Osoba.Plcie.M, "506925173", "ka@interia.eu", "Psy", "dr. weterynarz", 10);
            Lekarz lekarz3 = new Lekarz("Krystyna", "Brzyska", "09.10.1990", "00178446797", Osoba.Plcie.K, "5089258173", "kb@interia.eu", "Króliki", "dr. weterynarz", 6);
            Lekarz lekarz4 = new Lekarz("Aneta", "Gryfińska", "21.12.1988", "00178454427", Osoba.Plcie.K, "5089562173", "ag@interia.eu", "Koty", "dr. weterynarz", 8);

            Pacjent pacjent1 = new Pacjent("Felicja", "01.12.2015", Zwierze.Plcie_zwierzat.samica, "kot", "dachowiec", "czarna", "duże oczy", 1, lekarz1, klient1);
            Pacjent pacjent2 = new Pacjent("Zygi", "01.12.2015", Zwierze.Plcie_zwierzat.samiec, "kot", "dachowiec", "czarna", "duże oczy", 2, lekarz1, klient2);
            Pacjent pacjent3 = new Pacjent("Felix", "01.12.2015", Zwierze.Plcie_zwierzat.samiec, "kot", "dachowiec", "czarna", "duże oczy", 3, lekarz1, klient2);


            klient1.Dodaj_pacjenta(pacjent1);
            klient2.Dodaj_pacjenta(pacjent1);
            klient2.Dodaj_pacjenta(pacjent2);

            Console.WriteLine("Wypisanie obiektów\n");
            Console.WriteLine(lekarz1.ToString());
            Console.WriteLine(klient1.ToString());
            Console.WriteLine(klient2.ToString());
            Console.WriteLine(pacjent1.ToString());
            Console.WriteLine(pacjent2.ToString());


            //Test - Serializacja XML
            lekarz1.ZapiszXML("Lekarz.xml");
            Lekarz L2 = Lekarz.OdczytajXML("Lekarz.xml");
            klient1.ZapiszXML("Klient.xml");
            Klient K2 = Klient.OdczytajXML("Klient.xml");
            pacjent1.ZapiszXML("Pacjent.xml");
            Pacjent P2 = Pacjent.OdczytajXML("Pacjent.xml");

            Console.WriteLine("---------------");
            
            //Test sortowania 
            Zespol_lekarzy z = new Zespol_lekarzy();
            Console.WriteLine("Zespol nieposortowany: ");
            z.Dodaj_lekarza(lekarz1);
            z.Dodaj_lekarza(lekarz2);
            z.Dodaj_lekarza(lekarz3);
            z.Dodaj_lekarza(lekarz4);
            Console.WriteLine(z);

            Console.WriteLine("Zespol posortowany po nazwisku: ");
            z.Sortuj();
            Console.WriteLine(z);

            Console.WriteLine("Zespol posortowany po peselu: ");
            z.SortujPoPESEL();
            Console.WriteLine(z);

            Console.WriteLine("---------------");

            Klient lista_zwierzat = new Klient();

            lista_zwierzat.Dodaj_pacjenta(pacjent1);
            lista_zwierzat.Dodaj_pacjenta(pacjent2);
            lista_zwierzat.Dodaj_pacjenta(pacjent3);
            Console.WriteLine("Lista zwierząt nieposortowana: ");
            Console.WriteLine(lista_zwierzat.ToString2());

            Console.WriteLine("Lista zwierząt posortowana po imieniu: ");
            lista_zwierzat.Sortuj();
            Console.WriteLine(lista_zwierzat.ToString2());

            Console.WriteLine("Lista zwierząt posortowana po id: ");
            lista_zwierzat.SortujPoId();
            Console.WriteLine(lista_zwierzat.ToString2());


            Console.WriteLine("----------------");

            //Test klonowania

            Console.WriteLine("\nTest klonowania:\n");

            Lekarz l3 = lekarz1.Clone() as Lekarz;
            l3.Imie = "Marcin";
            Console.WriteLine(l3);
            Console.WriteLine(lekarz1);


            Klient k3 = klient1.Clone() as Klient;

            k3.Imie = "Damian";
            Console.WriteLine(k3);
            Console.WriteLine(klient1);

            Pacjent p3 = pacjent1.Clone() as Pacjent;

            p3.Imie = "Zygi";
            Console.WriteLine(p3);
            Console.WriteLine(pacjent1);
        }
    }
}
