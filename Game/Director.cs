using System;
using System.Collections.Generic;


namespace Unit03.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        bool _isPlaying = true;
        private Word _word = new Word();
        private Jumper _jumper = new Jumper();
        private TerminalService _terminalService = new TerminalService();

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
            }
            Console.WriteLine("Thanks for playing :)");
        }

        /// <summary>
        /// Asks the user if they think the next card will be higher or lower than the one displayed.
        /// </summary>
        public void GetInputs()
        {
            _word.getGuess();
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            bool correct = _word.testGuess();
            if (correct)
            {
                _word.updateHint();
            }
            else
            {
                _jumper.updateJumper();
            }
            bool loss = _jumper.checkLoss();
            bool win = _word.checkWin();
            if (loss || win)
            {
                _isPlaying = false;
            }
        }

        /// <summary>
        /// Displays the card value and the score. 
        /// </summary>
        public void DoOutputs()
        {
            _word.displayHint();
            _jumper.displayJumper();
        }
    }
}