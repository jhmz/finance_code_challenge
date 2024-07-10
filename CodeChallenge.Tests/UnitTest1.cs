using CodeChallenge;
using Xunit;

namespace CodeChallenge.Tests
{
    public class TaxCalculatorTests
    {
        [Fact]
        public void Case1()
        {
            // Arrange
            var inputOperations = new List<Operation>
            {
                new Operation { OperationType = OperationType.Buy, UnitCost = 10.00, Quantity = 100 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 15.00, Quantity = 50 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 15.00, Quantity = 50 }
            };

            var expectedTaxResults = new List<TaxResult>
            {
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
            };

            var taxCalculator = new TaxCalculator();

            // Act
            var actualTaxResults = taxCalculator.CalculateTaxes(inputOperations);

            // Assert
            Assert.Equal(expectedTaxResults, actualTaxResults);
        }

        [Fact]
        public void Case2()
        {
            // Arrange
            var inputOperations = new List<Operation>
            {
                new Operation { OperationType = OperationType.Buy, UnitCost = 10.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 20.00, Quantity = 5000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 5, Quantity = 5000 }
            };

            var expectedTaxResults = new List<TaxResult>
            {
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 10000 },
                new TaxResult { Tax = 0 },
            };

            var taxCalculator = new TaxCalculator();

            // Act
            var actualTaxResults = taxCalculator.CalculateTaxes(inputOperations);

            // Assert
            Assert.Equal(expectedTaxResults, actualTaxResults);
        }

        [Fact]
        public void Case3()
        {
            // Arrange
            var inputOperations = new List<Operation>
            {
                new Operation { OperationType = OperationType.Buy, UnitCost = 10.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 5.00, Quantity = 5000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 20, Quantity = 3000 }
            };

            var expectedTaxResults = new List<TaxResult>
            {
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 1000 },
            };

            var taxCalculator = new TaxCalculator();

            // Act
            var actualTaxResults = taxCalculator.CalculateTaxes(inputOperations);

            // Assert
            Assert.Equal(expectedTaxResults, actualTaxResults);
        }

        [Fact]
        public void Case4()
        {
            // Arrange
            var inputOperations = new List<Operation>
            {
                new Operation { OperationType = OperationType.Buy, UnitCost = 10.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Buy, UnitCost = 25.00, Quantity = 5000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 15, Quantity = 10000 }
            };

            var expectedTaxResults = new List<TaxResult>
            {
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
            };

            var taxCalculator = new TaxCalculator();

            // Act
            var actualTaxResults = taxCalculator.CalculateTaxes(inputOperations);

            // Assert
            Assert.Equal(expectedTaxResults, actualTaxResults);
        }

        [Fact]
        public void Case5()
        {
            // Arrange
            var inputOperations = new List<Operation>
            {
                new Operation { OperationType = OperationType.Buy, UnitCost = 10.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Buy, UnitCost = 25.00, Quantity = 5000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 15, Quantity = 10000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 25, Quantity = 5000 }
            };

            var expectedTaxResults = new List<TaxResult>
            {
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 10000 },
            };

            var taxCalculator = new TaxCalculator();

            // Act
            var actualTaxResults = taxCalculator.CalculateTaxes(inputOperations);

            // Assert
            Assert.Equal(expectedTaxResults, actualTaxResults);
        }

        [Fact]
        public void Case6()
        {
            // Arrange
            var inputOperations = new List<Operation>
            {
                new Operation { OperationType = OperationType.Buy, UnitCost = 10.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 2.00, Quantity = 5000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 20, Quantity = 2000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 20, Quantity = 2000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 25, Quantity = 1000 }
            };

            var expectedTaxResults = new List<TaxResult>
            {
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 3000 },
            };

            var taxCalculator = new TaxCalculator();

            // Act
            var actualTaxResults = taxCalculator.CalculateTaxes(inputOperations);

            // Assert
            Assert.Equal(expectedTaxResults, actualTaxResults);
        }


        [Fact]
        public void Case7()
        {
            // Arrange
            var inputOperations = new List<Operation>
            {
                new Operation { OperationType = OperationType.Buy, UnitCost = 10.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 2.00, Quantity = 5000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 20, Quantity = 2000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 20, Quantity = 2000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 25, Quantity = 1000 },
                new Operation { OperationType = OperationType.Buy, UnitCost = 20.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 15.00, Quantity = 5000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 30.00, Quantity = 4350 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 30.00, Quantity = 650 },
            };

            var expectedTaxResults = new List<TaxResult>
            {
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 3000 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 3700 },
                new TaxResult { Tax = 0 },
            };

            var taxCalculator = new TaxCalculator();

            // Act
            var actualTaxResults = taxCalculator.CalculateTaxes(inputOperations);

            // Assert
            Assert.Equal(expectedTaxResults, actualTaxResults);
        }
        [Fact]
        public void Case8()
        {
            // Arrange
            var inputOperations = new List<Operation>
            {
                new Operation { OperationType = OperationType.Buy, UnitCost = 10.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 50.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Buy, UnitCost = 20.00, Quantity = 10000 },
                new Operation { OperationType = OperationType.Sell, UnitCost = 50.00, Quantity = 10000 }
            };

            var expectedTaxResults = new List<TaxResult>
            {
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 80000 },
                new TaxResult { Tax = 0 },
                new TaxResult { Tax = 60000 }
            };

            var taxCalculator = new TaxCalculator();

            // Act
            var actualTaxResults = taxCalculator.CalculateTaxes(inputOperations);

            // Assert
            Assert.Equal(expectedTaxResults, actualTaxResults);
        }
    }
}