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
        /// Starts the game by running the main game loop. Handles ending game displays. 
        /// </summary>
        public void StartGame()
        {
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
            string word = _word.getWord();
            _terminalService.WriteLine($"The word was: {word}");
            _terminalService.WriteLine("Thanks for playing :)");
        }

        /// <summary>
        /// Calls the getGuess function from the Word class, which asks the user to guess a letter. Returns a string. 
        /// </summary>
        public void GetInputs()
        {
            _word.getGuess();
        }

        /// <summary>
        /// Checks if the letter was in the word. If yes, it updates the hint to reflect this. If no, it removes part of the parachute. Also checks for if the game was won. 
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
        /// Displays the updated hint and updated jumper. 
        /// </summary>
        public void DoOutputs()
        {
            _word.displayHint();
            _jumper.displayJumper();
        }
    }
}