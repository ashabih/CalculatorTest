using CalculatorTest.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CalculatorApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
        private readonly ISimpleCalculator _simpleCalculator;

        public CalculatorController(ILogger<CalculatorController> logger,
            ISimpleCalculator simpleCalculator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _simpleCalculator = simpleCalculator ?? throw new ArgumentNullException(nameof(simpleCalculator));
        }

        [HttpGet("add")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync(int number1, int number2)
        {
            _logger.LogInformation("Add operation called.");
            return await _simpleCalculator.Add(number1, number2);
        }

        [HttpGet("subtract")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> SubtractAsync(int number1, int number2)
        {
            _logger.LogInformation("Subtract operation called.");
            return await _simpleCalculator.Subtract(number1, number2);
        }

        [HttpGet("multiply")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> MultiplyAsync(int number1, int number2)
        {
            _logger.LogInformation("Multiple operation called.");
            return await _simpleCalculator.Multiply(number1, number2);
        }

        [HttpGet("divide")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> DivideAsync(int number1, int number2)
        {
            _logger.LogInformation("Divide operation called.");
            return await _simpleCalculator.Divide(number1, number2);
        }
    }
}
