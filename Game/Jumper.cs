using System;
using System.Collections.Generic;


namespace Unit03.Game
{
    /// <summary>
    /// The man in a parachute. 
    /// The responsibility of a jumper is to keep track of the jumper display and update it as needed. 
    /// </summary>
    public class Jumper
    {
        private List<string> _jumper = new List<string>();
        private TerminalService _terminalService = new TerminalService();
        /// <summary>
        /// Creates a new instance of a jumper by adding all the components to a list and displaying it. 
        /// </summary>       
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
        /// <summary>
        /// Removes the first item of the jumper string. When necessary, changes the 0 to an X to indicate to the user that the jumper died. 
        /// </summary>
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
        /// <summary>
        /// Checks if the first index contains the "  X  " used in the above function. If so, returns true meaning that the user lost. 
        /// </summary>
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
        /// <summary>
        /// Displays the jumper list line by line. 
        /// </summary>
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