

class Program
{
    static void Main(string[] args)
    {
        AlarmSystem alarm = new AlarmSystem();
        SecurityPanel panel = new SecurityPanel();

        ICommand activate = new ActivateAlarmCommand(alarm);
        ICommand deactivate = new DeactivateAlarmCommand(alarm);

        panel.SetCommand(activate);
        panel.PressButton();

        panel.SetCommand(deactivate);
        panel.PressButton();
    }
}