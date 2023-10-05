using Shopping_Center;
using System;

class Program
{
    static List<Produkt> listaProduktow = new List<Produkt>
    {
        new Produkt { Id = 1, Nazwa = "Chleb", Cena = 2.5 },
        new Produkt { Id = 2, Nazwa = "Masło", Cena = 4.0 },
        new Produkt { Id = 3, Nazwa = "Mleko", Cena = 1.8 },
        new Produkt { Id = 4, Nazwa = "Cukier", Cena = 3.2 },
        new Produkt { Id = 5, Nazwa = "Czekolada", Cena = 2.0 }
    };

    static List<Produkt> koszyk = new List<Produkt>();
    
    static void Main()
    {
        Console.WriteLine("Menu wyboru:");
        Console.WriteLine("1 Wyświetl listę produktów");
        Console.WriteLine("2 Zakupy");
        Console.WriteLine("3 Dodaj produkty do listy");
        Console.WriteLine("4 Usuń produkty z listy");
        Console.WriteLine("5 Modyfikuj produkty");
        Console.WriteLine("6 Wystaw paragon");
        Console.WriteLine("7 Wystaw fakturę");
       
        Console.Write("Wybierz opcję (wpisz numer): ");
        int userchoice = Convert.ToInt32(Console.ReadLine());

        switch (userchoice)
        {
            case 1:
                ProductList();
                break;
            case 2:
                MenuOptions AddToCart = new MenuOptions();
                AddToCart.AddToCart();
                break;
            case 3:
                AddProductToList();
                break;
            case 4:
                RemoveProductFromList();
                break;
            case 5:
                ModifyProduct();
                break;
            case 6:
                Receipt();
                break;
            case 7:
                Invoice();
                break;
            default:
                Console.WriteLine("Nieprawidłowy numer opcji.");
                break;
        }
    }

    static void ProductList()
    {
        // Kod do wyświetlenia listy produktów
        Console.Clear();
        Console.WriteLine("Lista produktów:");
        foreach (var produkt in listaProduktow)
        {
            Console.WriteLine($"{produkt.Id}. {produkt.Nazwa} - Cena: {produkt.Cena} zł");
        }

    }

    //static void AddToCart()
    //{
    //    Console.Clear();
    //    Console.WriteLine("Lista produktów:");
    //    foreach (var produkt in listaProduktow)
    //    {
    //        Console.WriteLine($"{produkt.Id}. {produkt.Nazwa} - Cena: {produkt.Cena} zł");
    //    }
    //    Console.WriteLine();

    //    List<Produkt> produktyWKoszyku = new List<Produkt>(); // Lista produktów do dodania do koszyka

    //    while (true)
    //    {
    //        Console.Write("Podaj numer produktu, który chcesz dodać do koszyka (0 aby zakończyć): ");
    //        int productId = Convert.ToInt32(Console.ReadLine());

    //        if (productId == 0)
    //        {
    //            break; // Zakończ pętlę, jeśli użytkownik wprowadzi 0
    //        }

    //        Produkt selectedProduct = listaProduktow.Find(product => product.Id == productId);

    //        if (selectedProduct != null)
    //        {
    //            produktyWKoszyku.Add(selectedProduct); // Dodaj produkt do listy produktów do dodania do koszyka
    //            Console.WriteLine($"Dodano {selectedProduct.Nazwa} do koszyka.");
    //        }
    //        else
    //        {
    //            Console.WriteLine("Nieprawidłowy numer produktu.");
    //        }
    //    }

    //    // Dodaj produkty z listy produktów do dodania do koszyka do właściwego koszyka
    //    koszyk.AddRange(produktyWKoszyku);

    //    double totalCost = 0; // Całkowita cena koszyka

    //    Console.WriteLine("Twój koszyk zawiera:");
    //    foreach (var item in koszyk)
    //    {
    //        Console.WriteLine($"{item.Nazwa} - Cena: {item.Cena} zł");
    //        totalCost += item.Cena;
    //    }

    //    Console.WriteLine($"Całkowita cena koszyka: {totalCost} zł");
    //    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
    //    Console.ReadKey();
    //}

    static void AddProductToList()
    {
        // Kod do dodawania produktów
        Console.Clear();

        Console.Write("Podaj nazwę nowego produktu: ");
        string nazwaProduktu = Console.ReadLine();

        Console.Write("Podaj cenę nowego produktu: ");
        double cenaProduktu = Convert.ToDouble(Console.ReadLine());

        // Tworzenie nowego produktu
        Produkt nowyProdukt = new Produkt
        {
            Id = listaProduktow.Count + 1, // Tworzymy nowy produkt z kolejnym numerem ID
            Nazwa = nazwaProduktu,
            Cena = cenaProduktu
        };

        // Dodanie nowego produktu do listy produktów
        listaProduktow.Add(nowyProdukt);

        Console.WriteLine($"Dodano nowy produkt: {nowyProdukt.Nazwa} - Cena: {nowyProdukt.Cena} zł");
        Console.WriteLine("Lista produktów:");
        foreach (var produkt in listaProduktow)
        {
            Console.WriteLine($"{produkt.Id}. {produkt.Nazwa} - Cena: {produkt.Cena} zł");
        }
        Console.WriteLine();
        Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();
    }

    static void RemoveProductFromList()
    {
        // Kod do usuwania produktów
        Console.Clear();
        Console.WriteLine("Lista produktów:");

        for (int i = 0; i < listaProduktow.Count; i++)
        {
            Console.WriteLine($"{listaProduktow[i].Id}. {listaProduktow[i].Nazwa} - Cena: {listaProduktow[i].Cena} zł");
        }

        Console.WriteLine();
        Console.Write("Podaj numer produktu, który chcesz usunąć: ");
        int productId = Convert.ToInt32(Console.ReadLine());

        // Sprawdzenie, czy produkt o podanym numerze ID istnieje
        Produkt selectedProduct = listaProduktow.Find(product => product.Id == productId);

        if (selectedProduct != null)
        {
            // Usunięcie produktu z listy
            listaProduktow.Remove(selectedProduct);
            Console.WriteLine($"Usunięto produkt: {selectedProduct.Nazwa} - Cena: {selectedProduct.Cena} zł");
        }
        else
        {
            Console.WriteLine("Nieprawidłowy numer produktu.");
        }

        Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
        Console.ReadKey();
    }

    static void ModifyProduct()
    {
        // Kod do modyfikowania produktów
        Console.WriteLine("Modyfikuję produkty.");
    }

    static void Receipt()
    {
        // Kod do wystawiania paragonu
        Console.WriteLine("Wystawiam paragon.");
    }

    static void Invoice()
    {
        // Kod do wystawiania faktury
        Console.WriteLine("Wystawiam fakturę.");
    }
}

class Produkt
{
    public int Id { get; set; }
    public string Nazwa { get; set; }
    public double Cena { get; set; }
}