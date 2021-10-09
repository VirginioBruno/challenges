using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace Challenges
{
    public class Program
    {
        static void Main(string[] args)
        {
            BotMovement(1, 1, 6, 2);
        }


        public static bool BotMovement(int x1, int y1, int x2, int y2)
        {
            var movement = true;
            var x = x1;
            var y = y1;

            while (movement)
            {
                if (y != y2)
                    y += x;
                else if (x != x2)
                    x += y;

                var reachedCoordinates = x == x2 && y == y2;
                if (reachedCoordinates)
                    return true;

                var needMoviment = x < x2 || y < y2;
                movement = needMoviment;
            }

            return false;
        }

        public static bool Palindrome(string text)
        {
            // Implementar uma classe para fazer todos os tratamentos necessários
            var formatedText = text
                .Replace(" ", "")
                .ToLower();

            var characters = formatedText.ToCharArray();
            var textSize = formatedText.Length - 1;

            for (int i = 0; i < formatedText.Length; i++)
            {
                if (characters[i] != characters[textSize])
                    return false;

                textSize--;
            }

            return true;
        }

        public static bool PrimeNumber(int n)
        {
            int i;
            int dividersCount = 0;
            string message;

            for (i = 0; i < n - 1; i++)
            {
                if (n % (i + 1) == 0)
                    dividersCount++;
            }

            var isPrime = dividersCount == 1;
            if (isPrime)
                message = $"O número {n} é primo. Número de iterações necessárias: {i}";
            else
                message = $"O número {n} não é primo. Número de iterações necessárias: {i}";

            Console.WriteLine(message);
            return isPrime;
        }

        public static char[] Sort(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int d = i; d < array.Length; d++)
                {
                    if (array[i] > array[d])
                    {
                        var aux = array[i];
                        array[i] = array[d];
                        array[d] = aux;
                    }
                }
            }

            return array;
        }

        public static void Fibonacci()
        {
            Console.WriteLine("Enter the number of elements: ");
            var n = int.Parse(Console.ReadLine());

            int n1 = 0, n2 = 1, n3;

            Console.Write($"{n2} ");

            for (int i = 2; i <= n; i++)
            {
                n3 = n1 + n2;
                Console.Write($"{n3} ");
                n1 = n2;
                n2 = n3;
            }
        }

        public static List<string> getRelevantFoodOutlets(string city, int maxCost)
        {
            var httpClient = new HttpClient();
            var baseUrl = $"https://jsonmock.hackerrank.com/api/food_outlets?city={city}";
            var response = httpClient.GetAsync(baseUrl).Result;
            var message = response.Content.ReadAsStringAsync().Result;

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(FoodOutletResult));
            object objResponse = jsonSerializer.ReadObject(response.Content.ReadAsStreamAsync().Result);
            var jsonResult = objResponse as FoodOutletResult;

            var requests = new List<Task<HttpResponseMessage>>();

            for (int i = 1; i <= jsonResult.TotalPages; i++)
                requests.Add(httpClient.GetAsync($"{baseUrl}&page={i}"));

            var results = Task.WhenAll(requests).Result;
            var dataResult = new List<Datum>();

            foreach (var result in results)
            {
                var messageResult = result.Content.ReadAsStreamAsync().Result;

                object newObjResult = jsonSerializer.ReadObject(messageResult);
                var newJsonResult = newObjResult as FoodOutletResult;

                dataResult.AddRange(newJsonResult.Data);
            }

            return dataResult.Where(x => x.EstimatedCost <= maxCost).Select(x => x.Name).Distinct().ToList();
        }
    }
}
