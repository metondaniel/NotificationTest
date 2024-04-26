using Allintra.Core.Case.EventNotifications;
using Allintra.Core.Case;
using Allintra.Core.Case.EventNotifications.Application;

public class NotificationApp : IApp
{
    private NotificationReceiver _receiver;

    public NotificationApp()
    {
        _receiver = new NotificationReceiver();
    }

    public void OnLoad( IAllintraCoreApp allintraCore  )
    {
        allintraCore.Subscribe( _receiver );
    }


}

public class NotificationReceiver : INotifiable<ICase>
{

    public void ReceiveNotification( Notification<ICase> notification )
    {
        Console.WriteLine( $"Received notification: {notification.Item}" );
    }
}

class Program
{
    static void Main( string[] args )
    {
        var core = AllintraCore.Instance; 

        IApp notificationApp = new NotificationApp();
        core.AddApp( notificationApp );

        core.Run(); 

        Console.WriteLine( "AllintraCore is now running. Press any key to exit..." );
        Console.ReadLine();
    }
}