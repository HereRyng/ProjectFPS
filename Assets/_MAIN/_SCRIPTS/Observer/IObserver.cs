
namespace Observables
{
    public interface IObserver
    {
        void ReceiveMessage(string message, params object[] args);

    }
    public interface ISubject
    {
        void SendMessage(string message);
    }

}
