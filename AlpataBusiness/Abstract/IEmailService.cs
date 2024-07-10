using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpataBusiness.Abstract
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string email);
    }
}
