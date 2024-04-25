A DLL foi projetada para oferecer uma interface (INotifiable<T>) para o recebimento e tratamento de notificações. A decisão de usar interfaces ao invés de métodos diretos (como Action<T>) 
para notificações visa proporcionar maior flexibilidade e encapsulamento.

Antes de utilizar a DLL em seu projeto, você deve adicioná-la como uma referência em seu projeto no Visual Studio ou outro ambiente de desenvolvimento que esteja usando.
No Visual Studio, clique com o botão direito do mouse sobre References em seu projeto e selecione Add Reference. Navegue até a localização da DLL e adicione-a ao seu projeto.

Para acessar as classes e interfaces da DLL, adicione a declaração using no topo de seus arquivos de código:

using Allintra.Core.Case.EventNotifications;

Crie uma classe que implemente a interface INotifiable<string>. Exemplo:

public class StringNotificationReceiver : INotifiable<string>
{
    public void ReceiveNotification(string message)
    {
        Console.WriteLine("Received notification: " + message);
    }
}

No ponto de entrada da sua aplicação, crie uma instância da classe de notificações e registre para receber notificações:

var receiver = new StringNotificationReceiver();
var notifier = new Notifier<string>();
notifier.Subscribe(receiver);

Utilize o método Notify para enviar notificações se quiser testar sua aplicação, depois de testar remova esse código:

notifier.Notify("New Notification");

Justificativa para utilizar interfaces:
Permite encapsular a lógica de notificação e facilita a manutenção e extensão do sistema. Clientes podem implementar suas próprias classes de recepção de notificações sem impactar outras partes do sistema.
