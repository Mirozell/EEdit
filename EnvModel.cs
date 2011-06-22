using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace EEdit
{
    class EnvModel
    {
        private const string LocalMachineEnvironmentLocation = @"System\CurrentControlSet\Control\Session Manager\Environment";
        private const string CurrentUserEnvironmentLocation = @"Environment";

        public EnvironmentVariableTarget EnvTarget { get; private set; }
        public Dictionary<string, EnvVariable> Variables;

        public EnvModel(EnvironmentVariableTarget target)
        {
            EnvTarget = target;
            Variables = new Dictionary<string, EnvVariable>();
            Load();
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
            foreach (EnvVariable value in Variables.Values.ToArray())
            {
                value.CleanUp();

                if (value.Edited || value.Added)
                {
                    Environment.SetEnvironmentVariable(value.Variable, value.FullValue, EnvTarget);
                }
                else if (value.Deleted)
                {
                    Environment.SetEnvironmentVariable(value.Variable, "", EnvTarget);
                    Variables.Remove(value.Variable);
                }

                value.ClearChangeStates();
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
    }
}