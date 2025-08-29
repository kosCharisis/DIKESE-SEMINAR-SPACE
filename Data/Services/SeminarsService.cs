using DIKESE.Data.Base;
using DIKESE.Data.ViewModels;
using DIKESE.Models;
using Microsoft.EntityFrameworkCore;

namespace DIKESE.Data.Services
{
    public class SeminarsService : EntityBaseRepository<Seminar>, ISeminarsService
    {
        private readonly DikeseDbContext _context;
        public SeminarsService(DikeseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewSeminarAsync(NewSeminarVM data)
        {
            var newSeminar = new Seminar()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                RoomId = data.RoomId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                SeminarCategory = data.SeminarCategory,
                SponsorId = data.SponsorId
            };
            await _context.Seminars.AddAsync(newSeminar);
            await _context.SaveChangesAsync();

            //Add Seminar Speakers
            foreach (var speakerId in data.SpeakerIds)
            {
                var newSpeakerSeminar = new Speaker_Seminar()
                {
                    SeminarId = newSeminar.Id,
                    SpeakerId = speakerId
                };
                await _context.Speakers_Seminars.AddAsync(newSpeakerSeminar);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Seminar> GetSeminarByIdAsync(int id)
        {
            var seminarDetails = await _context.Seminars
                .Include(r=> r.Room)
                .Include(p => p.Sponsor)
                .Include(se => se.Speakers_Seminars).ThenInclude(s => s.Speaker)
                .FirstOrDefaultAsync(n => n.Id == id);

            return seminarDetails;
        }

        public async Task<NewSeminarDropdownsVM> GetNewSeminarDropdownsValues()
        {
            var response = new NewSeminarDropdownsVM()
            {
                Speakers = await _context.Speakers.OrderBy(n => n.FullName).ToListAsync(),
                Rooms = await _context.Rooms.OrderBy(n => n.Name).ToListAsync(),
                Sponsors = await _context.Sponsors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateSeminarAsync(NewSeminarVM data)
        {
            var dbSeminar = await _context.Seminars.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbSeminar != null)
            {
                dbSeminar.Name = data.Name;
                dbSeminar.Description = data.Description;
                dbSeminar.Price = data.Price;
                dbSeminar.ImageURL = data.ImageURL;
                dbSeminar.RoomId = data.RoomId;
                dbSeminar.StartDate = data.StartDate;
                dbSeminar.EndDate = data.EndDate;
                dbSeminar.SeminarCategory = data.SeminarCategory;
                dbSeminar.SponsorId = data.SponsorId;
                await _context.SaveChangesAsync();
            }

            //Remove existing Speakers
            var existingSpeakersDb = _context.Speakers_Seminars.Where(n => n.SeminarId == data.Id).ToList();
            _context.Speakers_Seminars.RemoveRange(existingSpeakersDb);
            await _context.SaveChangesAsync();

            //Add Seminar Speakers
            foreach (var speakerId in data.SpeakerIds)
            {
                var newSpeakerSeminar = new Speaker_Seminar()
                {
                    SeminarId = data.Id,
                    SpeakerId = speakerId
                };
                await _context.Speakers_Seminars.AddAsync(newSpeakerSeminar);
            }
            await _context.SaveChangesAsync();
        }
    }
}