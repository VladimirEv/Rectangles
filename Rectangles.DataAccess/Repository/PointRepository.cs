using Rectangles.DataAccess.Data;
using Rectangles.DataAccess.IRepository;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;

namespace Rectangles.DataAccess.Repository
{
    public class PointRepository : Repository<Point>, IPointRepository
    {
        private readonly ApplicationDbContext _db;

        public PointRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
