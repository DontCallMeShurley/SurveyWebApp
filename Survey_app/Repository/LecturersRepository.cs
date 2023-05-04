using Microsoft.EntityFrameworkCore;
using Survey_app.Data;
using Survey_app.Models;

namespace Survey_app.Repository
{
    public class LecturersRepository
    {
        private readonly ApplicationDbContext _context;
        public LecturersRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Lecturers lecturers)
        {
            _context.Add(lecturers);
            return Save();
        }

        public bool Delete(Lecturers lecturers)
        {
            _context.Remove(lecturers);
            return Save();
        }

        public async Task<IEnumerable<Lecturers>> GetAll()
        {
            return await _context.Lecturers.Include(i => i.LecturersPost).ToListAsync(); 
        }

        public async Task<Lecturers> GetByIdAsync(int id)
        { 
            return await _context.Lecturers.Include(i => i.LecturersPost).Include(i => i.Subjects).ThenInclude(i => i.Subject).FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Lecturers lecturers)
        {
            _context.Update(lecturers);
            return Save(); 
        }
    }
}
