using System;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Models
{
    public class EFCandyRepository : ICandyRepository
    {
        private CandyshopContext csContext { get; set; }

        public EFCandyRepository(CandyshopContext someName)
        {
            csContext = someName;
        }

        public IQueryable<Candy> Candies => csContext.Candies;

        public IQueryable<Category> Categories => csContext.Categories;

        //public void SaveChanges()
        //{
        //    throw new NotImplementedException();
        //}

        public void AddIt(Candy candy)
        {
            csContext.Add(candy);
            csContext.SaveChanges();
        }

        public void UpdateIt(Candy candy)
        {
            csContext.Update(candy);
            csContext.SaveChanges();
        }

        public void DeleteIt(Candy candy)
        {
            csContext.Remove(candy);
            csContext.SaveChanges();
        }
    }
}

