using System;
using System.Collections.Generic;
using System.Text;

namespace GospoRol.Domain.Interfaces
{
    public interface IGenericRepository
    {
        public void Add<T>(T newItem) where T : class;
        public void Delete<T>(int itemId) where T : class;
    }
}
