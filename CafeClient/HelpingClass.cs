using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeClient
{
    public class HelpingClass
    {
        public static bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }
    }
}
