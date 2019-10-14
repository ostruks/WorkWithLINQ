using System;
using System.Collections.Generic;

namespace MyLibrary
{
    public class WorkLinq
    {
        private List<int?> _list1;
        private List<int?> _list2;
        private List<string> _listOfString;
        private List<Provider> _providers;

        public WorkLinq()
        {
            _list1 = new List<int?>();
            _list2 = new List<int?>();
            _providers = new List<Provider>();
            _listOfString = new List<string>() { "Space", "Cordon", "Cremia", "Nina", "Papa" };
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                _list1.Add(random.Next(-5, 10));
                _list2.Add(random.Next(-5, 10));
            }
        }

        public List<int?> List1 {
            get { return _list1; }
            private set { }
        }

        public List<int?> List2
        {
            get { return _list2; }
            private set { }
        }

        public List<string> ListOfString
        {
            get { return _listOfString; }
            private set { }
        }

        public List<Provider> Providers
        {
            get { return _providers; }
            private set { }
        }

        public void Show(IEnumerable<int?> allOdd)
        {
            foreach (var numb in allOdd)
            {
                Console.Write(numb + " ");
            }
            Console.WriteLine("\n===========");
        }

        public void ShowStrings()
        {
            Console.WriteLine("Array Of strings: ");
            foreach (var str in _listOfString)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("===========");
        }

        public void AddProvider(Provider provider)
        {
            _providers.Add(provider);
        }

        public void ShowProviders(IEnumerable<int?> providers)
        {
            foreach (var provider in providers)
            {
                Console.WriteLine(provider);
            }
            Console.WriteLine("===========");
        }
    }
}
