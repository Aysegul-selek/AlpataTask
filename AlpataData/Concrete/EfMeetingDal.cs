using AlpataData.Abstract;
using AlpataData.Concrete.Context.DataAccess.Concrete.EntityFramework.Contexts;
using AlpataEntities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpataData.Concrete
{
    public class EfMeetingDal : EfEntityRepoSitoryBase<Meeting, AlpataContext>, IMeetingDal
    {
    }
}
