using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    public class Word
    {
        private string _word = "apple";
        private int _length = 0;
        private List<string> _hintList = new List<string>();
        private string _guess = "";

        public Word()
        {
            displayHint();
        }
        public string makeHint()
        {            
            for (int i = 0; i < _word.Length; i++)
            {
                _hintList += " _ ";
            }          
        }
        public string displayHint()
        {
            string theWholeThing = String.Join(_hintList);
            return theWholeThing;
        }
        public string getGuess()
        {   
            _guess = TerminalService.ReadText("Guess a letter [a-z]: ");
        }
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
        public string updateHint()
        {
            int count = 0;
            foreach (string letter in _word)
            {
                if (_guess.ToLower() == letter)
                {
                    _hintList[count] = " " + letter + " ";
                }
                count += 1;
            }
        }
        public string getWord()
        {
            return _word;
        }
    }
}