using System;
using System.ComponentModel.DataAnnotations;

namespace FinalExam.Models
{
	public partial class Candy
	{
		[Key]
		[Required]
		public int CandyId { get; set; }
        [Required(ErrorMessage ="You need a title you cotton headed ninny muggins")]
        public string? Title { get; set; }
        //[Required]
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public string? Isbn { get; set; }
        public string? Classification { get; set; }
        public int PageCount { get; set; }
        
        public double Price { get; set; }

        //foreign key relationship
        [Required]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

