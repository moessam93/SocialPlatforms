using SocialPlatformsAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Entities
{
    public class SocialPlatformPostTypes
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("FK_SocialPlatformId")]
        public int SocialPlatformId { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Key { get; set; }
        public int DisplayOrder { get; set; }
    }
}
