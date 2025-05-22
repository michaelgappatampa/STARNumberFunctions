using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Workflow;
using Microsoft.Xrm.Sdk;

namespace STARNumberFunctions
{
    public class Arithmetics : CodeActivity
    {
        [Input("First Number")]
        [RequiredArgument]
        public InArgument<decimal> FirstNumber { get; set; }

        [Input("Second Number")]
        [RequiredArgument]
        public InArgument<decimal> SecondNumber { get; set; }

        [Output("Multiply")]
        public OutArgument<decimal> Multiply { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            var tracingService = context.GetExtension<ITracingService>();
            decimal firstNumber = FirstNumber.Get(context);
            decimal secondNumber = SecondNumber.Get(context);
            decimal result = (firstNumber * secondNumber);
            tracingService.Trace($"First: {firstNumber}, Second: {secondNumber}, Result: {result}");
            Multiply.Set(context, result);
        }        
    }
    public class FormatDecimalToTwoPlaces : CodeActivity
    {
        [RequiredArgument]
        [Input("Decimal Value")]
        public InArgument<decimal> DecimalValue { get; set; }

        [Output("Formatted Value")]
        public OutArgument<string> FormattedValue { get; set; }

        protected override void Execute(CodeActivityContext executionContext)
        {
            decimal inputValue = DecimalValue.Get(executionContext);
            string formatted = inputValue.ToString("0.00");

            FormattedValue.Set(executionContext, formatted);
        }
    }
}
