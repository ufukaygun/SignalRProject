using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    //Entity Framework içerisindeki classlarla interfaceleri ve genericr repoyu haberleştirmemiz gerekiyor.
    //ISliderDAL dan miras almasının sebebi şu başka zaman Slider özgü entityler gelebilir. o zaman devreye IAboutDAL bu giriyor
    public class EfSliderDal : GenericRepository<Slider>, ISliderDAL
    {
        public EfSliderDal(SignalRContext context) : base(context)
        {

        }
    }
}
