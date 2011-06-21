using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace EEdit
{
    class EnvValue
    {
        public string Key { get; private set; }

        public bool Deleted { get; set; }
        public bool Added { get; set; }
        public bool Edited { get; set; }

        public readonly ObservableCollection<string> Entries;

        private string splitChar = ";";

        public EnvValue(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentException("Key cannot be null, empty, or whitespace", "key");

            this.Key = key;

            Entries = new ObservableCollection<string>();
            SetEntries(value);
        }

        public string FullValue
        {
            get { return string.Join(splitChar, Entries.ToArray()); }
            set { SetEntries(value); }
        }

        public void CleanUp()
        {
            int i = Entries.Count;
            while (i > 0)
            {
                i--;

                if (string.IsNullOrWhiteSpace(Entries[i]))
                    Entries.RemoveAt(i);
            }
        }

        private string SetEntries(string value)
        {
            value = value ?? "";
            Entries.Clear();

            string[] entries = value.Split(
                new string[] { splitChar },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string entry in entries)
            {
                Entries.Add(entry);
            }

            return value;
        }
    }
}
