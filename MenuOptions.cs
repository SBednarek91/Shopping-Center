using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping_Center
{
    internal class MenuOptions
    {
        public void AddToCart()
        {
            Console.Clear();
            Console.WriteLine("Lista produktów:");
            foreach (var produkt in listaProduktow)
            {
                Console.WriteLine($"{produkt.Id}. {produkt.Nazwa} - Cena: {produkt.Cena} zł");
            }
            Console.WriteLine();

            List<Produkt> produktyWKoszyku = new List<Produkt>(); // Lista produktów do dodania do koszyka

            while (true)
            {
                Console.Write("Podaj numer produktu, który chcesz dodać do koszyka (0 aby zakończyć): ");
                int productId = Convert.ToInt32(Console.ReadLine());

                if (productId == 0)
                {
                    break; // Zakończ pętlę, jeśli użytkownik wprowadzi 0
                }

                Produkt selectedProduct = listaProduktow.Find(product => product.Id == productId);

                if (selectedProduct != null)
                {
                    produktyWKoszyku.Add(selectedProduct); // Dodaj produkt do listy produktów do dodania do koszyka
                    Console.WriteLine($"Dodano {selectedProduct.Nazwa} do koszyka.");
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy numer produktu.");
                }
            }
        }
    }
}
