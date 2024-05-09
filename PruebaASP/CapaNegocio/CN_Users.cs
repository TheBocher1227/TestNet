using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaDtos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Users
    {

        private CD_Users objCapaDato = new CD_Users();

        public List<User> Listar()
        {
            return objCapaDato.Listar();
        }



        public int Registrar(User obj,out string Mensaje)
        {
            Mensaje = string.Empty;

            if(string.IsNullOrEmpty(obj.Name)|| string.IsNullOrWhiteSpace(obj.Name))
            {

            }


            return objCapaDato.Registrar(obj,out Mensaje);
        }



       
    }
}
