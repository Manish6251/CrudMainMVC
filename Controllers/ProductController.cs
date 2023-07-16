using CrudMAin.Data;
using CrudMAin.Models;
using CrudMAin.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CrudMAin.Controllers
{
    public class ProductController : Controller
    {
        public readonly ApplicationContext context;
        public ProductController(ApplicationContext context)
        {
            this.context = context;
        }

        public IActionResult Index(int pg=1)
        {

            ProdCat pro = new ProdCat();
            pro.Products = context.Products.ToList();
            pro.Categories = context.Categories.ToList();

            const int pageSize =5;
            if(pg<1)
                pg = 1;
            int recsCount = pro.Products.Count();
            var pager = new Pager(recsCount,pg,pageSize);
            int recSkip =(pg-1) * pageSize;
            var data =pro.Products.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            return View(data);
        }
    }
}
