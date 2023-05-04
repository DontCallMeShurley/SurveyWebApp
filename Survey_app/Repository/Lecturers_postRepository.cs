using Microsoft.EntityFrameworkCore;
using Survey_app.Data;
using Survey_app.Models;

namespace Survey_app.Repository
{
    public class LecturersPostRepository
    {
        private readonly ApplicationDbContext _context;
        public LecturersPostRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(LecturersPost lecturersPost)
        {
            _context.Add(lecturersPost);
            return Save();
        }

        public bool Delete(LecturersPost lecturersPost)
        {
            _context.Remove(lecturersPost);
            return Save();
        }

        public async Task<IEnumerable<LecturersPost>> GetAll()
        {
            return await _context.LecturersPosts.ToListAsync();
        }

        public async Task<LecturersPost> GetByIdAsync(int id)
        {
            return await _context.LecturersPosts.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(LecturersPost lecturersPost)
        {
            _context.Update(lecturersPost);
            return Save();
        }
    }
}
