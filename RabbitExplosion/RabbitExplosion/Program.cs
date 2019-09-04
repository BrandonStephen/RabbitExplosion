using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace RabbitExplosion
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Game gm = new Game();
            gm.initialise();
        }
    }

    class Game
    {
        public void initialise()
        {
            List<Rabbit> rb = new List<Rabbit>();
            repeat(rb);
        }

        public void repeat(List<Rabbit> rb)
        {

            Garden gd = new Garden(0);


            var whiteSpace = new StringBuilder();
            whiteSpace.Append(' ', 10);
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                var sb = new StringBuilder();
                sb.AppendLine($"Rabbit Explosion");
                sb.AppendLine("-------------------------------");
                sb.AppendLine($"Last Updated: {DateTime.Now}{whiteSpace}");
                sb.AppendLine($"Rabbits Alive {gd.Amount}{whiteSpace}");
                sb.AppendLine("-------------------------------");
                Console.Write(sb);
                Thread.Sleep(1000);
                rb.Add(gd.createRabbit());
            }     
        }

        public void repeatDeath()
        {

            if (rb.Count > 1)
            {
                foreach (Rabbit rbs in rb)
                {
                    gd.killRabbit(rbs, gd);
                }
            }
        }



    }
    class Garden
    {
        private int amount;
        public int Amount
        {
            get => this.amount; set
            {
                this.amount = value;
            }
        }
        public Garden(int amount)
        {
            this.amount = amount;
        }

        public void killRabbit(Rabbit rb, Garden gd)
        {
            Thread.Sleep(rb.DeathRate * 1000);
            gd.Amount -= 1;
            rb = null;
        }

        public Rabbit createRabbit()
        {
            Rabbit rb = new Rabbit(10, 3);
            this.amount += 1;
            return rb;
        }
    }

    class Rabbit
    {
        private int deathrate;
        public int DeathRate
        {
            get => this.deathrate;
        }
        private int rebirthrate; 
        public int RebirthRate
        {
            get => this.rebirthrate;
        }

        public Rabbit(int DeathRate, int RebirthRate)
        {
            this.deathrate = DeathRate;
            this.rebirthrate = RebirthRate;
        }

    }
}
