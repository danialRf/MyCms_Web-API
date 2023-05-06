
using Microsoft.AspNetCore.Identity;
using MyCmsWebApi2.Domain.Enums;

namespace MyCmsWebApi2.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public string Name { get; set; }
    public string FamilyName { get; set; }
    
    
    
    



}