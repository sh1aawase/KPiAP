

public class SpaDecorator : RoomServiceDecorator
{
    public SpaDecorator(IRoomService service) : base(service) { }

    public override string GetServiceDetails() => base.GetServiceDetails() + ", посещение SPA";
    public override double GetCost() => base.GetCost() + 2500.0;
}