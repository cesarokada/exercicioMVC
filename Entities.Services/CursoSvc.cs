using IContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Entities;
using DB.Persistence;
using System.Data.Common;
using System.Data.SqlClient;

namespace Entities.Services
{
    public class CursoSvc : ICursoSvc
    {
        public List<Curso> GetAllCursos()
        {
            List<Curso> cursos = new List<Curso>();

            using (var context = new Context())
            {
                try
                {
                    context.Database.Connection.Open();
                    cursos = context.Cursos.ToList();
                    context.Database.Connection.Close();
                }
                catch (SqlException)
                {
                    throw;
                }
            }
            return cursos;
        }

        public Curso GetCurso(int Id)
        {
            Curso c;
            using (var context = new Context())
            {
               c = context.Cursos.FirstOrDefault(x => x.IdCurso== Id);
            }
            return c;
        }

        public void InsertCurso(Curso c)
        {
            using (var context = new Context())
            {
                context.Cursos.Add(c);
                context.SaveChanges();
            }
        }

        public void ModifyCurso(Curso c)
        {
            using (var context = new Context())
            {
                Curso cUpdate = context.Cursos.FirstOrDefault(x => x.IdCurso == c.IdCurso);
                cUpdate.NomeCurso = c.NomeCurso;
                context.SaveChanges();
            }

        }

        public void RemoveCurso(int Id)
        {
            using (var context = new Context())
            {
                Curso c = new Curso();
                c = context.Cursos.FirstOrDefault(x => x.IdCurso == Id);
                context.Cursos.Remove(c);
                context.SaveChanges();
            }
        }
    }
}
