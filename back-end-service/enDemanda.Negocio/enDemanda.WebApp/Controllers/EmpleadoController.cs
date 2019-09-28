using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace enDemanda.WebApp.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public JsonResult Index(Negocio.Objetos.Empleado empleado)
        {
            Negocio.Objetos.Response response = new Negocio.Objetos.Response();
            try
            {
                response.Exitoso = true;
                response.Mensaje = "Se creo correctamente el usuario";
            }
            catch (Exception)
            {
                response.Exitoso = false;
                response.Mensaje = "Se genero un error al intentar crear el usuario";
            }
            return new JsonResult() { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public JsonResult getEmpleado(int id)
        {
            Negocio.Objetos.Empleado response = new Negocio.Objetos.Empleado();
            try
            {
                Models.Data data = new Models.Data();
                response = data.findEmpleado(id);
            }
            catch (Exception)
            {
                
            }
            return new JsonResult() { Data = response, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }
    }
}