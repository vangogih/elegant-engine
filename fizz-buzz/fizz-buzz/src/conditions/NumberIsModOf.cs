using fizz_buzz.Inputs;

namespace fizz_buzz.conditions
{
    public sealed class NumberIsModOf : ICondition
    {
        private readonly IValue<int> _number;
        private readonly int _mod;

        public NumberIsModOf(IValue<int> number, int mod)
        {
            _number = number;
            _mod = mod;
        }

        public bool IsSatisfied()
        {
            if (_mod == 0)
                return true;

            if (_number.Value == 0)
                return false;

            return _number.Value % _mod == 0;
        }
    }
}