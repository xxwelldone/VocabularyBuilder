using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Entities.ExternalAPI
{
    public class Phonetic
    {
        public string Text { get; set; }
        public Uri Audio { get; set; }
        public Uri SourceUrl { get; set; }
        public License License { get; set; }
    }
}
