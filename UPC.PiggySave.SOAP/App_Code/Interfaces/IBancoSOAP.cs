using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBancoSOAP" in both code and config file together.
[ServiceContract]
public interface IBancoSOAP
{
    [OperationContract]
    Response<BancoModel> Registrar(BancoModel objBancoModel);

    [OperationContract]
    Response<BancoModel> Buscar(int idBanco);

    [OperationContract]
    Response<bool> Modificar(BancoModel objBancoModel);

    [OperationContract]
    Response<bool> Eliminar(int idBanco);

    [OperationContract]
    Response<List<BancoModel>> ListarPorActivo(bool acitivo);
}
