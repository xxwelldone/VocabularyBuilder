using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace VocabularyBuilder.App.Interfaces
{
    public interface IKindleFileService
    {
        Task ReadFile(IFormFile kindleFile);
        Task SaveBook(List<String> books);
        Task SaveWord(List<String> words);
    }
}
