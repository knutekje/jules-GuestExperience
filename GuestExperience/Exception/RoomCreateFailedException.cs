namespace GuestExperience.Exception;

public class RoomCreateFailedException : System.Exception
{
    public RoomCreateFailedException(string message, System.Exception? innerException = null)
        : base(message, innerException)
    {
    }
}