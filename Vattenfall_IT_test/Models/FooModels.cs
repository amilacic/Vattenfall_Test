using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vattenfall_IT_test.Models
{
    public class FooModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surename { get; set; }

        public string Age { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime Modified { get; set; }

    }
}
