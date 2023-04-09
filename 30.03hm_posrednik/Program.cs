using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _30._03hm_posrednik
{
    public interface Mediator {
        void Notify(object sender, string ev);
    }
    class Dispatcher : Mediator {
        private Ship ship;
        private Yacht yacht;
        private Bank bank;
        public Dispatcher(Ship plane, Yacht helicopter, Bank maiz) {
            this.ship = plane;
            this.ship.SetMediator(this);

            this.yacht = helicopter;
            this.yacht.SetMediator(this);

            this.bank = maiz;
            this.bank.SetMediator(this);
        }
        public void Notify(object sender, string ev) {
            if (ev == "Корабль") {
                yacht.FlightWait();
                bank.FlightWait();
            }
            else if (ev == "Яхта") {
                ship.FlightWait();
                bank.FlightWait();
            }
            else if(ev == "Банк") {
                ship.FlightWait();
                yacht.FlightWait();
            }
        }
    }
    class SwimMachin {
        protected Mediator med;
        public SwimMachin(Mediator med = null) { 
            this.med = med;
        }
        public void SetMediator(Mediator med) { 
            this.med = med;
        }
    }
    class Ship :   SwimMachin {
        public void FlightStart() {
            Console.WriteLine("Корабль начало плаванья");
            med.Notify(this, "Корабль");
        }
        public void FlightWait() {
            Console.WriteLine("Корабьл начало плаванья");
        }
    }
    class Yacht : SwimMachin{ 
        public void FlightStart() {
            Console.WriteLine("Яхта начало плаванья");
            med.Notify(this, "Яхта");
        }
        public void FlightWait() {
            Console.WriteLine("Яхта начало плаванья ");
        }
    }
    class Bank : SwimMachin { 
        public void FlightStart() {
            Console.WriteLine("Банк начал полет");
            med.Notify(this, "Банк");
        }
        public void FlightWait() {
            Console.WriteLine("Банк на воде");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Ship ship = new Ship();
            Yacht yacht = new Yacht();
            Bank bank = new Bank();
            new Dispatcher(ship, yacht, bank);
            Console.WriteLine("Клиант берет корабьл:");
            ship.FlightStart();
            Console.WriteLine();
            Console.WriteLine("Клиент обращаеться в банк:");
            bank.FlightStart();
        }
    }
}