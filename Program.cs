using System;

namespace PocetZnaku
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] selected_array;
            if (args.Length > 0) // Pokud je zadán argument a je platný, nastaví se nové pole.
            {
               selected_array = Arrays(args[0]);
            }
            else // Pokud není před spuštěním zadán argument, zvolí se abeceda s malými a velkými písmeny.
            {
                selected_array = Arrays("-a");
            }
            
            bool work = true;
            while (work) // Cyklus se opakuje dokud uživatel neopustí program (při metodě Exit musí tvolit možnost a nebo ano pro vypnutí).
            {
                Init(selected_array);
                work = Exit();
            }
        }

        static void Init(string [] selected_array) // Funkce která vypisuje uživateli všechny spočítané písmena v abecedním pořadí využitím funkce Count (jádro aplikace).
        {
            Console.WriteLine("Zadejte větu:");
            string znaky = Console.ReadLine();

            int pocet_pismen = 0;

            for (int i = 0; i < selected_array.Length; i++) // Pro každý jeden cyklus se vybere další písmeno z pole selected_array, do proměnné pocet_pismen se uloží počet výskytů aktuálně počítaného písmene a pokud NENÍ roven nule, vypíše počet výskytů daného písmene polečně se samostatným znakem.
            {
                pocet_pismen = Count(znaky, selected_array[i]);

                if (pocet_pismen != 0)
                {
                    Console.WriteLine("{0} - {1}", selected_array[i], pocet_pismen);
                    pocet_pismen = 0;
                }
            }
        }

        static int Count(string input_string, string input_character) // Funkce spočítá počet výskytů zadaného znaku (input_character) ze zadaného řetězce (input_string).
        {
            int occurrences = 0;

            for (int i = 0; i < input_string.Length; i++)
            {
                string input_string_single = input_string[i].ToString();

                if (input_string_single.Contains(input_character))
                {
                    occurrences++;
                }
            }

            return occurrences;
        }
        static bool Exit() // Funkce se ukončí nebo pokračuje při rozhodnutí uživatele.
        {
            bool work = true;
            bool exit_invalid = false;
            do
            {
                Console.WriteLine("Přejete si odejít?\nStiskněte 'a' pro ukončení aplikace nebo 'n' pro zadání nové věty");
                string volba = Console.ReadLine();
                volba.ToLower();
                switch (volba)
                {
                    case "n":
                    case "ne":
                        exit_invalid = false;
                        break;

                    case "a":
                    case "ano":
                        exit_invalid = false;
                        work = false;
                        break;

                    default:
                        Console.WriteLine("Neplatná volba");
                        exit_invalid = true;
                        break;
                }
            } while (exit_invalid);
            return work;
        }

        static string[] Arrays(string arr_choice) // Funkce vrátí zvolené pole pomocí argumentu při spuštění aplikace.
        {
            string[] lower_alpha = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string[] upper_alpha = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] alpha = new string[upper_alpha.Length + lower_alpha.Length]; // Deklarace pole alpha s velikostí 52 (Součet délek polí upper_alpha a lower_alpha)
            upper_alpha.CopyTo(alpha, 0);
            lower_alpha.CopyTo(alpha, upper_alpha.Length); // Přidá pole lower_alpha začínajíci na indexu 26 (Velké "z" je na indexu 25)(Vzdálenost pole upper_alpha)
            string[] num = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            switch (arr_choice)
            {
                case "-u":
                case "-U":
                    return upper_alpha;
                    break;
                case "-l":
                case "-L":
                    return lower_alpha;
                    break;
                case "-a":
                case "-A":
                    return alpha;
                    break;
                case "-n":
                case "-N":
                    return num;
                    break;
                default:
                    return lower_alpha;
                    break;
            }
        }
    }
}
