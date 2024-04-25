using Allintra.Core.Case.EventNotifications;
using Allintra.Core.Case;
using Allintra.Core.Case.EventNotifications.Application;

public class StringNotificationReceiver : INotifiable<string>
{

    public void ReceiveNotification( Notification<string> notification )
    {
        Console.WriteLine( "Received notification: " + notification.Item );
    }
}

class Program
{
    static void Main( string[] args )
    {
        
        var notifier = new Notifier<string>();  

        // Create an instance of your notifiable
        var receiver = new StringNotificationReceiver();

        // Subscribe the notifiable to the notifier
        notifier.Subscribe( receiver );

        //NEED TO REMOVE: Example to trigger a notification
        notifier.Notify( "New notification" );

        Console.WriteLine( "Press any key to exit..." );
        Console.ReadLine();
    }
}
