using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OpenTemplater.Services
{
    public class UnitConversionService : IUnitConversionService
    {
        private const string UnitExpression = @"(?<value>[0-9]{1,5}\.{0,1}[0-9]{0,5})(?<unit>mm|pt|inch)";

        public float GetValue(string unitValue)
        {
            var unitRegex = new Regex(UnitExpression);
            Match result = unitRegex.Match(unitValue);

            if (result.Success && result.Groups["value"].Success && result.Groups["unit"].Success)
            {
                string unit = result.Groups["unit"].Value;
                string value = result.Groups["value"].Value;

                float multiplier = GetMultiplier(unit);

                return multiplier*float.Parse(value, CultureInfo.InvariantCulture);
            }
            throw new NotSupportedException(string.Format("Invalid unit format for {0}", unitValue));
        }

        private float GetMultiplier(string unit)
        {
            if (unit == null) throw new ArgumentNullException("unit");
            if (unit.Equals("mm")) return (72/25.4f);
            if (unit.Equals("inch")) return (72);
            if (unit.Equals("pt")) return 1;

            throw new NotSupportedException(string.Format("unittype {0} is not supported.", unit));
        }
    }
}