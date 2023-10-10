using Lesson10.Models;
using Lesson10.Services;
/// <summary>
/// It's run method
/// </summary>
internal class Program
{
    private static ProductsService? productsService;
    private static Cart? cart;

    private static void Main(string[] args)
    {
        LoadData();
        productsService = new ProductsService();
        CartItems item = new CartItems();
        item.Quantity = 5;

        while (true)
        {
            ShowMenu();
        }

    }


    static void LoadData()
    {
        // Load cart from previous session
        // update cart
        cart = FileManagerService.Read();

    }

    static void ShowMenu()
    {
        Console.WriteLine($"{0,40:Select Menu}\n" +
            $"{0,0:1) See Products} {0,5:2) Check Cart} " +
            $"{0,10:3) Make Order} {0,8:4) Exit}");
        int selectedMenu = GetMenuOption();

        switch (selectedMenu)
        {
            case 1:
                ShowProducts();
                break;
            case 2:
                CheckoutCart();
                break;
            case 3:
                MakeOrder();
                break;
            case 4:
                CloseApplication();
                break;
            default:
                Console.WriteLine("Please, select valid menu option.");
                break;
        }
    }

    static int GetMenuOption()
    {
        string? input = Console.ReadLine();
        int result;

        while (!int.TryParse(input, out result))
        {
            Console.WriteLine("Please, enter a number");
            input = Console.ReadLine();
        }

        return result;
    }

    static void ShowProducts()
    {
        try
        {
            productsService.ShowAllProducts();

            Console.WriteLine("Enter product id to add to cart or 0 to go back");

            int input = int.Parse(Console.ReadLine() ?? string.Empty);

            if (input == 0)
            {
                return;
            }
            else
            {
                Console.WriteLine("Enter quantity");
                int quantity = int.Parse(Console.ReadLine() ?? string.Empty);

                var product = productsService.GetProductById(input);

                cart.AddItem(product, quantity);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("There was an error displaying products.");
            Console.WriteLine(ex.Message);
        }
    }

    static void MakeOrder()
    {

    }

    static void CheckoutCart()
    {

    }

    static void CloseApplication()
    {
        // Save cart

        FileManagerService.Write(cart);

        Environment.Exit(500);
    }




}