using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialPlatformsAPI.Data;
using SocialPlatformsAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LanguagesDAL
    {
        private readonly DataContext _context;
        public LanguagesDAL(DataContext context)
        {
            _context = context;
        }

        public LanguagesDAL()
        {
        }

        public async Task<List<Languages>> GetAllLanguages()
        {
            var _context = new DataContext();
            return await _context.languages.ToListAsync();
        }

        public async Task<List<Languages>> AddLanguage(Languages language)
        {
            var _context = new DataContext();
            _context.languages.Add(language);
            await _context.SaveChangesAsync();
            return await _context.languages.ToListAsync();

        }
    }
}
