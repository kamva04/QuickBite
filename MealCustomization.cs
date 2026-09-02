using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSystem
{
    public class MealCustomization
    {
        public abstract class Meal
        {
            public string Name { get; set; } = "";
            public decimal BasePrice { get; set; }
            public string Description { get; set; } = "";
            public virtual decimal GetPrice() => BasePrice;
            public virtual string GetDescription() => Description;
        }

        public class BurgerMeal : Meal
        {
            public BurgerMeal() { Name = "Burger"; BasePrice = 8.99m; Description = "Classic Beef Burger"; }
        }
        public class PizzaMeal : Meal
        {
            public PizzaMeal() { Name = "Pizza"; BasePrice = 12.99m; Description = "Margherita Pizza"; }
        }
        public class PastaMeal : Meal
        {
            public PastaMeal() { Name = "Pasta"; BasePrice = 10.99m; Description = "Creamy Alfredo Pasta"; }
        }
        public class DrinkMeal : Meal
        {
            public DrinkMeal() { Name = "Drink"; BasePrice = 2.99m; Description = "Soft Drink"; }
        }
        public class DessertMeal : Meal
        {
            public DessertMeal() { Name = "Dessert"; BasePrice = 4.99m; Description = "Chocolate Cake"; }
        }

        public abstract class MealDecorator : Meal
        {
            protected Meal _meal;
            public MealDecorator(Meal meal) => _meal = meal;
            public override decimal GetPrice() => _meal.GetPrice();
            public override string GetDescription() => _meal.GetDescription();
        }

        public class ExtraCheese : MealDecorator
        {
            public ExtraCheese(Meal meal) : base(meal) { }
            public override decimal GetPrice() => _meal.GetPrice() + 1.50m;
            public override string GetDescription() => _meal.GetDescription() + " + Extra Cheese";
        }
        public class Bacon : MealDecorator
        {
            public Bacon(Meal meal) : base(meal) { }
            public override decimal GetPrice() => _meal.GetPrice() + 2.00m;
            public override string GetDescription() => _meal.GetDescription() + " + Bacon";
        }
        public class DoublePatty : MealDecorator
        {
            public DoublePatty(Meal meal) : base(meal) { }
            public override decimal GetPrice() => _meal.GetPrice() + 3.00m;
            public override string GetDescription() => _meal.GetDescription() + " + Double Patty";
        }
        public class LargePortion : MealDecorator
        {
            public LargePortion(Meal meal) : base(meal) { }
            public override decimal GetPrice() => _meal.GetPrice() + 2.50m;
            public override string GetDescription() => _meal.GetDescription() + " + Large Portion";
        }
        public class ExtraSauce : MealDecorator
        {
            public ExtraSauce(Meal meal) : base(meal) { }
            public override decimal GetPrice() => _meal.GetPrice() + 0.99m;
            public override string GetDescription() => _meal.GetDescription() + " + Extra Sauce";
        }
        public class GlutenFreeBase : MealDecorator
        {
            public GlutenFreeBase(Meal meal) : base(meal) { }
            public override decimal GetPrice() => _meal.GetPrice() + 2.00m;
            public override string GetDescription() => _meal.GetDescription() + " + Gluten-Free Base";
        }
    }
}
