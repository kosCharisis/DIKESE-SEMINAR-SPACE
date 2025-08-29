using DIKESE.Data.Base;
using DIKESE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DIKESE.Data.Services
{
    public class SpeakersService : EntityBaseRepository<Speaker>, ISpeakersService
    {     

        public SpeakersService(DikeseDbContext context) : base(context) { }      
       
    }
}
