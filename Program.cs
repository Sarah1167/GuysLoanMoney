using System;
using System.Runtime.CompilerServices;

namespace GuysLoanMoney
{
    class Guy
    {
        public string Name;
        public int Cash;
        /// <summary>
        /// Writes my name and then amount of cash I have to the console.
        /// </summary>
        public void WriteMyInfo()
        {
            Console.WriteLine(Name + " has " + Cash + " bucks.");
        }
        /// <summary>
        /// Gives some of my cash, removing it from my wallet ( or printing a message to the console of I don't have enough cash.)
        /// </summary>
        /// <param name="amount">Amout of cash to give.</param>
        /// <returns>
        /// The amount of cash removed from my wallet, or 0 if I don't have enough cash (or if the amount is invalid).
        /// </returns>
        public int GiveCash(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't a valid amount");
                return 0;
            }
            if (amount > Cash)
            {
                Console.WriteLine(Name + " says: " + "I done't have enough cash to give you " + amount);
                return 0;
            }
            Cash -= amount;
            return amount;
        }

        /// <summary>
        /// Receive some cash, adding it to my wallet ( or printing a message to the console if the amount is invalid).
        /// </summary>
        /// <param name="amount">Amount of cash to give.</param>
        public void ReceivedCash(int amount)
        {
            if (amount < 0)
            {
                Console.WriteLine(Name + " says: " + amount + " isn't an amount I'll take");
            }
            else
            {
                Cash += amount;
            }
        }

        static void Main(string[] args)
        {
            Guy joe = new Guy() { Name = "Joe", Cash = 50 };
            Guy bob = new Guy() { Name = "Bob", Cash = 100 };
            while (true)
            {
                joe.WriteMyInfo();
                bob.WriteMyInfo();
                Console.Write("Enter an amount: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") return;
                if (int.TryParse(howMuch, out int amount))
                {
                    Console.Write("Who should give the cash: ");
                    string whichGuy = Console.ReadLine();
                    if (whichGuy == "Joe")
                    {
                        int cashGiven = joe.GiveCash(amount);
                        bob.ReceivedCash(cashGiven);
                    }
                    else if (whichGuy == "Bob")
                    {
                        int cashGiven = bob.GiveCash(amount);
                        joe.ReceivedCash(cashGiven);
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'Joe' or 'Bob'");
                    }
                }
            }
        }
    }
}
