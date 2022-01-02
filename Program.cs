using System;

namespace IMJunior
{
    class Program
    {
        static void Main(string[] args)
        {
            string systemId = OrderForm.ShowForm();
            IPaymentSystem system = Initilizer.InitilizeSystem(systemId);
            system.ShowPaymentResult();
        }
    }

    public class Initilizer
    {
        public static IPaymentSystem InitilizeSystem(string systemId)
        {
            switch (systemId)
            {
                case "QIWI":
                    return new QIWI();
                case "WebMoney":
                    return new WebMoney();
                case "Card":
                    return new Card();
                default:
                    throw new ArgumentException(systemId);
            }
        }
    }

    public class OrderForm
    {
        public static string ShowForm()
        {
            Console.WriteLine("Мы принимаем: QIWI, WebMoney, Card");
            Console.WriteLine("Какой системой вы хотите совершить оплату?");
            return Console.ReadLine();
        }
    }

    public class PaymentHandler
    {
        public static void ShowPaymentResult(string systemId)
        {
            Console.WriteLine($"Вы оплатили с помощью {systemId}");
            Console.WriteLine($"Проверка платежа через {systemId}...");
            Console.WriteLine("Оплата прошла успешно!");
        }
    }

    public class QIWI : IPaymentSystem
    {
        public string SystemId => "QIWI";

        public QIWI()
        {
            Initialize();
        }

        public void Initialize()
        {
            Console.WriteLine("Перевод на страницу QIWI...");
        }

        public void ShowPaymentResult()
        {
            PaymentHandler.ShowPaymentResult(SystemId);
        }
    }

    public class WebMoney : IPaymentSystem
    {
        public string SystemId => "WebMoney";

        public WebMoney()
        {
            Initialize();
        }

        public void Initialize()
        {
            Console.WriteLine("Вызов API WebMoney...");
        }

        public void ShowPaymentResult()
        {
            PaymentHandler.ShowPaymentResult(SystemId);
        }
    }

    public class Card : IPaymentSystem
    {
        public string SystemId => "Card";

        public Card()
        {
            Initialize();
        }

        public void Initialize()
        {
            Console.WriteLine("Вызов API банка эмитера карты Card...");
        }

        public void ShowPaymentResult()
        {
            PaymentHandler.ShowPaymentResult(SystemId);
        }
    }

    public interface IPaymentSystem
    {
        public string SystemId { get; }
        public void Initialize();
        public void ShowPaymentResult();
    }
}
