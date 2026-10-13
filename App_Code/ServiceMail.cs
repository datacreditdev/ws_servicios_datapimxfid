using System;
using System.Collections;
using System.Configuration;
using System.Web;
using System.Web.Mail;
using System.Web.Services;
using System.Web.Services.Protocols;

/// <summary>
/// Descripción breve de ServiceMail
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class ServiceMail : System.Web.Services.WebService {

    public string cdgEmpresa;
    public string usuarioMail;
    public string passMail;
    public string serverMail;
    public string puertoMail;

    public ServiceMail () {
        cdgEmpresa = ConfigurationManager.AppSettings.Get("Empresa");
        usuarioMail = ConfigurationManager.AppSettings.Get("emisorMail");
        passMail = ConfigurationManager.AppSettings.Get("passMail");
        serverMail = ConfigurationManager.AppSettings.Get("serverMail");
        puertoMail = ConfigurationManager.AppSettings.Get("puertoMail");
    }

    private string setEnvia(string receptor, string asunto, string contenido)
    {
        System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();
        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", serverMail);
        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", puertoMail);
        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1"); //Use 0 for anonymous
        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", usuarioMail);
        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", passMail);
        myMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");

        string path = AppDomain.CurrentDomain.BaseDirectory;

        myMail.From = usuarioMail;
        myMail.To = receptor;
        myMail.Subject = asunto;
        myMail.BodyFormat = System.Web.Mail.MailFormat.Html;
        myMail.Body = contenido;

        try
        {
            MailAttachment mailAttachment = new MailAttachment(@"" + path + "img\\encabezado.png");
            myMail.Attachments.Add(mailAttachment);
            System.Web.Mail.SmtpMail.SmtpServer = serverMail + ":" + puertoMail;
            System.Web.Mail.SmtpMail.Send(myMail);
        }
        catch (Exception ex)
        {
            return "0 " + ex.Message;
        }
        return "1";
    }

    [WebMethod]
    public string setEnviaEmailEvaluacion(string receptor, string asunto, string contenido)
    {
        string[] arrContenido = contenido.Split('|');

        string BODY = string.Format(@"<!DOCTYPE html>
                                    <html lang='es'>
                                        <head>
                                            <meta charset='utf-8'>
                                            <title>Opportunity</title>
                                        </head>
                                        <body>
                                            <table style='max-width: 600px; padding: 10px; margin:0 auto; border-collapse: collapse;'>
                                                <tr>
                                                    <td style='padding: 0;'>
                                                        <img style='padding: 0; display:block;' src='encabezado.png'>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style='background-color: #f6f6f6; color: #000000;  font-size: 18px; font-family: Century Gothic, CenturyGothic, AppleGothic, sans-serif; padding: 10px 20px 40px 20px; text-align: center;'>
                                                        <p style='color: #000000; text-align: left;'>Hola</p>
                                                        <p style='text-align: left'><span>Se ha concluido el proceso de evaluación de la solicitud</span><br><span>de crédito:</span></p>
                                                        <ul style='text-align: left'>
                                                            <li>Nombre: {0}</li>
                                                            <li>Convenio: {1}</li>
                                                            <li>Fecha de Entrega: {2}</li>
                                                            <li>Monto Autorizado: ${3}</li>
                                                        </ul>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style='background-color: #000000; max-width: 600px;'>
                                                        <p style='color:white; text-align: center; margin: 15px 0px; font-size: 15px; font-family: Century Gothic, CenturyGothic, AppleGothic, sans-serif;'>Opportunity Tu Solución</p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style='height: 20px; max-width: 600px;'>
                                                    </td>
                                                </tr>
                                            </table>
                                        </body>
                                    </html>", arrContenido[0], arrContenido[1], arrContenido[2], arrContenido[3]);

        return setEnvia(receptor, asunto, BODY);
    }

    [WebMethod]
    public string setEnviaEmailRegistro(string receptor, string asunto, string contenido)
    {
        string[] arrContenido = contenido.Split('|');

        string BODY = string.Format(@"<!DOCTYPE html>
                                    <html lang='es'>
                                        <head>
                                            <meta charset='utf-8'>
                                            <title>Opportunity</title>
                                        </head>
                                        <body>
                                            <table style='max-width: 600px; padding: 10px; margin:0 auto; border-collapse: collapse;'>
                                                <tr>
                                                    <td style='padding: 0;'>
                                                        <img style='padding: 0; display:block;' src='encabezado.png'>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style='background-color: #f6f6f6; color: #000000;  font-size: 18px; font-family: Century Gothic, CenturyGothic, AppleGothic, sans-serif; padding: 10px 20px 40px 20px; text-align: center;'>
                                                        <p style='color: #000000; text-align: left;'>Hola</p>
                                                        <p style='text-align: left'><span>Se ha concluido el proceso de registro de una nueva solicitud</span><br><span>de crédito:</span></p>
                                                        <ul style='text-align: left'>
                                                            <li>Nombre: {0}</li>
                                                            <li>Convenio: {1}</li>
                                                            <li>Fecha de Entrega: {2}</li>
                                                            <li>Monto Solicitado: ${3}</li>
                                                        </ul>
                                                        <p style='padding-bottom: 20px;'><span>Favor de revisar la documentación enviada.</span><br></p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style='background-color: #000000; max-width: 600px;'>
                                                        <p style='color:white; text-align: center; margin: 15px 0px; font-size: 15px; font-family: Century Gothic, CenturyGothic, AppleGothic, sans-serif;'>Opportunity Tu Solución</p>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style='height: 20px; max-width: 600px;'>
                                                    </td>
                                                </tr>
                                            </table>
                                        </body>
                                    </html>", arrContenido[0], arrContenido[1], arrContenido[2], arrContenido[3]);

        return setEnvia(receptor, asunto, BODY);
    }
    
}

