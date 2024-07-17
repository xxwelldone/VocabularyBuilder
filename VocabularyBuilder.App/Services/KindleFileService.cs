using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VocabularyBuilder.App.Interfaces;

namespace VocabularyBuilder.App.Services
{
    public class KindleFileService : IKindleFileService
    {
        public Task<IEnumerable<IEnumerable<string>>> FormatKindleData(IFormFile kindleFile)
        {
            throw new NotImplementedException();
        }

        public Task SaveKindleData(IEnumerable<IEnumerable<string>> data)
        {
            throw new NotImplementedException();
        }
    }
}
