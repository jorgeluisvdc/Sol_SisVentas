using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FNT_BusinessEntities.Interface
{
    public class DTOHeader
    {
        public string CodigoRetorno { get; set; }
        public string DescRetorno { get; set; }
    }

    public class DTOEjecucion
    {
        public string CodigoEjecucion { get; set; }
        public string DescEjecucion { get; set; }
        public string DescError { get; set; }
    }
}