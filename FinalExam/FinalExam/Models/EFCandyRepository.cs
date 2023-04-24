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

        public IQueryable<Candy> Candies => throw new NotImplementedException();
    }
}

