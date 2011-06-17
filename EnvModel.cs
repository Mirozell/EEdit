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
        public Dictionary<string, EnvValue> Variables;

        public EnvModel(EnvironmentVariableTarget target)
        {
            this.EnvTarget = target;
            this.Variables = new Dictionary<string, EnvValue>();
            this.Load();
        }

        private void Load()
        {
            this.Variables.Clear();

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
                    Variables[variable] = new EnvValue(variable, key.GetValue(variable, "", RegistryValueOptions.DoNotExpandEnvironmentNames) as string);
                }
            }
        }

        public void Export(string filepath)
        {
            StringBuilder output = new StringBuilder();

            foreach (EnvValue value in this.Variables.Values)
            {
                if (value.State == EnvValueState.Deleted) continue;

                output.AppendLine(value.Key + "=" + value.ToString());
            }

            File.WriteAllBytes(filepath, Encoding.ASCII.GetBytes(output.ToString()));
        }
    }
}