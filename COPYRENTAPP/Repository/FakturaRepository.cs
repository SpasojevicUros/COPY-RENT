using ProjekatPPP.Data;
using ProjekatPPP.Models.Entity;
using ProjekatPPP.Repository.Base;

namespace ProjekatPPP.Repository
{
    public class FakturaRepository : BaseRepository<Faktura>, IFakturaRepository
    {
        private readonly ProjekatPPPContext _context;

        public FakturaRepository(ProjekatPPPContext context) : base(context)
        {
            _context = context;
        }
    }
}
