using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockControl.Domain.Repositories;

namespace StockControl.Infrastructure.DataAcess
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly StockControlContext _context;

        public UnityOfWork(StockControlContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
