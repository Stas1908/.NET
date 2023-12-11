using lab1_ado2.Configuration;
using lab1_ado2.Models;
using lab1_ado2.Repository.Interface;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace lab1_ado2.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly DBConnection dBConnection;
        public CatalogRepository(DBConnection connection)
        {
            dBConnection = connection;
        }
        public int createCatalog(Catalog catalog)
        {
            int status;
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Catalog (cloth_id,price) VALUES (@cloth_id,@price)", sqlConnection);
                SqlParameter parameterName = new SqlParameter("@cloth_id", catalog.cloth_id);
                cmd.Parameters.Add(parameterName);
                SqlParameter parameterDescription = new SqlParameter("@price", catalog.price);
                status = cmd.ExecuteNonQuery();
            }

            return status;
        }

        public int deleteCatalog(int id)
        {
            int status;
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Catalog WHERE id=@id", sqlConnection);
                SqlParameter parameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(parameter);
                status = cmd.ExecuteNonQuery();
            }

            return status;
        }

        public List<Catalog> getAllCatalog()
        {
            List<Catalog> catalogs= new List<Catalog>();
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Catalog", sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Catalog catalog = new Catalog();
                        catalog.id = reader.GetInt32(0);
                        catalog.cloth_id = reader.GetInt32(1);
                        catalog.price = reader.GetDecimal(2);
                        catalogs.Add(catalog);
                    }
                }
            }

            return catalogs;
        }

        public Catalog getCatalog(int id)
        {
            Catalog catalog = new Catalog();
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Catalog WHERE id = @id", sqlConnection);
                SqlParameter parameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(parameter);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        catalog.id = reader.GetInt32(0);
                        catalog.cloth_id = reader.GetInt32(1);
                        catalog.price = reader.GetDecimal(2);
                    }
                }
            }

            return catalog;
        }

        public int updateCatalog(Catalog catalog)
        {
            int status;
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Catalog SET cloth_id=@name, price=@size, type=@type WHERE id=@id", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@name", catalog.cloth_id));
                cmd.Parameters.Add(new SqlParameter("@size", catalog.price));
                cmd.Parameters.Add(new SqlParameter("@id", catalog.id));
                status = cmd.ExecuteNonQuery();
            }
            return status;
        }
    }
}
