using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUsuarioSOAP" in both code and config file together.
[ServiceContract]
public interface IUsuarioSOAP
{
    [OperationContract]
    Response<UsuarioModel> Regitrar(UsuarioModel objUsuarioModel);
    [OperationContract]
    Response<bool> Actualizar(UsuarioModel objUsuarioModel);
    [OperationContract]
    Response<bool> Eliminar(int idUsuario);
    [OperationContract]
    Response<UsuarioModel> Buscar(int idUsuario);
}
