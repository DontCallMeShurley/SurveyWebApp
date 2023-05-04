using Microsoft.EntityFrameworkCore;
using Survey_app.Data;
using Survey_app.Models;

namespace Survey_app.Repository
{
    public class SubjectsLecturersRepository
    {
        private readonly ApplicationDbContext _context;

        public SubjectsLecturersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(SubjectsLecturers subjectsLecturers)
        {
            _context.Add(subjectsLecturers);
            return Save();
        }

        public bool Delete(SubjectsLecturers subjectsLecturers)
        {
            _context.Remove(subjectsLecturers);
            return Save();
        }

        public async Task<IEnumerable<SubjectsLecturers>> GetAll()
        {
            return await _context.SubjectsLecturers.Include(i => i.Lecturers).Include(i => i.Subject).ToListAsync();
        }

        public async Task<SubjectsLecturers?> GetByIdAsync(int id)
        {
            return await _context.SubjectsLecturers.Include(i => i.Lecturers).Include(i => i.Subject).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(SubjectsLecturers subjectsLecturers)
        {
            _context.Update(subjectsLecturers);
            return Save();
        }
    }
}
