using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    public class Jumper
    {
        private List<string> _jumper = new List<string>();
        
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
            _jumper.Remove();
        }
        public string displayJumper()
        {
            TerminalService.WriteText("");
            TerminalService.WriteText("");
            foreach (string line in _jumper) {
                TerminalService.WriteText(line);
            }   
        }
    }
}