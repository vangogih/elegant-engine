using System.Linq;
using fizz_buzz.conditions;

namespace fizz_buzz.acts
{
    public class TrueForAll : ICondition
    {
        private readonly ICondition[] _conditions;

        public TrueForAll(params ICondition[] conditions)
        {
            _conditions = conditions;
        }

        public bool IsSatisfied()
        {
            return _conditions.All(condition => condition.IsSatisfied());
        }
    }
}