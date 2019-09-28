using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace enDemanda.WebApp.Models
{
    public class Data
    {
        public Negocio.Objetos.Empleado findEmpleado(int id)
        {
            List<Negocio.Objetos.Empleado> lstEmpleado = new List<Negocio.Objetos.Empleado>();
            Negocio.Objetos.Empleado empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 1, Nombre = "Juan Perez", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 2, Nombre = "Anita Sanchez", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 3, Nombre = "Jualiana Patarollo", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 4, Nombre = "Roberto Pastrana", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 5, Nombre = "Juan Buitrago", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 6, Nombre = "Ana Perez", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 7, Nombre = "Paola Angarita", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 8, Nombre = "Anita Diaz", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 9, Nombre = "Camilo Castro", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            empleado = new Negocio.Objetos.Empleado { Correo = "sacvaion@gmail.com", Id = 10, Nombre = "Felipe Castañead", NoTelefono = "3163284245" };
            lstEmpleado.Add(empleado);
            Negocio.Objetos.Empleado empleadoFind = lstEmpleado.Find(x => x.Id ==id);
            return empleadoFind;
        }
    }
}