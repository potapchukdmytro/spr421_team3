using Microsoft.AspNetCore.Identity;

namespace Team_Job.DAL.Entities.Identity
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser? User { get; set; }
    }
}
