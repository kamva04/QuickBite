using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace FoodOrderingSystem
{
    public sealed class OrderManager
    {
        private static OrderManager? _instance;
        private static readonly object _lock = new();
        public List<string> OrderLog { get; private set; }
        public int NextOrderId { get; private set; }

        private OrderManager()
        {
            OrderLog = new List<string>();
            NextOrderId = 1001;
            Console.WriteLine("   [Singleton] Order Manager Initialized");
        }

        public static OrderManager Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new OrderManager();
                    return _instance;
                }
            }
        }

        public string GenerateOrderId() => (NextOrderId++).ToString();

        public void LogOrder(string message)
        {
            string entry = $"[{DateTime.Now:HH:mm:ss}] {message}";
            OrderLog.Add(entry);
            Console.WriteLine($"   [Order Log] {entry}");
        }

        public void ShowLog()
        {
            Console.WriteLine("\n═══════════════════════════════════════════");
            Console.WriteLine("              ORDER HISTORY");
            Console.WriteLine("═══════════════════════════════════════════");
            foreach (var entry in OrderLog)
                Console.WriteLine($"  {entry}");
        }

        // Save/Load bonus
        public void SaveOrders(string filename = "orders.json")
        {
            var data = new { OrderLog, NextOrderId };
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json);
            Console.WriteLine($"💾 Orders saved to {filename}");
        }
    }
}