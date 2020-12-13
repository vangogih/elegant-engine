using fizz_buzz.conditions;
using fizz_buzz.Inputs;

namespace fizz_buzz
{
    public class FizzBuzzCluster : ICluster<string>
    {
        private readonly ICondition _condition;
        private readonly IAct<string> _act;

        public FizzBuzzCluster(ICondition condition, IAct<string> act)
        {
            _condition = condition;
            _act = act;
        }

        public bool Use(IValue<string> clusterReturnValue)
        {
            if (!_condition.IsSatisfied())
                return false;

            clusterReturnValue.Value = _act.Act();
            return true;
        }
    }

    public interface ICluster
    {
        bool Use();
    }

    public interface ICluster<TOut>
    {
        bool Use(IValue<TOut> value);
    }
}