namespace fizz_buzz
{
    public interface IAct<out TOut>
    {
        TOut Act();
    }

    public interface IAct<in TIn, out TOut>
    {
        TOut Act(TIn @in);
    }
}