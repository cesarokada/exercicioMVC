using DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace IContracts
{
    [ServiceContract]
    public interface ICursoSvc
    {
        [OperationContract]
        List<Curso> GetAllCursos();

        [OperationContract]
        Curso GetCurso(int Id);

        [OperationContract]
        void InsertCurso(Curso c);

        [OperationContract]
        void ModifyCurso(Curso c);

        [OperationContract]
        void RemoveCurso(int Id);
    }
}
