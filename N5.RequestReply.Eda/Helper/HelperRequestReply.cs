using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.RequestReply.Eda.Helper
{
    public static class HelperRequestReply
    {
        public static string CreateEventId => Guid.NewGuid().ToString().Replace("-", "").Substring(0, 24);
    }
}
