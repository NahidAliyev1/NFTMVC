using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTMVC.BL.ViewModel;

public class CollectionVM
{
    [Required (ErrorMessage ="Sekil elave ett")]
   public IFormFile ImgFile { get; set; }
    [Required(ErrorMessage = "Ad elave ett")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Categoryname elave ett")]
    public string CategoryName { get; set; }
    [Required(ErrorMessage = "Say elave ett")]
    public double CollectionNumber { get; set; }
}
