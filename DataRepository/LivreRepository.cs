using IDataRepository;
using Models;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class LivreRepository : ILivreRepository
    {
        private ConDB _context = null;

        public LivreRepository()
        {
            _context = ConDB.Instance;
        }

        public IQueryable<Livre> GetLivres()
        {
            return _context.Livres;
        }
        public Livre PostLivre(Livre book)
        {
            Livre booky = _context.Livres.Add(book);
            _context.SaveChangesAsync();

            return booky;
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

    }
}
