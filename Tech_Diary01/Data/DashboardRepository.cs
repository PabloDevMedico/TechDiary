using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tech_Diary01.Data
{
    internal class DashboardRepository
    {
        public int GetTotalCursos()
        {
            using (SqlConnection connection = Conection.GetConnection())
            {
                connection.Open();

                string sql = "SELECT COUNT(*) FROM COURSE";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int GetTotalMatriculas()
        {
            using (SqlConnection connection = Conection.GetConnection())
            {
                connection.Open();

                string sql = "SELECT COUNT(*) FROM REGISTRATION";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public int GetPresencasHoje()
        {
            using (SqlConnection connection = Conection.GetConnection())
            {
                connection.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM PRESENCE
                    WHERE date_presence = CAST(GETDATE() AS DATE)
                    AND status = 'Present'";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public decimal GetTaxaPresenca()
        {
            using (SqlConnection connection = Conection.GetConnection())
            {
                connection.Open();

                string sql = @"
                    SELECT
                        CASE
                            WHEN COUNT(*) = 0 THEN 0
                            ELSE
                                SUM(CASE WHEN status = 'Present' THEN 1 ELSE 0 END)
                                * 100.0 / COUNT(*)
                        END
                    FROM PRESENCE";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    return Convert.ToDecimal(command.ExecuteScalar());
                }
            }
        }
    }
}
