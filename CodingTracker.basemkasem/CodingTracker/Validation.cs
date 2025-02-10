using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker;

internal static class Validation
{
    public static (bool Check, DateTime Value) ValidateTime(this string time)
    {
        return (DateTime.TryParse(time, out DateTime t), t);
    }

}
