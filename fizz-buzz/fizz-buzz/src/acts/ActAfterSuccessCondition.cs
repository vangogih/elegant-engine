using fizz_buzz.conditions;

namespace fizz_buzz.acts
{
    public sealed class ActAfterSuccessCondition : IAct
    {
        private readonly ICondition _condition;
        private readonly IAct _act;

        public ActAfterSuccessCondition(ICondition condition, IAct act)
        {
            _condition = condition;
            _act = act;
        }

        public void Act()
        {
            if (_condition.IsSatisfied())
               _act.Act();
        }
    }
}