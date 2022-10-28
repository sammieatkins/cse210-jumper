using System;
using System.Collections.Generic;
using System.IO;


namespace Unit03.Game
{
    /// <summary>
    /// The word the user is trying to guess. 
    /// The responsibility of the Word class is to keep track of what the word is and creating and updating the hint. 
    /// </summary>
    public class Word
    {
        private string _word;
        // private int _length = 0;
        private List<string> _hintList = new List<string>();
        private string _guess;
        private TerminalService _terminalService = new TerminalService();

        /// <summary>
        /// Creates a new instance of a word by getting a random one and displays what's necessary for the user. 
        /// </summary>
        public Word()
        {
            readFile();
            makeHint();
            displayHint();
        }
        /// <summary>
        /// Reads the file called "words.txt" and gets a random word from that list. 
        /// </summary>
        public string readFile()
        {
            List<string> words = new List<string>(File.ReadLines("words.txt"));

            Random random = new Random();
            _word = words[random.Next(words.Count + 1)];
            return _word;
        }
        /// <summary>
        /// Loops through the word chosen and for each letter in the word adds " _ " to the hint. 
        /// </summary>
        public void makeHint()
        {            
            for (int i = 0; i < _word.Length; i++)
            {
                _hintList.Add(" _ ");
            }          
        }
        /// <summary>
        /// Loops through the hint list and displays it item by item. 
        /// </summary>
        public void displayHint()
        {
            foreach (string character in _hintList)
            {
                _terminalService.WriteText(character);
            }
        }
        /// <summary>
        /// Asks the user for a guess and stores that in the _guess variable.
        /// </summary>
        public string getGuess()
        {   
            _guess = _terminalService.ReadText("Guess a letter [a-z]: ");
            return _guess;
        }
        /// <summary>
        /// Checks if the word contains the letter guessed. Returns true (it was in the word) or false (was not in the word). 
        /// </summary>
        public bool testGuess()
        {
            if (_word.Contains(_guess))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Replaces the " _ " at the index the guessed letter was found to update the hint.
        /// </summary>
        public void updateHint()
        {
            int count = 0;
            foreach (char letter in _word)
            {
                if (_guess.ToLower() == letter.ToString())
                {
                    _hintList[count] = " " + letter + " ";
                }
                count += 1;
            }
        }
        /// <summary>
        /// Returns the current word the user is trying to guess. 
        /// </summary>
        public string getWord()
        {
            return _word;
        }
        /// <summary>
        /// Checks if there are any " _ " underscores left in the hint to determine if the user won. Returns true if they won, returns false if they should keep going. 
        /// </summary>
        public bool checkWin()
        {
            string underscore = " _ ";
            if (_hintList.Contains(underscore))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}