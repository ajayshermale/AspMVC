using DBcon.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DBcon
{
    public class DB_Context
    {
        string Constring { get; set; }

        public DB_Context() { }

        public DB_Context(string constring = @"Data Source=RAHUL\SQLEXPRESS;Initial Catalog=MVCSQL;User ID=Ajay;Password=Ajay")
        { Constring = constring; }

        public List<ProductM> GetProduct(int id)
        {
            List<ProductM> products = new List<ProductM>();
            ProductM productsdata = new ProductM();
            using (SqlConnection sql = new SqlConnection(Constring))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("Getproduct", sql);
                // cmd.Parameters.AddWithValue("@ID" int , id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                if (dataTable != null)
                {
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        productsdata = new ProductM()
                        {
                            ID = Convert.ToInt32(dataTable.Rows[i]["ID"].ToString()),
                            Name = dataTable.Rows[i]["Name"].ToString(),
                            Description = dataTable.Rows[i]["Description"].ToString()
                        };
                        products.Add(productsdata);
                    }

                }
                return products;
            }


        }

        public int AddProduct(ProductM productsdata)
        {
            using (SqlConnection sql = new SqlConnection(Constring))
            {
                sql.Open();
                SqlCommand cmd = new SqlCommand("Addproduct", sql);
                // cmd.Parameters.AddWithValue("@ID" int , id);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", productsdata.Name);
                cmd.Parameters.AddWithValue("@Description", productsdata.Description);
                int inserted = cmd.ExecuteNonQuery();

                return inserted;
            }
        }
    }
}
