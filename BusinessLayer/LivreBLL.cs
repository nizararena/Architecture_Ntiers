using DataRepository;
using IBusinessLayer;
using IDataRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class LivreBLL : ILivreBLL
    {
        ILivreRepository _dataFactory;
        public LivreBLL() : this(new LivreRepository())
        {

        }

        /// <summary>
        /// Constructeur 2
        /// Injection de dépendence par le constructeur
        /// </summary>
        /// <param name="dataFactory"></param>
        public LivreBLL(ILivreRepository dataFactory)
        {
            _dataFactory = dataFactory;
        }
        public IQueryable<Livre> GetLivres()
        {
            try
            {
                return _dataFactory.GetLivres();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Livre PostLivre(Livre book)

        {
            return _dataFactory.PostLivre(book);
        }
        public void Dispose()
        {
            if (_dataFactory != null)
            {
                _dataFactory.Dispose();
            }

        }
    }
}