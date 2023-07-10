using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Galaxy.DTO
{
     class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public decimal price { get; set; }
        public decimal quantity { get; set; }
        public int catory { get; set; }
        public int company { get; set; }
        public byte[] image { get; set; }

        public Products(DataRow row)
        {
            this.id = (int)row["ProductID"];
            this.company = (int)row["CompanyID"];
            this.quantity = (decimal)row["Quantity"];
            this.name = row["ProductName"].ToString();
            this.unit = row["Unit"].ToString();
            this.catory = (int)row["CatoryID"];
            this.price = (decimal)row["SellPrice"];
            if (row["Image"] != System.DBNull.Value)
            {
                this.image = (byte[])row["Image"];

            }
        }
    }
}
