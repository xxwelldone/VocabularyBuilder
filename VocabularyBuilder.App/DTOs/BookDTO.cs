using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.App.DTOs
{
    public class BookDTO
    {
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Vocabulary> Vocabularies { get; set; }
    }
}
