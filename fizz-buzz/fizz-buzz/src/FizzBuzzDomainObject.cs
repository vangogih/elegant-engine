using System.Collections.Generic;
using fizz_buzz.acts;
using fizz_buzz.conditions;
using fizz_buzz.Inputs;

namespace fizz_buzz
{
    public class FizzBuzzDomainObject
    {
        private readonly IValue<int> _input;
        private readonly IValue<string> _output;

        private readonly List<ICluster<string>> _clusters = new List<ICluster<string>>(4);

        public FizzBuzzDomainObject()
        {
            _input = new Parameter<int>();
            _output = new Parameter<string>();
            var isModOfThree = new NumberIsModOf(_input, 3);
            var isModOfFive = new NumberIsModOf(_input, 5);
            var writeFizz = new ReturnString(() => "fizz");
            var writeBuzz = new ReturnString(() => "buzz");
            var writeFizzbuzz = new ReturnString(() => "fizz|buzz");
            var writeParameter = new ReturnString(() => _input.Value.ToString());

            _clusters.Add(new FizzBuzzCluster(new TrueForAll(isModOfThree, isModOfFive), writeFizzbuzz));
            _clusters.Add(new FizzBuzzCluster(isModOfThree, writeFizz));
            _clusters.Add(new FizzBuzzCluster(isModOfFive, writeBuzz));
            _clusters.Add(new FizzBuzzCluster(new FalseForAll(isModOfThree, isModOfFive), writeParameter));
        }

        public string Realise(int number)
        {
            _input.Value = number;

            foreach (var cluster in _clusters)
            {
                if (cluster.Use(_output))
                    return _output.Value;
            }

            return null;
        }
    }
}