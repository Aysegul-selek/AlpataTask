using AlpataEntities.Concrete;
using Core.Utilities.Results;

namespace AlpataBusiness.Abstract
{
    public interface IMeetingServices
    {
        IDataResult<List<Meeting>> GetAll();
        IDataResult<Meeting> GetById(int id);
        IResult Update(Meeting meet);
        IResult Delete(Meeting meet);
        IResult Add(Meeting meet);
        Task SendMeetingNotification(string name, string description, DateTime StartDate);
    }
}
