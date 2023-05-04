using Microsoft.EntityFrameworkCore;
using Survey_app.Data;
using Survey_app.Models;

namespace Survey_app.Repository
{
    public class QuestionsRepository
    {
        private readonly ApplicationDbContext _context;
        public QuestionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Questions questions)
        {
            _context.Add(questions);
            return Save();
        }

        public bool Delete(Questions questions)
        {
            _context.Remove(questions);
            return Save();
        }

        public async Task<IEnumerable<Questions>> GetAll()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Questions> GetByIdAsync(int id)
        {
            return await _context.Questions.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Questions questions)
        {
            _context.Update(questions);
            return Save();
        }
    }
}
