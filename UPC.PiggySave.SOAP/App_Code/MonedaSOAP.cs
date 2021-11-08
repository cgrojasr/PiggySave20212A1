using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using UPC.PiggySave.BL;
using UPC.PiggySave.DA;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MonedaSOAP" in code, svc and config file together.
public class MonedaSOAP : IMonedaSOAP
{
    private readonly MonedaBL objMonedaBL;
    public MonedaSOAP()
    {
        objMonedaBL = new MonedaBL();
    }

    public MonedaModel Buscar(int id)
    {
        try
        {
            var objMoneda = objMonedaBL.Buscar(id);
            var objMonedaModel = new MonedaModel {
                id = objMoneda.idMoneda,
                nombre = objMoneda.nombre,
                abreviatura = objMoneda.abreviatura
            };

            return objMonedaModel;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool Eliminar(int id)
    {
        try
        {
            return objMonedaBL.Eliminar(id);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public IEnumerable<MonedaModel> Listar()
    {
        try
        {
            var lstMoneda = objMonedaBL.Listar();
            var lstMonedaModel = new List<MonedaModel>();
            foreach (var moneda in lstMoneda) {
                var monedaModel = new MonedaModel()
                {
                    id = moneda.idMoneda,
                    nombre = moneda.nombre,
                    abreviatura = moneda.abreviatura
                };
                lstMonedaModel.Add(monedaModel);
            }
            return lstMonedaModel;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool Modificar(MonedaModel objMonedaModel)
    {
        try
        {
            var objMoneda = new Moneda() {
                idMoneda = objMonedaModel.id,
                nombre = objMonedaModel.nombre,
                abreviatura = objMonedaModel.abreviatura,
                idUsuarioModifico = objMonedaModel.idUsuarioRegistro
            };

            return objMonedaBL.Modificar(objMoneda);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public MonedaModel Registrar(MonedaModel objMonedaModel)
    {
        try
        {
            var objMoneda = new Moneda()
            {
                nombre = objMonedaModel.nombre,
                abreviatura = objMonedaModel.abreviatura,
                idUsuarioRegistro = objMonedaModel.idUsuarioRegistro
            };

            objMoneda = objMonedaBL.Registrar(objMoneda);
            objMonedaModel.id = objMoneda.idMoneda;

            return objMonedaModel;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
