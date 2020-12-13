namespace fizz_buzz.Inputs
{
    public class Parameter<T> : IValue<T>
    {
        public T Value { get; set; } = default;

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public interface IValue<T>
    {
        T Value { get; set; }
    }
}