namespace Authorization.Domain.Entities;

public class AppUser
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string HashedPassword { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public bool IsDeleted { get; set; }
}