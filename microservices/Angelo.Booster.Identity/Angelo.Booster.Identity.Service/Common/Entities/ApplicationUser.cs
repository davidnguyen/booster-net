using Microsoft.AspNetCore.Identity;

namespace Angelo.Booster.Identity.Service.Common.Entities;

public class ApplicationUser : IdentityUser
{
    public string ApplicationRealm { get; set; }
}