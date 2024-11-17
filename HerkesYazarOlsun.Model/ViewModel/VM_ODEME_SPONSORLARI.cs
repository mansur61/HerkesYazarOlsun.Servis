using Microsoft.AspNetCore.Http;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_ODEME_SPONSORLARI
    {
        public long ID { get; set; }

        public DateTime? CREATE_AT { get; set; }

        public long USER_CREATED_ID { get; set; }

        public long IS_MODIFIED { get; set; }

        public DateTime? MODIFIED_AT { get; set; }

        public long USER_MODIFIED_ID { get; set; }

        public long IS_DELETED { get; set; }
        public long KitapId { get; set; }

        public long SponsorId { get; set; }
        public long LoginUserId { get; set; }
        public long tck { get; set; }

        public string NameSurname { get; set; }

        public string Tel { get; set; }
        public string? Mail { get; set; }
        public List<IFormFile>? dosyalar { get; set; }
        public string Mesaj { get; set; }


    }
}
