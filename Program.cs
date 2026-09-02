using FoodOrderingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using static FoodOrderingSystem.MealCustomization;
using static FoodOrderingSystem.OrderNotifier;

namespace FoodOrderingSystem
{
    internal class Program
    {
        static OrderManager orderMgr = OrderManager.Instance;
        static List<Meal> currentCart = new List<Meal>();
        static IPaymentStrategy selectedPayment = new CreditCardPayment();
        static string currentRestaurant = "";

        static void Main()
        {
            Console.Title = "QuickBite - Food Delivery";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
            ╔══════════════════════════════════════════════════════════════╗
            ║                    QUICKBITE                                 ║
            ║              Food Ordering & Delivery                        ║
            ╚══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            bool exit = false;
            while (!exit)
            {
                ShowMainMenu();
                string choice = Console.ReadLine()?.Trim();
                switch (choice)
                {
                    case "1": SelectRestaurantAndOrder(); break;
                    case "2": ViewCartAndCheckout(); break;
                    case "3": ShowOrderLog(); break;
                    case "4": LoyaltyRewardsDemo(); break;
                    case "5": MultiRestaurantCartDemo(); break;
                    case "6": exit = true; WriteSuccess("Thank you for using QuickBite!"); break;
                    default: WriteError("Invalid option."); break;
                }
            }
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            WriteHeader("MAIN MENU");
            Console.WriteLine(" 1. 🍽️  Order from a Restaurant (Abstract Factory + Factory Method)");
            Console.WriteLine(" 2. 🛒 View Cart & Checkout (Decorator + Strategy + Observer)");
            Console.WriteLine(" 3. 📜 View Order Log (Singleton)");
            Console.WriteLine(" 4. ⭐ Loyalty Rewards Demo (Bonus)");
            Console.WriteLine(" 5. 🛍️ Multi-Restaurant Cart Demo (Bonus)");
            Console.WriteLine(" 6. 🚪 Exit");
            Console.Write("\nSelect option: ");
        }

        static void SelectRestaurantAndOrder()
        {
            Console.Clear();
            WriteHeader("SELECT RESTAURANT TYPE");
            Console.WriteLine(" 1. 🍔 Fast Food Restaurant");
            Console.WriteLine(" 2. 🥩 Premium Restaurant");
            Console.WriteLine(" 3. 🥗 Healthy Food Restaurant");
            Console.Write("Your choice: ");
            string resChoice = Console.ReadLine()?.Trim();

            IRestaurantFactory factory = resChoice switch
            {
                "1" => new FastFoodFactory(),
                "2" => new PremiumFactory(),
                "3" => new HealthyFactory(),
                _ => new FastFoodFactory()
            };
            var menuItem = factory.CreateMenuItem();
            var packaging = factory.CreatePackaging();
            var branding = factory.CreateBranding();
            currentRestaurant = branding.GetBranding();

            WriteInfo($"\n✨ Restaurant: {branding.GetBranding()}");
            WriteInfo($"📦 Packaging: {packaging.GetPackaging()}");
            WriteInfo($"🍽️  Featured Item: {menuItem.GetName()} - ${menuItem.GetPrice()}");

            // Factory Method to create a meal
            Console.WriteLine("\nSelect meal to order:");
            Console.WriteLine(" 1. Burger Meal");
            Console.WriteLine(" 2. Pizza Meal");
            Console.WriteLine(" 3. Pasta Meal");
            Console.WriteLine(" 4. Drink");
            Console.WriteLine(" 5. Dessert");
            Console.Write("Choice: ");
            string mealChoice = Console.ReadLine()?.Trim();
            MealFactory mealFactory = mealChoice switch
            {
                "1" => new BurgerFactory(),
                "2" => new PizzaFactory(),
                "3" => new PastaFactory(),
                "4" => new DrinkFactory(),
                "5" => new DessertFactory(),
                _ => new BurgerFactory()
            };
            Meal meal = mealFactory.CreateMeal();
            WriteSuccess($"Added {meal.Name} (${meal.BasePrice}) to cart.");

            // Decorator customization
            bool customizing = true;
            while (customizing)
            {
                Console.Clear();
                WriteHeader("CUSTOMIZE YOUR MEAL");
                Console.WriteLine($"Current: {meal.GetDescription()} - ${meal.GetPrice()}");
                Console.WriteLine("\nAdd extras:");
                Console.WriteLine(" 1. Extra Cheese (+$1.50)");
                Console.WriteLine(" 2. Bacon (+$2.00)");
                Console.WriteLine(" 3. Double Patty (+$3.00)");
                Console.WriteLine(" 4. Large Portion (+$2.50)");
                Console.WriteLine(" 5. Extra Sauce (+$0.99)");
                Console.WriteLine(" 6. Gluten-Free Base (+$2.00)");
                Console.WriteLine(" 7. Done");
                Console.Write("Choice: ");
                string opt = Console.ReadLine();
                switch (opt)
                {
                    case "1": meal = new ExtraCheese(meal); break;
                    case "2": meal = new Bacon(meal); break;
                    case "3": meal = new DoublePatty(meal); break;
                    case "4": meal = new LargePortion(meal); break;
                    case "5": meal = new ExtraSauce(meal); break;
                    case "6": meal = new GlutenFreeBase(meal); break;
                    case "7": customizing = false; break;
                    default: WriteError("Invalid."); break;
                }
            }
            currentCart.Add(meal);
            WriteSuccess($"\n✅ {meal.GetDescription()} added to cart. Total: ${meal.GetPrice():0.00}");
            Console.ReadKey();
        }

