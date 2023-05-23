using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace AspNetCore.Contexts
{

    public class AppDbContext
    {
        protected MySqlConnection conn;
        protected MySqlCommand qy;
        protected MySqlDataReader reader;

        protected void OpenConn()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();

            try
            {
                conn = new MySqlConnection(configuration.GetConnectionString("Default"));
                conn.Open();
            }
            catch (Exception err)
            {
                throw new Exception("Erro ao conectar ao banco de dados: " + err.Message);
            }
        }

        protected void CloseConn()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception err)
            {
                throw new Exception("Erro ao fechar conexão com o banco de dados: " + err.Message);
            }
        }
    }
}