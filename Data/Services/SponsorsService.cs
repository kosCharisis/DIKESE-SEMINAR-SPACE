using DIKESE.Data.Base;
using DIKESE.Models;

namespace DIKESE.Data.Services
{
    public class SponsorsService : EntityBaseRepository<Sponsor>, ISponsorsService
    {
        public SponsorsService(DikeseDbContext context) : base(context) { }

    }
    
}
