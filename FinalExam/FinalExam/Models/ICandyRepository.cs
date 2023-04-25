using System;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Models
{
	public interface ICandyRepository
	{

        IQueryable<Candy> Candies { get; }
        IQueryable<Category> Categories { get; }

        //void SaveChanges();
        void AddIt(Candy candy);
        void UpdateIt(Candy candy);
        void DeleteIt(Candy candy);
        
        
        
    }
}

