using CrudWindowsFormAnalisisDeSistemas.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWindowsFormAnalisisDeSistemas.Dato
{
    public class VehiculoAdmin
    {
        public List <vehiculo> Consultar()
        {
            using (CrudWFEntities contexto = new CrudWFEntities())
            {
                return contexto.vehiculo.AsNoTracking().ToList();
            }
        }
        public void Guardar(vehiculo modelo)
        {
            using (CrudWFEntities contexto = new CrudWFEntities())
            {
                contexto.vehiculo.Add(modelo);
                contexto.SaveChanges();
            }
        }

        public void Actualizar(vehiculo modelo)
        {
            using (CrudWFEntities contexto = new CrudWFEntities())
            {
                var data = contexto.vehiculo.FirstOrDefault(vehiculo => vehiculo.Id == modelo.Id);
                if (data != null)
                {
                    data.precio = modelo.precio;
                    data.color = modelo.color;
                    data.marca = modelo.marca;
                    contexto.SaveChanges();
                }
            }
        }

        public void Eliminar(vehiculo modelo)
        {
            using (CrudWFEntities contexto = new CrudWFEntities())
            {
                var data = contexto.vehiculo.FirstOrDefault(vehiculo => vehiculo.Id == modelo.Id);
                if (data != null)
                {
                    contexto.vehiculo.Remove(data);
                    contexto.SaveChanges();
                }
            }
        }
    }
}
