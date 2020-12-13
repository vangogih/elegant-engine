using System.Linq;
using fizz_buzz.conditions;

namespace fizz_buzz.acts
{
    public class FalseForAll : ICondition
    {
        private readonly ICondition[] _conditions;

        public FalseForAll(params ICondition[] conditions)
        {
            _conditions = conditions;
        }

        public bool IsSatisfied()
        {
            return _conditions.All(conditions => !conditions.IsSatisfied());
        }
    }
}