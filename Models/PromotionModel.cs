using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PromotionModel
    {
        public int Sale_Id { get; set; }
        public int? Product_Id { get; set; }
        public float? Discount { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }
    }
}
