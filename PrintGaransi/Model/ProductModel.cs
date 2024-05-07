using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PrintGaransi.Model
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ModelCode { get; set; }
        public string ModelNumber { get; set; }
        public string GlobalCodeId { get; set; }
        public string Register {  get; set; }
        public TimeOnly CycleTime { get; set; }

    }
}
