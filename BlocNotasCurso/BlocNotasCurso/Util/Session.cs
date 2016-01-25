using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocNotasCurso.Util
{
   public class Session
    {
        private Dictionary<String, Object> _session = 
            new Dictionary<string, object>();
        public Object this[String index]
        {
            // The get accessor.
            get { return _session[index]; }

            // The set accessor.
            set { _session[index] = value; }
        }
    }
}
