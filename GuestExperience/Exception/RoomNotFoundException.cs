

namespace GuestExperience.Exception;

public class RoomNotFoundException : System.Exception
{
    public RoomNotFoundException(string message, System.Exception? innerException = null)
        : base(message, innerException)
    {
    }
}