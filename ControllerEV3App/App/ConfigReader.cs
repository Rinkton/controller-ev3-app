using Lego.Ev3.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    static class ConfigReader
    {
        private static readonly string configPath = "config.txt";

        public static int GetInt(string key)
        {
            int value = 0;

            try
            {
                value = Convert.ToInt32(ConfigReader.getValue(key));
            }
            catch
            {
                FormKeeper.Form.DisplayError("Value is not a number.\n" + "key:" + key);
            }

            return value;
        }

        public static OutputPort GetOutputPort(string key)
        {
            OutputPort value = OutputPort.All;

            try
            {
                switch(ConfigReader.getValue(key))
                {
                    case "A":
                        value = OutputPort.A;
                        break;
                    case "B":
                        value = OutputPort.B;
                        break;
                    case "C":
                        value = OutputPort.C;
                        break;
                    case "D":
                        value = OutputPort.D;
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch
            {
                FormKeeper.Form.DisplayError("Value is not an output port.\n" + "key:" + key);
            }

            return value;
        }

        private static string getValue(string key)
        {
            string[] parts = null;

            try
            {
                string[] lines = File.ReadAllLines(configPath);

                foreach (string line in lines)
                {
                    parts = line.Split(new char[] { ':' });

                    if (parts[0] == key)
                    {
                        break;
                    }
                }
            }
            catch
            {
                FormKeeper.Form.DisplayError("An error appearing while reading config.\n" + "key:" + key);
                return null;
            }

            return parts[1];
        }
    }
}
