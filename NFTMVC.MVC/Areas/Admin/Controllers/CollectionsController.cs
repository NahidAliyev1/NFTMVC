using Microsoft.AspNetCore.Mvc;
using NFTMVC.BL.Services;
using NFTMVC.DAL.Models;
using NFTMVC.BL.ViewModel; 

namespace NFTMVC.MVC.Areas.Admin.Controllers;

[Area("Admin")]
public class CollectionsController : Controller
{


    private readonly CollectionsService _collectionsService;
    public CollectionsController(CollectionsService collectionsService)
    {
        _collectionsService = collectionsService;
    }

    public IActionResult Index()
    {
        List<Collections> collections = _collectionsService.GetAllCllections();
        return View(collections);
    }

    [HttpGet]
    public IActionResult Info(int id) 
    {
        Collections collections = _collectionsService.GetCollectionsById(id);
        return View(collections);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(CollectionVM collectionsVM)
    {
        
        _collectionsService.CreateCollections(collectionsVM);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
    
        Collections collections = _collectionsService.GetCollectionsById(id);
        CollectionVM colvm = new CollectionVM();
        colvm.CollectionNumber = collections.CollectionNumber;
        colvm.CategoryName = collections.CategoryName;
        colvm.Name = collections.Name;
        return View(colvm);
    }
    [HttpPost]
    public IActionResult Update(int id, CollectionVM collections)
    {
        _collectionsService.UpdateCollections(id, collections);
        return RedirectToAction(nameof(Index));
    }
    [HttpGet]
    public IActionResult Delete(int id) 
    {
        _collectionsService.DeleteCollections(id);
        return RedirectToAction(nameof(Index));
    }
}
