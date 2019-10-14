using System;

namespace MyLibrary
{
    public class Provider
    {
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Provider: {Name}, {Amount}, {Date.ToShortDateString()}";
        }
    }
}
