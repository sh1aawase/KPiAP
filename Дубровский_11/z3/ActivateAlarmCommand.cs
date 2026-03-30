

public class ActivateAlarmCommand : ICommand
{
    private AlarmSystem _alarm;

    public ActivateAlarmCommand(AlarmSystem alarm) => _alarm = alarm;

    public void Execute() => _alarm.Activate();
}