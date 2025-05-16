using Microsoft.EntityFrameworkCore;
using NFTMVC.BL.Exceptions;
using NFTMVC.DAL.Contexts;
using NFTMVC.DAL.Models;
using NFTMVC.BL.ViewModel;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTMVC.BL.Services;

public class CollectionsService
{
    private readonly AppDbContext _context;
    public CollectionsService(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }
    #region Read
    public List<Collections> GetAllCllections()
    {
        List<Collections> collections = _context.Collections.ToList();
        return collections;
    }
    public Collections GetCollectionsById(int id)
    {
        Collections? collections = _context.Collections.Find(id);
        if (collections is null)
        {
            throw new CollectionsException($"Databasada Bu {id} tapilmadi");
        }
        return collections;
    }
    #endregion

    #region Create
    public void CreateCollections(CollectionVM collectionsVM) 
    {
        Collections newcollections = new Collections();

        newcollections.Name = collectionsVM.Name;
        newcollections.CategoryName = collectionsVM.CategoryName;
        newcollections.CollectionNumber = collectionsVM.CollectionNumber;

        string fileName = Path.GetFileNameWithoutExtension(collectionsVM.ImgFile.FileName);
        string extension = Path.GetExtension(collectionsVM.ImgFile.FileName);
        string resultName = fileName + Guid.NewGuid().ToString() + extension;

        newcollections.ImgPath = resultName;
        string uploadedPath = "C:\\Users\\II Novbe\\source\\repos\\NFTMVC\\NFTMVC.MVC\\wwwroot\\assets\\uploadedImages";
        uploadedPath = Path.Combine(uploadedPath, resultName);

       using  FileStream fileStream = new FileStream(uploadedPath, FileMode.Create);


        collectionsVM.ImgFile.CopyTo(fileStream);


       



        _context.Collections.Add(newcollections);
        _context.SaveChanges();
    }
    #endregion

    #region Update
    public void UpdateCollections(int id, CollectionVM collectionsVM) 
    {

        Collections newcollections = new Collections();

        newcollections.Name = collectionsVM.Name;
        newcollections.CategoryName = collectionsVM.CategoryName;
        newcollections.CollectionNumber = collectionsVM.CollectionNumber;

        string fileName = Path.GetFileNameWithoutExtension(collectionsVM.ImgFile.FileName);
        string extension = Path.GetExtension(collectionsVM.ImgFile.FileName);
        string resultName = fileName + Guid.NewGuid().ToString() + extension;

        newcollections.ImgPath = resultName;
        string uploadedPath = "C:\\Users\\II Novbe\\source\\repos\\NFTMVC\\NFTMVC.MVC\\wwwroot\\assets\\uploadedImages";
        uploadedPath = Path.Combine(uploadedPath, resultName);

        using FileStream fileStream = new FileStream(uploadedPath, FileMode.Create);


        collectionsVM.ImgFile.CopyTo(fileStream);

       
        Collections? collections1 = _context.Collections.AsNoTracking().SingleOrDefault(cl =>cl.Id==id);

        if (collections1 is not null)
        {
            _context.Update(collections1);
            _context.SaveChanges();
        }
        else
        {
            throw new CollectionsException($"databasda bu {id} tapilmadi");
        }
    }
    #endregion
    #region Delete
    public void DeleteCollections(int id) 
    {
        Collections? collections = _context.Collections.Find(id);
        if (collections is null)
        {
            throw new CollectionsException($"databasda bu {id} tapilmadi");
        }
        _context.Remove(collections);
        _context.SaveChanges();
    }
    #endregion



}
