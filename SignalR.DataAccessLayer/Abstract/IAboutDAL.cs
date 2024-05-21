using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    //IGenericDal dan miras alacak. Kim için? About sınıfı için.Abouta ait bir özellik olduğunda gelip burada tanımlayabiliriz.
    public interface IAboutDAL : IGenericDal<About>
    {
    }
}
