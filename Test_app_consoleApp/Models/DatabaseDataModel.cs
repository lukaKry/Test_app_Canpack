using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_app_consoleApp
{
    public class DatabaseDataModel
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string ProcessingStatus { get; set; } = string.Empty;

        [Column(TypeName = "decimal(5,4)")]
        public decimal Efficiency { get; set; }

        [Column(TypeName = "Date")]
        public DateTime CurrentDate { get; set; }
    }
}
