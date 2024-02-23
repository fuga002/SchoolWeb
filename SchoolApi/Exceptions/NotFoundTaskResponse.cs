namespace SchoolApi.Exceptions;

public class NotFoundTaskResponse:Exception
{
    public NotFoundTaskResponse() : base("Task response not found")
    {

    }
}