using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSystem
{
    
        public interface IPaymentStrategy
        {
            void Pay(decimal amount);
            string GetDescription();
        }
        public class CreditCardPayment : IPaymentStrategy
        {
            public void Pay(decimal amount) => Console.WriteLine($"   💳 Paid ${amount} using Credit Card");
            public string GetDescription() => "Credit Card (2.5% fee)";
        }

        public class EFTPayment : IPaymentStrategy
        {
            public void Pay(decimal amount) => Console.WriteLine($"   🏦 Paid ${amount} via EFT");
            public string GetDescription() => "EFT - No fee";
        }

        public class PayFastPayment : IPaymentStrategy
        {
            public void Pay(decimal amount) => Console.WriteLine($"   📱 Paid ${amount} using PayFast");
            public string GetDescription() => "PayFast - Instant";
        }

        public class PromoCodeDiscount : IPaymentStrategy
        {
            private readonly decimal _discountPercent;
            private readonly IPaymentStrategy _wrapped;
            public PromoCodeDiscount(IPaymentStrategy wrapped, decimal discountPercent)
            { _wrapped = wrapped; _discountPercent = discountPercent; }
            public void Pay(decimal amount)
            {
                decimal discounted = amount * (1 - _discountPercent / 100);
                Console.WriteLine($"   🎫 Promo {_discountPercent}% applied: ${amount} -> ${discounted}");
                _wrapped.Pay(discounted);
            }
            public string GetDescription() => $"{_wrapped.GetDescription()} + Promo {_discountPercent}%";
        }

        public class LoyaltyDiscount : IPaymentStrategy
        {
            private readonly IPaymentStrategy _wrapped;
            public LoyaltyDiscount(IPaymentStrategy wrapped) => _wrapped = wrapped;
            public void Pay(decimal amount)
            {
                decimal discounted = amount * 0.9m;
                Console.WriteLine($"   ⭐ Loyalty 10% discount: ${amount} -> ${discounted}");
                _wrapped.Pay(discounted);
            }
            public string GetDescription() => $"{_wrapped.GetDescription()} + Loyalty 10%";
        }

        public class SurgeDeliveryFee : IPaymentStrategy
        {
            private readonly IPaymentStrategy _wrapped;
            private readonly decimal _surgeMultiplier;
            public SurgeDeliveryFee(IPaymentStrategy wrapped, decimal surgeMultiplier = 1.5m)
            { _wrapped = wrapped; _surgeMultiplier = surgeMultiplier; }
            public void Pay(decimal amount)
            {
                decimal surged = amount * _surgeMultiplier;
                Console.WriteLine($"   ⚡ Surge fee (x{_surgeMultiplier}): ${amount} -> ${surged}");
                _wrapped.Pay(surged);
            }
            public string GetDescription() => $"{_wrapped.GetDescription()} + Surge {_surgeMultiplier}x";
        }
    
}
