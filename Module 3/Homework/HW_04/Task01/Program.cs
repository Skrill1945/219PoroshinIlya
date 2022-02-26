using System;

namespace Task01
{
    delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs args);

    class RingIsFoundEventArgs : EventArgs
    {
        public string Place { get; set; }
        public RingIsFoundEventArgs(string s = "")
        {
            Place = s;
        }
    }

    abstract class Creature
    {
        public string Name { get; private set; }
        protected Creature(string name)
        {
            Name = name;
        }
    }

    class Wizard : Creature
    {

        public event RingIsFoundEventHandler RaiseRingIsFoundEvent;

        public Wizard(string name = "") : base(name) { }

        public void SomethingHasChangedInTheAir()
        {
            Console.WriteLine($"{Name} >_ Rjkmwj yfqltyj e cnfhjuj <bkm,j! Ghbpsdf. dfc d Hbdthltqk!"); // Так лучше XD
            RaiseRingIsFoundEvent(this, new RingIsFoundEventArgs("Hbdthltqk"));
        }
    }

    class Dwarf : Creature
    {
        public Dwarf(string name = "") : base(name) { }

        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs args)
        {
            Console.WriteLine($"{Name} >_ Njxbv njgjhs? cj,bhftv ghbgfcs! Dsldbuftvcz d " + args.Place);
        }
    }

    class Elf : Creature
    {
        public Elf(string name = "") : base(name) { }

        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs args)
        {
            Console.WriteLine($"{Name} >_ Pd`pls cdtnzn yt nfr zhrj rfr j,sxyj. Wdtns edzlf.n. Kbcnmz ghtlcrfpsdf.n blnb d " + args.Place);
        }
    }

    class Hobbit : Creature
    {
        public Hobbit(string name = "") : base(name) { }

        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs args)
        {
            Console.WriteLine($"{Name} >_ Gjrblf. Ibh! Ble d " + args.Place);
        }
    }

    class Human : Creature
    {
        public Human(string name = "") : base(name) { }

        public void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs args)
        {
            Console.WriteLine($"{Name} >_ Djkit,ybr {((Wizard)sender).Name} gjpdfk. Vjz wtkm - " + args.Place);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Wizard wizard = new("Utylfkma");

            Hobbit[] hobbits = new Hobbit[4];
            hobbits[0] = new("Ahjlj");
            hobbits[1] = new("C'v");
            hobbits[2] = new("Gbgby");
            hobbits[3] = new("V'hhb");
            for (int i = 0; i < 4; i++)
                wizard.RaiseRingIsFoundEvent += hobbits[i].RingIsFoundEventHandler;

            Human[] humans = { new("<jhjvbh"), new("Fhfujhy") };
            Dwarf dwarf = new("Ubvkb");
            Elf elf = new("Legolas");
            wizard.RaiseRingIsFoundEvent += humans[0].RingIsFoundEventHandler;
            wizard.RaiseRingIsFoundEvent += humans[1].RingIsFoundEventHandler;
            wizard.RaiseRingIsFoundEvent += dwarf.RingIsFoundEventHandler;
            wizard.RaiseRingIsFoundEvent += elf.RingIsFoundEventHandler;

            wizard.SomethingHasChangedInTheAir();
        }
    }
}
