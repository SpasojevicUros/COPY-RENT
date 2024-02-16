using ProjekatPPP.Data;
using ProjekatPPP.Models.Entity;
using ProjekatPPP.Repository.Base;

namespace ProjekatPPP.Repository
{
    public class KupacRepository : BaseRepository<Kupac>, IKupacRepository
    {
        private readonly ProjekatPPPContext _context;

        public KupacRepository(ProjekatPPPContext context) : base(context)
        {
            _context = context;
        }
    }
}
