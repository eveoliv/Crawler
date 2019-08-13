using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerDotNet
{
    [DebuggerDisplay("{Nome}")]
    class CrawlerDados
    {
        public string Nome { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}