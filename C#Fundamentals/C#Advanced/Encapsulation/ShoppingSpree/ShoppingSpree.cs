namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingSpree
    {
        public static void Main()
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var allPeople = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var allProduct = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                foreach (var pair in allPeople)
                {
                    var personDetails = pair.Split('=');
                    var person = new Person(personDetails[0], decimal.Parse(personDetails[1]));
                    people.Add(person);
                }

                foreach (var pair in allProduct)
                {
                    var productDetails = pair.Split('=');
                    var product = new Product(productDetails[0], decimal.Parse(productDetails[1]));
                    products.Add(product);
                }

                var purchase = Console.ReadLine();

                while (purchase != "END")
                {
                    var purchaseDetails = purchase.Split();
                    var buyerName = purchaseDetails[0];
                    var productName = purchaseDetails[1];

                    var buyer = people.FirstOrDefault(b => b.Name == buyerName);
                    var productToBuy = products.FirstOrDefault(bp => bp.Name == productName);


                    try
                    {
                        buyer.BuyProduct(productToBuy);
                        Console.WriteLine($"{buyerName} bought {productName}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    purchase = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    var boughtProducts = person.GetProduct();
                    var result = boughtProducts.Any()
                        ? string.Join(", ", boughtProducts.Select(pr => pr.Name).ToList())
                        : "Nothing bought";
                    Console.WriteLine($"{person.Name} - {result}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}