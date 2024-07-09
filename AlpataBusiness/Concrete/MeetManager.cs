using AlpataBusiness.Abstract;
using AlpataData.Abstract;
using AlpataEntities.Concrete;
using Business.Constants;
using Castle.Core.Configuration;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpataBusiness.Concrete
{
    public class MeetManager : IMeetingServices
    {
        private readonly IConfiguration _configuration;

        IMeetingDal _meetingDal;

        public MeetManager(IMeetingDal meetingDal, IConfiguration configuration)
        {
            _meetingDal = meetingDal;
            _configuration = configuration;
        }

        public IResult Add(Meeting meet)
        {
            _meetingDal.Add(meet);
            return new SuccessResult(Messages.Success);
        }

        public IResult Delete(Meeting meet)
        {
            _meetingDal.Delete(meet);
            return new SuccessResult(Messages.Success);

        }

        public IDataResult<List<Meeting>> GetAll()
        {
            return new SuccessDataResult<List<Meeting>>(_meetingDal.GetAll(), Messages.Success);
        }

        public IDataResult<Meeting> GetById(int id)
        {
            return new SuccessDataResult<Meeting>(_meetingDal.Get(p => p.Id == id));
        }

        public Task SendMeetingNotification(string userEmail, string meetingSubject, DateTime meetingTime)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Meeting meet)
        {
            _meetingDal.Update(meet);
            return new SuccessResult(Messages.Success);
        }
       
    }
}
