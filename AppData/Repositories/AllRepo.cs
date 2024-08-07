﻿using App_Data.DbContext;
using App_Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App_Data.Repositories
{
    public class AllRepo<T> : IAllRepo<T> where T : class
    {
        private AppDbContext context;

        private DbSet<T> dbset;

        public AllRepo()
        {
            context = new AppDbContext();
            dbset = context.Set<T>();
        }

        public AllRepo(AppDbContext context, DbSet<T> dbset)
        {
            this.context = context;
            this.dbset = dbset;
        }

        public AppDbContext Context => context;

        public DbSet<T> Dbset => dbset;
        public bool AddItem(T item)
        {
            try
            {
                dbset.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool EditItem(T item)
        {
            try
            {
                dbset.Update(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }


        public bool RemoveItem(T item)
        {
            try
            {

                dbset.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //public string MaTS()
        //{
        //    string typeName = typeof(T).Name.Substring(0, 4);
        //    PropertyInfo propertyInfo = typeof(T).GetProperty("Ma");

        //    if (propertyInfo != null && propertyInfo.PropertyType == typeof(string))
        //    {
        //        return GetAll().Count() == 0 ? typeName + "1" : typeName + GetAll().Max(c => Convert.ToInt32(propertyInfo.GetValue(c).ToString().Substring(4)) + 1).ToString();
        //    }
        //    return "";
        //}
    }
}
