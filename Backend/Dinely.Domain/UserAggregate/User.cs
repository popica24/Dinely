using Dinely.Domain.Common.Models;
using Dinely.Domain.UserAggregate.ValueObjects;

namespace Dinely.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private User()
    {

    }

    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime
        ) : base(id)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password
    )
    {
        return new(
            UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }

}
