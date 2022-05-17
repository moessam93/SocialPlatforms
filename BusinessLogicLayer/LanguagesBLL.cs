using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformsAPI.Data.Entities;

namespace BusinessLogicLayer
{
    public class LanguagesBLL
    {
        private DataAccessLayer.LanguagesDAL _DAL;
        public LanguagesBLL()
        {
            _DAL = new DataAccessLayer.LanguagesDAL(); 
        }
        public async Task<List<Languages>> GetAllLanguages()
        {
            return await _DAL.GetAllLanguages();
        }

        public async Task<List<Languages>> AddLanguage(Languages language)
        {
            return await _DAL.AddLanguage(language);
        }
    }
}
