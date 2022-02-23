using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLocal._0._0_._Entities.General.Response
{
    public class ResponseAll
    {
        public bool error { get; set; }
        public string message { get; set; }
        public IEnumerable<Object> result { get; set; }
    }
}
