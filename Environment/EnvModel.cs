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
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace EEdit.Environment
{
    public class EnvModel
    {
        private const string LocalMachineEnvironmentLocation = @"System\CurrentControlSet\Control\Session Manager\Environment";
        private const string CurrentUserEnvironmentLocation = @"Environment";

        public EnvironmentVariableTarget EnvTarget { get; private set; }
        public readonly Dictionary<string, EnvVariable> Variables;

        public EnvModel(EnvironmentVariableTarget target)
        {
            EnvTarget = target;
            Variables = new Dictionary<string, EnvVariable>();
            Load();
        }

        public void Export(string filepath)
        {
            StringBuilder output = new StringBuilder();

            foreach (EnvVariable value in Variables.Values)
            {
                if (value.Deleted) continue;

                output.AppendLine(value.Variable + "=" + value.FullValue);
            }

            File.WriteAllBytes(filepath, Encoding.ASCII.GetBytes(output.ToString()));
        }

        public void Save()
        {
            RegistryKey root = null;
            string location = null;

            switch (EnvTarget)
            {
                case EnvironmentVariableTarget.Machine:
                    root = Registry.LocalMachine;
                    location = LocalMachineEnvironmentLocation;
                    break;
                case EnvironmentVariableTarget.User:
                    root = Registry.CurrentUser;
                    location = CurrentUserEnvironmentLocation;
                    break;
                case EnvironmentVariableTarget.Process:
                    throw new NotSupportedException("Process environment variables will have no other effects.");
            }

            using (RegistryKey key = root.OpenSubKey(location, true))
            {
                foreach (EnvVariable value in Variables.Values.ToArray())
                {
                    value.CleanUp();

                    if (value.Edited || value.Added)
                    {
                        string fullvalue = value.FullValue;
                        
                        // Set registry entry to expand variables if at least a pair of % are in the value.
                        RegistryValueKind kind = (fullvalue.IndexOf('%', fullvalue.IndexOf('%')) >= 0) ?  RegistryValueKind.ExpandString : RegistryValueKind.String;

                        key.SetValue(value.Variable, fullvalue, kind);
                    }
                    else if (value.Deleted)
                    {
                        key.DeleteValue(value.Variable);
                        Variables.Remove(value.Variable);
                    }

                    value.ClearChangeStates();
                }
            }
        }

        public EnvVariable AddVariable(string variable)
        {
            EnvVariable newVar = new EnvVariable(variable, "", true);
            Variables[variable] = newVar;
            return newVar;
        }

        public void RemoveVariable(string variable)
        {
            Variables[variable].Delete();
        }

        public void RestoreVariable(string variable)
        {
            Variables[variable].ClearDeletedState();
        }

        private void Load()
        {
            Variables.Clear();

            RegistryKey root = null;
            string location = null;

            switch (EnvTarget)
            {
                case EnvironmentVariableTarget.Machine:
                    root = Registry.LocalMachine;
                    location = LocalMachineEnvironmentLocation;
                    break;
                case EnvironmentVariableTarget.User:
                    root = Registry.CurrentUser;
                    location = CurrentUserEnvironmentLocation;
                    break;
                case EnvironmentVariableTarget.Process:
                    throw new NotSupportedException("Process environment variables will have no other effects.");
            }

            using (RegistryKey key = root.OpenSubKey(location))
            {
                foreach (string variable in key.GetValueNames())
                {
                    Variables[variable] = new EnvVariable(variable, key.GetValue(variable, "", RegistryValueOptions.DoNotExpandEnvironmentNames) as string, false);
                }
            }
        }
    }
}