using System;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.VisualBasic;

[WebService(Namespace = "http://172.20.19.90/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ServiceInfoAcred : System.Web.Services.WebService
{
    Parameters oP = new Parameters();
    Engine oE = new Engine();
    public string cdgEmpresa;
    public string emisor;
    public string receptor;
    
    public ServiceInfoAcred()
    {
        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
        cdgEmpresa = ConfigurationManager.AppSettings.Get("Empresa");
        receptor = ConfigurationManager.AppSettings.Get("receptorMail");
    }

    //SERVICIO ENCARGADO DE NOTIFICAR LA CONCLUSIÓN DE REGISTRO DE UNA SOLICITUD
    [WebMethod]
    public string setNotificaRegistro(string request)
    {
        string empresa = cdgEmpresa;
        string contenido = string.Empty;
        string status = string.Empty;
        DataSet dref = new DataSet();

        string query = "SELECT NOMBREC(CL.CDGEM, CL.CODIGO, 'I', 'N', NULL, NULL, NULL, NULL) NOMBRE " +
                       ",CO.NOMBRE CONVENIO " +
                       ",TO_CHAR(SC.INICIO,'DD/MM/YYYY') FECHA " +
                       ",SC.CANTSOLIC " +
                       "FROM REG_INFO_SOLIC RS, SC, CL, CO " +
                       "WHERE RS.CDGEM = '" + empresa + "' " +
                       "AND RS.IDVAL = '" + request + "' " +
                       "AND SC.CDGEM = RS.CDGEM " +
                       "AND SC.CDGCL = RS.CDGCL " +
                       "AND SC.CICLO = RS.CICLO " +
                       "AND SC.CLNS = RS.CLNS " +
                       "AND CL.CDGEM = SC.CDGEM " +
                       "AND CL.CODIGO = SC.CDGCL " +
                       "AND CO.CDGEM = SC.CDGEM " +
                       "AND CO.CODIGO = SC.CDGCO";

        int iRes = oE.ExecuteDS(ref dref, query, CommandType.Text);

        if (dref.Tables[0].Rows.Count > 0)
        {
            contenido = dref.Tables[0].Rows[0]["NOMBRE"].ToString() + "| " +
                        dref.Tables[0].Rows[0]["CONVENIO"].ToString() + "| " +
                        dref.Tables[0].Rows[0]["FECHA"].ToString() + "| " +
                        string.Format("{0:0,0.00}", Convert.ToDecimal(dref.Tables[0].Rows[0]["CANTSOLIC"].ToString()));

            ServiceMail servMail = new ServiceMail();
            status = servMail.setEnviaEmailRegistro(receptor, "Registro de Solicitud", contenido);

            if(status.Substring(0,1) == "1") 
                return "1 Notificación enviada";
            else
                return "0 Fallo el proceso de envio";
        }
        else
            return "0 No se encontraron registros";

    }                                                      
}
