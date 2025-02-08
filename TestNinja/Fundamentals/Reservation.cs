namespace TestNinja.Fundamentals
{
    public class Reservation
    {
        public User MadeBy { get; set; } = new User();

        public bool CanBeCancelledBy(User user)
        {
            return (user.IsAdmin || MadeBy == user);
        }
        
    }

    public class User
    {
        public bool IsAdmin { get; set; }
    }
}