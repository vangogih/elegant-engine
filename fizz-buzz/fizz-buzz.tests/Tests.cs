using fizz_buzz.acts;
using fizz_buzz.conditions;
using fizz_buzz.Inputs;
using NSubstitute;
using NUnit.Framework;

namespace fizz_buzz.tests
{
    public sealed class FizzBussTests
    {
        [TestCase(0, false)]
        [TestCase(-1, false)]
        [TestCase(-30, true)]
        [TestCase(3, true)]
        [TestCase(999, true)]
        public void FizzBuzz_WhenNumberModThreeZero_True(int number, bool isModThree)
        {
            var parameter = Substitute.For<IValue<int>>();
            parameter.Value.Returns(number);
            var modOfThree = new NumberIsModOf(parameter, 3);
            Assert.AreEqual(modOfThree.IsSatisfied(), isModThree);
        }

        [TestCase(0, false)]
        [TestCase(-50, true)]
        [TestCase(50, true)]
        [TestCase(3, false)]
        [TestCase(78, false)]
        public void FizzBuzz_WhenNumberModeFiveZero_True(int number, bool isModFive)
        {
            var parameter = Substitute.For<IValue<int>>();
            parameter.Value.Returns(number);
            var modOfFive = new NumberIsModOf(parameter, 5);
            Assert.AreEqual(modOfFive.IsSatisfied(), isModFive);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FizzBuzz_ActAfterSuccessCondition_True(bool conditionReturn)
        {
            var condition = Substitute.For<ICondition>();
            condition.IsSatisfied().Returns(conditionReturn);

            var act = Substitute.For<IAct>();

            IAct actAfterSuccess = new ActAfterSuccessCondition(condition, act);
            actAfterSuccess.Act();

            if (conditionReturn)
                act.Received().Act();
            else
                act.DidNotReceive().Act();
        }

        [TestCase(0, "0")]
        [TestCase(2, "2")]
        [TestCase(999, "fizz")]
        [TestCase(1000, "buzz")]
        [TestCase(15, "fizz|buzz")]
        [TestCase(-15, "fizz|buzz")]
        [TestCase(-3, "fizz")]
        [TestCase(-5, "buzz")]
        public void FizzBuzzDomainObject_ModOf3ModOf5_FizzBuzz(int input, string output)
        {
            var domainObject = new FizzBuzzDomainObject();
            Assert.AreEqual(output, domainObject.Realise(input));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FizzBuzzCluster_ModOf3_True(bool returnCondition)
        {
            var condition = Substitute.For<ICondition>();
            condition.IsSatisfied().Returns(returnCondition);
            
            var act = Substitute.For<IAct<string>>();
            act.Act().Returns("fizz");
            
            var output = Substitute.For<IValue<string>>();
            
            var cluster = new FizzBuzzCluster(condition, act);
            cluster.Use(output);

            if (returnCondition)
                Assert.AreEqual(output.Value, "fizz");
            else
                Assert.AreEqual(string.Empty, output.Value);
        }
    }
}