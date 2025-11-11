using Microsoft.AspNetCore.Identity;

namespace Team_Job.DAL.Entities.Identity
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
