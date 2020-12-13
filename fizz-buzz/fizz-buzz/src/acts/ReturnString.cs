using System;

namespace fizz_buzz.acts
{
    public class ReturnString : IAct<string>
    {
        private readonly Func<string> _getText;

        public ReturnString(Func<string> getText)
        {
            _getText = getText;
        }
        public string Act()
        {
            return _getText.Invoke();
        }
    }
}