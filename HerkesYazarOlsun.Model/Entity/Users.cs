
using System.ComponentModel.DataAnnotations.Schema;


namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Users")]
    public class Users : NewBaseEntity
    {
        public string NAME { get; set; }
        public string SURNAME { get; set; }

        public string EMAIL { get; set; }
        public string TCKNO { get; set; }

        public string PASSWORD { get; set; }


    }

   
}
