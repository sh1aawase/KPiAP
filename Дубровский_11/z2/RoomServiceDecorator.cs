

public abstract class RoomServiceDecorator : IRoomService
{
    protected IRoomService _roomService;

    public RoomServiceDecorator(IRoomService roomService)
    {
        _roomService = roomService;
    }

    public virtual string GetServiceDetails() => _roomService.GetServiceDetails();
    public virtual double GetCost() => _roomService.GetCost();
}