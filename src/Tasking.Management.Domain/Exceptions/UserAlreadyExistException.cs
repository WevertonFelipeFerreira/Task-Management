namespace Tasking.Management.Domain.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        //TODO Remove the hard code string and use resource message
        public UserAlreadyExistException() : base("User Already Exist")
        {

        }
    }
}
