using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace FWWCode
{
    public class Cipher
    {
        public Dictionary<string, char> Letter { set; get; }

        public Cipher()
        {
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(Dictionary<string, char>));
            using (FileStream fs = new FileStream(@"C:\Users\Lenovo\Documents\Visual Studio 2015\Projects\WW1Code\WW1Code\bin\Debug\fww.json", FileMode.OpenOrCreate))
            {
                Letter = (Dictionary<string, char>)jsonFormatter.ReadObject(fs);
            }
        }

        public string Encrypt(string message)
        {
            try
            {
                string result = "";
                foreach (var letter in message.ToUpper())
                {
                    var tmp = from kvp in Letter
                              where kvp.Value == letter
                              select kvp.Key;
                    result += tmp.First().ToString() + " ";
                }
                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Decipher(string message)
        {
            var msg = message.Split(' ');
            try
            {
                string result = "";
                for (int i = 0; i < msg.Count() - 1; i++)
                {
                    var tmp = from kvp in Letter
                              where kvp.Key == msg[i]
                              select kvp.Value;
                    result += tmp.First();
                }
                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}