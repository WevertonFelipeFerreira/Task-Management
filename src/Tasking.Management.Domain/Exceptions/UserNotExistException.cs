namespace Tasking.Management.Domain.Exceptions
{
    public class UserNotExistException : Exception
    {
        public UserNotExistException() : base("User not exist.")
        {

        }
    }
}
