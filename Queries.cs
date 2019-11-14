using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    struct AutoInf
    {
        public string BrandName { get; }
        private string model;
        private int productionYear;
        private string color;

        public AutoInf(string brand, string model, int year, string color)
        {
            BrandName = brand;
            this.model = model;
            productionYear = year;
            this.color = color;
        }
        override public string ToString()
        {
            return new string("Model - " + model + "\nProduction year - " + productionYear + "\nColor - " + color);
        }
    }

    struct Client
    {
        public string Model { get; }
        public string Name { get; }
        private double number;

        public Client(string model, string name, double number)
        {
            this.Model = model;
            Name = name;
            this.number = number;
        }

        override public string ToString()
        {
            string result = "Brand - " + Model + "\nName - " + Name + "\nnumber - " + number;
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<AutoInf> autoList = new List<AutoInf>();
            List<Client> clientList = new List<Client>();
            string userName;

            autoList.Add(new AutoInf("Nissan", "Leaf", 2015, "Green"));
            autoList.Add(new AutoInf("BMW", "X5", 2018, "Black"));
            autoList.Add(new AutoInf("Renault", "Kangoo", 2009, "White"));

            clientList.Add(new Client("Nissan", "Vasiliy", 21341235));
            clientList.Add(new Client("BMW", "Vitaliy", 21341235));
            clientList.Add(new Client("Renault", "Ivan", 21341235));

            Console.WriteLine("Enter the name of the man you want to find");
            userName = Console.ReadLine();

            var clientResult = clientList
                .Where(clientsList => clientsList.Name == userName)
                .Select(clientList => clientList);

            foreach (Client client in clientResult)
            {
                Console.WriteLine(client.ToString());
                var carResult = autoList
                    .Where(autoList => autoList.BrandName == client.Model)
                    .Select(autoList => autoList);
                foreach (AutoInf auto in carResult)
                    Console.WriteLine(auto.ToString());
            }
        }
    }
}
