namespace SchoolApi.Exceptions;

public class InvalidPhotoException:Exception
{
    public InvalidPhotoException() : base($"Invalid photo data")
    {

    }
}