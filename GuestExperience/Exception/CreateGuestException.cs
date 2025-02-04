namespace GuestExperience.Exception;

public class CreateGuestException : System.Exception
{
    public CreateGuestException(string message, System.Exception? innerException = null)
        : base(message, innerException)
    {
    }
}