using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMonedaSOAP" in both code and config file together.
[ServiceContract]
public interface IMonedaSOAP
{
    [OperationContract]
    MonedaModel Buscar(int id);
    [OperationContract]
    IEnumerable<MonedaModel> Listar();
    [OperationContract]
    MonedaModel Registrar(MonedaModel objMonedaModel);
    [OperationContract]
    bool Modificar(MonedaModel objMonedaModel);
    [OperationContract]
    bool Eliminar(int id);
}