﻿using RestWithASPNETUdemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        T FindById(long id);
        List<T> FindAll();
        T Create(T item);
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
