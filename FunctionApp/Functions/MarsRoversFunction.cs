using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using System.Threading;
using System.Web.Http;
using Application.UseCases.MarsRovers.Models.Commands;
using System.Text.Json;

namespace FunctionApp.Functions
{
    public class MarsRoversFunction
    {
        private readonly ILogger<MarsRoversFunction> _logger;
        private readonly IMediator _mediator;
        public MarsRoversFunction(ILogger<MarsRoversFunction> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [FunctionName("MarsRoversFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "marsrovers")] HttpRequest req, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin MarsRovers Test");

            try
            {
                var command = await JsonSerializer.DeserializeAsync<MarsRoversCommand>(req.Body);
                var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

                if (result.IsValid)
                {
                    _logger.LogInformation("End execution MarsRovers Test");
                    return new OkObjectResult(result.Result);
                }

                _logger.LogError(string.Join(",", result.ErrorNessages));

                return new BadRequestErrorMessageResult("Error processing your request, MarsRoversCommand return an invalid result");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro on the server");
                return new InternalServerErrorResult();
            }
        }
    }
}
