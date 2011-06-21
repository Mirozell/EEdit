using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Collections;
using System.IO;

namespace EEdit
{
    class EnvModel
    {
        private const string LocalMachineEnvironmentLocation = @"System\CurrentControlSet\Control\Session Manager\Environment";
        private const string CurrentUserEnvironmentLocation = @"Environment";

        public EnvironmentVariableTarget EnvTarget { get; private set; }
        public Dictionary<string, EnvValue> Values;

        public EnvModel(EnvironmentVariableTarget target)
        {
            EnvTarget = target;
            Values = new Dictionary<string, EnvValue>();
            Load();
        }

        private void Load()
        {
            Values.Clear();

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
                    Values[variable] = new EnvValue(variable, key.GetValue(variable, "", RegistryValueOptions.DoNotExpandEnvironmentNames) as string);
                }
            }
        }

        public void Export(string filepath)
        {
            StringBuilder output = new StringBuilder();

            foreach (EnvValue value in Values.Values)
            {
                if (value.Deleted) continue;

                output.AppendLine(value.Key + "=" + value.FullValue);
            }

            File.WriteAllBytes(filepath, Encoding.ASCII.GetBytes(output.ToString()));
        }

        public void Save()
        {
            foreach (EnvValue value in Values.Values.ToArray())
            {
                value.CleanUp();

                if (value.Edited || value.Added)
                {
                    Environment.SetEnvironmentVariable(value.Key, value.FullValue, EnvTarget);
                    value.Edited = false;
                    value.Added = false;
                }
                else if (value.Deleted)
                {
                    Environment.SetEnvironmentVariable(value.Key, "", EnvTarget);
                    Values.Remove(value.Key);
                }
            }
        }
    }
}