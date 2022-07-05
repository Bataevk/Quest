using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consol_Quest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Вы готовы начать? Нажмити любую клавишу");
            Console.ReadLine();
            Console.WriteLine("Напишите ваше имя.");
            string name = Convert.ToString(Console.ReadLine());
            Game game = new Game(name);
            game.Events(0);
            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Через некоторое время Вы приходите в себя и понимаете, что Вы в больнице.");
            Console.WriteLine("Свет слепит Вас. Вы понимаете, что это был сон.");
        }
    }
}
