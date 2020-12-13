using System;

namespace fizz_buzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fizzbuzz = new FizzBuzzDomainObject();

            for (var i = 0; i < 100; i++)
                Console.WriteLine(fizzbuzz.Realise(i));
        }

        public string Alternate(int value)
        {
            if (value == 0)
                return 0.ToString();

            var modOf3 = value % 3 == 0;
            var modOf5 = value % 5 == 0;

            if (modOf3 && modOf5)
                return "fizz|buzz";

            if (modOf3)
                return "fizz";

            if (modOf5)
                return "buzz";
            
            return value.ToString();
        }
    }
}