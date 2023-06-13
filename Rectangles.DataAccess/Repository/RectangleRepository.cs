using Rectangles.DataAccess.Data;
using Rectangles.DataAccess.IRepository;
using Rectangles.DataAccess.Repository.IRepository;
using Rectangles.Models;

namespace Rectangles.DataAccess.Repository
{
    public class RectangleRepository : Repository<Rectangle>, IRectangleRepository
    {
        private readonly ApplicationDbContext _db;

        public RectangleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