        static void ViewCartAndCheckout()
        {
            if (currentCart.Count == 0)
            {
                WriteError("Cart is empty. Please order first.");
                Console.ReadKey();
                return;
            }
            Console.Clear();
            WriteHeader("YOUR CART");
            decimal total = 0;
            foreach (var m in currentCart)
            {
                Console.WriteLine($"   {m.GetDescription()} - ${m.GetPrice():0.00}");
                total += m.GetPrice();
            }
            Console.WriteLine($"\n💰 Subtotal: ${total:0.00}");
            Console.WriteLine($"Delivery fee: $3.99");
            total += 3.99m;

            // Strategy Pattern: Select payment
            WriteHeader("SELECT PAYMENT METHOD");
            Console.WriteLine(" 1. Credit Card");
            Console.WriteLine(" 2. EFT");
            Console.WriteLine(" 3. PayFast");
            Console.WriteLine(" 4. Apply Promo Code (10% off)");
            Console.WriteLine(" 5. Apply Loyalty Discount (10% off)");
            Console.WriteLine(" 6. Surge Delivery Fee (1.5x)");
            Console.Write("Choice: ");
            string payChoice = Console.ReadLine()?.Trim();

            IPaymentStrategy basePayment = payChoice switch
            {
                "1" => new CreditCardPayment(),
                "2" => new EFTPayment(),
                "3" => new PayFastPayment(),
                "4" => new PromoCodeDiscount(new CreditCardPayment(), 10),
                "5" => new LoyaltyDiscount(new CreditCardPayment()),
                "6" => new SurgeDeliveryFee(new CreditCardPayment(), 1.5m),
                _ => new CreditCardPayment()
            };
            selectedPayment = basePayment;

            Console.WriteLine($"\n💰 Final amount: ${total:0.00}");
            selectedPayment.Pay(total);

            // Observer Pattern
            string orderId = orderMgr.GenerateOrderId();
            var orderSubject = new OrderStatusSubject(orderId);
            orderSubject.Attach(new CustomerNotifier());
            orderSubject.Attach(new RestaurantNotifier());
            orderSubject.Attach(new DriverNotifier());

            orderMgr.LogOrder($"Order {orderId} placed at {currentRestaurant}, total ${total:0.00}");
            orderSubject.SetStatus("Order Confirmed");
            orderSubject.SetStatus("Restaurant Preparing");
            orderSubject.SetStatus("Out for Delivery");
            orderSubject.SetStatus("Delivered");

            WriteSuccess($"\n🎉 Order {orderId} completed! Thank you.");
            currentCart.Clear();
            Console.ReadKey();
        }

        static void ShowOrderLog()
        {
            Console.Clear();
            orderMgr.ShowLog();
            Console.WriteLine("\nPress any key to return.");
            Console.ReadKey();
        }

        // Bonus: Loyalty Rewards System
        static void LoyaltyRewardsDemo()
        {
            Console.Clear();
            WriteHeader("LOYALTY REWARDS");
            Console.WriteLine("⭐ Every 5th order gets a free drink!");
            Console.WriteLine("⭐ Earn 10 points per dollar spent.");
            Console.WriteLine("⭐ 100 points = $5 off next order.");
            Console.WriteLine("\nDemo: Simulating a loyal customer...");
            orderMgr.LogOrder("Loyalty points: +150 (order #1005)");
            orderMgr.LogOrder("Redeemed 200 points for $10 discount");
            WriteSuccess("Loyalty system integrated with Strategy pattern (LoyaltyDiscount).");
            Console.ReadKey();
        }

        // Bonus: Multi-Restaurant Cart
        static void MultiRestaurantCartDemo()
        {
            Console.Clear();
            WriteHeader("MULTI-RESTAURANT CART");
            WriteInfo("Add items from different restaurants (simulated)");
            var multiCart = new List<(string restaurant, Meal meal)>();
            multiCart.Add(("FastFoodCo", new ExtraCheese(new BurgerMeal())));
            multiCart.Add(("GreenEats", new GlutenFreeBase(new PastaMeal())));
            multiCart.Add(("GourmetDelight", new Bacon(new PizzaMeal())));
            decimal total = 0;
            foreach (var item in multiCart)
            {
                Console.WriteLine($"   {item.restaurant}: {item.meal.GetDescription()} - ${item.meal.GetPrice():0.00}");
                total += item.meal.GetPrice();
            }
            Console.WriteLine($"\n💰 Combined total: ${total:0.00}");
            WriteSuccess("Multi-restaurant ordering supported with separate packaging/branding per restaurant.");
            Console.ReadKey();
        }

        static void WriteHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n╔════════════════════════════════════════╗");
            Console.WriteLine($"║  {title.PadRight(32)}║");
            Console.WriteLine($"╚════════════════════════════════════════╝");
            Console.ResetColor();
        }
        static void WriteInfo(string msg) { Console.ForegroundColor = ConsoleColor.Cyan; Console.WriteLine(msg); Console.ResetColor(); }
        static void WriteSuccess(string msg) { Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine(msg); Console.ResetColor(); }
        static void WriteError(string msg) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine(msg); Console.ResetColor(); }
    }
}