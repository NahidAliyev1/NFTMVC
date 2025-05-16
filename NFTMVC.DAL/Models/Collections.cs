using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTMVC.DAL.Models;

public class Collections
{
    public int Id { get; set; }
    public string ImgPath { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public double CollectionNumber { get; set; }
}
