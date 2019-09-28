using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace enDemanda.WebApp.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public JsonResult Index()
        {
            Negocio.Objetos.Response response = new Negocio.Objetos.Response();
            try
            {
                response.Exitoso = true;
                response.Mensaje = "Se envio correctamenmte el msj";

                List<Negocio.Objetos.Empleado> lstEmpleado = new List<Negocio.Objetos.Empleado>();
                Negocio.Objetos.Empleado emp = new Negocio.Objetos.Empleado();
                emp.Correo = "sacvaion@gmail.com";
                emp.Nombre = "carlos adolfo";
                emp.NoTelefono = "3163284245";
                lstEmpleado.Add(emp);

                Negocio.Util.Util.EnvioCorreo(lstEmpleado);

            }
            catch (Exception)
            {
                response.Exitoso = false;
                response.Mensaje = "Se genero un error enviado el correo";
            }


            return new JsonResult() { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}