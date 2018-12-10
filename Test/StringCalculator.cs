using System;
using System.Collections.Generic;
using System.Linq;

namespace Test {
    public class StringCalculator {
        public int Add(string numbers) {
            var result = 0;
            if (numbers == "") return 0;
            var splitChars = new List<string>() { ",", "\n" };
            var negatives = new List<int>();

            if (numbers.StartsWith("//") && numbers[2] != '[') {
                splitChars.Add(numbers[2].ToString());
                numbers = numbers.Substring(4);
            }

            if (numbers.StartsWith("//") && numbers[2] == '[') {
                var start = numbers.IndexOf('[') + 1;
                var end = numbers.IndexOf(']');
                var length = end - start;
                splitChars.Add(numbers.Substring(start, length));
                numbers = numbers.Substring(end + 1);
            }

            while (numbers.First() == '[') {
                var start = numbers.IndexOf('[') + 1;
                var end = numbers.IndexOf(']');
                var length = end - start;
                splitChars.Add(numbers.Substring(start, length));
                numbers = numbers.Substring(end + 1);
            }

            foreach (var number in numbers.Split(splitChars.ToArray(), StringSplitOptions.RemoveEmptyEntries)) {
                if (number.StartsWith("-") && !splitChars.Contains("-")) negatives.Add(int.Parse(number));
                if (!string.IsNullOrWhiteSpace(number) && int.Parse(number) < 1000) result += int.Parse(number);
            }

            if (negatives.Count != 0) throw new Exception($"Negative Zahlen werden nicht unterstützt. Negative Zahlen = {string.Join(", ", negatives)}");

            return result;
        }
    }
}