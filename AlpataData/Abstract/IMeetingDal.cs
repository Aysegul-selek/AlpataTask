using AlpataEntities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpataData.Abstract
{
    public interface IMeetingDal : IEntityRepository<Meeting>
    {
    }
}
