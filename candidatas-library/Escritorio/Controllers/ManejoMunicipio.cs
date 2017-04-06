using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using candidatas_library.Model;

namespace Escritorio.Controllers
{
    class ManejoMunicipio
    {
        public static List<Municipio> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Municipios.Where(r => r.bStatus == Status && r.sNombre.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Municipio> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Municipios.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Municipio getById(int pkMunicipio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Municipios.Where(r => r.bStatus == true && r.pkMunicipio == pkMunicipio).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Guardar(Municipio nMunicipio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Municipios.Add(nMunicipio);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Modificar(Municipio nMunicipio)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Municipios.Attach(nMunicipio);
                    ctx.Entry(nMunicipio).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Eliminar(int pkCandidata)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    Municipio nMunicipio = ManejoMunicipio.getById(pkCandidata);
                    nMunicipio.bStatus = false;

                    ctx.Entry(nMunicipio).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
