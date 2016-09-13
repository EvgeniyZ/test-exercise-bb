using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = File.Open("in.txt", FileMode.Open);
            var cookiesCollections = new List<string[]>();
            using (var streamReader = new StreamReader(input))
            {
                var collectionsCount = streamReader.ReadLine();
                var collectionsCountAsNumber = int.Parse(collectionsCount);
                for (int i = 0; i < collectionsCountAsNumber; i++)
                {
                    streamReader.ReadLine();
                    var cookies = streamReader.ReadLine();
                    cookiesCollections.Add(cookies.Split(' '));
                }
            }
            input.Close();
            var caseNumber = 1;
            foreach (var cookieCollection in cookiesCollections)
            {
                var binarySum = "0";
                var actualSum = 0;
                var minimum = int.Parse(cookieCollection[0]);
                foreach (var cookie in cookieCollection)
                {
                    var weight = int.Parse(cookie);
                    if (weight < minimum)
                    {
                        minimum = weight;
                    }
                    binarySum = Sum(Convert.ToString(weight, 2), binarySum);
                    actualSum += weight;
                }
                var condition = Convert.ToInt32(binarySum, 2);
                if (condition != 0)
                {
                    WriteToOutput(caseNumber, "NO");
                }
                else
                {
                    WriteToOutput(caseNumber, (actualSum - minimum).ToString());
                }
                caseNumber++;
            }
        }

        public static string Sum(string first, string second)
        {
            var shortestValue = first.Length < second.Length ? first : second;
            var longestValue = first.Length < second.Length ? second : first;
            var commonPart = longestValue.Substring(longestValue.Length - shortestValue.Length);
            var result = new StringBuilder();
            for (var i = 0; i < commonPart.Length; i++)
            {
                result.Append(shortestValue[i] != commonPart[i] ? '1' : '0');
            }
            var greaterPart = longestValue.Substring(0, longestValue.Length - shortestValue.Length);

            return greaterPart + result;
        }

        private static void WriteToOutput(int caseNumber, string value)
        {
            var output = File.Open("out.txt", FileMode.OpenOrCreate);
            output.Seek(0, SeekOrigin.End);
            using (var streamWriter = new StreamWriter(output))
            {
                streamWriter.WriteLine(string.Format("Case #{0}: {1}", caseNumber, value));
            }
            output.Close();
        }
    }
}
