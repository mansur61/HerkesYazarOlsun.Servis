using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "BooksStars")]
    public class BooksStars : BaseEntity
    {
        public int StarPuani { get; set; }
        public int LoginUserId { get; set; }
        public int BookaId { get; set; }
    }
}
