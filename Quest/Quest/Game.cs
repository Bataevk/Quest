using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quest
{
    internal class Game
    {
        public int numLocation { get; private set; }
        Location[] locations = new Location[5];
        Player player;

        public Game()
        {
            numLocation = 0;
            locations[0] = new Location
            (
                "Вход",
                "Перед вами высокие металические ворота, запертые на ключ. Вы заметили дерево, на ветке которого сидела ворона с чем-то блестящим в клюве! ",
                new List<MyObject>()
                {
                    new MyObject("камень", "камень слева от ворота"),
                    new MyObject("ключ", "ключ в клюве вороны", false)
                }
            );
            locations[1] = new Location(
                        "Полянка сторожа",
                        "Перед вами тропинка, по бокам от которой спящий сторож и его домик! ",
                        new List<MyObject>()
                        {
                            new MyObject("лопата", "лопата подпирающая дверь домика"),
                        }
                    );
            locations[2] = new Location(
                        "Домик сторожа",
                        "Войдя внутрь вы видите стол возле окна и кровать сбоку! ",
                        new List<MyObject>()
                        {
                            new MyObject("фонарик", "фонарик, лежащий на кровати"),
                        }
                    );
            locations[3] = new Location(
                        "могилы",
                        "Вы проходите среди могил в поисках своей! ",
                        new List<MyObject>()
                        {
                            new MyObject("могила", "ваша могила"),
                        }
                    );
            locations[4] = new Location(
                        "могила",
                        "Наконец вам удалось отыскать свою могилу. Вы нервно вдыхайте воздух. На вас нагрянули нежные воспоминания о ваших похоронах ",
                        new List<MyObject>()
                        {
                            new MyObject("могила", "свое имя на вашей могиле"),
                        }
                    );

        }

        public void Start()
        {


        }



        public string Next(int p)
        {
            return "error";
        }
        public string Next()
        {
            return "error";
        }
        public string Variations()
        {
            return "empty";
        }
    }
}
