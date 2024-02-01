using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HiredFirst.Domain.Helpers
{
    public static class StringComparer
    {
        public static bool AnyCharacterUppercase(this string GivenString)
        {
           var result=GivenString.Any(char.IsUpper);
            return result;
        }
    }
}
