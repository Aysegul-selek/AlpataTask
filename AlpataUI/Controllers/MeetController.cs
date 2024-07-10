using AlpataBusiness.Abstract;
using AlpataEntities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AlpataAPI.Controllers
{
    public class MeetController : Controller
    {
        private readonly IMeetingServices _meetServices;

        public MeetController(IMeetingServices meetServices)
        {
            _meetServices = meetServices;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var meetings = _meetServices.GetAll().Data; 
            return View(meetings);
        }

        [HttpPost("add")]
        public IActionResult Add(Meeting meet)
        {
            var result = _meetServices.Add(meet);
            if (result.Success)
            {
                return RedirectToAction(nameof(GetAll));
            }
            return View(meet);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var meeting = _meetServices.GetById(id).Data; 
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Meeting meet)
        {
            var result = _meetServices.Delete(meet);
            if (result.Success)
            {
                return RedirectToAction(nameof(GetAll));
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Meeting meet)
        {
            var result = _meetServices.Update(meet);
            if (result.Success)
            {
                return RedirectToAction(nameof(GetAll));
            }
            return View(meet);
        }

        [HttpPost]
        public async Task<IActionResult> ScheduleMeeting(Meeting model)
        {
            // Meeting scheduling operations

            // Sending meeting notification email
            await _meetServices.SendMeetingNotification(model.Name, model.Description, model.StartDate);
            return Ok("Meeting scheduled successfully.");
            // Other operations
        }
    }
}
