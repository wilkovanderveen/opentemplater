using System;
using NUnit.Framework;
using OpenTemplater.Services;

namespace OpenTemplater.Test.Services
{
    [TestFixture]
    public class UnitConversionServiceTest
    {
        [TestCase("2pt", ExpectedResult = 2f)]
        [TestCase("2mm", ExpectedResult = 5.6692915f)]
        [TestCase("2inch", ExpectedResult = 144f)]
        [TestCase("blaat", ExpectedException = typeof (NotSupportedException))]
        [TestCase("3.16mm", ExpectedResult = 8.95748043f)]
        [TestCase("3.16pt", ExpectedResult = 3.16f)]
        [TestCase("3.16inch", ExpectedResult = 227.520004f)]
        public float PointConversion(string value)
        {
            var unitConversionService = new UnitConversionService();
            return unitConversionService.GetValue(value);
        }
    }
}