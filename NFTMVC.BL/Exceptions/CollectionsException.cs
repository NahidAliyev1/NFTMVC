using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTMVC.BL.Exceptions;

public class CollectionsException:Exception
{
    public CollectionsException():base("Default mesajdir")
    {
        
    }
    public CollectionsException(string errormessage):base(errormessage)
    {
        
    }
}
