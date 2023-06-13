using Rectangles.DataAccess.Data;
using Rectangles.DataAccess.IRepository;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;

namespace Rectangles.DataAccess.Repository
{
    public class ColorBodyRepository : Repository<ColorBody>, IColorBodyRepository
    {
        private readonly ApplicationDbContext _db;

        public ColorBodyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
