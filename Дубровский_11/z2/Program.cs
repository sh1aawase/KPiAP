using System;

class Program
{
    static void Main(string[] args)
    {
        IRoomService myOrder = new BasicRoomService();
        Console.WriteLine($"Базовый заказ: {myOrder.GetServiceDetails()} | Цена: {myOrder.GetCost()}");

        myOrder = new BreakfastDecorator(myOrder);
        myOrder = new SpaDecorator(myOrder);

        Console.WriteLine($"Заказ с услугами: {myOrder.GetServiceDetails()}");
        Console.WriteLine($"Итоговая стоимость: {myOrder.GetCost()}");

        IRoomService vipOrder = new AirportPickupDecorator(new BreakfastDecorator(new BasicRoomService()));
        Console.WriteLine($"\nVIP заказ: {vipOrder.GetServiceDetails()} | Цена: {vipOrder.GetCost()}");
    }
}