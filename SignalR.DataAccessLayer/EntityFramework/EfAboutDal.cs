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
    //IAboutDAL dan miras almasının sebebi şu başka zaman Abouta özgü entityler gelebilir. o zaman devreye IAboutDAL bu giriyor
    public class EfAboutDal : GenericRepository<About>, IAboutDAL
    {
        public EfAboutDal(SignalRContext context) : base(context)
        {
        }
    }
}
