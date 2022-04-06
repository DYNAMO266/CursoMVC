using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;


namespace CapaNegocio
{
   public class CN_Recursos
    {

        //generar clave automatica al usuario
        public static string GenerarClave()
        {
            string clave = Guid.NewGuid().ToString("N").Substring(0, 6);
            return clave;
        }


        //encriptacion
        public static string ConvertirSHa256(string texto)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    sb.Append(b.ToString("x2"));

            }

            return sb.ToString();

        }

        //enviar correo

        public static bool EnviarCorreo(string correo,string asunto,string mensaje)
        {
            bool Resultado = false;

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(correo);
                mail.From = new MailAddress("rticselazo@gmail.com");
                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;


                var smtp = new SmtpClient()
                {
                    //credenciales generado por google
                    Credentials = new NetworkCredential("rticselazo@gmail.com", "prpuzmfvvelunqfg"),
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true
                };

                smtp.Send(mail);
                Resultado = true;
            }
            catch (Exception e)
            {

                Resultado = false;
            }


            return Resultado;
        }



    }
}
