using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishUp.Domain.Types
{
    public class MailingException : BaseException
    {
        public MailingException(ExceptionCode code) : base(code)
        {

        }
        public MailingException(ExceptionCode code, string message) : base(code, message)
        {

        }
    }
}
