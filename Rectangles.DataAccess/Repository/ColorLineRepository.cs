using Rectangles.DataAccess.Data;
using Rectangles.DataAccess.IRepository;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;

namespace Rectangles.DataAccess.Repository
{
    public class ColorLineRepository : Repository<ColorLine>, IColorLineRepository
    {
        private readonly ApplicationDbContext _db;

        public ColorLineRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
