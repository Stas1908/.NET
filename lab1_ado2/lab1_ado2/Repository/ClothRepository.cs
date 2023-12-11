using lab1_ado2.Configuration;
using lab1_ado2.Models;
using lab1_ado2.Repository.Interface;
using System.Data.Common;
using System.Data.SqlClient;

namespace lab1_ado2.Repository
{
    public class ClothRepository : IClothRepository
    {
        private readonly DBConnection dBConnection;
        public ClothRepository(DBConnection connection)
        {
            dBConnection = connection;
        }
        public int createCloth(Cloth cloth)
        {
            int status;
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Cloth (name, size, type) VALUES (@name,@size,@type)", sqlConnection);
                SqlParameter parameterName = new SqlParameter("@name", cloth.name);
                cmd.Parameters.Add(parameterName);
                SqlParameter parameterDescription = new SqlParameter("@size", cloth.size);
                cmd.Parameters.Add(parameterDescription);
                SqlParameter parameterRecipe = new SqlParameter("@type", cloth.type);
                cmd.Parameters.Add(parameterRecipe);
                status = cmd.ExecuteNonQuery();
            }

            return status;
        }

        public int deleteCloth(int id)
        {
            int status;
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Cloth WHERE id=@id", sqlConnection);
                SqlParameter parameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(parameter);
                status = cmd.ExecuteNonQuery();
            }

            return status;
        }

        public List<Cloth> getAllCloth()
        {
            List<Cloth> products = new List<Cloth>();
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cloth", sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Cloth product = new Cloth();
                        product.id = reader.GetInt32(0);
                        product.name = reader.GetString(1);
                        product.size = reader.GetString(2);
                        product.type = reader.GetString(3);
                        products.Add(product);
                    }
                }
            }

            return products;
        }

        public Cloth getCloth(int id)
        {
            Cloth product = new Cloth();
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {

                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Cloth WHERE id = @id", sqlConnection);
                SqlParameter parameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(parameter);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        product.id = reader.GetInt32(0);
                        product.name = reader.GetString(1);
                        product.size = reader.GetString(2);
                        product.type = reader.GetString(3);
                    }
                }
            }

            return product;
        }

        public int updateCloth(Cloth cloth)
        {
            int status;
            using (SqlConnection sqlConnection = dBConnection.CreateConnection())
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Cloth SET name=@name, size=@size, type=@type WHERE id=@id", sqlConnection);
                cmd.Parameters.Add(new SqlParameter("@name", cloth.name));
                cmd.Parameters.Add(new SqlParameter("@size", cloth.size));
                cmd.Parameters.Add(new SqlParameter("@type", cloth.type));
                cmd.Parameters.Add(new SqlParameter("@id", cloth.id));
                status = cmd.ExecuteNonQuery();
            }
            return status;
        }
    }
}
