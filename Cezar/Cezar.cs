using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Cezar
{
    public class Cezar
    {
        public List<char> Alphabet { get; set; }
        public List<char> Key { get; set; }

        public Cezar()
        {
            string alph = "А Б В Г Д Е Ё Ж З И Й К Л М Н О П Р С Т У Ф Х Ц Ч Ш Щ Ъ Ы Ь Э Ю Я";
            Alphabet = new List<char>();
            Alphabet.AddRange(alph.Replace(" ", ""));
        }

        public string Encrypt(string message, int key)
        {
            //  Move
            Key = Alphabet.Skip(key).Concat(Alphabet.Take(key)).ToList();
            var alph = Alphabet;
            try
            {
                string result = "";
                foreach (char let in message)
                {
                    if (char.IsLetter(let))
                    {
                        for (int i = 0; i < Alphabet.Count; i++)
                        {
                            if (char.ToUpper(let) == alph[i])
                            {
                                result += Key[i];
                                break;
                            }
                        }
                    }
                    else
                        result += let;
                }
                return result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Decipher(string message, int key)
        {
            //  Move
            Key = Alphabet.Skip(33 - key).Concat(Alphabet.Take(33 - key)).ToList();
            var alph = Alphabet;
            try
            {
                string result = "";
                foreach (char let in message)
                {
                    if (char.IsLetter(let))
                    {
                        for (int i = 0; i < Alphabet.Count; i++)
                        {
                            if (char.ToUpper(let) == alph[i])
                            {
                                result += Key[i];
                                break;
                            }
                        }
                    }
                    else
                        result += let;
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