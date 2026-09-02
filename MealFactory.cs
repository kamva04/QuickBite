using static FoodOrderingSystem.MealCustomization;

namespace FoodOrderingSystem
{
    public abstract class MealFactory
    {
        public abstract Meal CreateMeal();
    }

    public class BurgerFactory : MealFactory
    {
        public override Meal CreateMeal() => new BurgerMeal();
    }
    public class PizzaFactory : MealFactory
    {
        public override Meal CreateMeal() => new PizzaMeal();
    }
    public class PastaFactory : MealFactory
    {
        public override Meal CreateMeal() => new PastaMeal();
    }
    public class DrinkFactory : MealFactory
    {
        public override Meal CreateMeal() => new DrinkMeal();
    }
    public class DessertFactory : MealFactory
    {
        public override Meal CreateMeal() => new DessertMeal();
    }
}