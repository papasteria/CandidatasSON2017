using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using candidatas_library.Model;

namespace Escritorio.Controllers
{
    class ManejoCandidata
    {
        public static List<Candidata> Buscar(string valor, Boolean Status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Candidatas.Where(r => r.bStatus == Status && r.sNombreCompleto.Contains(valor)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Candidata> getAll(Boolean status)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Candidatas.Where(r => r.bStatus == status).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Candidata getById(int pkCandidata)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Candidatas.Where(r => r.bStatus == true && r.pkCandidata == pkCandidata).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Guardar(Candidata nCandidata, int pkMunicipio, int pkUsuario)
        {
            Municipio municipio = ManejoMunicipio.getById(pkMunicipio);
            Usuario usuario = ManejoUsuario.getById(pkUsuario);
            try
            {
                using (var ctx = new DataModel())
                {
                    nCandidata.fkMunicipio = municipio;
                    nCandidata.fkUsuario = usuario;
                    ctx.Candidatas.Add(nCandidata);
                    ctx.Municipios.Attach(municipio);
                    ctx.Usuarios.Attach(usuario);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Modificar(Candidata nCandidata)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    ctx.Candidatas.Attach(nCandidata);
                    ctx.Entry(nCandidata).State = EntityState.Modified;
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
                    Candidata nCandidata = ManejoCandidata.getById(pkCandidata);
                    nCandidata.bStatus = false;

                    ctx.Entry(nCandidata).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void Like(int pkCandidata)
        {
            Candidata nCandidata = ManejoCandidata.getById(pkCandidata);
            try
            {
                using (var ctx = new DataModel())
                {
                    int likes = nCandidata.iLike;
                    int like = 1;
                    likes += like;

                    nCandidata.iLike = likes;
                    ctx.Candidatas.Attach(nCandidata);
                    ctx.Entry(nCandidata).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Candidata> Buscar(string valor, Boolean Status, string mun)
        {
            try
            {
                using (var ctx = new DataModel())
                {
                    return ctx.Candidatas.Where(r => r.bStatus == Status && r.sNombreCompleto.Contains(valor) && r.fkMunicipio.sNombre.Contains(mun))
                        .OrderByDescending(r => r.iLike)
                        .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
