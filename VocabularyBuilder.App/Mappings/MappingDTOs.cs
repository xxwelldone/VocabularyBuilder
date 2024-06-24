using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using VocabularyBuilder.App.DTOs;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.App.Mappings
{
    public class MappingDTOs : Profile
    {
        public MappingDTOs()
        {
            CreateMap<Vocabulary, VocabularyDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
        }

        //Agora devo injetar nos services a interface Imapper para realizar as conversoes entre unitofwork e os services
    }
}
