

public class BreakfastDecorator : RoomServiceDecorator
{
    public BreakfastDecorator(IRoomService service) : base(service) { }

    public override string GetServiceDetails() => base.GetServiceDetails() + ", завтрак (шведский стол)";
    public override double GetCost() => base.GetCost() + 800.0;
}