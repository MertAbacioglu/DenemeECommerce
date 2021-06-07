using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap:BaseMap<AppUser>
    {
        // HasKey() : Tabloda Primary key ataması yapılandırmanızı sağlar.
        // ToTable() : İlgili entity’nin tablo adını yapılandırmanızı sağlar.
        // HasRequired() : İlgili entity’nin gerekli olan ilişkisini yapılandırmanızı sağlar.

        public AppUserMap()
        {
            HasOptional(x => x.UserProfile).WithRequired(x => x.AppUser);
        }

    }
}
