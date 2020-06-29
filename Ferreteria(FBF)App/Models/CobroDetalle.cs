using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_FBF_App.Models
{
    public class CobroDetalle
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int Monto { get; set; }
    }
}
