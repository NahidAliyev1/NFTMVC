using Microsoft.AspNetCore.Mvc;
using NFTMVC.BL.Services;
using NFTMVC.DAL.Models;

namespace NFTMVC.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CollectionsService _collectionsService;

        public HomeController(CollectionsService collectionsService)
        {
            _collectionsService = collectionsService;
        }
        public IActionResult Index()
        {
            List<Collections> collections = _collectionsService.GetAllCllections();
            return View(collections);
        }
    }
}
