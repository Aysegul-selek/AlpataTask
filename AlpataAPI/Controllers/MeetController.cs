using AlpataBusiness.Abstract;
using AlpataEntities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace AlpataAPI.Controllers
{
    public class MeetController : ControllerBase
    {
        IMeetingServices _meetServices;

        public MeetController(IMeetingServices meetServices)
        {
            _meetServices = meetServices;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _meetServices.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Meeting meet)
        {
            var result = _meetServices.Add(meet);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _meetServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Meeting meet)
        {
            var result = _meetServices.Delete(meet);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Meeting meet)
        {
            var result = _meetServices.Update(meet);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpPost]
        public async Task<IActionResult> ScheduleMeeting(Meeting model)
        {
            // Toplantı planlama işlemleri

            // Toplantı bilgilendirme maili gönderimi
            await _meetServices.SendMeetingNotification(model.Name, model.Description, model.StartDate);
            return Ok("Toplantı başarıyla planlandı.");
            // Diğer işlemler
        }
    }
}
