namespace SchoolApi.Exceptions;

public class UserSubjectNotFoundException:Exception
{
    public UserSubjectNotFoundException() : base($"UserSubject Not Found")
    {

    }
}