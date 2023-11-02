using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public interface ICypher
    {
        public string Name { get; set; }
        public string Alphabet { get; set; }
        //public int Key;
        //public string KEY { get; protected set; }
        public string Key { get; set;}
        public string Encrypt(string Text);
        public string Decrypt(string Text);
    }
}
