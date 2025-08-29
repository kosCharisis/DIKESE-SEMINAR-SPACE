using DIKESE.Data.Base;
using DIKESE.Models;

namespace DIKESE.Data.Services
{
    public class RoomsService : EntityBaseRepository<Room>, IRoomsService
    {
        public RoomsService(DikeseDbContext context) : base(context)
        {
        }

    }
}
