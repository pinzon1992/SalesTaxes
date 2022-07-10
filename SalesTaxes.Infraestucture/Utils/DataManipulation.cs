namespace SalesTaxes.Infraestructure.Utils
{
    public static class DataManipulation
    {

        public static string JoinStrArray(string[] array, int index)
        {
            string[] new_array = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                if (i != index)
                {
                    new_array[i-1] = array[i];
                }
                
            }

            string result_string = string.Join(" ", new_array);

            return result_string.Trim();
        }
    }

    public static class Round
    {
        public enum Type
        {
            Nearest,
            Up,
            Down
        }

        /// <summary>
        /// Rounds a number to the nearest X
        /// </summary>
        /// <param name="value">The value to round</param> 
        /// <param name="stepAmount">The amount to round the value by</param>
        /// <param name="type">The type of rounding to perform</param>
        /// <returns>The value rounded by the step amount and type</returns>
        public static decimal Amount(decimal value, decimal stepAmount, Round.Type type = Round.Type.Nearest)
        {
            var inverse = 1 / stepAmount;
            var dividend = value * inverse;
            switch (type)
            {
                case Round.Type.Nearest:
                    dividend = Math.Round(dividend);
                    break;
                case Round.Type.Up:
                    dividend = Math.Ceiling(dividend);
                    break;
                case Round.Type.Down:
                    dividend = Math.Floor(dividend);
                    break;
                default:
                    throw new ArgumentException($"Unknown type: {type}", nameof(type));
            }
            var result = dividend / inverse;
            return result;
        }
    }
}
