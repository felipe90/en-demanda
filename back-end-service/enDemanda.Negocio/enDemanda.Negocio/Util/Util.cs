using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace enDemanda.Negocio.Util
{
    public class Util
    {

        /// <summary>
        /// se Utiliza para el envio de correo
        /// </summary>
        /// <returns></returns>
        public static bool EnvioCorreo(List<Objetos.Empleado> lstDestinatario)
        {
            bool rpta = false;
            MailMessage msg = new MailMessage();
            foreach (Objetos.Empleado Destinatario in lstDestinatario)
            {
                msg.To.Add(new MailAddress(Destinatario.Correo));
            }

            msg.Subject = "Hemos encontrado una oferta para ti";
            msg.Body = "De acuerdo a tus habilidades hemos encontrado una oferta de trabajo que se ajusta a tus conocimientos : ";

            msg.From = new MailAddress("help.desk@ondemanda.com.co", "Help Desk");
            //msg.Body = msg.Body + "<br><br>Usuario: " + empleado.NombresCompletos +"<br>NoDocumento: " + empleado.NoDocumento +"<br>Pertenece a La Empresa: " + empleado.Empresa +"<br>Datos GPS: " + empleado.Direccion;
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = true;
            client.Credentials = new System.Net.NetworkCredential("sacvaiontv@gmail.com", "Carlos.88");
            client.Port = 587; // You can use Port 25 if 587 is blocked (mine is!)
            client.Host = "smtp.gmail.com";
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
                //EnvioCorreoBytte(empleado, lstDestinatario);
                Console.WriteLine("Message Sent Succesfully");
                rpta = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Enviando Correo: " + ex.ToString());
                //rpta = EnvioCorreoBytte(empleado, lstDestinatario, TipoCorreo);
            }
            return rpta;
        }


    }
}
