using System;

namespace Arrays
{

    public class Article
    {
        public string ProductName { get; set; }
        public string ShopName { get; set; }
        public int ProductPrice { get; set; }

        public Article(string name, string shop, int price)
        {
            ProductName = name;
            ProductPrice = price;
            ShopName = shop;
        }

        override public string ToString()
        {
            string result;
            result = "Name:" + ProductName + "\n" + "Store:" + ShopName + "\n" + "Price:" + ProductPrice;
            return result;
        }
    }

    public class Store
    {
        private Article[] products;


        public Article this[int index]
        {
            get { return products[index]; }
        }

        public Store()
        {
            string usersDecision1, usersDecision2;
            int usersDecision3;
            bool usersDecision4 = true;
            while (usersDecision4)
            {

                Console.WriteLine("Enter the name of the product");
                usersDecision1 = Console.ReadLine();
                Console.WriteLine("Enter the name of the store");
                usersDecision2 = Console.ReadLine();
                Console.WriteLine("Enter the price of the product");
                usersDecision3 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Do you wish to add one more?");
                usersDecision4 = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine()));
                if (products == null)
                {
                    products = new Article[1];
                    products[0] = new Article(usersDecision1, usersDecision2, usersDecision3);
                }
                else
                {
                    Array.Resize(ref products, products.Length + 1);
                    products[products.Length - 1] = new Article(usersDecision1, usersDecision2, usersDecision3);
                }
            }
        }

        public void ShowProd(int index)
        {
            Console.WriteLine(products[index].ToString());
        }

        public void SpecificProd()
        {
            Console.WriteLine("Enter the name of the product you wanna find");
            string userInput = Console.ReadLine();
            int i = 0;

            while (products[i].ProductName != userInput && i < products.Length - 1)
            {
                i++;
            }

            if (products[i].ProductName == userInput)
            {
                Console.WriteLine("The product has been found");
                Console.WriteLine(products[i].ToString());
            }
            else
                Console.WriteLine("There is no product with this name");
        }
    }


    class Arrays
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            int decision = 1;
            while (true)
            {
                Console.WriteLine("Choose what do you wanna do:\n");
                Console.WriteLine("1-Find the product by index\n");
                Console.WriteLine("2-Find the product by name\n");
                Console.WriteLine("3-Exit\n");
                decision = Convert.ToInt32(Console.ReadLine());

                switch (decision)
                {
                    case 1:
                        Console.WriteLine("Enter the index");
                        decision = Convert.ToInt32(Console.ReadLine());
                        store.ShowProd(decision);
                        break;
                    case 2:
                        store.SpecificProd();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
