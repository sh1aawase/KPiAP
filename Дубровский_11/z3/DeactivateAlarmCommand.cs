

public class DeactivateAlarmCommand : ICommand
{
    private AlarmSystem _alarm;

    public DeactivateAlarmCommand(AlarmSystem alarm) => _alarm = alarm;

    public void Execute() => _alarm.Deactivate();
}