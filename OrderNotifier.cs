using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingSystem
{
    public class OrderNotifier
    {
        public interface IOrderObserver
        {
            void Update(string orderId, string status);
        }

        public class CustomerNotifier : IOrderObserver
        {
            public void Update(string orderId, string status)
                => Console.WriteLine($"   📱 [Customer] Order #{orderId} status: {status}");
        }

        public class RestaurantNotifier : IOrderObserver
        {
            public void Update(string orderId, string status)
                => Console.WriteLine($"   🍕 [Restaurant] Order #{orderId} - {status} – prepare food");
        }

        public class DriverNotifier : IOrderObserver
        {
            public void Update(string orderId, string status)
                => Console.WriteLine($"   🚗 [Driver] Order #{orderId} - {status} – pickup ready");
        }

        public class OrderStatusSubject
        {
            private List<IOrderObserver> _observers = new();
            private string _orderId;

            public OrderStatusSubject(string orderId) => _orderId = orderId;

            public void Attach(IOrderObserver observer) => _observers.Add(observer);
            public void Detach(IOrderObserver observer) => _observers.Remove(observer);

            public void SetStatus(string status)
            {
                Console.WriteLine($"\n📢 Order #{_orderId} status changed to: {status}");
                foreach (var obs in _observers)
                    obs.Update(_orderId, status);
            }
        }
    }
}
