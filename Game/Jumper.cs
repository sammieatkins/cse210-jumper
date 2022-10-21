using System;
using System.Collections.Generic;


namespace Unit03.Game
{
    public class Jumper
    {
        private List<string> _jumper = new List<string>();
        private TerminalService _terminalService = new TerminalService();
        
        public Jumper()
        {
            _jumper.Add(@" ___ ");
            _jumper.Add(@"/___\");
            _jumper.Add(@"\   /");
            _jumper.Add(@" \ / ");
            _jumper.Add(@"  O  ");
            _jumper.Add(@" /|\ ");
            _jumper.Add(@" / \ ");
            _jumper.Add(@"     ");
            _jumper.Add(@"     ");
            _jumper.Add(@"^^^^^");

            displayJumper();
        }
        public void updateJumper()
        {
            if (_jumper[0] == "  O  ")
            {
                _jumper[0] = "  X  ";
            }
            else 
            {
                _jumper.RemoveAt(0);
            }
        }
        public bool checkLoss()
        {
            if (_jumper[0] == "  X  ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void displayJumper()
        {
            _terminalService.WriteLine("");
            _terminalService.WriteLine("");
            foreach (string line in _jumper) {
                _terminalService.WriteLine(line);
            }   
        }
    }
}