namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Diagnostics;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels;
    using AspNetCoreTemplate.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {

        //DB 1 Method
        //public readonly ApplicationDbContext db;
        //public HomeController(ApplicationDbContext db)
        //{
        //    this.db = db;
        //}


        //Implementing IDeletable 2 Method and having access too AllWithDeleted()... +  IMap 3 Method
        //private readonly IDeletableEntityRepository<Category> categoriesRepository;
        //public HomeController(IDeletableEntityRepository<Category> categoriesRepository)
        //{
        //    this.categoriesRepository = categoriesRepository;
        //}

        public ICategoriesService categoriesService { get; }

        public HomeController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }
        public IActionResult Index()
        {
            //var viewModel = new IndexViewModel();

            //DB 1 Method
            //var categories = db.Categories.Select(x => new IndexCategoryViewModel()
            //{
            //    Description = x.Description,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    Title = x.Title,

            //}).ToList();


            //IMap 2 Method
            //var categories = this.categoriesRepository.All().Select(x => new IndexCategoryViewModel()
            //{
            //    Description = x.Description,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    Title = x.Title,

            //}).ToList();


            //3 IMAM FROM<Category> in IndexCategoryViewModel 
            //var categories = this.categoriesRepository
            //    .All()
            //    .To<IndexCategoryViewModel>()
            //    .ToList();

            var viewModel = new IndexViewModel
            {
                Categories = categoriesService.GetAll<IndexCategoryViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
