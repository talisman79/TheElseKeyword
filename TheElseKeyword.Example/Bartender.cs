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
            switch (drink)
            {
                case "beer":
                    ServeBeer();
                    break;
                case "juice":
                    ServeJuice();
                    break;
                default:
                    UnavailableDrink(drink);
                    break;
            }
        }

        private void UnavailableDrink(string drink)
        {
            _outputProvider($"Sorry mate but we don't do {drink}");
        }

        private void ServeJuice()
        {
            _outputProvider("Here you go! Fresh and nice juice.");
        }

        private void ServeBeer()
        {
            _outputProvider("Not so fast cowboy. How old are you?");
            if (!int.TryParse(_inputProvider(), out var age))
            {
                HandleInvalidAge();
                return;
            }
            
            HandleBeerAgeCheck(age);
        }

        private void HandleBeerAgeCheck(int age)
        {
            if (age >= 18)
            {
                _outputProvider("Here you go! Cold beer.");
                return;
            }
            
            _outputProvider("Sorry but you're not old enough to drink (in the UK)");
        }

        private void HandleInvalidAge()
        {
            _outputProvider("Could not parse the age provided");
        }
    }
}