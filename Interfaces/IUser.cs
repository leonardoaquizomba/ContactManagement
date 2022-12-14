namespace ContactManagement.Interfaces
{
    public interface IUser
    {
        long Id { get; }
        string Name { get; }
        bool IsAuthenticated();
    }
}
