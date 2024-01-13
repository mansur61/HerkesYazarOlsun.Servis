using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.ViewModel
{
    public class VM_KARTLAR
    {
        public long ID { get; set; }

        public DateTime? CREATE_AT { get; set; }

        public long USER_CREATED_ID { get; set; }

        public long IS_MODIFIED { get; set; }

        public DateTime? MODIFIED_AT { get; set; }

        public long USER_MODIFIED_ID { get; set; }

        public long IS_DELETED { get; set; }
        public long Cvv { get; set; }
        public string KartUzerindekiIsim { get; set; }
        public string? KartTarihi { get; set; }

        public string KartNo { get; set; }
        public int KartTarihiAy { get; set; }
        public int KartTarihiYil { get; set; }

        public long OdemeId { get; set; }
        public long tck { get; set; }
        public string Tutar { get; set; }
        public long LoginUserId { get; set; }
        public long KitapId { get; set; }

    }
}
