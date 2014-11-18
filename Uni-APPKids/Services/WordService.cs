﻿

namespace Uni_APPKids.Services
{
    using System.Collections.Generic;

    using AutoMapper;

    using Uni_AppKids.Core.EntityModels;

    using Uni_APPKids.Dto;

    public class WordService
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();

        public List<WordDto> GetListOfWordsForAPhrase(string wordsId)
        {
            GetMappedEntities();
            var listOfWords = this.unitOfWork.GetCustomWordRepository().GetListOfOrderedWordsForAPhrase(wordsId);
            var mappedListOfWords = Mapper.Map<List<Word>, List<WordDto>>(listOfWords);
            return mappedListOfWords;
        }

        private static void GetMappedEntities()
        {
            Mapper.CreateMap<CreatePhraseDictionaryInput, PhraseDictionary>()
         .ForMember(c => c.Phrases, option => option.MapFrom(src => src.Phrases));
            Mapper.CreateMap<PhraseDictionary, PhraseDictionaryDto>()
                .ForMember(c => c.Phrases, option => option.MapFrom(src => src.Phrases));
            Mapper.CreateMap<Phrase, PhraseDto>();
            Mapper.CreateMap<Word, WordDto>();
        }
    }
}