
using Microsoft.AspNetCore.Identity;
using MyCmsWebApi2.Domain.Enums;

namespace MyCmsWebApi2.Domain.Entities;

public class ApplicationUser : IdentityUser<Guid>
{
    public String Name { get; set; }
    public String FamilyName { get; set; }
    
    
    
    



}