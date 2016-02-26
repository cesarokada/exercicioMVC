using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using DB.Entities;

namespace IContracts
{
    [ServiceContract]
    public interface IProdutoSvc
    {
        [OperationContract]
        List<Produto> GetAllProdutos();

        [OperationContract]
        Produto GetProduto(int Id);

        [OperationContract]
        void InsertProduto(Produto p);

        [OperationContract]
        void ModifyProduto(Produto p);

        [OperationContract]
        void RemoveProduto(int Id);
    }
}
