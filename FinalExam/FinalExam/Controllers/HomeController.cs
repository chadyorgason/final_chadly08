using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FinalExam.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Controllers;

public class HomeController : Controller
{
    private CandyshopContext csContext { get; set; }

    public HomeController(CandyshopContext someName)
    {
        csContext = someName;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.cats = csContext.Categories.ToList();
        return View(new Candy());
    }

    [HttpPost]
    public IActionResult Add ( Candy can)
    {
        if (ModelState.IsValid)
        {
            csContext.Add(can);
            csContext.SaveChanges();
            return View("Confirmation", can);
        }
        else
        {
            ViewBag.cats = csContext.Categories.ToList();
            return View();
        }
    }

    public IActionResult CList()
    {
        var candies = csContext.Candies
            .Include(x => x.Category)
            //.Where(x => x.Title == "Michael")
            .OrderBy(x => x.Title)
            .ToList();

        return View(candies);
    }

    [HttpGet]
    public IActionResult Edit(int candyid)
    {
        ViewBag.cats = csContext.Categories.ToList();
        var candy = csContext.Candies.Single(x => x.CandyId == candyid);
        return View("Add", candy);
    }

    [HttpPost]
    public IActionResult Edit(Candy duh)
    {
        if (ModelState.IsValid)
        {
            csContext.Update(duh);
            csContext.SaveChanges();
            return RedirectToAction("CList");
        }
        else
        {
            ViewBag.cats = csContext.Categories.ToList();
            var candy = csContext.Candies.Single(x => x.CandyId == duh.CandyId);
            return View("Add", candy);
        }
    }

    [HttpGet]
    public IActionResult Delete(int candyid)
    {
        var candy = csContext.Candies.Single(x => x.CandyId == candyid);
        return View(candy);
    }

    [HttpPost]
    public IActionResult Delete(Candy can)
    {
        csContext.Candies.Remove(can);
        csContext.SaveChanges();
        return RedirectToAction("CList");
    }



    //public IActionResult Index(string bookType, int pageNum = 1)
    //{
    //    int pageSize = 10;

    //    var x = new BooksViewModel
    //    {
    //        Books = repo.Books
    //        .Where(b => b.Category == bookType || bookType == null)
    //        .OrderBy(b => b.Title)
    //        .Skip((pageNum - 1) * pageSize)
    //        .Take(pageSize),

    //        PageInfo = new PageInfo
    //        {
    //            TotalNumBooks =
    //                (bookType == null
    //                ? repo.Books.Count()
    //                : repo.Books.Where(b => b.Category == bookType).Count()),
    //            BooksPerPage = pageSize,
    //            CurrentPage = pageNum
    //        }
    //    };

    //    return View(x);
}

