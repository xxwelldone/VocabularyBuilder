using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Entities.ExternalAPI
{
    public class License
    {
        public string Name { get; set; }
        public Uri Url { get; set; }
    }
}
