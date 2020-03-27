using System;
using System.Collections.Generic;

namespace Camada.Infra.Data.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string EstaCompleto { get; set; }
        public string Nome { get; set; }
    }
}
