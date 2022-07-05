using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consol_Quest
{
    internal class Game
    {
        public bool rock = false;
        public bool bird = false;

        public bool key = false;
        public bool hata = false;
        int k;

        int f=0;
        bool f1 = false;
        bool f2 = false;
        bool f3 = false;


        public string name { get; set; }

        public Game(string name)
        {
            this.name = name;
        }
        public void Events(int loc)
        {
            switch (loc)
            {
                case 0:
                    Console.WriteLine("Вы стоити перед закрытыми воротами кладбища. Для того, чтобы попасть внутрь, вам необходимо найти ключ от ворот.");
                    Actions(0, false);
                    Events(1);
                    break;
                case 1:
                    Console.WriteLine("Вы зашли на территорию кладбища. Впереди вас находилась не большая сторожевая хата, а также поворот налево, ведущий к покоям местных обитателей кладбища и их надгробиям.");
                    Console.WriteLine("Некоторое зловоние притягивало вас туда, словно хотело привести вас к себе.");
                    Actions(1, false);
                    if (k == 0) Events(2);
                    else Events(3);
                    break;
                case 2:
                    Console.WriteLine("Перед вами пыльная комната с кучей хлама, инструментов и орудия. Комната немного освещена.");
                    Actions(2, false);
                    Events(1);
                    break;
                case 3:
                    Console.WriteLine("Вы чувствуете, как зловоние усиливается. Вы осматриваете три рядом стоящих надгробия, но не можете разгледеть их из далека.");
                    Actions(3, false);
                    Events(4);
                    break;
                case 4:
                    Console.WriteLine("Вы нашли свою могилу. Она давно заросшая. Вы в недоумении спрашиваете себя - 'Сколько времени уже прошло?'");
                    Actions(4, false);

                    break;

            }
        }

        public void Actions(int locka, bool complied)
        {
            switch (locka)
            {
                case 0:
                    while (complied == false)
                    {
                        Console.WriteLine("(1) - осмотреться, (2) - ворота");
                        int act = Convert.ToInt32(Console.ReadLine());

                        while (act != 1 && act != 2)
                        {
                            Console.WriteLine("Дайте другой ответ! ");
                            Console.WriteLine("(1) - осмотреться, (2) - ворота");
                            act = Convert.ToInt32(Console.ReadLine());
                        }

                        if (act == 1) Rock(rock);
                        else complied = Bird(rock);
                    }
                    break;
                case 1:
                    while (!complied)
                    {
                        Console.WriteLine("(1) - осмотреться, (2) - хата, (3) - тропинка");
                        int act = Convert.ToInt32(Console.ReadLine());
                        while (act != 1 && act != 2 && act != 3)
                        {
                            Console.WriteLine("Дайте другой ответ! ");
                            Console.WriteLine("(1) - осмотреться, (2) - хата, (3) - тропинка");
                            act = Convert.ToInt32(Console.ReadLine());
                        }
                        if (act == 1) Key(key);
                        else if (act == 2 && !key) Console.WriteLine("Дверь заперта. Нужно осмотреться и найти ключи.");
                        else if (act == 2 && key)
                        {
                            Console.WriteLine("Вы вошли в хату.");
                            complied = Key(key);
                            k = 0;
                        }
                        else  complied = Trop(hata);  

                    }           
                    break;
                case 2:
                    complied = false;
                    while (!complied)
                    {
                        Console.WriteLine("(1) - осмотреться, (2) - выйти");
                        int act = Convert.ToInt32(Console.ReadLine());

                        while (act != 1 && act != 2)
                        {
                            Console.WriteLine("Дайте другой ответ! ");
                            Console.WriteLine("(1) - осмотреться, (2) - выйти");
                            act = Convert.ToInt32(Console.ReadLine());
                        }
                        if (act == 1) Hata(hata);
                        else {
                            Console.WriteLine("Вы вышли обратно."); 
                            complied= true;
                        }
                    }
                    break;
                case 3:
                    complied = false;
                    while (!complied)
                    {
                        Console.WriteLine("(1) - изучить первое, (2) - изучить второе, (3) - изучить третье");
                        int act = Convert.ToInt32(Console.ReadLine());

                        while (act != 1 && act != 2 && act !=3)
                        {
                            Console.WriteLine("Дайте другой ответ! ");
                            Console.WriteLine("(1) - изучить первое, (2) - изучить второе, (3) - изучить третье");
                            act = Convert.ToInt32(Console.ReadLine());
                        }
                        if (act == 1) Finding(0);
                        else if (act == 2) Finding(1);
                        else
                        {
                            Finding(2);
                            complied = f3;
                        }
                    }
                    break;
                case 4:
                    f = 0;
                    complied = false;
                    while (!complied)
                    {
                        Console.WriteLine("(1) - копать");
                        int act = Convert.ToInt32(Console.ReadLine());

                        while (act != 1 && act != 2 && act != 3)
                        {
                            Console.WriteLine("Дайте другой ответ! ");
                            Console.WriteLine("(1) - копать");
                            act = Convert.ToInt32(Console.ReadLine());
                        }
                        if (act == 1) Dig();
                        if (f == 4) complied = true;
                    }
                    break;
            }
        }
        public void Dig()
        {
           
            switch (f)
            {
                case 0:
                    Console.WriteLine("Вы начинаете копать.");
                    f++;
                    break;
                case 1:
                    Console.WriteLine("Во время копки, вы замечаете, что засыпаете, но все равно продолжаете это делать с большим усердием.");
                    f++;
                    break;
                case 2:
                    Console.WriteLine("Вы почти увидели крышку гроба.");
                    f++;
                    break;
                case 3:
                    Console.WriteLine("Дело сделано. Вы открываете деревянный ящик. Из него выливается яркий свет, ослепляющий вас. Вы ничего не понимаете и ничего не видите.\nПосле чего вы просыпайтесь после комы в больнице! Это был лишь сон, вам удалось проснуться!");
                    f++;
                    break;
            }
        }

        public void Finding(int f)
        {
            switch (f)
            {
                case 0:
                    if (!f1)
                    { Console.WriteLine("Вы подошли осмотреть могильный камень. На нем написано имя создателя этого квеста. Его звали Hideo Kojima."); f1 = true; }
                    else Console.WriteLine("Вы уже осмотрели его.");
                    break;
                case 1:
                    if (!f2)
                    { Console.WriteLine("Вы подошли осмотреть могильный камень. На нем написаны имена двух разработчиков этого квеста. Братская могила."); f2 = true; }
                    else Console.WriteLine("Вы уже осмотрели его.");
                    break;
                case 2:
                    if (!f3)
                    { Console.WriteLine("Вы подошли осмотреть могильный камень. На нем написано ваше имя - " + name);
                        Console.WriteLine("Вы нашли то, что искали. Зловоние усилилось.");
                        f3 = true; }
                    break;
            }

            
            
        }
        public bool Rock(bool rock) {
            if (!rock) Console.WriteLine("Вы нашли маленький камешек.");
            else Console.WriteLine("Вы уже осмотрелись.");
            return this.rock = true;
        }
        public bool Bird(bool rock)
        {
            if (!rock) Console.WriteLine("Ворота закрыты на замок. Внезапно вы замечаете сидящую на на них ворону с ключами в клюве, которая будто дразнит ими.");
            else
            {
                Console.WriteLine("Вы взяли камешек и кинули в сторону вороны. Испугавшись, она уронила ключи и улетела от вас. Вы открываете ворота.");
                return true;
            }
            return false;
        }
        public bool Key(bool key)
        {
            if (!key) Console.WriteLine("Возле избы на кресле спал местный сторож. У него был ключ от избы. Вы тихо взяли его себе и оставили старика отдыхать.");
            else Console.WriteLine("Вы уже осмотрелись.");
            return this.key = true;
        }

        public bool Hata(bool hata)
        {
            if (!hata) Console.WriteLine("Вы подошли к столу, на котором стоял еще не затухший фонарь. Вы взяли его. Также вы прихватили с собой лопату.");
            else Console.WriteLine("Вы уже осмотрелись.");
            return this.hata = true;
        }
        public bool Trop(bool hata)
        {
            if (!hata) Console.WriteLine("Там слишком темно, чтобы туда идти.");
            else
            {
                Console.WriteLine("Осветив свой путь, вы двинулись дальше.");
                k = 1;
                return true;
            }
            return false;
        }
    }
}
