/*
EEdit - A Windows Environment Editor
Copyright (C) 2011  Mirozell

Website: https://github.com/Mirozell/EEdit

EEdit is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

EEdit is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with EEdit.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace EEdit.Environment
{
    public class EnvVariable
    {
        public string Variable { get; private set; }
        public bool Deleted { get; private set; }
        public bool Added { get; private set; }
        public bool Edited { get; private set; }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private readonly ObservableCollection<string> Entries;
        private const string splitChar = ";";

        internal EnvVariable(string variable, string value, bool setAdded)
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

        #region Entries Access Wrappers

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

        internal void ClearChangeStates()
        {
            Edited = false;
            Added = false;
            Deleted = false;
        }

        internal void ClearDeletedState()
        {
            Deleted = false;
        }

        internal void Delete()
        {
            Deleted = true;
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

        private void Entries_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged(sender, e);
        }
    }
}
