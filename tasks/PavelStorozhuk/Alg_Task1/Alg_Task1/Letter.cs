using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Task1
{
    class Letter
    {
        public  List<string> _wordsArray { get; set; }

        public Letter()
        {
            _wordsArray= new List<string>();
        }

        public string this[int index]
        {
            get { return _wordsArray[index]; }
            set { _wordsArray[index] = value; }
        }     
        
      
    }
}
