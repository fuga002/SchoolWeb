namespace SchoolApi.Exceptions;

public class TaskNotFoundException:Exception
{
    public TaskNotFoundException(int subjectId) : base($"Task not with subject id -> {subjectId} ")
    {

    }
}