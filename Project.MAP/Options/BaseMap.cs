using Project.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        /* EntityTypeConfiguration :
            veritabanında ayarlamaları yapmamızı saglayan sınıf. context’imizin oluştuğu sırada OnModelCreate methodunu override edebileceğimiz EntityTypeConfiguration sınıfından yararlanıyoruz.*/
        public BaseMap()
        {
            /*
            buraya istersek ortak ayarlamaları yapmak istediğimiz kodlarımızı yazarız.
            örneğin  : 
            Property(x => x.ModifiedDate).HasColumnName("Veri Güncelleme Tarihi").HasColumnType("datetime2");
            gibi...

            Property() : Belirli bir alana tablodaki durumu için özellik atamak için kullanılır.
            */

        }
    }
}
