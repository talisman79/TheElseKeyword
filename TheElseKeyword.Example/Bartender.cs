using System;

namespace TheElseKeyword.Example
{
    public class Bartender
    {
        private readonly Func<string> _inputProvider;
        private readonly Action<string> _outputProvider;

        public Bartender(Func<string> inputProvider, Action<string> outputProvider)
        {
            _inputProvider = inputProvider;
            _outputProvider = outputProvider;
        }
        
        public void AskForDrink()
        {
            _outputProvider("What drink to you want? (beer, juice)");

            var drink = _inputProvider() ?? string.Empty;
            if (drink.Equals("beer"))
            {
                _outputProvider("Not so fast cowboy. How old are you?");
                if (!int.TryParse(_inputProvider(), out var age))
                {
                    _outputProvider("Could not parse the age provided");
                }
                else
                {
                    if (age >= 18)
                    {
                        _outputProvider("Here you go! Cold beer.");
                    }
                    else
                    {
                        _outputProvider("Sorry but you're not old enough to drink (in the UK)");
                    }
                }
            }
            else if (drink.Equals("juice"))
            {
                _outputProvider("Here you go! Fresh and nice juice.");
            }
            else
            {
                _outputProvider($"Sorry mate but we don't do {drink}");
            }
        }
    }
}