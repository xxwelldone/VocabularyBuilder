
using Microsoft.AspNetCore.Http;


namespace VocabularyBuilder.App.Interfaces
{
    public interface IKindleFileService
    {
        //Tres listas strings -> Vocabulary, Book, date
        //pega os dados do Dictionary
        //inicia listas dos tipos Vocabulary, Meaning, Book

     
        Task<IEnumerable<IEnumerable<String>>>FormatKindleData(IFormFile kindleFile);
        Task SaveKindleData(IEnumerable<IEnumerable<String>> data);
    };
        
     
    
}
