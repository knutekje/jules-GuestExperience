namespace GuestExperience.Exception;

public class GuestServiceException: System.Exception

{
    public GuestServiceException(string message, System.Exception? innerException = null)
        : base(message, innerException)
    {
    }    
}