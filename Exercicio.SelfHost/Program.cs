using Entities.Services;
using IContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                using (var host = new ServiceHost(typeof(PordutoSvc)
                                                , new Uri("http://localhost:20444/ProdutoSvc/")
                                                , new Uri("net.tcp://localhost:20445/ProdutoSvc/")
                                                , new Uri("net.pipe://localhost/ProdutoSvc/")))
                {
                    // endpoint http
                    host.AddServiceEndpoint(typeof(IProdutoSvc), new BasicHttpBinding(), "web");

                    // endpoint net.tcp
                    host.AddServiceEndpoint(typeof(IProdutoSvc), new NetTcpBinding(), "tcp");

                    // endpoint net.pipe
                    host.AddServiceEndpoint(typeof(IProdutoSvc), new NetNamedPipeBinding(), "pipe");

                    // endpoint mex
                    host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                    host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                    host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                    host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexNamedPipeBinding(), "mex");

                    host.Open();

                    Console.WriteLine("The server is ready");
                    Console.WriteLine("press enter");
                    Console.ReadKey();

                    host.Close();
                }
            });


            Task.Run(() =>
            {
                using (var host = new ServiceHost(typeof(CursoSvc)
                                                , new Uri("http://localhost:20444/CursoSvc/")
                                                , new Uri("net.tcp://localhost:20445/CursoSvc/")
                                                , new Uri("net.pipe://localhost/CursoSvc/")))
                {
                    // endpoint http
                    host.AddServiceEndpoint(typeof(ICursoSvc), new BasicHttpBinding(), "web");

                    // endpoint net.tcp
                    host.AddServiceEndpoint(typeof(ICursoSvc), new NetTcpBinding(), "tcp");

                    // endpoint net.pipe
                    host.AddServiceEndpoint(typeof(ICursoSvc), new NetNamedPipeBinding(), "pipe");

                    // endpoint mex
                    host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                    host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                    host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
                    host.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexNamedPipeBinding(), "mex");

                    host.Open();

                    Console.WriteLine("The server is ready");
                    Console.WriteLine("press enter");
                    Console.ReadKey();

                    host.Close();
                }
            });

            Console.ReadKey();
        }
    }
}
