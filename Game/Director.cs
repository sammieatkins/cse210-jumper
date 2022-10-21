using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        bool _isPlaying = true;
        private TerminalService _terminalService = new TerminalService();
        int _score = 0;
        int _totalScore = 300;
        Card card = new Card();
        Card nextCard = new Card();
        string guess = "";


        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
                if (_totalScore <= 0) {
                    _isPlaying = false;
                }
                else {
                    Console.Write("Play again? [y/n] ");
                    string playAgain = Console.ReadLine();
                    _isPlaying = (playAgain == "y");
                }
                
            }
            Console.WriteLine("Thanks for playing :)");
        }

        /// <summary>
        /// Asks the user if they think the next card will be higher or lower than the one displayed.
        /// </summary>
        public void GetInputs()
        {
            Console.WriteLine($"The card is: {card.value} ");
            Console.Write("Higher or lower? [h/l] ");
            guess = Console.ReadLine();
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            _score = 0;
            string highLow = "";
            if (card.value < nextCard.value) {
                highLow = "h";
            }
            else if (card.value > nextCard.value) {
                highLow = "l";
            }
            else {
                highLow = "t";
            }

            if (highLow == guess) {
                _score += 100;
            }
            else if (highLow != guess) {
                _score -= 75;
            }
            else {
                Console.WriteLine("AHHH");
            }
            _totalScore += _score;
            card.value = nextCard.value;
            nextCard.Draw();
        }

        /// <summary>
        /// Displays the card value and the score. 
        /// </summary>
        public void DoOutputs()
        {
            Console.WriteLine($"Next card was: {card.value}");
            Console.WriteLine($"Your score is: {_totalScore}");
        }
    }
}