using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialPlatformsAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SocialPlatformDAL : ISocialPlatformDAL
    {
        private readonly DataContext _context;
        public SocialPlatformDAL(DataContext context)
        {
            _context = context;
        }
        public SocialPlatformDAL()
        {

        }
        public async Task<List<SocialPlatform>> GetAllPlatforms()
        {
            var _context = new DataContext();
            return await _context.socialPlatforms.Include(x => x.Translations).ThenInclude(x => x.Language).ToListAsync();
        }

        public async Task<SocialPlatform> GetSingle(int id)
        {
            var _context = new DataContext();
            return await _context.socialPlatforms.FindAsync(id);
        }
        public async Task<SocialPlatform> GetWithTranslation(string languageKey,int id) 
        {
            var _context = new DataContext();
            return await _context.socialPlatforms.Include(x=>x.Translations).ThenInclude(x=>x.Language).FirstOrDefaultAsync(x=>x.Id == id);
        }

        //public async Task<List<SocialPlatform>> GetPlatformsWithPostsTypes()
        //{
        //    var _context = new DataContext();
        //    return await _context.socialPlatforms.Include(x=>x.Translations).ThenInclude(x=>x.Language).ToListAsync();
        //}

        public async Task<List<SocialPlatform>> AddPlatform(SocialPlatform socialPlatform)
        {
            var _context = new DataContext();
            _context.socialPlatforms.Add(socialPlatform);
            await _context.SaveChangesAsync();
            return _context.socialPlatforms.ToList();
        }
    }
}
