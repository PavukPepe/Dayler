using Dayler_v2;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Dayler_v2
{

    internal class Program
    {
        static void Menu(List<Tips> ls)
        {
            foreach (Tips t in ls)
            {
                t.Getter_name(t);
            }
        }
        public static void Main()
        {
            Dictionary<DateTime, List<Tips>> days = new Dictionary<DateTime, List<Tips>>();
            Tips tip1 = Tips.Setter("Pepe", "Frog");
            Tips tip2 = Tips.Setter("Pepes", "Frogs");
            Tips tip3 = Tips.Setter("Pepees", "Froges");

            DateTime dt = DateTime.Now;
            days.Add(dt, new List<Tips>() { tip1, tip2, tip3 });
            days.Add(dt.AddDays(1), new List<Tips>() { tip1, tip2 });

            Console.WriteLine("Добро пожаловать в филиал говнокода МПТ.... \nНажмите любую клавишу");
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.Clear();
                Console.Clear();
                Console.WriteLine("Добро пожаловать в филиал говнокода МПТ....\nНавигация Right - Left \nДля перехода в заментки дня тыкни Enter");
                switch (key)
                {
                    case ConsoleKey.RightArrow: dt = dt.AddDays(1); break;
                    case ConsoleKey.LeftArrow: dt = dt.AddDays(-1); break;
                }
                Console.WriteLine(dt.ToString("D"));
                foreach (var day in days)
                {
                    if (day.Key == dt)
                    {

                        Menu(day.Value);
                        if (key == ConsoleKey.Enter)
                        {
                            key = ConsoleKey.B; // Косты((
                            int position = -1;
                            ConsoleKey key_arr = ConsoleKey.DownArrow;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Для выхода нажмите ESC | Для добавлениея F1");
                                Console.WriteLine(day.Key.ToString("D"));
                                Menu(day.Value);

                                switch (key_arr)
                                {
                                    case ConsoleKey.DownArrow: position++; break;
                                    case ConsoleKey.UpArrow: position--; break;
                                }
                                if (key_arr == ConsoleKey.Enter)
                                {
                                    while (key_arr != ConsoleKey.Escape)
                                    {
                                        Console.Clear();
                                        Tips.Getter(day.Value[Math.Abs(position % day.Value.Count())]);
                                        key_arr = Console.ReadKey().Key;
                                    }
                                    key_arr = ConsoleKey.B; //Костылек(((
                                    continue;
                                }
                                if (key_arr == ConsoleKey.F1)
                                {
                                    Console.WriteLine("---------------------");
                                    Console.Write("Введите название: ");
                                    string n1 = Console.ReadLine();
                                    Console.WriteLine("Введите текст заметки: ");
                                    string n2 = Console.ReadLine();
                                    day.Value.Add(Tips.Setter(n1, n2));
                                    break;
                                }
                                Console.SetCursorPosition(0, Math.Abs(position) % day.Value.Count() + 2);
                                Console.WriteLine("->");
                                key_arr = Console.ReadKey().Key;
                            } while (key_arr != ConsoleKey.Escape);
                            Console.Clear();
                            Console.WriteLine("Добро пожаловать в филиал говнокода МПТ....\nНавигация Right - Left \nДля перехода в заментки дня тыкни Enter");
                            Console.WriteLine(dt.ToString("D"));
                            Menu(day.Value);
                        }
                    }
                }
                if (key == ConsoleKey.Enter)
                {
                    days.Add(dt, new List<Tips>());
                    Console.Write("Введите название: ");
                    string n1 = Console.ReadLine();
                    Console.WriteLine("Введите текст заметки: ");
                    string n2 = Console.ReadLine();
                    days[dt].Add(Tips.Setter(n1, n2));
                    continue;
                }
                else
                    continue;
            }
        }
    }
}