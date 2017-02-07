using NewsPortal.Core.Infrastructure;
using NewsPortal.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Data.Model;
using System.Linq.Expressions;
using System.Data.Entity.Migrations; //AddOrUpdate için

namespace NewsPortal.Core.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsContext _context = new NewsContext();
        public int Count()
        {
            return _context.Newss.Count();
        }

        public void Delete(int id)
        {
            var news = GetById(id);
            if (news != null)
            {
                _context.Newss.Remove(news);
            }
        }
        
        public News Get(Expression<Func<News, bool>> expression)
        {
            return _context.Newss.FirstOrDefault(expression);
        }

        public IEnumerable<News> GetAll()
        {
            return _context.Newss.Select(x => x); //Tüm haberler dönecek.
        }

        public News GetById(int id)
        {
            return _context.Newss.FirstOrDefault(x => x.ID == id); //Id deki değere sahip haber dönecek.
        }

        public IQueryable<News> GetMany(Expression<Func<News, bool>> expression)
        {
            return _context.Newss.Where(expression); 
        }

        public void Insert(News obj)
        {
            _context.Newss.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(News obj)
        {
            _context.Newss.AddOrUpdate(obj);
        }
    }
}
