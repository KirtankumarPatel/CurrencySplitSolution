using System;
using System.Collections.Generic;
using CurrencyLibrary;
using Xunit;

//we create namespace currency library then we create public class and dollar each function
namespace CurrencyLibraryTests
{
    public class CurrencyHelperTests
    {
        // Tests for SplitAmount
        [Fact]
        public void SplitAmount_100Dollars_4People_Returns25DollarsEach()
        {
            Assert.Equal(25m, CurrencyHelper.SplitAmount(100m, 4));
        }

        [Fact]
        public void SplitAmount_NegativePeopleCount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => CurrencyHelper.SplitAmount(100m, -1));
        }

        [Fact]
        public void SplitAmount_ZeroPeopleCount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => CurrencyHelper.SplitAmount(100m, 0));
        }

        // Tests for CalculateTips
        [Fact]
        public void CalculateTips_WeightedTips_ReturnsCorrectValues()
        {
            var meals = new Dictionary<string, decimal>
            {
                {"Alice", 50m},
                {"Bob", 50m}
            };

            var expected = new Dictionary<string, decimal>
            {
                {"Alice", 5m},
                {"Bob", 5m}
            };

            var result = CurrencyHelper.CalculateTips(meals, 10);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CalculateTips_EmptyMealCosts_ReturnsEmptyDictionary()
        {
            var result = CurrencyHelper.CalculateTips(new Dictionary<string, decimal>(), 10);
            Assert.Empty(result);
        }

        [Fact]
        public void CalculateTips_ZeroTip_ReturnsZeroForEach()
        {
            var meals = new Dictionary<string, decimal>
            {
                {"Alice", 50m},
                {"Bob", 50m}
            };

            var expected = new Dictionary<string, decimal>
            {
                {"Alice", 0m},
                {"Bob", 0m}
            };

            var result = CurrencyHelper.CalculateTips(meals, 0);
            Assert.Equal(expected, result);
        }

        // Tests for TipPerPerson
        [Fact]
        public void TipPerPerson_100Dollars_4People_10Percent_Returns2Point5Dollars()
        {
            Assert.Equal(2.5m, CurrencyHelper.TipPerPerson(100m, 4, 10));
        }

        [Fact]
        public void TipPerPerson_NegativePatronCount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => CurrencyHelper.TipPerPerson(100m, -1, 10));
        }

        [Fact]
        public void TipPerPerson_ZeroPatronCount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => CurrencyHelper.TipPerPerson(100m, 0, 10));
        }
    }
}
