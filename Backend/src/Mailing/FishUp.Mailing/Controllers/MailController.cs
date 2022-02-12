using System.Threading.Tasks;
using FishUp.Mailing.Messages.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FishUp.Mailing.Controllers
{
    [ApiController]
    [Route("mailing/mail")]
    public class MailController : ControllerBase
    {
        private readonly ILogger<MailController> _logger;
        private readonly IMediator _mediator;

        public MailController(ILogger<MailController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(SendMessageCommand command)
        {
            _logger.LogDebug("Start sending an email");
            return Ok(await _mediator.Send(command));
        }
    }
}
