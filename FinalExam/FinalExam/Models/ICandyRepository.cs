using System;
namespace FinalExam.Models
{
	public interface ICandyRepository
	{
		IQueryable<Candy> Candies { get; }
	}
}

