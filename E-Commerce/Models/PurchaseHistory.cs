using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class PurchaseHistory
    {
        public int customer_id { get; set; }
        [Key]
        public int p_id { get; set; }
        public int c_Id { get; set; }
        public string p_title { get; set; }
        public int p_count { get; set; }
        public int price { get; set; }
        public string date_time { get; set; }
        public Boolean p_status { get; set; }
    }

    public class Purchase : PurchaseHistory
    {
        public object purchaseHistories { get; set; }
    }
}
