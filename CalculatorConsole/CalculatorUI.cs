using CalculatorTest.Services.Services.Interfaces;
using Spectre.Console;
using System;
using System.Threading.Tasks;

namespace CalculatorConsole
{
    public class CalculatorUI : ICalculatorUI
    {
        private readonly ISimpleCalculator _simpleCalculator;
        private readonly ICalculatorClient _calculatorClient;

        public CalculatorUI(ISimpleCalculator simpleCalculator,
            ICalculatorClient calculatorClient)
        {
            _simpleCalculator = simpleCalculator ?? throw new ArgumentNullException(nameof(simpleCalculator));
            _calculatorClient = calculatorClient ?? throw new ArgumentNullException(nameof(calculatorClient));
        }

        public async Task RenderAsync()
        {
            var continueApp = true;
            while (continueApp)
            {
                var operation = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select operation")
                    .PageSize(5)
                    .AddChoices(new[] {
                    "Add", "Subtract", "Multiply", "Divide"
                    })).ToLower();


                var number1 = GetNumber("First number:");

                var number2 = GetNumber("Second number:");

                AnsiConsole.WriteLine();

                int result = 0;
                try
                {
                    switch (operation)
                    {
                        case "add":
                            result = await _calculatorClient.Add(number1, number2);
                            break;
                        case "subtract":
                            result = await _calculatorClient.Subtract(number1, number2);
                            break;
                        case "multiply":
                            result = await _calculatorClient.Multiply(number1, number2);
                            break;
                        case "divide":
                            result = await _calculatorClient.Divide(number1, number2);
                            break;
                    }

                    AnsiConsole.Clear();

                    AnsiConsole.WriteLine($"Result: {result}");
                }
                catch (Exception exp)
                {
                    AnsiConsole.WriteException(exp);
                }
                AnsiConsole.WriteLine();

                continueApp = AnsiConsole.Confirm("Continue using calculator");

                AnsiConsole.Clear();
            }

            Environment.Exit(0);
        }

        private int GetNumber(string promptText)
        {
            return AnsiConsole.Prompt(
                   new TextPrompt<int>(promptText)
                       .PromptStyle("green")
                       .ValidationErrorMessage("[red]That's not a valid number[/]"));
        }
    }
}
