using System;
using System.Collections.Generic;
using System.IO;


namespace Unit03.Game
{
    public class Word
    {
        private string _word;
        // private int _length = 0;
        private List<string> _hintList = new List<string>();
        private string _guess;
        private TerminalService _terminalService = new TerminalService();

        public Word()
        {
            readFile();
            makeHint();
            displayHint();
        }
        public string readFile()
        {
            List<string> words = new List<string>(File.ReadLines("words.txt"));

            Random random = new Random();
            _word = words[random.Next(words.Count + 1)];
            return _word;
        }
        public void makeHint()
        {            
            for (int i = 0; i < _word.Length; i++)
            {
                _hintList.Add(" _ ");
            }          
        }
        public void displayHint()
        {
            foreach (string character in _hintList)
            {
                _terminalService.WriteText(character);
            }
        }
        public string getGuess()
        {   
            _guess = _terminalService.ReadText("Guess a letter [a-z]: ");
            return _guess;
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
        public string getWord()
        {
            return _word;
        }
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