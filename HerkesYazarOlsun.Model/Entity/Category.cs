using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerkesYazarOlsun.Model.Entity
{
    [Table(name: "Category")]
    public class Category : BaseEntity
    {
        public int BooksId { get; set; }
        public string Name { get; set; }
    }
}
