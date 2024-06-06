using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductModel
    {
        public int Product_Id { get; set; }
        public int Cate_Id { get; set; }
        public string Product_Name { get; set; }
        public string Unit { get; set; }
        public int Unit_Price { get; set; }
        public int Quantity_In_Stock { get; set; }
        public string Picture { get; set; }
        public int Status { get; set; } 
        public string Description { get; set; }
        public int BrandID { get; set; }

        public DateTime CreatedDay { get; set; }
    }

    public class Product_ReportModel
    {
        public int Product_Id { get; set; }
        public int Cate_Id { get; set; }
        public string Product_Name { get; set; }
        public string Unit { get; set; }
        public int Unit_Price { get; set; }
        public int Quantity_In_Stock { get; set; }
        public string Picture { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public int BrandID { get; set; }

        public DateTime CreatedDay { get; set; }
        public int TotalQuantitySold { get; set; }
    }

    public class ProductModel_withSoldNumber
    {
        public int Product_Id { get; set; }
        public int Cate_Id { get; set; }
        public string Product_Name { get; set; }
        public string Unit { get; set; }
        public int Unit_Price { get; set; }
        public int Quantity_In_Stock { get; set; }
        public int Total_Quantity_Sold { get; set; }
    }
    public class ProductModel_withRevenue
    {
        public int Product_Id { get; set; }
        public int Cate_Id { get; set; }
        public string Product_Name { get; set; }
        public string Unit { get; set; }
        public int Unit_Price { get; set; }
        public int Quantity_In_Stock { get; set; }
        public string Picture { get; set; }
        public int Total_Sales_Amount { get; set; }
    }

}
