using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Domain.Interface.Adapter
{
    public interface IBaseAdapter
    {

        Task<HttpResponseMessage?> CallAPI(string url, HttpMethod method, string? body, string? token);
    }
}
