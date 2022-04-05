using System;

namespace Staty
{
    //Objekt state, do kterého ukládáme jednotlivé státy a jejich vlastnosti
    internal class State
    {

        public string Name { get; set; }
        public string Continent { get; set; }
        public string Shortcut { get; set; }
        public string StateSystem { get; set; }
        public string Capital { get; set; }
        public uint Population { get; set; }
        public int Area { get; set; }
        public State(string name, string continent, string shortcut, string stateSystem, string capital, uint population, int area)
        {
            Name = name;
            Continent = continent;
            Shortcut = shortcut;
            StateSystem = stateSystem;
            Capital = capital;
            Population = population;
            Area = area;
        }
        //public override string ToString() { return string.Format(("{0} {1} {2} {3} {4} {5} {6} Name, Continent, Shortcut, StateSystem, Capital, Population, Area"));}
    }
}
