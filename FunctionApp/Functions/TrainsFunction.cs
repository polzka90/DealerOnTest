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
using System.Text.Json;
using Application.UseCases.Trains.Models.Commands;
using System.Web.Http;

namespace FunctionApp.Functions
{
    public class TrainsFunction
    {
        private readonly ILogger<TrainsFunction> _logger;
        private readonly IMediator _mediator;
        public TrainsFunction(ILogger<TrainsFunction> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [FunctionName("TrainsFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "trains")] HttpRequest req, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin Trains Test");

            try
            {
                var command = await JsonSerializer.DeserializeAsync<TrainsCommand>(req.Body);
                var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

                if (result.IsValid)
                {
                    _logger.LogInformation("End execution Trains Test");
                    return new OkObjectResult(result.Result);
                }

                _logger.LogError(string.Join(",", result.ErrorNessages));

                return new BadRequestErrorMessageResult("Error processing your request, CommandTrains return an invalid result");

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Erro on the server");
                return new InternalServerErrorResult();
            }
        }
    }
}
