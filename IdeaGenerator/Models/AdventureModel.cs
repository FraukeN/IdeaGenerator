using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaGenerator.Models
{
    internal class AdventureModel
    {
        public AdventureModel() {
            Introduction = "Intro";
            Goal = "Goal";
            Villain = "Villain";
            Ally = "Ally";
            Patron = "Patron";
            Climax = "Climax";
        }
        public string Introduction { get; set; }
        public string Goal { get; set; }
        public string Villain { get; set; }
        public string Ally { get; set; }
        public string Patron { get; set; }
        public string Climax { get; set; }
    }
}
