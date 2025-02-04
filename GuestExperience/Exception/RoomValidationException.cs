namespace GuestExperience.Exception;

public class RoomValidationException : System.Exception
{
    
    public RoomValidationException(string message, System.Exception? innerException = null)
        : base(message, innerException)
    {
    }
}