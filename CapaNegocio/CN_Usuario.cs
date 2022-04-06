using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
   public class CN_Usuario
    {

        private CD_Usuarios objCapaDato = new CD_Usuarios();


        public List<Usuario> listar()
        {
            return objCapaDato.Listar();
        }


        public int Registrar(Usuario obj, out string Mensaje)
        {

            Mensaje =  string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                Mensaje = "El apellido del usuario no puede ser vacio";
            }
           else if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
            {
                Mensaje = "El correo del usuario no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {



                string clave = CN_Recursos.GenerarClave();

                string asunto = "Creacion de Cuenta";

                string mensaje_correo = "<h3>Su cuenta fue creada correctamente</h3><br><p>Su contrasenia para acceder es : !clave!</p>";
                mensaje_correo = mensaje_correo.Replace("!clave!", clave);

                bool respuesta = CN_Recursos.EnviarCorreo(obj.correo,asunto,mensaje_correo);
                if (respuesta)
                {
                    obj.clave = CN_Recursos.ConvertirSHa256(clave);
                    return objCapaDato.Registrar(obj, out Mensaje);


                }
                else
                {
                    Mensaje = "No se puede enviar el correo";
                    return 0;
                }

                
            }else
            {
                return 0;
            }


           
        }


        public bool Editar(Usuario obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.apellidos) || string.IsNullOrWhiteSpace(obj.apellidos))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }
            else if (string.IsNullOrEmpty(obj.correo) || string.IsNullOrWhiteSpace(obj.correo))
            {
                Mensaje = "El nombre del usuario no puede ser vacio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {


                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }



        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }



    }
}
