namespace Lab
{
    using System;
    using System.Collections.Generic;

    public class Lab
    {
        public static void Main()
        {
            var accounts = new Dictionary<int, BankAccount>();

            var command = Console.ReadLine();

            while (command != "End")
            {
                var commandParams = command.Split();

                var currentCommand = commandParams[0];

                switch (currentCommand)
                {
                    case "Create":
                        Create(commandParams, accounts);
                        break;
                    case "Deposit":
                        Deposit(commandParams, accounts);
                        break;
                    case "Withdraw":
                        Withdrow(commandParams, accounts);
                        break;
                    case "Print":
                        Print(commandParams, accounts);
                        break;
                }

                command = Console.ReadLine();
            }
        }

        private static void Print(string[] commandParams, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(commandParams[1]);

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine(accounts[id].ToString());
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Withdrow(string[] commandParams, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(commandParams[1]);
            var amount = double.Parse(commandParams[2]);

            if (accounts.ContainsKey(id))
            {
                if (accounts[id].Balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                }
                else
                {
                    accounts[id].Withdraw(amount);
                }
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Deposit(string[] commandParams, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(commandParams[1]);
            var amount = double.Parse(commandParams[2]);

            if (accounts.ContainsKey(id))
            {
                accounts[id].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(string[] commandParams, Dictionary<int, BankAccount> accounts)
        {
            var id = int.Parse(commandParams[1]);

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                accounts.Add(id, new BankAccount { ID = id });
            }
        }
    }
}