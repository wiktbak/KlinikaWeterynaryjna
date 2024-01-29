


using System;

namespace KlinikaWeterynaryjna
{
    public class Program
    { 
        static void ProbaTestu()
        {
            Klinika klinika = new Klinika("KLINIKA");

            Lekarz L_Wojcik = new("Wiktor", "Wójcik", EnumSpecjalizacja.kardiolog);
            Lekarz L_Mochocka = new("Karolina", "Mochocka", EnumSpecjalizacja.chirurg);
            Lekarz L_Mamczyk = new("Jakub", "Mamczyk", EnumSpecjalizacja.fizjoterapeuta);
            Lekarz L_Wloczek = new("Mateusz", "Włoczek", EnumSpecjalizacja.Ogolny);
            Lekarz L_Filus = new("Gabriel", "Filus", EnumSpecjalizacja.Ogolny);
            Lekarz L_Maciasz = new("Kinga", "Maciasz", EnumSpecjalizacja.internista);
            Lekarz L_Krzyskowski = new("Paweł", "Krzyśkowski", EnumSpecjalizacja.chirurg);

            Zwierze Roxy = new("Roxy", "Witold", "Maciasz", "6665321521", "Pies", 8);
            Zwierze Rafi = new("Rafi", "Wiktoria", "Bąk", "532357222", "Pies", 5);
            Zwierze Kropeczka = new("Kropeczka", "Marta", "Gorczyńska", "765345987", "Koń", 10);
            Zwierze Harvey = new("Harvey", "Marcin", "Mochocki", "567432456", "Kot", 3);
            Zwierze Cirilla = new("Cirilla", "Wiktoria", "Semeniuk", "987999456", "Kot", 6);
            Zwierze Loki = new("Loki", "Kamilla", "Ciach", "660767321", "Wąż", 4);
            Zwierze Fluffy = new("Fluffy", "Janusz", "Wróbel", "765666876", "Szczur", 5);
            Zwierze Tales = new("Tales", "Teresa", "Styczyńska", "324559879", "Pies", 12);
            Zwierze Burek = new("Burek", "Adam", "Małysz", "668546321", "Pies", 15);
            Zwierze Francesca = new("Francesca", "Hanna", "Wicha", "887546998", "Kot", 2);
            Zwierze Flavio = new("Flavio", "Joanna", "Krupa", "879654777", "Kot", 2);

            Termin T1 = new(new DateTime(2024, 01, 23, 15, 0, 0), true);
            Termin T2 = new(new DateTime(2024, 01, 10, 16, 30, 0), true);
            Termin T3 = new(new DateTime(2023, 01, 9, 9, 0, 0), true);
            Termin T4 = new(new DateTime(2023, 02, 28, 17, 30, 0), true);
            Termin T5 = new(new DateTime(2024, 01, 28, 11, 15, 0), true);

            Termin T6 = new(new DateTime(2024, 02, 1, 16, 0, 0), true);
            Termin T7 = new(new DateTime(2024, 02, 1, 18, 30, 0), true);
            Termin T8 = new(new DateTime(2024, 02, 1, 10, 15, 0), true);
            Termin T9 = new(new DateTime(2024, 02, 1, 7, 30, 0), true);
            Termin T10 = new(new DateTime(2024, 02, 2, 12, 30, 0), true);
            Termin T11 = new(new DateTime(2024, 02, 2, 14, 0, 0), true);
            Termin T12 = new(new DateTime(2024, 02, 2, 16, 0, 0), true);
            Termin T13 = new(new DateTime(2024, 02, 2, 10, 15, 0), true);
            Termin T14 = new(new DateTime(2024, 02, 2, 15, 0, 0), true);
            Termin T15 = new(new DateTime(2024, 02, 3, 8, 0, 0), true);
            Termin T16 = new(new DateTime(2024, 02, 3, 13, 0, 0), true);
            Termin T17 = new(new DateTime(2024, 02, 4, 8, 30, 0), true);
            Termin T18 = new(new DateTime(2024, 02, 4, 10, 0, 0), true);
            Termin T19 = new(new DateTime(2024, 02, 5, 16, 15, 0), true);
            Termin T20 = new(new DateTime(2024, 02, 6, 11, 0, 0), true);

            Termin T21 = new(new DateTime(2024, 02, 5, 11, 0, 0), true);
            Termin T22 = new(new DateTime(2024, 02, 5, 15, 0, 0), true);
            Termin T23 = new(new DateTime(2024, 02, 6, 14, 30, 0), true);
            Termin T24 = new(new DateTime(2024, 02, 6, 9, 0, 0), true);
            Termin T25 = new(new DateTime(2024, 02, 7, 11, 0, 0), true);
            Termin T26 = new(new DateTime(2024, 02, 7, 12, 15, 0), true);
            Termin T27 = new(new DateTime(2024, 02, 7, 14, 30, 0), true);
            Termin T28 = new(new DateTime(2024, 02, 8, 16, 0, 0), true);
            Termin T29 = new(new DateTime(2024, 02, 8, 11, 0, 0), true);
            Termin T30 = new(new DateTime(2024, 02, 8, 14, 30, 0), true);


            klinika.DodawanieLekarza(L_Wojcik);
            klinika.DodawanieLekarza(L_Mochocka);
            klinika.DodawanieLekarza(L_Mamczyk);
            klinika.DodawanieLekarza(L_Wloczek);
            klinika.DodawanieLekarza(L_Filus);
            klinika.DodawanieLekarza(L_Maciasz);
            klinika.DodawanieLekarza(L_Krzyskowski);

            L_Wojcik.DodawanieTerminu(T1);
            L_Mochocka.DodawanieTerminu(T2);
            L_Mamczyk.DodawanieTerminu(T3);
            L_Wloczek.DodawanieTerminu(T4);
            L_Filus.DodawanieTerminu(T5);

            L_Wojcik.DodawanieTerminu(T6);
            L_Mochocka.DodawanieTerminu(T7);
            L_Mamczyk.DodawanieTerminu(T8);
            L_Wloczek.DodawanieTerminu(T9);
            L_Filus.DodawanieTerminu(T10);
            L_Maciasz.DodawanieTerminu(T11);
            L_Krzyskowski.DodawanieTerminu(T12);
            L_Wojcik.DodawanieTerminu(T13);
            L_Mochocka.DodawanieTerminu(T14);
            L_Mamczyk.DodawanieTerminu(T15);
            L_Wloczek.DodawanieTerminu(T16);
            L_Filus.DodawanieTerminu(T17);
            L_Maciasz.DodawanieTerminu(T18);
            L_Krzyskowski.DodawanieTerminu(T19);
            L_Maciasz.DodawanieTerminu(T20);

            L_Wojcik.DodawanieTerminu(T21);
            L_Mochocka.DodawanieTerminu(T22);
            L_Mamczyk.DodawanieTerminu(T23);
            L_Wloczek.DodawanieTerminu(T24);
            L_Filus.DodawanieTerminu(T25);
            L_Maciasz.DodawanieTerminu(T26);
            L_Krzyskowski.DodawanieTerminu(T27);
            L_Wojcik.DodawanieTerminu(T28);
            L_Mochocka.DodawanieTerminu(T29);
            L_Wojcik.DodawanieTerminu(T30);

            klinika.DodawanieZwierzecia(Roxy);
            klinika.DodawanieZwierzecia(Rafi);
            klinika.DodawanieZwierzecia(Kropeczka);
            klinika.DodawanieZwierzecia(Harvey);
            klinika.DodawanieZwierzecia(Cirilla);
            klinika.DodawanieZwierzecia(Loki);
            klinika.DodawanieZwierzecia(Fluffy);
            klinika.DodawanieZwierzecia(Tales);
            klinika.DodawanieZwierzecia(Burek);
            klinika.DodawanieZwierzecia(Francesca);
            klinika.DodawanieZwierzecia(Flavio);


            Wizyta wizyta_1 = new(L_Wojcik, Roxy, new DateTime(2024, 01, 23, 15, 0, 0), "Gorączka");
            Wizyta wizyta_2 = new(L_Mochocka, Rafi, new DateTime(2024, 01, 10, 16, 30, 0), "Kastracja");
            Wizyta wizyta_3 = new(L_Mamczyk, Kropeczka, new DateTime(2023, 01, 9, 9, 0, 0), "Szczepienie przeciw wściekliznie");
            Wizyta wizyta_4 = new(L_Wloczek, Harvey, new DateTime(2023, 02, 28, 17, 30, 0), "Złamanie łapy");
            Wizyta wizyta_5 = new(L_Filus, Roxy, new DateTime(2024, 01, 28, 11, 15, 0), "Problemy żołądkowe");
            Wizyta wizyta_6 = new(L_Wojcik, Cirilla, new DateTime(2024, 02, 1, 16, 0, 0), "Wścieklizna");
            Wizyta wizyta_7 = new(L_Mochocka, Rafi, new DateTime(2024, 02, 1, 18, 30, 0), "Gorączka");
            Wizyta wizyta_8 = new(L_Mamczyk, Loki, new DateTime(2024, 02, 1, 10, 15, 0), "Wizyta kontrolna");
            Wizyta wizyta_9 = new(L_Wloczek, Fluffy, new DateTime(2024, 02, 1, 7, 30, 0), "Szczepienie przeciw tężcowi");
            Wizyta wizyta_10 = new(L_Filus, Roxy, new DateTime(2024, 02, 2, 12, 30, 0), "Wizyta kontrolna");
            Wizyta wizyta_11 = new(L_Maciasz, Harvey, new DateTime(2024, 02, 2, 14, 0, 0), "Problemy żołądkowe");
            Wizyta wizyta_12 = new(L_Krzyskowski, Cirilla, new DateTime(2024, 02, 2, 16, 0, 0), "Szczepienie przeciw wściekliznie");
            Wizyta wizyta_13 = new(L_Wojcik, Rafi, new DateTime(2024, 02, 2, 10, 15, 0), "Złamanie łapy");
            Wizyta wizyta_14 = new(L_Mochocka, Kropeczka, new DateTime(2024, 02, 2, 15, 0, 0), "Wizyta kontrolna");
            Wizyta wizyta_15 = new(L_Mamczyk, Roxy, new DateTime(2024, 02, 3, 8, 0, 0), "Szczepienie przeciw tężcowia");
            Wizyta wizyta_16 = new(L_Wloczek, Tales, new DateTime(2024, 02, 3, 13, 0, 0), "Wizyta kontrolna");
            Wizyta wizyta_17 = new(L_Filus, Burek, new DateTime(2024, 02, 4, 8, 30, 0), "Problemy żołądkowe");
            Wizyta wizyta_18 = new(L_Maciasz, Harvey, new DateTime(2024, 02, 4, 10, 0, 0), "Szczepienie przeciw wściekliznie");
            Wizyta wizyta_19 = new(L_Krzyskowski, Francesca, new DateTime(2024, 02, 5, 16, 15, 0), "Szczepienie przeciw tężcowi");
            Wizyta wizyta_20 = new(L_Maciasz, Flavio, new DateTime(2024, 02, 6, 11, 0, 0), "Wizyta kontrolna");


            klinika.DodawanieWizyty(wizyta_1);
            klinika.DodawanieWizyty(wizyta_2);
            klinika.DodawanieWizyty(wizyta_3);
            klinika.DodawanieWizyty(wizyta_4);
            klinika.DodawanieWizyty(wizyta_5);
            klinika.DodawanieWizyty(wizyta_6);
            klinika.DodawanieWizyty(wizyta_7);
            klinika.DodawanieWizyty(wizyta_8);
            klinika.DodawanieWizyty(wizyta_9);
            klinika.DodawanieWizyty(wizyta_10);
            klinika.DodawanieWizyty(wizyta_11);
            klinika.DodawanieWizyty(wizyta_12);
            klinika.DodawanieWizyty(wizyta_13);
            klinika.DodawanieWizyty(wizyta_14);
            klinika.DodawanieWizyty(wizyta_15);
            klinika.DodawanieWizyty(wizyta_16);
            klinika.DodawanieWizyty(wizyta_17);
            klinika.DodawanieWizyty(wizyta_18);
            klinika.DodawanieWizyty(wizyta_19);
            klinika.DodawanieWizyty(wizyta_20);

            //L_Wojcik.WypiszHarmonogram();
            //klinika.WypiszOdbyteWizytyZwierzecia(Roxy);
            //klinika.WypiszOdbyteWizytyZwierzecia(Rafi);

            klinika.ZapiszXML("Klinika.xml");
            Klinika? klinika2 = Klinika.OdczytXml("Klinika.xml");
            //Console.WriteLine(klinika2);

        }

        static void Main(string[] args)
        {
            ProbaTestu();
        }
    }
   

}
