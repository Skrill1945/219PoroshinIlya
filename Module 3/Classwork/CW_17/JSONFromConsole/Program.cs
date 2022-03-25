using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;

namespace JSONFromConsole
{
    class Program
    {
        static string GetStringByHttpPost(string url, byte[] dataBytes, string contentType = "application/x-www-form-urlencoded")
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.ContentLength = dataBytes.Length;
            request.ContentType = contentType;
            request.Method = "POST";
            using (Stream requestBody = request.GetRequestStream())
            {
                requestBody.Write(dataBytes, 0, dataBytes.Length);
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string BuildJsonForSqEq(string[] coefficients)
        {
            object[] col = new object[coefficients.Length];
            int i = 0;
            Array.ForEach(coefficients, st => {
                var arr = st.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                col[i++] = new { a = double.Parse(arr[0]), b = double.Parse(arr[1]), c = double.Parse(arr[2]) };
            });
            return JsonSerializer.Serialize(col);
        }

        static void Main(string[] args)
        {
            int n = 2;
            string[] lines = new string[n];
            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
            }
            Console.WriteLine(GetStringByHttpPost("https://localhost:44334/SqEq/?handler=bulk", Encoding.ASCII.GetBytes(BuildJsonForSqEq(lines))));
            Console.ReadLine();
        }
    }
}
