using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;

namespace CapaDtos
{
    public class CD_Users
    {

        public List<User> Listar()
        {
            List<User> lista = new List<User>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    string query = "select IdUsuario,Name,Email,Password from Users";
                    SqlCommand cmd = new SqlCommand(query, oconexion);
                    cmd.CommandType = CommandType.Text;

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(
                                new User()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Name = dr["Name"].ToString(),
                                    Email = dr["Email"].ToString(),
                                    Password = dr["Password"].ToString()
                                });
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                
                Console.WriteLine("Se produjo un error al intentar listar usuarios: " + ex.Message);

                lista = new List<User>();
            }
            return lista;
        }





        public int Registrar(User obj,out string Mensaje)
        {

            int idautogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Name", obj.Name);
                    cmd.Parameters.AddWithValue("Email", obj.Email);
                    cmd.Parameters.AddWithValue("Password", obj.Password);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();

                    cmd.ExecuteNonQuery();
                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }

            catch(Exception ex)
            {
                idautogenerado=0;
                Mensaje = ex.Message;
            }

            return idautogenerado;
            }
    }
}
