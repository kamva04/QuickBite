using System;

namespace FoodOrderingSystem
{
    // Abstract products
    public interface IMenuItem { string GetName(); decimal GetPrice(); }
    public interface IPackaging { string GetPackaging(); }
    public interface IBranding { string GetBranding(); }

    // Concrete products for Fast Food
    public class FastFoodBurger : IMenuItem { public string GetName() => "Fast Burger"; public decimal GetPrice() => 5.99m; }
    public class FastFoodPackaging : IPackaging { public string GetPackaging() => "Paper Wrap"; }
    public class FastFoodBranding : IBranding { public string GetBranding() => "FastFoodCo Logo"; }

    // Premium Restaurant
    public class PremiumSteak : IMenuItem { public string GetName() => "Grilled Steak"; public decimal GetPrice() => 24.99m; }
    public class PremiumPackaging : IPackaging { public string GetPackaging() => "Elegant Box"; }
    public class PremiumBranding : IBranding { public string GetBranding() => "GourmetDelight"; }

    // Healthy Food
    public class HealthySalad : IMenuItem { public string GetName() => "Quinoa Salad"; public decimal GetPrice() => 11.99m; }
    public class HealthyPackaging : IPackaging { public string GetPackaging() => "Eco-Friendly Container"; }
    public class HealthyBranding : IBranding { public string GetBranding() => "GreenEats"; }

    // Abstract Factory
    public interface IRestaurantFactory
    {
        IMenuItem CreateMenuItem();
        IPackaging CreatePackaging();
        IBranding CreateBranding();
    }

    public class FastFoodFactory : IRestaurantFactory
    {
        public IMenuItem CreateMenuItem() => new FastFoodBurger();
        public IPackaging CreatePackaging() => new FastFoodPackaging();
        public IBranding CreateBranding() => new FastFoodBranding();
    }

    public class PremiumFactory : IRestaurantFactory
    {
        public IMenuItem CreateMenuItem() => new PremiumSteak();
        public IPackaging CreatePackaging() => new PremiumPackaging();
        public IBranding CreateBranding() => new PremiumBranding();
    }

    public class HealthyFactory : IRestaurantFactory
    {
        public IMenuItem CreateMenuItem() => new HealthySalad();
        public IPackaging CreatePackaging() => new HealthyPackaging();
        public IBranding CreateBranding() => new HealthyBranding();
    }
}