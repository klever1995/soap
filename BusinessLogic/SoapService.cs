using System.ServiceModel;

namespace soap.BusinessLogic
{
    // Implementación del servicio SOAP
    public class SoapService : ISoapService
    {
        // Método que devuelve "Hello World"
        public string SayHello()
        {
            return "Hello World";
        }
    }

    // Interfaz que define el contrato del servicio
    [ServiceContract]
    public interface ISoapService
    {
        // Operación que devuelve "Hello World"
        [OperationContract]
        string SayHello();
    }
}
