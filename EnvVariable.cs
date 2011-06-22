using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace EEdit
{
    class EnvVariable
    {
        public string Variable { get; private set; }

        public bool Deleted { get; private set; }
        public bool Added { get; private set; }
        public bool Edited { get; private set; }

        private readonly ObservableCollection<string> Entries;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private string splitChar = ";";

        public EnvVariable(string variable, string value, bool setAdded)
        {
            if (string.IsNullOrWhiteSpace(variable)) throw new ArgumentException("Variable cannot be null, empty, or whitespace", "Variable");

            Variable = variable;
            Added = setAdded;

            Entries = new ObservableCollection<string>();
            SetEntries(value);

            Entries.CollectionChanged += new NotifyCollectionChangedEventHandler(Entries_CollectionChanged);
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

        public void ClearChangeStates()
        {
            Edited = false;
            Added = false;
            Deleted = false;
        }

        public void ClearDeletedState()
        {
            Deleted = false;
        }

        public void Delete()
        {
            Deleted = true;
        }

        #region Entries Access Wrappers

        private void Entries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged(sender, e);
        }

        public void MoveEntry(int oldIndex, int newIndex)
        {
            Entries.Move(oldIndex, newIndex);
            Edited = true;
        }

        public void RemoveEntry(int index)
        {
            Entries.RemoveAt(index);
            Edited = true;
        }

        public void AddEntry(string item)
        {
            Entries.Add(item);
            Edited = true;
        }

        public int EntryCount
        {
            get { return Entries.Count; }
        }

        public void UpdateEntry(int index, string item)
        {
            Entries[index] = item;
            Edited = true;
        }

        public IEnumerable<string> GetEntries()
        {
            return Entries.ToArray();
        }

        #endregion
    }
}
