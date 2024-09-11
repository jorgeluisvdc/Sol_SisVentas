using FNT_BusinessEntities.Interface;

namespace FNT_BusinessLogic
{
    public interface IVentasBusinessLogic
    {
        DTOVentasRespuesta ObtenerListaVentas(DTOVentasConsulta oConsulta);
    }
}