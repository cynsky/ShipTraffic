using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipTraffic.UI
{
    public class UI
    {
        public void Menu(Dictionary<string, Action> menu)
        {
            ConsoleKeyInfo key;
            int current = 0;
            do
            {
                Console.CursorVisible = false;
                Console.Clear();
                echoMenu(menu, current);
                Console.SetCursorPosition(0, Console.WindowHeight - 3);
                Console.WriteLine("Press Enter to choose the menu item");
                Console.WriteLine("Press ESC to return to previous menu or to exit");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.UpArrow && current != 0) current--;
                if (key.Key == ConsoleKey.DownArrow && current != menu.Count - 1) current++;
                if (key.Key == ConsoleKey.Escape) { break ; }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.CursorVisible = true;
                    menu.ElementAt(current).Value();
                }
            }
            while (true);
        }
        private void echoMenu(Dictionary<string, Action> menu, int current)
        {
            int i = 0;
            foreach (var m in menu)
            {
                if (i == current) Console.Write("> ");
                else Console.Write("  ");
                Console.WriteLine(m.Key);
                ++i;
            }
        }
       
    }
}
