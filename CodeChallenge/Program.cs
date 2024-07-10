using System.Text.Json;
using System.Text.Json.Serialization;


namespace CodeChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> inputLines = new List<string>();

            // Checking the data input type (either from file or console)
            if (args.Length > 0)
            {
                string filePath = args[0];
                inputLines.AddRange(File.ReadAllLines(filePath));
            }
            else
            {
                string line;
                while (!string.IsNullOrEmpty(line = Console.ReadLine()))
                {
                    inputLines.Add(line);
                }
            }

            var taxCalculator = new TaxCalculator();

            foreach (var inputLine in inputLines)
            {
                if (string.IsNullOrEmpty(inputLine))
                    continue;
                // Deserialize the input line into a list of Operation objects
                var operations = JsonSerializer.Deserialize<List<Operation>>(inputLine);
                // Process the operations and calculate the taxes
                var taxes = taxCalculator.CalculateTaxes(operations);
                // Serialize the taxes and print the output into a json string
                string output = JsonSerializer.Serialize(taxes);
                Console.WriteLine(output);

            }
        }
    }

    public class TaxCalculator
    {
        private const double maxAmountWithoutTax = 20000;
        private const double taxPercentage = 0.2;
        private double weightedAveragePrice = 0;
        private int quantity = 0;
        private double totalLoss = 0;


        public List<TaxResult> CalculateTaxes(List<Operation> operations)
        {
            var taxResults = new List<TaxResult>();

            foreach (var operation in operations)
            {
                ProcessOperation(operation, taxResults);
            }

            return taxResults;
        }

        private void ProcessOperation(Operation operation, List<TaxResult> taxResults)
        {
            if (operation.OperationType == OperationType.Buy)
            {
                weightedAveragePrice = CalculateWeightedAveragePrice(quantity, weightedAveragePrice, operation.Quantity, operation.UnitCost);
                quantity += operation.Quantity;
                taxResults.Add(new TaxResult { Tax = 0.00 });
            }
            else if (operation.OperationType == OperationType.Sell)
            {
                double totalSaleValue = operation.UnitCost * operation.Quantity;
                double profitOrLoss = CalculateProfitOrLoss(operation.UnitCost, weightedAveragePrice, operation.Quantity);

                ProcessSellOperation(totalSaleValue, profitOrLoss, taxResults);

                quantity -= operation.Quantity;
            }
        }

        private void ProcessSellOperation(double totalSaleValue, double profitOrLoss, List<TaxResult> taxResults)
        {
            if (totalSaleValue <= maxAmountWithoutTax)
            {
                if (profitOrLoss < 0)
                    totalLoss += -profitOrLoss;

                taxResults.Add(new TaxResult { Tax = 0.00 });
                return;
            }

            if (profitOrLoss > 0)
            {
                profitOrLoss -= totalLoss;
                totalLoss = Math.Max(0, -profitOrLoss);
                if (totalLoss > 0)
                    taxResults.Add(new TaxResult { Tax = 0.00 });
                else
                {
                    double tax = Math.Max(0, profitOrLoss * taxPercentage);
                    taxResults.Add(new TaxResult { Tax = tax });
                }
                return;
            }

            totalLoss += -profitOrLoss;
            taxResults.Add(new TaxResult { Tax = 0.00 });

        }

        private double CalculateWeightedAveragePrice(int quantity, double weightedAveragePrice, int operationQuantity, double unitCost)
        {
            return Math.Round(((quantity * weightedAveragePrice) + (operationQuantity * unitCost)) / (quantity + operationQuantity), 2);
        }

        private double CalculateProfitOrLoss(double saleUnitCost, double weightedAveragePrice, int quantity)
        {
            return (saleUnitCost - weightedAveragePrice) * quantity;
        }

    }

    public enum OperationType
    {
        [JsonPropertyName("buy")]
        Buy,

        [JsonPropertyName("sell")]
        Sell
    }

    public class Operation
    {
        [JsonPropertyName("operation")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public OperationType OperationType { get; set; }

        [JsonPropertyName("unit-cost")]
        public double UnitCost { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }


    public class TaxResult
    {
        public double Tax { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TaxResult other)
            {
                return Tax == other.Tax;
            }
            return false;
        }
    }


}



