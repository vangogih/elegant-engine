using System;

namespace fizz_buzz.acts
{
    public sealed class ConsoleWriteLine : IAct
    {
        private readonly Func<string> _getText;

        public ConsoleWriteLine(Func<string> getText)
        {
            _getText = getText;
        }

        public void Act()
        {
            Console.Write(_getText() + " ");
        }
    }
}