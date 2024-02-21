namespace SchoolApi.Exceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException(string message): base($"User not foud with this {message}")
    {
        
    }
}