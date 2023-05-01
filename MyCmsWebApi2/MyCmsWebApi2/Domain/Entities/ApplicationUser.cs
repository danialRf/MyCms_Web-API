
using Microsoft.AspNetCore.Identity;

namespace MyCmsWebApi2.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string FullName { get; set; }
}