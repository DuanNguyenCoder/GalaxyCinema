using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Galaxy.DAO
{
    internal class ProductsDAO
    {
        
    
        private static ProductsDAO instance;

        public static ProductsDAO Instance
        {
            get { if (instance == null) instance = new ProductsDAO(); return ProductsDAO.instance; }
            private set { ProductsDAO.instance = value; }
        }

        public List<DTO.Products> GetListProduct()
        {

            List<DTO.Products> list = new List<DTO.Products>();

            string query = "select * from Product";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO.Products food = new DTO.Products(item);
                list.Add(food);
            }

            return list;
        }
        public List<DTO.Products> getListByCatory(int idcatory)
        {
            List<DTO.Products> list = new List<DTO.Products>();

            string query = $"SELECT * FROM Product WHERE CatoryID = {idcatory}";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO.Products food = new DTO.Products(item);
                list.Add(food);
            }

            return list;
        }
        public List<DTO.Products> findProductByName(string name)
        {
            List<DTO.Products> list = new List<DTO.Products>();

            string query = $"SELECT * FROM Product p WHERE p.ProductName LIKE '%{name}%'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DTO.Products food = new DTO.Products(item);
                list.Add(food);
            }

            return list;
        }
        public int addNewProduct(string name, string unit, double sellPrice, int quantity, int companyID, int catory, byte[] image)
        {
            string query = "INSERT INTO Product (ProductName, Unit, SellPrice, Quantity, CompanyID, CatoryID, Image)" +
  $"VALUES(N'{name}', N'{unit}', {sellPrice}, {quantity}, {companyID}, {catory}, @image) ";
            return DataProvider.Instance.excuteWithPara(query, image);
        }
        public int updateProduct(string name, string unit, double sellPrice, int quantity, int companyID, int catory, byte[] image, int oldID)
        {
            string query = "UPDATE Product "
+ $"SET ProductName = N'{name}'"
+ $" ,Unit = N'{unit}'"
 + $",SellPrice = {sellPrice}"
 + $",Quantity = {quantity}"
 + $",CompanyID = {companyID}"
  + $",CatoryID = {catory}"
  + $",Image = @image"
+ $"WHERE ProductID = {oldID} ";
            return DataProvider.Instance.excuteWithPara(query, image);
        }
        public int deleteProduct(int id)
        {
            string query = $"delete Product where ProductID = N'{id}'";
            return DataProvider.Instance.ExecuteNonQuery(query);
        }

    }

}
