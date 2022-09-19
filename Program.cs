using System;

namespace AnteckningsBok

{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Deklarerar en vektorlista som sparar varje enskild anteckning
            List<string[]> anteckningsBok = new List<string[]>();

            /* Deklarerar [on] och tilldelar värdet true
               medans [on] är true så körs while-loopen */
            bool on = true;
            while (on)
            {
                Console.Clear();

                // Menyn skrivs ut
                Console.WriteLine("Arvids anteckningar\n");
                Console.WriteLine("[1] Skriv en ny anteckning\n" +
                                  "[2] Visa alla anteckningar\n" +
                                  "[3] Sök efter en anteckning\n" +
                                  "[4] Avsluta\n" +
                                  "[5] Radera innehåll");

                /* TryParse används ifall användaren vid menyvalet skriver in något
                   som inte kan konverteras till en int, exempelvis bokstäver */
                Int32.TryParse(Console.ReadLine(), out int menyVal);
                switch (menyVal)
                {
                    case 1:

                        // Deklarerar en strängvektor med 3 element där info från varje anteckning sparas.
                        // Första vektorn innehåller titeln, andra vektorn själva anteckningen och tredje vektorn datumet det skrevs
                        string[] anteckning = new string[3];

                        Console.Clear();
                        Console.WriteLine("Skriv en titel:");

                        // Användaren får skriva in en titel
                        anteckning[0] = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Skriv ditt inlägg:");

                        // Användaren skriver in sin anteckning
                        anteckning[1] = Console.ReadLine();
                        Console.Clear();

                        // Datum och tiden för anteckningen sparas ned med DateTime.Now
                        // ToString() gör att datumet konverteras till en sträng (behövs eftersom att det är en sträng-vektor den sparas ned till)
                        anteckning[2] = DateTime.Now.ToString();
                        Console.Clear();
                        // sparar ner vektorn anteckning till listan anteckningsBok
                        anteckningsBok.Add(anteckning);

                        Console.WriteLine("Inlägget har sparats!");
                        break;
                    case 2:

                        Console.Clear();

                        // Om längden på listan är mindre än 1, alltså helt tom så körs koden i if-strukturen
                        if (anteckningsBok.Count < 1)
                        {
                            Console.WriteLine("Det finns inga sparade anteckningar");
                        }

                        // For-loopen går igenom anteckningsBok listan och kör koden för varje element i listan 
                        for (int i = 0; i < anteckningsBok.Count; i++)
                        {
                            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");

                            // Skriver ut titeln samt indexnumret + 1 (tydligare för användaren att första inlägget heter 1 istället för dess faktiska indexnummer 0)
                            Console.WriteLine("Inlägg #" + (i + 1) + ": " + anteckningsBok[i][0]);

                            // Skriver ut själva inlägget
                            Console.WriteLine(anteckningsBok[i][1]);

                            // Skriver ut datum och tid när inlägget skrevs
                            Console.WriteLine(anteckningsBok[i][2]);

                        }
                        break;
                    case 3:
                        // Kallar på metoden Sökning
                        Sökning();

                        break;
                    case 4:

                        Console.Clear();
                        Console.WriteLine("Programmet avslutas.");

                        // Tilldelar värdet false till [on] och vi går därför ur while-loopen/programmet avslutas
                        on = false;
                        break;
                    case 5:

                        Console.Clear();

                        // Om längden på listan är mindre än 1 (alltså tom) så skrivs meddelande i if-strukturen ut
                        if (anteckningsBok.Count < 1)
                        {
                            Console.WriteLine("Det finns inga sparade anteckningar");
                        }
                        // om längden på listan är 1 eller mer så kallar vi på metoden RaderaInlägg
                        else
                        {
                            // kallar på metoden RaderaInlägg
                            RaderaInlägg();
                        }
                        break;
                    default:

                        Console.Clear();

                        // Om användaren skriver något annat än menyvalen 1 till 5 skrivs nedan ut
                        Console.WriteLine("Välj mellan 1 till 5");
                        break;
                }
                Console.WriteLine("\nTryck ENTER");
                Console.ReadLine();

            }
            //här skapar vi metoden Sökning
            void Sökning()
            {
                Console.Clear();
                Console.WriteLine("Sök efter titeln på en anteckning:");

                // användarens input sparas till variabeln sökOrd
                string sökOrd = Console.ReadLine();
                Console.Clear();
                bool avPå = false;

                // Om det finns mindre än 1 element i listan anteckningsBok så körs koden i if-strukturen
                if (anteckningsBok.Count < 1)
                {
                    Console.WriteLine("Det finns inga anteckningar sparade");
                }

                // for-loopen går igenom alla element i anteckningsBok och jämför sökOrd med element 0 i vektorn  på alla inlägg
                for (int i = 0; i < anteckningsBok.Count; i++)
                {

                    // Jämför [sökOrd] med index 0 i anteckningsvektorn, om dom stämmer överens/argumentet är true så körs koden i if-strukturen
                    if (sökOrd.ToUpper() == anteckningsBok[i][0].ToUpper())
                    {
                        avPå = true;
                        Console.WriteLine("Det fanns en matchande anteckning!\n");
                        Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");

                        // Skriver ut titeln samt indexnumret + 1
                        Console.WriteLine("Inlägg #" + (i + 1) + ": " + anteckningsBok[i][0]);

                        // Skriver ut själva inlägget
                        Console.WriteLine(anteckningsBok[i][1]);

                        // Skriver ut datum och tid när inlägget skrevs
                        Console.WriteLine(anteckningsBok[i][2]);
                    }
                    // Koden i else-strukturen körs om sökOrd inte matchar någon sparad titel 
                    else
                    {
                        Console.WriteLine("Sökningen matchade ingen anteckning");
                        // break; Detta gör att sökningen hoppar ur loopen direkt om inte 1a sökningen matchade input. 
                    }
                }
            }
            // Skapar metod för att radera inlägg
            void RaderaInlägg()
            {

                Console.WriteLine("[1] Radera ett specifikt inlägg\n[2] Radera alla inlägg");

                /* TryParse används ifall användaren vid menyvalet skriver in något
                   som inte kan konverteras till en int, exempelvis bokstäver */
                Int32.TryParse(Console.ReadLine(), out int val);

                switch (val)
                {
                    case 1:
                        Console.WriteLine("Skriv in numret på det inlägg du vill ta bort(står innan titeln när man söker efter ett inlägg)");

                        // användarens input sparas till int radera
                        if (Int32.TryParse(Console.ReadLine(), out int radera))
                        {
                            /* RemoveAt metoden används för att ta bort det inlägg användaren har valt
                               lade till -1 så att användaren kan skriva 1 istället för 0 om man vill ta bort första inlägget i listan*/
                            anteckningsBok.RemoveAt(radera - 1);
                            Console.WriteLine("Inlägg #" + radera + " togs bort");
                        }
                        else
                        {
                            // Felmeddelande om användaren skriver in någonting annat än 1 eller 2
                            Console.WriteLine("Du måste välja mellan 1 och 2");
                        }
                        break;

                    case 2:
                        // Metoden Clear används för att rensa hela anteckningsBok listan
                        anteckningsBok.Clear();
                        Console.WriteLine("Alla anteckningar har raderats");
                        break;
                }

            }
        }
    }
}
