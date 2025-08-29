using DIKESE.Data.Base;
using DIKESE.Data.ViewModels;
using DIKESE.Models;

namespace DIKESE.Data.Services
{
    public interface ISeminarsService : IEntityBaseRepository<Seminar>
    {
        Task<Seminar> GetSeminarByIdAsync(int id);

        Task<NewSeminarDropdownsVM> GetNewSeminarDropdownsValues();
        Task AddNewSeminarAsync(NewSeminarVM data);

        Task UpdateSeminarAsync(NewSeminarVM data);

    }
}
