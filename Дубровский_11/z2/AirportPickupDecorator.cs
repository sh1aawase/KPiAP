

public class AirportPickupDecorator : RoomServiceDecorator
{
    public AirportPickupDecorator(IRoomService service) : base(service) { }

    public override string GetServiceDetails() => base.GetServiceDetails() + ", трансфер из аэропорта";
    public override double GetCost() => base.GetCost() + 1500.0;
}