using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment
{
    public class Campaigns
    {
        public double backersCount  { get; set; }
        public int? categoryId { get; set; }
        public string code { get; set; }
        public string created { get; set; }
        public int daysLeft { get; set; }
        public string endDate { get; set; }
        public bool featured { get; set; }
        public string imageSrc { get; set; }
        public string ngoCode { get; set; }
        public string ngoName { get; set; }
        public double percentage { get; set; }
        public int priority { get; set; }
        public double procuredAmount { get; set; }
        public string? shortDesc { get; set; }
        public string title { get; set; }
        public double totalAmount { get; set; }
        public double totalProcured { get; set; }
    }
}
