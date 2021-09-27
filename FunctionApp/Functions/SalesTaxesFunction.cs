using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MediatR;
using Application.UseCases.SalesTaxes.Models.Commands;
using System.Threading;
using System.Text.Json;
using System.Web.Http;

namespace FunctionApp.Functions
{
    public class SalesTaxesFunction
    {
        private readonly ILogger<SalesTaxesFunction> _logger;
        private readonly IMediator _mediator;
        public SalesTaxesFunction(ILogger<SalesTaxesFunction> logger,
            IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [FunctionName("SalesTaxesFunction")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "salestaxes")] HttpRequest req, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Begin SalesTaxes Test");

            try
            {
                var command = await JsonSerializer.DeserializeAsync<SalesTaxesCommand>(req.Body);
                var result = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);

                if (result.IsValid)
                {
                    _logger.LogInformation("End execution SalesTaxes Test");
                    return new OkObjectResult(result.Result);
                }

                _logger.LogError(string.Join(",", result.ErrorNessages));

                return new BadRequestErrorMessageResult("Error processing your request, SalesTaxesCommand return an invalid result");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro on the server");
                return new InternalServerErrorResult();
            }
        }
    }
}
