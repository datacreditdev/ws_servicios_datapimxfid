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
public class Service : System.Web.Services.WebService
{
    Parameters oP = new Parameters();
    Engine oE = new Engine();
    public string cdgEmpresa;

    public Service () {
        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
        cdgEmpresa = ConfigurationManager.AppSettings.Get("Empresa");
    }

    #region Ocupa flex

    //METODO ENCARGADO DE CARGAR LOS REGISTROS DE TABLA DE AMORTIZACION
    [WebMethod]
    public string setCargaTablaAmort(string codigo, string ciclo, int[] noPago, string[] fecIni, string[] fecFin, string[] fecha, 
                                     decimal[] importe, decimal[] capital, decimal[] interes, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        int iRes = 0;

        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_CARGA_ARCHIVO.SP_CARGA_TABLA_AMORT", CommandType.StoredProcedure,
                oP.ParamsCargaArchivoTablaAmort(empresa, codigo, ciclo, noPago, fecIni, fecFin, fecha, importe, capital, interes, usuario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return "0 " + mensaje;
        }
    }

    //EXTRAE LA INFORMACION DE LOS GRUPOS QUE CUMPLEN LAS CONDICIONES PARA SER MARCADOS CON FONDEO
    [WebMethod]
    public string setIniciaFondeo(int tipo, string orgFond, string lineaCred, string disp, decimal importe, decimal montoMax,
                                  string fecIni, string fecFin, string sexo, string region, string coord, string entFed,
                                  string munic, string localidad, string usuario, string fecSaldo)
    {
        DataSet dref = new DataSet();
        string empresa = cdgEmpresa;
        string status = string.Empty;
        int iRes = 0;

        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPINFOFONDEOTMP", CommandType.StoredProcedure,
              oP.ParamsInfoFondeo(empresa, tipo, orgFond, lineaCred, disp, importe, montoMax, fecIni, fecFin, sexo, 
                                  region, coord, entFed, munic, localidad, usuario, fecSaldo));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return status;
        }
    }

    //EXTRAE EL CODIGO DEL NUEVO CICLO QUE GENERA LA SOLICITUD
    [WebMethod]
    public string getCicloSolic(string codigo, string tipo)
    {
        string empresa = cdgEmpresa;
        string ciclo = string.Empty;

        int iRes = oE.myExecuteNonQuery(ref ciclo, "SP_GEN_NUEVO_CICLO", CommandType.StoredProcedure,
               oP.ParamsNvoCiclo(empresa, codigo, tipo));

        return ciclo;
    }

    //METODO QUE CONSULTA LA SITUACION DE LAS SOLICITUDES GRUPO/ACREDITADO
    [WebMethod]
    public string getValidaSituacionSolic(string cdgclns, string clns)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_VAL_SITUACION_SOLIC", CommandType.StoredProcedure,
            oP.ParamsSituacionSolic(empresa, cdgclns, clns));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE VALIDA QUE LOS CHEQUES INDICADOS ESTEN REGISTRADOS EN UNA CHEQUERA
    [WebMethod]
    public string getValidaRangoCheques(string coord, string cuenta, string chqFin)
    {
        int iRes;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        DataSet dref = new DataSet();
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_VAL_RANGO_CHEQUES", CommandType.StoredProcedure,
            oP.ParamsValidaRangoCheques(empresa, coord, cuenta, chqFin));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE VALIDA QUE EL ACREDITADO NO SE ENCUENTRE EN UNA SOLICITUD O PRESTAMO VIGENTE
    [WebMethod]
    public string getValidaSituacionAcred(string acred, string usuario)
    {
        int iRes;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        DataSet dref = new DataSet();
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_VAL_SITUACION_ACRED", CommandType.StoredProcedure,
            oP.ParamsValidaSituacionAcred(empresa, acred, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE VALIDA LAS CONDICIONES INICIALES DEL PRESTAMO PARA PERMITIR LA ENTREGA DEL MISMO
    [WebMethod]
    public string getValidaSituacionCredito(string cdgclns, string ciclo, string clns)
    {
        int iRes;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        DataSet dref = new DataSet();
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_VAL_SITUACION_CREDITO", CommandType.StoredProcedure,
            oP.ParamsValidaSituacionCredito(empresa, cdgclns, ciclo, clns));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    [WebMethod]
    public string setAccionAcred(int tipo, string usuario, string grupo, string codigo, string coord, string nombre, 
                string segNombre, string aPaterno, string aMaterno, string sexo, string fecha, string paisNac, string entFedNac, string nac, 
                string rfc, string curp, string ife, string fiel, string calle, string noInt, string noExt, string entreCalles, string telefono, 
                string codPostal, string pais, string entFed, string nomEntFed, string munic, string nomMunic, string localidad, string nomLocalidad, 
                string colonia, string nomColonia, string edoCivil/*, string nivelEsc, int depend, int marca, int enano, decimal cantEnano*/, 
                string asesor, string recuperador, string calleNeg, string noIntNeg, string noExtNeg, string entreCallesNeg, string telefonoNeg, 
                string paisNeg, string entFedNeg, string municNeg, string localidadNeg, string coloniaNeg, string tipoPers, string[] repLegal, string giro, 
                string origen, string destino, string otroDesRec, string pep, string[] propReal, string[] provRec, string figura, string nomCom, string telefono2, 
                string email1, string email2, string contacto1, string telCon1, string emailCon1, string contacto2, string telCon2, string emailCon2, 
                string finalidad, string instFiduc, string patFid, string aport, string actVul, string[] fideicomit, string[] fideicomis, 
                string[] delegado, string[] apodLegal, string[] secOrgGob, string[] nomOrgGob, string[] fecNacOrgGob, string[] tipoComOrgGob)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        int commit = 1;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_ACRED.SP_MTTO_ACRED", CommandType.StoredProcedure,
            oP.ParamsAccionAcred(tipo, empresa, usuario, grupo, codigo, coord, nombre, segNombre, aPaterno, aMaterno, sexo, Convert.ToDateTime(fecha), 
                                paisNac, entFedNac, nac, rfc, curp, ife, fiel, calle, noInt, noExt, entreCalles, telefono, codPostal, pais, entFed, nomEntFed, munic, 
                                nomMunic, localidad, nomLocalidad, colonia, nomColonia, edoCivil/*, nivelEsc, depend, marca, enano, cantEnano*/, asesor, 
                                recuperador, calleNeg, noIntNeg, noExtNeg, entreCallesNeg, telefonoNeg, paisNeg, entFedNeg, municNeg, localidadNeg, coloniaNeg, tipoPers, repLegal, 
                                giro, origen, destino, otroDesRec, pep, propReal, provRec, figura, nomCom, telefono2, email1, email2, contacto1, telCon1, emailCon1, contacto2, 
                                telCon2, emailCon2, finalidad, instFiduc, patFid, aport, actVul, fideicomit, fideicomis, delegado, apodLegal, secOrgGob, nomOrgGob, 
                                fecNacOrgGob, tipoComOrgGob, commit));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS DISPOSICIONES DE FONDEO
    [WebMethod]
    public string setAccionActividad(int tipo, string sector, string giro, string codigo, string nombre, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_ACTIVIDAD", CommandType.StoredProcedure,
                                          oP.ParamsAccionActividad(empresa, sector, giro, codigo, nombre, usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LA BITACORA DE OPERACION
    [WebMethod]
    public string setAccionBitacoraOp(string grupo, string ciclo, string coord, string actividad, string usuario, string acred)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        string status = string.Empty;
        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_REG_BITACORA_OP", CommandType.StoredProcedure,
                       oP.ParamsAccionBitacoraOp(empresa, grupo, ciclo, coord, actividad, usuario, acred));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REALIZAR EL BLOQUEO DE LA SOLICITUD 
    [WebMethod]
    public string setBloqueaAcred(string codigo, string accion, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;

        string status = string.Empty;
        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_BLOQUEA_ACRED", CommandType.StoredProcedure,
                      oP.ParamsBloqueaAcred(empresa, codigo, accion, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REALIZAR EL BLOQUEO DE LA SOLICITUD 
    [WebMethod]
    public string setBloqueaSolic(string codigo, string ciclo, string clns, string accion, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;

        string status = string.Empty;
        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_BLOQUEA_SOLIC", CommandType.StoredProcedure,
                      oP.ParamsBloqueaSolic(empresa, codigo, ciclo, clns, accion, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE CANCELAR LOS CHEQUES INDICADOS
    [WebMethod]
    public string setAccionCancCheque(int tipo, string coord, string cuenta, string[] grupo, string[] ciclo,
                                      string[] clns, string[] acred, string[] cheque, string[] chequera, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_CON_ARRAY.SP_CANC_CHEQUE", CommandType.StoredProcedure,
            oP.ParamsAccionCancCheque(tipo, empresa, coord, cuenta, grupo, ciclo, clns, acred, cheque, chequera, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REALIZAR Y REGISTRAR LAS CONSULTAS DE CLIENTES A CIRCULO DE CREDITO
    [WebMethod]
    public string setAccionCDC(string acred)
    {
        string sql = string.Empty;
        string cadConsulta = string.Empty;
        string cadResp = string.Empty;
        string empresa = cdgEmpresa;
        string query = string.Empty;
        DataSet dref = new DataSet();
        DataSet dinfo = new DataSet();
        DataSet ds = new DataSet();

        string status = string.Empty;
        try
        {
            query = "SELECT * " +
                    "FROM CONSULTA_BURO " +
                    "WHERE CDGEM = '" + empresa + "' " +
                    "AND CDGCL = '" + acred + "' " +
                    "AND FVIGENCIA > TO_CHAR(SYSDATE, 'DD/MM/YYYY')";

            int iRes = oE.ExecuteDS(ref dinfo, query, CommandType.Text);

            if (dinfo.Tables[0].Rows.Count > 0)
                return "1";
            else
            {
                query = "SELECT CL.PRIMAPE, " +
                              "CL.SEGAPE, " +
                              "CL.NOMBRE1, " +
                              "CL.NOMBRE2, " +
                              "CL.NACIMIENTO, " +
                              "CL.RFC, " +
                              "CL.CURP, " +
                              "(SELECT BC FROM PAI WHERE CODIGO = CL.NACIONALIDAD) AS NACIONALIDAD, " +
                              "DECODE(CL.EDOCIVIL,'D','D','C','M','S','S','V','W','U','F') AS EDOCIVIL, " +
                              "CL.SEXO, " +
                              "CL.IFE, " +
                              "CL.NODEPEND, " +
                              "CL.CALLE, " +
                              "CL.TELEFONO, " +
                              "CL.CDGEF, " +
                              "CL.CDGMU, " +
                              "CL.CDGLO, " +
                              "CL.CDGCOL, " +
                              "(SELECT EF.NOMBRE FROM EF WHERE EF.CODIGO = CL.CDGEF) AS ENTFED, " +
                              "(SELECT EF.BC FROM EF WHERE EF.CODIGO = CL.CDGEF) AS ENTFEDBC, " +
                              "(SELECT MU.NOMBRE FROM MU WHERE MU.CDGEF = CL.CDGEF AND MU.CODIGO = CL.CDGMU ) AS MUNIC, " +
                              "(SELECT LO.NOMBRE FROM LO WHERE LO.CDGEF = CL.CDGEF AND LO.CDGMU = CL.CDGMU AND LO.CODIGO = CL.CDGLO) AS LOC, " +
                              "(SELECT COL.NOMBRE FROM COL WHERE COL.CDGEF = CL.CDGEF AND COL.CDGMU = CL.CDGMU AND COL.CDGLO = CL.CDGLO AND COL.CODIGO = CL.CDGCOL) AS COL, " +
                              "(SELECT COL.CDGPOSTAL FROM COL WHERE COL.CDGEF = CL.CDGEF AND COL.CDGMU = CL.CDGMU AND COL.CDGLO = CL.CDGLO AND COL.CODIGO = CL.CDGCOL) AS CDGPOSTAL, " +
                    //"SC.CANTSOLIC " +
                              "0 AS CANTSOLIC " +
                              "FROM CL " + //", SC " +
                              "WHERE CL.CDGEM = '" + empresa + "' " +
                              "AND CL.CODIGO = '" + acred + "'";
                //"AND SC.CDGEM = CL.CDGEM " +
                //"AND SC.CDGCL = CL.CODIGO";
                //"AND SC.SITUACION = 'S'";

                iRes = oE.ExecuteDS(ref dref, query, CommandType.Text);
                if (dref.Tables[0].Rows.Count > 0)
                {
                    formatoCirculo cdc = new formatoCirculo();
                    cadConsulta = cdc.generaConsulta(dref);
                    //ConexionBuro.Service cb = new ConexionBuro.Service();
                    //cadResp = cb.consultar(cadConsulta);
                    ds = cdc.interpretaRespuesta(cadResp);
                }
                if (ds != null)
                {
                    /*iRes = oE.myExecuteNonQuery(ref status, "SPALTACONSULTABURO", CommandType.StoredProcedure,
                                                oP.ParamsAltaConsulta(empresa, acred));
                    if (status.Substring(0, 1) != "1")
                        return status;

                    DataTable dtNombre = ds.Tables["dtNombre"];
                    status = setAccionSegNombre(dtNombre, acred);
                    if (status == "" || status.Substring(0, 1) != "1")
                        return status;

                    DataTable dtDir = ds.Tables["dtDireccion"];
                    if (dtDir.Rows.Count > 0)
                    {
                        status = setAccionSegDireccion(dtDir, acred);
                        if (status == "" || status.Substring(0, 1) != "1")
                            return status;
                    }

                    DataTable dtCta = ds.Tables["dtCuenta"];
                    if (dtCta.Rows.Count > 0)
                    {
                        status = setAccionSegCuenta(dtCta, acred);
                        if (status == "" || status.Substring(0, 1) != "1")
                            return status;
                    }

                    /*DataTable dtRes = ds.Tables["dtResumen"];
                    status = setAccionSegResumen(dtRes, acred);
                    if (status == "" || status.Substring(0, 1) != "1")
                        return status;*/

                    /*DataTable dtCons = ds.Tables["dtConsulta"];
                    if (dtCons.Rows.Count > 0)
                    {
                        status = setAccionSegConsulta(dtCons, acred);
                        if (status == "" || status.Substring(0, 1) != "1")
                            return status;
                    }*/
                }
            }
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR O MIDIFICAR UNA CHEQUERA
    [WebMethod]
    public string setAccionChequera(int tipo, string coord, string cuenta, string chequera, string fecha, string chqIni,
                                    string chqFin, string estatus, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa; 
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_CHEQUERA", CommandType.StoredProcedure,
            oP.ParamsAccionChequera(tipo, empresa, coord, cuenta, chequera, fecha, chqIni, chqFin, estatus, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LA INFORMACION DE LOS CICLOS PERTENECIENTES A UN PRODUCTO DE CREDITO
    [WebMethod]
    public string setAccionCiclo(int tipo, string tipoProd, string prod, string ciclo, int plazo,
                                 decimal montoMax, decimal tasa, string cumpMonto)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_CICLO", CommandType.StoredProcedure,
            oP.ParamsAccionCiclo(tipo, empresa, tipoProd, prod, ciclo, plazo, montoMax, tasa, cumpMonto));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS COLONIAS 
    [WebMethod]
    public string setAccionCol(int tipo, string entFed, string munic, string localidad, string codigo, 
                               string colonia, string codPostal, string pobreza)
    {
        string sql = string.Empty;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_COLONIA", CommandType.StoredProcedure,
            oP.ParamsAccionCol(tipo, entFed, munic, localidad ,codigo, colonia, codPostal, pobreza));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS SUCURSALES 
    [WebMethod]
    public string setAccionCoord(int tipo, string codReg, string codigo, string coord, string gerente, string calle,
                                 string entFed, string munic, string localidad, string colonia, string telefono,
                                 string iva)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa; 
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_SUCURSAL", CommandType.StoredProcedure,
            oP.ParamsAccionCoord(tipo, empresa, codReg, codigo, coord, gerente, calle, entFed, munic, localidad,
                               colonia, telefono, iva));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LOS CREDITOS REVOLVENTES
    [WebMethod]
    public string setAccionCredRevolvente(int tipo, string acred, string autorizado, string inicio, string fin, decimal monto,
                                          string fecLim, string autoriza)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_CRED_REVOLVENTE", CommandType.StoredProcedure,
            oP.ParamsAccionCredRevolvente(tipo, empresa, acred, autorizado, inicio, fin, monto, fecLim, autoriza));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS DISPOSICIONES DE FONDEO
    [WebMethod]
    public string setAccionCuentaBancaria(int tipo, string instBanc, string sucBanc, string codigo, string numero, string tipoCta, 
                                          string cuentaAsoc, string nombre, string titular, string favor, decimal saldo, string moneda, 
                                          string tipoMov, string activa, string clabe, string swift, string edoCta, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_CTA_BANCARIA", CommandType.StoredProcedure,
                                          oP.ParamsAccionCuentaBancaria(empresa, instBanc, sucBanc, codigo, numero, tipoCta, 
                                                                        cuentaAsoc, nombre, titular, favor, saldo, moneda, tipoMov, 
                                                                        activa, clabe, swift, edoCta, usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LA DISPERSION DEL CREDITO
    [WebMethod]
    public string setAccionDispersion(int tipo, string codigo, string ciclo, string acred, string tipoCred, string metodo, string banco,
                                      string cuenta, string concepto, decimal monto, string fecha, string motivo, string reportado, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_DISPERSION", CommandType.StoredProcedure,
                                          oP.ParamsAccionDispersion(tipo, empresa, codigo, ciclo, acred, tipoCred, metodo, banco,
                                                                    cuenta, concepto, monto, fecha, motivo, reportado, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS DISPOSICIONES DE FONDEO
    [WebMethod]
    public string setAccionDisposicion(int tipo, string orgFond, string lineaCred, string codigo, string contrato, string descripcion, 
                                       string fecDisp, decimal cantidad, int plazo, string pagoCap, string pagoInt, 
                                       int graciaCap, int graciaInt, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_DISPOSICION", CommandType.StoredProcedure,
                                          oP.ParamsAccionDisposicion(empresa, orgFond, lineaCred, codigo, contrato, descripcion, 
                                                                     fecDisp, cantidad, plazo, pagoCap, pagoInt, graciaCap,
                                                                     graciaInt, usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR LAS ORGANIZACIONES FONDEADORAS
    [WebMethod]
    public string setAccionFideicomiso(int tipo, string codigo, string numero, string fecha, string[] secParte, 
                                       string[] nomParte, string[] figParte, string fines, string[] secMiemCM, 
                                       string[] miemCM, string presCM, string secCM, string[] secMiemCT, 
                                       string[] miemCT, string presCT, string secCT, string[] secDF,
                                       string[] nomDF, string[] cargoDF, string[] telDF, string[] emailDF, 
                                       string usuario)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "PKG_FONDEO.SPACCIONFIDEICOMISO", CommandType.StoredProcedure,
                                            oP.ParamsAccionFideicomiso(empresa, codigo, numero, fecha, secParte, nomParte,
                                                                       figParte, fines, secMiemCM, miemCM, presCM, secCM, 
                                                                       secMiemCT, miemCT, presCT, secCT, secDF, nomDF, cargoDF,
                                                                       telDF, emailDF, usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    [WebMethod]
    public string setAccionGarantia(int tipo, string cdgclns, string clns, string sec, string tipoGtia, string articulo, decimal valorNominal, decimal valorContable,
                                    string tipoProp, string descripcion, string factura, string activa, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPACCIONGARANTIA", CommandType.StoredProcedure,
            oP.ParamsAccionGarantia(tipo, empresa, cdgclns, clns, sec, tipoGtia, articulo, valorNominal, valorContable, tipoProp,
                                    descripcion, factura, activa, usuario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS DISPOSICIONES DE FONDEO
    [WebMethod]
    public string setAccionGiro(int tipo, string sector, string codigo, string nombre, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_GIRO", CommandType.StoredProcedure,
                                          oP.ParamsAccionGiro(empresa, sector, codigo, nombre, usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    [WebMethod]
    public string setAccionGrupo(int tipo, string codigo, string nombre, string fecha, string coord, string codPostal,
                                     string entidad, string munic, string localidad, string colonia,
                                     string calle, string domMun, string domLoc, string domCol, string promotor, string recup)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPACCIONGRUPO", CommandType.StoredProcedure,
            oP.ParamsAccionGrupo(tipo, empresa, codigo, nombre, Convert.ToDateTime(fecha), coord, codPostal, 
                                 entidad, munic, localidad, colonia, promotor, recup));
                                
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR LINEAS DE CREDITO
    [WebMethod]
    public string setAccionLineaCred(int tipo, string orgFond, string codigo, string contrato, string descripcion, 
                                     string otorgada, string instrumento, decimal cantidad, int plazo, decimal montoMax, 
                                     int periodoRep, string pagoCap, string pagoInt, int graciaCap, int graciaInt,
                                     string tipoCred, string tipoRec, string recursos, string usuario)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_LINEA_CRED", CommandType.StoredProcedure,
                                            oP.ParamsAccionLineaCred(empresa, orgFond, codigo, contrato, descripcion, otorgada, 
                                                                     instrumento, cantidad, plazo, montoMax, periodoRep, pagoCap, 
                                                                     pagoInt, graciaCap, graciaInt, tipoCred, tipoRec, recursos, 
                                                                     usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS LOCALIDADES
    [WebMethod]
    public string setAccionLoc(int tipo, string entFed, string munic, string codigo, string localidad, string cdgTel,
                               string tipoLoc)
    {
        string sql = string.Empty;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_LOCALIDAD", CommandType.StoredProcedure,
            oP.ParamsAccionLoc(tipo, entFed, munic, codigo, localidad, cdgTel, tipoLoc));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR PRODUCTOS DE CREDITO
    [WebMethod]
    public string setAccionProd(int tipo, string tipoProdCred, string codigo, string nombre, string moneda, string tipoCred, string valido,
                                decimal montoMinimo, decimal montoMaximo, string baseCalc, string periodicidad, int multPerio, int diaEsp, 
                                int pagoCapital, int pagoInteres, int duracion, string fijaPer, string fijaMultPer, string fijaPGC, string fijaPGI, 
                                string fijaPlazo, /*string perPagoCap, string fijaPagoCap, string perCapital, int multPerCap,*/ string metodoCobro, 
                                string formaDist, string instrumento, decimal interes, string fijaMCI, string fijaFDI, string fijaTas, string tasaFija, 
                                string factorTasa, string aplican, string metodoAplic, string fijaMAP, string fijaRec, string formaEntre, 
                                string fijaEnt, string[] tipoMov, decimal[] montoCom, decimal[] porcCom, string[] tipoCargo, string[] opcional, 
                                int[] orden, string[] artefacto)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_CATALOGOS.SPACCIONPROD", CommandType.StoredProcedure,
            oP.ParamsAccionProd(tipo, empresa, tipoProdCred, codigo, nombre, moneda, tipoCred, valido, montoMinimo,
                                montoMaximo, baseCalc, periodicidad, multPerio, diaEsp,  pagoCapital, pagoInteres, 
                                duracion, fijaPer, fijaMultPer, fijaPGC, fijaPGI, fijaPlazo,/* perPagoCap, fijaPagoCap, 
                                perCapital, multPerCap,*/ metodoCobro, formaDist, instrumento, interes, fijaMCI, fijaFDI, 
                                fijaTas, tasaFija, factorTasa, aplican, metodoAplic, fijaMAP, fijaRec, formaEntre, fijaEnt, 
                                tipoMov, montoCom, porcCom, tipoCargo, opcional, orden, artefacto));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LOS PROYECTOS DE INVERSION
    [WebMethod]
    public string setAccionProy(string tipoProy, string acred, string codigo, string nombre, string fecha, string texto, string giro,
                                    string sector, string actEco, string tipo, string grupo, string nomEmp, string rfc, string tamano)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_PROYECTO", CommandType.StoredProcedure,
            oP.ParamsAccionProy(empresa, tipoProy, acred, codigo, nombre, Convert.ToDateTime(fecha), texto, giro, sector, 
                                actEco, tipo, grupo, nomEmp, rfc, tamano));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE UTILIZAR EL PROCESO MASIVO DE ENTREGA DE CREDITOS
    [WebMethod]
    public string setAccionEntPrnMas(string[] grupo, string[] ciclo, string usuario)
    {
        string empresa = cdgEmpresa;

        int i;
        int iRes = 0;
        string status = string.Empty;
        string res = string.Empty;
        try
        {
            for (i = 0; i < grupo.Length; i++)
            {
                iRes = oE.myExecuteNonQuery(ref status, "SP_ENT_PRESTAMO_MAS", CommandType.StoredProcedure,
                      oP.ParamsAccionEntPrnMas(empresa, grupo[i], ciclo[i], usuario));
                res += status + "|";
            }
            return "1" + res;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LA ETAPA DE EVALUACION
    [WebMethod]
    public string setAccionEvSolic(string cdgclns, string cdgns, string cdgcl, string ciclo, string periodicidad, decimal cantSolic, decimal cantAutor, string diaJunta,
                                   int desfasePago, decimal tasa, decimal cat, int plazo, decimal pagoCapital, decimal pagoInteres, string instCred,
                                   string factorTasa, string metodoAplic, string metodoCobro, string distInt, string clns, string situacion, string aplican,
                                   string entrega, string solicitud, string tipoProd, string prodCred, string moneda, string contrato, string presidente,
                                   string tesorero, string secretario, string usuario, string formaEntrega, string nombreCheq, int multPerio, int diaEsp, string sucursal,
                                   string promotor, string tasaFija, string[] acred, decimal[] montos, string[] proyInv, string[] situacionAcred, string[] rechazo, 
                                   decimal[] cantAutorAcred, string calle, string entFed, string munic, string localidad, string colonia,
                                   string horario, string reunion, string autorCrr, string secuencia, string aval, string naturaleza, string credRel/*, string[] excepcion, string observacion, string[] excAcred, string[] lstAcred,
                                   string[] obsAcred*/)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_CON_ARRAY.SP_EV_SOLICITUD", CommandType.StoredProcedure,
            oP.ParamsAccionEvSolic(empresa, cdgclns, cdgns, cdgcl, ciclo, periodicidad, cantSolic, cantAutor, diaJunta, desfasePago, tasa,
                                   cat, plazo, pagoCapital, pagoInteres, instCred, factorTasa, metodoAplic, metodoCobro, distInt,
                                   clns, situacion, aplican, entrega, solicitud, tipoProd, prodCred, moneda, contrato, presidente,
                                   tesorero, secretario, usuario, formaEntrega, nombreCheq, multPerio, diaEsp, sucursal, promotor, tasaFija, "I",
                                   "N", acred, montos, proyInv, situacionAcred, rechazo, cantAutorAcred, calle, entFed, munic, 
                                   localidad, colonia, horario, reunion, autorCrr, secuencia, aval, naturaleza, credRel/*, excepcion, observacion, excAcred, lstAcred, obsAcred*/));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LOS CHEQUES A IMPRIMIR
    [WebMethod]
    public string setAccionImpCheque(string cdgclns, string grupo, string cdgAcred, string ciclo, string clns, string[] acred, string[] cheque, string fecha, 
                                     string usuario, string cuenta)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_CON_ARRAY.SP_INS_CHEQUES_CTE", CommandType.StoredProcedure,
            oP.ParamsAccionOrdenPago(empresa, cdgclns, grupo, cdgAcred, ciclo, clns, acred, cheque, fecha, usuario, cuenta, "", ""));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LOS CHEQUES A IMPRIMIR
    [WebMethod]
    public string setAccionImpChequeDisp(string cdgclns, string grupo, string cdgAcred, string ciclo, string clns, string[] acred, string[] cheque, string fecha,
                                         string usuario, string cuenta, string autorizado, string secuencia)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_CON_ARRAY.SP_INS_CHEQUES_CTE", CommandType.StoredProcedure,
            oP.ParamsAccionOrdenPago(empresa, cdgclns, grupo, cdgAcred, ciclo, clns, acred, cheque, fecha, usuario, cuenta, autorizado, secuencia));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR INFORMACION DEL INSTRUMENTO DE CREDITO
    [WebMethod]
    public string setAccionInst(int tipo, string codigo, string descripcion, string tipoInst)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_INST_CRED", CommandType.StoredProcedure,
                                            oP.ParamsAccionInst(tipo, empresa, codigo, descripcion, tipoInst));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR INFORMACION DE LA INSTITUCION BANCARIA
    [WebMethod]
    public string setAccionInstBancaria(int tipo, string codigo, string nombre)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_INST_BANCARIA", CommandType.StoredProcedure,
                                            oP.ParamsAccionInstBancaria(tipo, empresa, codigo, nombre));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE MODIFICAR LA MESA DIRECTIVA DEL GRUPO
    [WebMethod]
    public string setAccionModMesaDir(string grupo, string ciclo, string presidente, string tesorero, string secretario, string usuario)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MOD_MESA_DIR", CommandType.StoredProcedure,
                                            oP.ParamsAccionModMesaDir(empresa, grupo, ciclo, presidente, tesorero, secretario, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }
    
    //METODO QUE PERMITE MODIFICAR LOS PARAMETROS DEL PRESTAMO
    [WebMethod]
    public string setAccionModPrn(int tipo, string cdgclns, string ciclo, string clns, string fecha, string usuario)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            //TIPO = 1 SIGNIFICA QUE SE VA A REALIZAR LA DESAUTORIZACION DEL PRESTAMO (TESORERIA -> AUT. POR CARTERA)
            //TIPO = 2 SIGNIFICA QUE SE VA A REALIZAR LA MODIFICACION DE LA FECHA DE DESEMBOLSO
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MOD_CREDITO", CommandType.StoredProcedure,
                                            oP.ParamsAccionModPrn(empresa, cdgclns, ciclo, clns, fecha, tipo, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE MODIFICAR LA MESA DIRECTIVA DEL GRUPO
    [WebMethod]
    public string setAccionModTasaInt(string codigo, string ciclo, string clns, decimal tasa, string usuario)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MOD_TASA_INT", CommandType.StoredProcedure,
                                            oP.ParamsAccionModTasaInt(empresa, codigo, ciclo, clns, tasa, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS ORDENES DE PAGO POR ACREDITADO
    [WebMethod]
    public string setAccionOrdenPago(string cdgclns, string grupo, string cdgAcred, string ciclo, string clns, string[] acred, string [] chqAcred, string fecha, string usuario, string cuenta)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_CON_ARRAY.SP_INS_CHEQUES_CTE", CommandType.StoredProcedure,
                                            oP.ParamsAccionOrdenPago(empresa, cdgclns, grupo, cdgAcred, ciclo, clns, acred, chqAcred, fecha, usuario, cuenta, "",""));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR LAS ORGANIZACIONES FONDEADORAS
    [WebMethod]
    public string setAccionOrgFond(int tipo, string codigo, string nombre, string segNombre, string aPaterno,
                                   string aMaterno, string calle, string entFed, string munic, 
                                   string localidad, string colonia, string telefono, string usuario)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_ORG_FOND", CommandType.StoredProcedure,
                                            oP.ParamsAccionOrgFond(empresa, codigo, nombre, segNombre, aPaterno,
								                                   aMaterno, calle, entFed, munic, localidad, 
								                                   colonia, telefono, usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LOS PARAMETROS OPERATIVOS DEL SISTEMA
    [WebMethod]
    public string setAccionParamsOperativos(decimal montoMax, decimal tipoCambio, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_PARAMS_OPER", CommandType.StoredProcedure,
            oP.ParamsAccionParamsOper(empresa, montoMax, tipoCambio, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LA INFORMACION DE PERSONA
    [WebMethod]
    public string setAccionPersona(int tipo, string usuario, string codigo, string nombre,
                string segNombre, string aPaterno, string aMaterno, string figura, string nomCom, string sexo, string fecha, string nacPais, 
                string nacEntFed, string nac, string rfc, string curp, string ife, string fiel, string edoCivil, string email1, string email2, 
                string telefono, string telefono2, string calle, string noExt, string noInt, string entreCalles, string pais, string codPostal,
                string dirEntFed, string munic, string localidad, string colonia, string calleNeg, string noIntNeg, string noExtNeg, 
                string entreCallesNeg, string paisNeg, string entFedNeg, string municNeg, string localidadNeg, string coloniaNeg, string tipoPers, 
                string[] repLegal, string giro, string origen, string destino, string otroDesRec, string pep, string[] propReal, string[] provRec,
                string puesto, string puestoDesc, string periodo, string puestoFam, string nomFam, string parentescoFam, string puestoDescFam,
                string periodoFam)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        int commit = 1;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_PERSONA.SPACCIONPERSONA", CommandType.StoredProcedure,
            oP.ParamsAccionPersona(tipo, empresa, usuario, codigo, nombre, segNombre, aPaterno, aMaterno, figura, nomCom, 
                                   sexo, fecha, nacPais, nacEntFed, nac, rfc, curp, ife, fiel, edoCivil, email1, email2, telefono,
                                   telefono2, calle, noExt, noInt, entreCalles, pais, dirEntFed, munic, localidad, colonia, calleNeg, 
                                   noExtNeg, noIntNeg, entreCallesNeg, paisNeg, entFedNeg, municNeg, localidadNeg, coloniaNeg, 
                                   tipoPers, repLegal, giro, origen, destino, otroDesRec, pep, propReal, provRec, puesto, puestoDesc, 
                                   periodo, puestoFam, nomFam, parentescoFam, puestoDescFam, periodoFam, commit));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LOS DATOS DEL PRESTAMO
    [WebMethod]
    public string setAccionPrn(int tipo, string usuario, string cdgclns, string grupo, string cdgAcred, string ciclo, string clns, 
                               decimal cantEntre, decimal cantDevol, string situacion, string entrega, string solicitud, string[] acred, 
                               decimal[] cantEntreAcred, string[] situacionAcred, string autorizado, string sec)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_CON_ARRAY.SP_ENT_PRESTAMO", CommandType.StoredProcedure,
            oP.ParamsAccionPrn(tipo, usuario, empresa, cdgclns, grupo, cdgAcred, ciclo, clns, cantEntre, cantDevol, situacion, entrega, solicitud, 
                               acred, cantEntreAcred, situacionAcred, autorizado, sec));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LOS DATOS DE LA REGION
    [WebMethod]
    public string setAccionReg(int tipo, string codigo, string regional, string gerente, string calle,
							   string entFed, string munic, string localidad, string colonia,
							   string telefono)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_REGION", CommandType.StoredProcedure,
            oP.ParamsAccionReg(tipo, empresa, codigo, regional, gerente, calle, entFed, munic, localidad, 
                               colonia, telefono));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    public string setAccionSegConsulta(DataTable dt, string acred)
    {
        string fecConsulta = string.Empty;
        string idBuro = string.Empty;
        string cveOtorga = string.Empty;
        string nomOtorga = string.Empty;
        string telOtorga = string.Empty;
        string tipoContrato = string.Empty;
        string cveMoneda = string.Empty;
        string strImporte = string.Empty;
        string tipoRespons = string.Empty;
        string consNuevo = string.Empty;
        string resFinal = string.Empty;
        
        decimal importe;

        string empresa = cdgEmpresa;

        int i = 0;
        int iRes = 0;
        string status = string.Empty;
        try
        {
            for (i = 0; i < dt.Rows.Count; i++)
            {
                fecConsulta = dt.Rows[i]["FECREGCONS"].ToString();
                idBuro = dt.Rows[i]["IDBURO"].ToString();
                cveOtorga = dt.Rows[i]["CVEOTORGA"].ToString();
                nomOtorga = dt.Rows[i]["NOMOTORGA"].ToString();
                telOtorga = dt.Rows[i]["TELOTORGA"].ToString();
                tipoContrato = dt.Rows[i]["TIPOCONTRATO"].ToString();
                cveMoneda = dt.Rows[i]["CVEMONEDA"].ToString();
                strImporte = dt.Rows[i]["IMPORTE"].ToString();
                importe = strImporte != "" ? Convert.ToDecimal(strImporte) : 0;
                tipoRespons = dt.Rows[i]["TIPORESPONS"].ToString();
                consNuevo = dt.Rows[i]["CONSNUEVO"].ToString();
                resFinal = dt.Rows[i]["RESFINAL"].ToString();
                
                iRes = oE.myExecuteNonQuery(ref status, "SPALTASEGCONSULTA", CommandType.StoredProcedure,
                                              oP.ParamsAltaSegConsulta(empresa, acred, fecConsulta, idBuro, cveOtorga, nomOtorga, telOtorga,
                                                                       tipoContrato, cveMoneda, importe, tipoRespons, consNuevo, resFinal));
            }
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    public string setAccionSegCuenta(DataTable dt, string acred)
    {
        string fecActualiza = string.Empty;
        string regImp = string.Empty;
        string cveOtorga = string.Empty;
        string nomOtorga = string.Empty;
        string idSIC = string.Empty;
        string cuenta = string.Empty;
        string tipoRespons = string.Empty;
        string tipoCuenta = string.Empty;
        string tipoContrato = string.Empty;
        string cveMoneda = string.Empty;
        string strValorActivo = string.Empty;
        string strNumPagos = string.Empty;
        string frecPagos = string.Empty;
        string strMontoPagar = string.Empty;
        string fecCuenta = string.Empty;
        string fecUltPago = string.Empty;
        string fecUltCompra = string.Empty;
        string fecCierreCta = string.Empty;
        string fecRep = string.Empty;
        string modoRep = string.Empty;
        string fecCtaCero = string.Empty;
        string garantia = string.Empty;
        string strCredMax = string.Empty;
        string strSaldoAct = string.Empty;
        string strLimCred = string.Empty;
        string strSaldoVenc = string.Empty;
        string strPagosVenc = string.Empty;
        string formaPago = string.Empty;   //MOP
        string histPago = string.Empty;
        string fecRecHistPago = string.Empty;
        string fecAntHistPago = string.Empty;
        string cveObs = string.Empty;
        string strTotalPagos = string.Empty;
        string strTotalPagosMOP02 = string.Empty;
        string strTotalPagosMOP03 = string.Empty;
        string strTotalPagosMOP04 = string.Empty;
        string strTotalPagosMOP05 = string.Empty;
        string strImpSaldoMora = string.Empty;
        string fecSaldoMora = string.Empty;
        string MOPHistorico = string.Empty;
        string fecRestruc = string.Empty;
        string anio1 = string.Empty;
        string anio2 = string.Empty;
        string anio3 = string.Empty;
        string mes1 = string.Empty;
        string mes2 = string.Empty;
        string mes3 = string.Empty;
        string segMes1 = string.Empty;
        string segMes2 = string.Empty;
        string segMes3 = string.Empty;

        int numPagos;
        int pagosVenc;
        int totalPagos;
        int totalPagosMOP02;
        int totalPagosMOP03;
        int totalPagosMOP04;
        int totalPagosMOP05;

        decimal valorActivo;
        decimal montoPagar;
        decimal credMax;
        decimal saldoAct;
        decimal limCred;
        decimal saldoVenc;
        
        decimal impSaldoMora;

        string empresa = cdgEmpresa;

        int i = 0;
        int iRes = 0;
        string status = string.Empty;
        try
        {
            for (i = 0; i < dt.Rows.Count; i++)
            {
                fecActualiza = dt.Rows[i]["FECACTUALIZA"].ToString();
                regImp = dt.Rows[i]["REGIMP"].ToString();
                cveOtorga = dt.Rows[i]["CVEOTORGA"].ToString();
                nomOtorga = dt.Rows[i]["NOMOTORGA"].ToString();
                idSIC = dt.Rows[i]["IDSIC"].ToString();
                cuenta = dt.Rows[i]["CUENTA"].ToString();
                tipoRespons = dt.Rows[i]["TIPORESPONS"].ToString();
                tipoCuenta = dt.Rows[i]["TIPOCUENTA"].ToString();
                tipoContrato = dt.Rows[i]["TIPOCONTRATO"].ToString();
                cveMoneda = dt.Rows[i]["CVEMONEDA"].ToString();
                strValorActivo = dt.Rows[i]["VALORACTIVO"].ToString();
                valorActivo = strValorActivo != "" ? Convert.ToDecimal(strValorActivo) : 0;
                strNumPagos = dt.Rows[i]["NUMPAGOS"].ToString();
                numPagos = strNumPagos != "" ? Convert.ToInt32(strNumPagos) : 0;
                frecPagos = dt.Rows[i]["FRECPAGOS"].ToString();
                strMontoPagar = dt.Rows[i]["MONTOPAGAR"].ToString();
                montoPagar = strMontoPagar != "" ? Convert.ToDecimal(strMontoPagar) : 0;
                fecCuenta = convFormatoFecha(dt.Rows[i]["FECCUENTA"].ToString());
                fecUltPago = convFormatoFecha(dt.Rows[i]["FECULTPAGO"].ToString());
                fecUltCompra = convFormatoFecha(dt.Rows[i]["FECULTCOMPRA"].ToString());
                fecCierreCta = convFormatoFecha(dt.Rows[i]["FECCIERRECTA"].ToString());
                fecRep = convFormatoFecha(dt.Rows[i]["FECREP"].ToString());
                modoRep = dt.Rows[i]["MODOREP"].ToString();
                fecCtaCero = convFormatoFecha(dt.Rows[i]["FECCTACERO"].ToString());
                garantia = dt.Rows[i]["GARANTIA"].ToString();
                strCredMax = dt.Rows[i]["CREDMAX"].ToString();
                credMax = strCredMax != "" ? Convert.ToDecimal(strCredMax) : 0;
                strSaldoAct = dt.Rows[i]["SALDOACT"].ToString();
                saldoAct = strSaldoAct != "" ? Convert.ToDecimal(strSaldoAct) : 0;
                strLimCred = dt.Rows[i]["LIMCRED"].ToString();
                limCred = strLimCred != "" ? Convert.ToDecimal(strLimCred) : 0;
                strSaldoVenc = dt.Rows[i]["SALDOVENC"].ToString();
                saldoVenc = strSaldoVenc != "" ? Convert.ToDecimal(strSaldoVenc) : 0;
                strPagosVenc = dt.Rows[i]["PAGOSVENC"].ToString();
                pagosVenc = strPagosVenc != "" ? Convert.ToInt32(strPagosVenc) : 0;
                formaPago = dt.Rows[i]["FORMAPAGO"].ToString();
                histPago = dt.Rows[i]["HISTPAGO"].ToString();
                fecRecHistPago = convFormatoFecha(dt.Rows[i]["FECRECHISTPAGO"].ToString());
                fecAntHistPago = convFormatoFecha(dt.Rows[i]["FECANTHISTPAGO"].ToString());
                cveObs = dt.Rows[i]["CVEOBS"].ToString();
                strTotalPagos = dt.Rows[i]["TOTALPAGOS"].ToString();
                totalPagos = strTotalPagos != "" ? Convert.ToInt32(strTotalPagos) : 0;
                strTotalPagosMOP02 = dt.Rows[i]["TOTALPAGOSMOP02"].ToString();
                totalPagosMOP02 = strTotalPagosMOP02 != "" ? Convert.ToInt32(strTotalPagosMOP02) : 0;
                strTotalPagosMOP03 = dt.Rows[i]["TOTALPAGOSMOP03"].ToString();
                totalPagosMOP03 = strTotalPagosMOP03 != "" ? Convert.ToInt32(strTotalPagosMOP03) : 0;
                strTotalPagosMOP04 = dt.Rows[i]["TOTALPAGOSMOP04"].ToString();
                totalPagosMOP04 = strTotalPagosMOP04 != "" ? Convert.ToInt32(strTotalPagosMOP04) : 0;
                strTotalPagosMOP05 = dt.Rows[i]["TOTALPAGOSMOP05"].ToString();
                totalPagosMOP05 = strTotalPagosMOP05 != "" ? Convert.ToInt32(strTotalPagosMOP05) : 0;
                strImpSaldoMora = dt.Rows[i]["IMPSALDOMORA"].ToString();
                impSaldoMora = strImpSaldoMora != "" ? Convert.ToDecimal(strImpSaldoMora) : 0;
                fecSaldoMora = convFormatoFecha(dt.Rows[i]["FECSALDOMORA"].ToString());
                MOPHistorico = dt.Rows[i]["MOPHISTORICO"].ToString();
                fecRestruc = convFormatoFecha(dt.Rows[i]["FECRESTRUC"].ToString());
                anio1 = dt.Rows[i]["ANIO1"].ToString();
                anio2 = dt.Rows[i]["ANIO2"].ToString();
                anio3 = dt.Rows[i]["ANIO3"].ToString();
                mes1 = dt.Rows[i]["MES1"].ToString();
                mes2 = dt.Rows[i]["MES2"].ToString();
                mes3 = dt.Rows[i]["MES3"].ToString();
                segMes1 = dt.Rows[i]["SEGMES1"].ToString();
                segMes2 = dt.Rows[i]["SEGMES2"].ToString();
                segMes3 = dt.Rows[i]["SEGMES3"].ToString();

                iRes = oE.myExecuteNonQuery(ref status, "SPALTASEGCUENTA", CommandType.StoredProcedure,
                                              oP.ParamsAltaSegCuenta(empresa, acred, fecActualiza, regImp, cveOtorga,
                                                                     nomOtorga, idSIC, cuenta, tipoRespons, tipoCuenta, tipoContrato, cveMoneda,
                                                                     valorActivo, numPagos, frecPagos, montoPagar, fecCuenta, fecUltPago, fecUltCompra, fecCierreCta, 
                                                                     fecRep, modoRep, fecCtaCero, garantia, credMax, saldoAct, limCred, saldoVenc, pagosVenc, formaPago, 
                                                                     histPago, fecRecHistPago, fecAntHistPago, cveObs, totalPagos, totalPagosMOP02, totalPagosMOP03, 
                                                                     totalPagosMOP04, totalPagosMOP05, impSaldoMora, fecSaldoMora, MOPHistorico, fecRestruc, anio1, 
                                                                     anio2, anio3, mes1, mes2, mes3, segMes1, segMes2, segMes3));
            }
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    public string setAccionSegDireccion(DataTable dt, string acred)
    {
        string dir1 = string.Empty;
        string dir2 = string.Empty;
        string colonia = string.Empty;
        string municipio = string.Empty;
        string ciudad = string.Empty;
        string estado = string.Empty;
        string codPostal = string.Empty;
        string fecResid = string.Empty;
        string telefono = string.Empty;
        string ext = string.Empty;
        string fax = string.Empty;
        string tipoDom = string.Empty;
        string indEspDom = string.Empty;
        string fecRepDir = string.Empty;

        string empresa = cdgEmpresa;

        int i = 0;
        int iRes = 0;
        string status = string.Empty;
        try
        {
            for (i = 0; i < dt.Rows.Count; i++)
            {
                dir1 = dt.Rows[i]["DIR1"].ToString();
                dir2 = dt.Rows[i]["DIR2"].ToString();
                colonia = dt.Rows[i]["COLONIA"].ToString();
                municipio = dt.Rows[i]["MUNICIPIO"].ToString();
                ciudad = dt.Rows[i]["CIUDAD"].ToString();
                estado = dt.Rows[i]["ESTADO"].ToString();
                codPostal = dt.Rows[i]["CODPOSTAL"].ToString();
                fecResid = convFormatoFecha(dt.Rows[i]["FECRESIDENCIA"].ToString());
                telefono = dt.Rows[i]["TELEFONO"].ToString();
                ext = dt.Rows[i]["EXTENSION"].ToString();
                fax = dt.Rows[i]["FAX"].ToString();
                tipoDom = dt.Rows[i]["TIPODOM"].ToString();
                indEspDom = dt.Rows[i]["INDESPDOM"].ToString();
                fecRepDir = convFormatoFecha(dt.Rows[i]["FECDOM"].ToString());

                iRes = oE.myExecuteNonQuery(ref status, "SPALTASEGDIRECCION", CommandType.StoredProcedure,
                                            oP.ParamsAltaSegDireccion(empresa, acred, dir1, dir2, colonia, municipio, ciudad,
                                                                      estado, codPostal, fecResid, telefono,
                                                                      ext, fax, tipoDom, indEspDom, fecRepDir));
            }
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    public string setAccionSegNombre(DataTable dt, string acred)
    {
        string primape = string.Empty;
        string segape = string.Empty;
        string opcape = string.Empty;
        string nombre1 = string.Empty;
        string nombre2 = string.Empty;
        string strFecNac = string.Empty;
        string rfc = string.Empty;
        string prefPers = string.Empty;
        string subfijo = string.Empty;
        string nac = string.Empty;
        string resid = string.Empty;
        string licencia = string.Empty;
        string edoCivil = string.Empty;
        string sexo = string.Empty;
        string cedula = string.Empty;
        string ife = string.Empty;
        string impOtroPai = string.Empty;
        string otroPai = string.Empty;
        string strDepend = string.Empty;
        string edadDepend = string.Empty;
        string fecNac = string.Empty;
        string fecInfoDepend = string.Empty;
        string fecDefunc = string.Empty;

        int depend;

        string empresa = cdgEmpresa;

        int iRes = 0;
        string status = string.Empty;
        try
        {
            primape = dt.Rows[0]["APATERNO"].ToString();
            segape = dt.Rows[0]["AMATERNO"].ToString();
            opcape = dt.Rows[0]["AOPCIONAL"].ToString();
            nombre1 = dt.Rows[0]["PNOMBRE"].ToString();
            nombre2 = dt.Rows[0]["SNOMBRE"].ToString();
            fecNac = convFormatoFecha(dt.Rows[0]["FECNAC"].ToString());
            rfc = dt.Rows[0]["RFC"].ToString();
            prefPers = dt.Rows[0]["PREFPERS"].ToString();
            subfijo = dt.Rows[0]["SUBFIJO"].ToString();
            nac = dt.Rows[0]["NAC"].ToString();
            resid = dt.Rows[0]["RESID"].ToString();
            licencia = dt.Rows[0]["LICENCIA"].ToString();
            edoCivil = dt.Rows[0]["EDOCIVIL"].ToString();
            sexo = dt.Rows[0]["SEXO"].ToString();
            cedula = dt.Rows[0]["CEDULA"].ToString();
            ife = dt.Rows[0]["IFE"].ToString();
            impOtroPai = dt.Rows[0]["IMPOTROPAIS"].ToString();
            otroPai = dt.Rows[0]["OTROPAIS"].ToString();
            strDepend = dt.Rows[0]["DEPEND"].ToString();
            depend = strDepend != "" ? Convert.ToInt32(strDepend) : 0;
            edadDepend = dt.Rows[0]["EDADDEPEND"].ToString();
            fecInfoDepend = convFormatoFecha(dt.Rows[0]["FECINFODEPEND"].ToString());
            fecDefunc = convFormatoFecha(dt.Rows[0]["FECDEFUNC"].ToString());
           
            iRes = oE.myExecuteNonQuery(ref status, "SPALTASEGNOMBRE", CommandType.StoredProcedure,
                                        oP.ParamsAltaSegNombre(empresa, acred, primape, segape, opcape, nombre1, nombre2, 
                                                               fecNac, rfc, prefPers, subfijo, nac,
                                                               resid, licencia, edoCivil, sexo, cedula, ife, impOtroPai,
                                                               otroPai, depend, edadDepend, fecInfoDepend, fecDefunc));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    public string setAccionSegResumen(DataTable dt, string acred)
    {
        string fecRegBuro = string.Empty;
        string strNumMOP07 = string.Empty;
        string strNumMOP06 = string.Empty;
        string strNumMOP05 = string.Empty;
        string strNumMOP04 = string.Empty;
        string strNumMOP03 = string.Empty;
        string strNumMOP02 = string.Empty;
        string strNumMOP01 = string.Empty;
        string strNumMOP00 = string.Empty;
        string strNumMOPUR = string.Empty;
        string strNumCtas = string.Empty;
        string strNumCtasFijos = string.Empty;
        string strNumCtasRev = string.Empty;
        string strNumCtasCer = string.Empty;
        string strNumCtasNeg = string.Empty;
        string strNumCtasMOP = string.Empty;
        string strNumCtasDisp = string.Empty;
        string strNumSolic = string.Empty;
        string indNvaDir = string.Empty;
        string msjAlerta = string.Empty;
        string indExistDec = string.Empty;
        string cveMoneda = string.Empty;
        string strTotCredMaxRev = string.Empty;
        string strTotLimCredRev = string.Empty;
        string strTotSdoActRev = string.Empty;
        string strTotSdoVencRev = string.Empty;
        string strTotPagosRev = string.Empty;
        string strPorcLimCredRev = string.Empty;
        string strTotCredMaxFijos = string.Empty;
        string strTotSdoActFijos = string.Empty;
        string strTotSdoVencFijos = string.Empty;
        string strImpTotPagFijos = string.Empty;
        string strNumMOP96 = string.Empty;
        string strNumMOP97 = string.Empty;
        string strNumMOP99 = string.Empty;
        string fecCtaAnt = string.Empty;
        string fecCtaRec = string.Empty;
        string strNumTotSolicRep = string.Empty;
        string fecRecRep = string.Empty;
        string strNumTotCtasCob = string.Empty;
        string fecCtaRecCob = string.Empty;
        string strNumTotSolicCob = string.Empty;
        string fecSolicCob = string.Empty;

        int numMOP07; 
        int numMOP06; 
        int numMOP05; 
        int numMOP04;                                        
        int numMOP03; 
        int numMOP02; 
        int numMOP01; 
        int numMOP00; 
        int numMOPUR;
        int numCtas;
        int numCtasFijos;
        int numCtasRev;
        int numCtasCer;
        int numCtasNeg;
        int numCtasMOP;
        int numCtasDisp;
        int numSolic;
        int porcLimCredRev;
        int numMOP96;
        int numMOP97;
        int numMOP99;
        int numTotSolicRep;
        int numTotCtasCob;
        int numTotSolicCob;

        decimal totCredMaxRev;
        decimal totLimCredRev;
        decimal totSdoActRev;
        decimal totSdoVencRev;
        decimal totPagosRev;
        decimal totCredMaxFijos;
        decimal totSdoActFijos;
        decimal totSdoVencFijos;
        decimal impTotPagFijos;

        string empresa = cdgEmpresa;

        int i = 0;
        int iRes = 0;
        string status = string.Empty;
        try
        {
            for (i = 0; i < dt.Rows.Count; i++)
            {
                fecRegBuro = convFormatoFecha(dt.Rows[i]["FECREGBURO"].ToString());
                strNumMOP07 = dt.Rows[i]["NUMMOP07"].ToString();
                numMOP07 = strNumMOP07 != "" ? Convert.ToInt32(strNumMOP07) : 0;
                strNumMOP06 = dt.Rows[i]["NUMMOP06"].ToString();
                numMOP06 = strNumMOP06 != "" ? Convert.ToInt32(strNumMOP06) : 0;
                strNumMOP05 = dt.Rows[i]["NUMMOP05"].ToString();
                numMOP05 = strNumMOP05 != "" ? Convert.ToInt32(strNumMOP05) : 0;
                strNumMOP04 = dt.Rows[i]["NUMMOP04"].ToString();
                numMOP04 = strNumMOP04 != "" ? Convert.ToInt32(strNumMOP04) : 0;
                strNumMOP03 = dt.Rows[i]["NUMMOP03"].ToString();
                numMOP03 = strNumMOP03 != "" ? Convert.ToInt32(strNumMOP03) : 0;
                strNumMOP02 = dt.Rows[i]["NUMMOP02"].ToString();
                numMOP02 = strNumMOP02 != "" ? Convert.ToInt32(strNumMOP02) : 0;
                strNumMOP01 = dt.Rows[i]["NUMMOP01"].ToString();
                numMOP01 = strNumMOP01 != "" ? Convert.ToInt32(strNumMOP01) : 0;
                strNumMOP00 = dt.Rows[i]["NUMMOP00"].ToString();
                numMOP00 = strNumMOP00 != "" ? Convert.ToInt32(strNumMOP00) : 0;
                strNumMOPUR = dt.Rows[i]["NUMMOPUR"].ToString();
                numMOPUR = strNumMOPUR != "" ? Convert.ToInt32(strNumMOPUR) : 0;
                strNumCtas = dt.Rows[i]["NUMCTAS"].ToString();
                numCtas = strNumCtas != "" ? Convert.ToInt32(strNumCtas) : 0;
                strNumCtasFijos = dt.Rows[i]["NUMCTASFIJOS"].ToString();
                numCtasFijos = strNumCtasFijos != "" ? Convert.ToInt32(strNumCtasFijos) : 0;
                strNumCtasRev = dt.Rows[i]["NUMCTASREV"].ToString();
                numCtasRev = strNumCtasRev != "" ? Convert.ToInt32(strNumCtasRev) : 0;
                strNumCtasCer = dt.Rows[i]["NUMCTASCER"].ToString();
                numCtasCer = strNumCtasCer != "" ? Convert.ToInt32(strNumCtasCer) : 0;
                strNumCtasNeg = dt.Rows[i]["NUMCTASNEG"].ToString();
                numCtasNeg = strNumCtasNeg != "" ? Convert.ToInt32(strNumCtasNeg) : 0;
                strNumCtasMOP = dt.Rows[i]["NUMCTASMOP"].ToString();
                numCtasMOP = strNumCtasMOP != "" ? Convert.ToInt32(strNumCtasMOP) : 0;
                strNumCtasDisp = dt.Rows[i]["NUMCTASDISP"].ToString();
                numCtasDisp = strNumCtasDisp != "" ? Convert.ToInt32(strNumCtasDisp) : 0;
                strNumSolic = dt.Rows[i]["NUMSOLIC"].ToString();
                numSolic = strNumSolic != "" ? Convert.ToInt32(strNumSolic) : 0;
                indNvaDir = dt.Rows[i]["INDNVADIR"].ToString();
                msjAlerta = dt.Rows[i]["MENSAJE"].ToString();
                indExistDec = dt.Rows[i]["INDEXISTDEC"].ToString();
                cveMoneda = dt.Rows[i]["CVEMONEDA"].ToString();
                strTotCredMaxRev = dt.Rows[i]["TOTCREDMAXREV"].ToString();
                totCredMaxRev = strTotCredMaxRev != "" ? Convert.ToDecimal(strTotCredMaxRev) : 0;
                strTotLimCredRev = dt.Rows[i]["TOTLIMCREDREV"].ToString();
                totLimCredRev = strTotLimCredRev != "" ? Convert.ToDecimal(strTotLimCredRev) : 0;
                strTotSdoActRev = dt.Rows[i]["TOTSDOACTREV"].ToString();
                totSdoActRev = strTotSdoActRev != "" ? Convert.ToDecimal(strTotSdoActRev) : 0;
                strTotSdoVencRev = dt.Rows[i]["TOTSDOVENCREV"].ToString();
                totSdoVencRev = strTotSdoVencRev != "" ? Convert.ToDecimal(strTotSdoVencRev) : 0;
                strTotPagosRev = dt.Rows[i]["TOTPAGREV"].ToString();
                totPagosRev = strTotPagosRev != "" ? Convert.ToDecimal(strTotPagosRev) : 0;
                strPorcLimCredRev = dt.Rows[i]["PORCLIMCREDREV"].ToString();
                porcLimCredRev = strPorcLimCredRev != "" ? Convert.ToInt32(strPorcLimCredRev) : 0;
                strTotCredMaxFijos = dt.Rows[i]["TOTCREDMAXFIJOS"].ToString();
                totCredMaxFijos = strTotCredMaxFijos != "" ? Convert.ToDecimal(strTotCredMaxFijos) : 0;
                strTotSdoActFijos = dt.Rows[i]["TOTSDOACTFIJOS"].ToString();
                totSdoActFijos = strTotSdoActFijos != "" ? Convert.ToDecimal(strTotSdoActFijos) : 0;
                strTotSdoVencFijos = dt.Rows[i]["TOTSDOVENCFIJOS"].ToString();
                totSdoVencFijos = strTotSdoVencFijos != "" ? Convert.ToDecimal(strTotSdoVencFijos) : 0;
                strImpTotPagFijos = dt.Rows[i]["IMPTOTPAGFIJOS"].ToString();
                impTotPagFijos = strImpTotPagFijos != "" ? Convert.ToDecimal(strImpTotPagFijos) : 0;
                strNumMOP96 = dt.Rows[i]["NUMMOP96"].ToString();
                numMOP96 = strNumMOP96 != "" ? Convert.ToInt32(strNumMOP96) : 0;
                strNumMOP97 = dt.Rows[i]["NUMMOP97"].ToString();
                numMOP97 = strNumMOP97 != "" ? Convert.ToInt32(strNumMOP97) : 0;
                strNumMOP99 = dt.Rows[i]["NUMMOP99"].ToString();
                numMOP99 = strNumMOP99 != "" ? Convert.ToInt32(strNumMOP99) : 0;
                fecCtaAnt = convFormatoFecha(dt.Rows[i]["FECCTAANT"].ToString());
                fecCtaRec = convFormatoFecha(dt.Rows[i]["FECCTAREC"].ToString());
                strNumTotSolicRep = dt.Rows[i]["NUMTOTSOLICREP"].ToString();
                numTotSolicRep = strNumTotSolicRep != "" ? Convert.ToInt32(strNumTotSolicRep) : 0;
                fecRecRep = convFormatoFecha(dt.Rows[i]["FECRECREP"].ToString());
                strNumTotCtasCob = dt.Rows[i]["NUMTOTCTASCOB"].ToString();
                numTotCtasCob = strNumTotCtasCob != "" ? Convert.ToInt32(strNumTotCtasCob) : 0;
                fecCtaRecCob = convFormatoFecha(dt.Rows[i]["FECCTARECCOB"].ToString());
                strNumTotSolicCob = dt.Rows[i]["NUMTOTSOLICCOB"].ToString();
                numTotSolicCob = strNumTotSolicCob != "" ? Convert.ToInt32(strNumTotSolicCob) : 0;
                fecSolicCob = convFormatoFecha(dt.Rows[i]["FECSOLICCOB"].ToString());

                iRes = oE.myExecuteNonQuery(ref status, "SPALTASEGRESUMEN", CommandType.StoredProcedure,
                                              oP.ParamsAltaSegResumen(empresa, acred, fecRegBuro, numMOP07, numMOP06, numMOP05, numMOP04,
                                                                      numMOP03, numMOP02, numMOP01, numMOP00, numMOPUR,
                                                                      numCtas, numCtasFijos, numCtasRev, numCtasCer, numCtasNeg, 
                                                                      numCtasMOP, numCtasDisp, numSolic, indNvaDir, msjAlerta,
                                                                      indExistDec, cveMoneda, totCredMaxRev, totLimCredRev,
                                                                      totSdoActRev, totSdoVencRev, totPagosRev, porcLimCredRev,
                                                                      totCredMaxFijos, totSdoActFijos, totSdoVencFijos, impTotPagFijos,
                                                                      numMOP96, numMOP97, numMOP99, fecCtaAnt, fecCtaRec, numTotSolicRep,
                                                                      fecRecRep, numTotCtasCob, fecCtaRecCob, numTotSolicCob, fecSolicCob));
            }
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LAS DISPOSICIONES DE FONDEO
    [WebMethod]
    public string setAccionSector(int tipo, string codigo, string nombre, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_SECTOR", CommandType.StoredProcedure,
                                          oP.ParamsAccionSector(empresa, codigo, nombre, usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LOS DATOS DE LA SOLICITUD
    [WebMethod]
    public string setAccionSolic(int tipo, string cdgclns, string cdgNs, string ciclo, string periodicidad, decimal cantSolic, decimal cantAutor, string diaJunta, 
                                int desfasePago, decimal tasa, decimal cat, int plazo, decimal pagoCapital, decimal pagoInteres, string instCred, 
                                string factorTasa, string metodoAplic, string metodoCobro, string distInt, string clns, string situacion, string aplican,
                                string entrega, string solicitud, string tipoProd, string prodCred, string moneda, string contrato, string presidente,
                                string tesorero,  string secretario, string usuario, string formaEntrega, string nombreCheq, string cdgCb, 
                                string tipoDes, int multPerio, int diaEsp, string sucursal, string promotor, string tasaFija, string[] acred, decimal[] montos, 
                                string[] proyInv, int[] emplGenH, int[] emplGenM, int[] emplSostH, int[] emplSostM, string calle, string entFed, string munic, 
                                string localidad, string colonia, string horario, string reunion, string autorCrr, string secuencia, string aval, string naturaleza,
                                string[] tipoMovCom, decimal[] montoCom, decimal[] porcCom, string[] tipoCargoCom, string[] opcCom, int[] ordenPrel, string[] artefactoPrel,
                                string credRel)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "PKG_SPS_CON_ARRAY.SP_INS_SOLICITUD", CommandType.StoredProcedure,
            oP.ParamsAccionSolic(tipo, empresa, cdgclns, cdgNs, ciclo, periodicidad, cantSolic, cantAutor, diaJunta, desfasePago, tasa,
                                cat, plazo, pagoCapital, pagoInteres, instCred, factorTasa, metodoAplic, metodoCobro, distInt,
                                clns, situacion, aplican, entrega, solicitud, tipoProd, prodCred, moneda, contrato, presidente, 
                                tesorero, secretario, usuario, formaEntrega, nombreCheq, cdgCb, tipoDes, multPerio, diaEsp,
                                sucursal, promotor, tasaFija, "I", "N", acred, montos, proyInv, emplGenH, emplGenM, 
                                emplSostH, emplSostM, calle, entFed, munic, localidad, colonia, horario, reunion, autorCrr, secuencia, aval,
                                naturaleza, tipoMovCom, montoCom, porcCom, tipoCargoCom, opcCom, ordenPrel, artefactoPrel, credRel));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR INFORMACION DE LA SUCURSAL BANCARIA
    [WebMethod]
    public string setAccionSucBancaria(int tipo, string instBanc, string codigo, string nombre, string gerente, string ejecutivo, string calle, 
									   string entFed, string munic, string localidad, string colonia, string telefono, string labora)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_SUC_BANCARIA", CommandType.StoredProcedure,
                                              oP.ParamsAccionSucBancaria(empresa, instBanc, codigo, nombre, gerente, ejecutivo, calle,
                                                                         entFed, munic, localidad, colonia, telefono, labora, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR SUPLEMENTOS DE FIDEICOMISO
    [WebMethod]
    public string setAccionSuplemento(int tipo, string fideicomiso, string codigo, string clave, string fecha, string alias,
                                      string[] cuentas, string[] secAcred, string[] acreditantes, string usuario)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "PKG_FONDEO.SPACCIONSUPLEMENTO", CommandType.StoredProcedure,
                                            oP.ParamsAccionSuplemento(empresa, fideicomiso, codigo, clave, fecha, alias, cuentas, 
                                                                      secAcred, acreditantes, usuario, tipo));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR INFORMACION DE TASA
    [WebMethod]
    public string setAccionTasa(int tipo, string instrumento, string valDesde, decimal tasa)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_TASA", CommandType.StoredProcedure,
                                            oP.ParamsAccionTasa(tipo, empresa, instrumento, valDesde, tasa));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR, MODIFICAR O ELIMINAR INFORMACION DEL TIPO DE PRODUCTO
    [WebMethod]
    public string setAccionTipoProd(int tipo, string codigo, string nombre)
    {
        string empresa = cdgEmpresa;
        string status = string.Empty;

        try
        {
            int iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_TIPO_PROD", CommandType.StoredProcedure,
                                            oP.ParamsAccionTipoProd(tipo, empresa, codigo, nombre));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //SERVICIO ENCARGADO DE AGREGAR ACREDITADOS EXISTENTES AL GRUPO
    [WebMethod]
    public string setAgregaAcred(string[] registro)
    {
        string sql = string.Empty;
        string status = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();
        int i;
        int iRes = 0;

        try
        {
            for (i = 0; i < registro.Length; i++)
            {
                string[] campo = registro[i].Split(',');
                iRes = oE.myExecuteNonQuery(ref status, "SP_MTTO_ACRED_GRUPO", CommandType.StoredProcedure,
                oP.ParamsAgregaAcred(empresa, campo[0], campo[1], Convert.ToDateTime(campo[2])));

                if (status.Substring(0, 1) == "0")
                    return status;

            }
            return status;
             
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //SERVICIO ENCARGADO DE ASIGNAR EL IMPORTE DE FONDEO  
    [WebMethod]
    public string setAsignaFondeo(string orgFond, string lineaCred, string disp, int tipo, string info, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        int iRes = 0;
        
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPASIGNAFONDEO", CommandType.StoredProcedure,
              oP.ParamsAsignaFondeo(empresa, orgFond, lineaCred, disp, tipo, info, usuario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return "0 " + mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LA DEVOLUCION DE GARANTIA DEL GRUPO INDICADO 
    [WebMethod]
    public string setDevGarantia(string grupo, int secPago, string fecha, decimal monto, string devolucion, string cuenta, 
                                 string cheque, string codAcred, string acred, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            string refer = "3" + grupo + "01I";
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_DEV_GARANTIA", CommandType.StoredProcedure,
            oP.ParamsDevGarantia(empresa, devolucion, grupo, "G", refer, secPago, fecha, monto, cuenta, cheque, codAcred, acred, usuario));
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //SERVICIO ENCARGADO DE ELIMINAR EL REGISTRO DE ACREDITADO
    [WebMethod]
    public string setEliminaAcred(string usuario, string grupo, string acred, string fecha)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        int iRes;

        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "spBajaClienteGrupo", CommandType.StoredProcedure,
              oP.ParamsElimAcred(empresa, Convert.ToDateTime(fecha), acred, grupo));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return "-1 " + mensaje;
        }
    }

    //SERVICIO ENCARGADO DE ELIMINAR EL REGISTRO DE GRUPO
    [WebMethod]
    public string setEliminaGrupo(string usuario, string grupo)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        int iRes;

        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPELIMINAGRUPO", CommandType.StoredProcedure,
             oP.ParamsElimGrupo(empresa, grupo));

            return status;

        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return "-1 " + mensaje;
        }
    }

    //SERVICIO ENCARGADO DE ELIMINAR EL REGISTRO DE PRODUCTO DE CREDITO DE UN TIPO DE PRODUCTO
    [WebMethod]
    public string setEliminaProd(string tipoProd, string prodCred)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        int iRes;

        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPELIMINAPRODCRED", CommandType.StoredProcedure,
            oP.ParamsElimProdCred(empresa, tipoProd, prodCred));

            return status;

        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return "-1 " + mensaje;
        }
    }

    //SERVICIO ENCARGADO DE ELIMINAR EL REGISTRO DE SOLICITUD
    [WebMethod]
    public string setEliminaSolic(string cdgclns, string ciclo, string clns, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        int iRes;

        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPELIMINASOLICITUD", CommandType.StoredProcedure,
            oP.ParamsElimSolic(empresa, cdgclns, ciclo, clns, usuario));

            return status;

        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return "-1 " + mensaje;
        }
    }

    //SERVICIO ENCARGADO DE ELIMINAR EL REGISTRO DE SOLICITUD
    [WebMethod]
    public string setEliminaSolicDisp(string cdgclns, string ciclo, string clns, string autorCrr, string secuencia, 
                                      string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        string status = string.Empty;
        int iRes;

        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPELIMINASOLICITUDDISP", CommandType.StoredProcedure,
            oP.ParamsElimSolicDisp(empresa, cdgclns, ciclo, clns, autorCrr, secuencia, usuario));

            return status;

        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return "-1 " + mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LA EMISION DE LOS DOCUMENTOS INDICADOS
    [WebMethod]
    public string setEmisionDocumentos(string codigo, string ciclo, string tipoCred, int anexo, int pago, int garantia, 
                                       int contrato, int pagare, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            //EJECUTA PROCEDURE PARA OBTENER LA INFORMACION DEL CONTRATO
            if (contrato == 1)
            {
                iRes = oE.myExecuteNonQuery(ref status, "SPIMPCONTRATO", CommandType.StoredProcedure,
                oP.ParamsImpContrato(empresa, codigo, ciclo, tipoCred, usuario));

                if (status.Substring(0, 1) == "0")
                {
                    return status;
                }
            }
            //EJECUTA PROCEDURE PARA OBTENER LA INFORMACION DE LOS PAGARES
            if (pagare == 1)
            {
                iRes = oE.myExecuteNonQuery(ref status, "SPIMPPAGARE", CommandType.StoredProcedure,
                oP.ParamsImpDocumento(empresa, codigo, ciclo, tipoCred, usuario));

                if (status.Substring(0, 1) == "0")
                {
                    return status;
                }
            }
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //METODO QUE PERMITE REGISTRAR LA EMISION DE LOS DOCUMENTOS INDICADOS
    [WebMethod]
    public string setEmisionDocumentosInd(string codigo, string ciclo, string tipoCred, int anexo, int pagos,
                                          int garantia, int contrato, int pagare, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            //EJECUTA PROCEDURE PARA OBTENER LA INFORMACION DE LOS ANEXOS
            if (anexo == 1)
            {
                status = "1";

                if (status.Substring(0, 1) == "0")
                {
                    return status;
                }
            }
            //EJECUTA PROCEDURE PARA OBTENER LA INFORMACION DE LA CARTA DE INSTRUCCION DE PAGO
            if (pagos == 1)
            {
                iRes = oE.myExecuteNonQuery(ref status, "SPIMPCARTAPAGOIND", CommandType.StoredProcedure,
                oP.ParamsImpDocumento(empresa, codigo, ciclo, tipoCred, usuario));

                if (status.Substring(0, 1) == "0")
                {
                    return status;
                }
            }
            //EJECUTA PROCEDURE PARA OBTENER LA INFORMACION DE LA CARTA DE GARANTIA
            if (garantia == 1)
            {
                iRes = oE.myExecuteNonQuery(ref status, "SPIMPGARANTIAIND", CommandType.StoredProcedure,
                oP.ParamsImpDocumento(empresa, codigo, ciclo, tipoCred, usuario));

                if (status.Substring(0, 1) == "0")
                {
                    return status;
                }
            }
            //EJECUTA PROCEDURE PARA OBTENER LA INFORMACION DEL CONTRATO
            if (contrato == 1)
            {
                iRes = oE.myExecuteNonQuery(ref status, "SPIMPCONTRATOIND", CommandType.StoredProcedure,
                oP.ParamsImpDocumento(empresa, codigo, ciclo, tipoCred, usuario));

                if (status.Substring(0, 1) == "0")
                {
                    return status;
                }
            }
            //EJECUTA PROCEDURE PARA OBTENER LA INFORMACION DE LOS PAGARES
            if (pagare == 1)
            {
                iRes = oE.myExecuteNonQuery(ref status, "SPIMPPAGAREIND", CommandType.StoredProcedure,
                oP.ParamsImpDocumento(empresa, codigo, ciclo, tipoCred, usuario));

                if (status.Substring(0, 1) == "0")
                {
                    return status;
                }
            }
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //SERVICIO ENCARGADO DE MODIFICAR EL ESTATUS DEL PAGO REGISTRADO
    [WebMethod]
    public int setModEstatus(string[] registro)
    {
        string empresa = cdgEmpresa;
        string sucursal = string.Empty;
        string grupo = string.Empty;
        string estatus = string.Empty;
        string observaciones;
        string fecha = string.Empty;
        string secuencia = string.Empty;
        string sql = string.Empty;

        Boolean band = false;
        decimal monto = 0;

        int i;
        int iRes = 0;
        int cont = registro.Length;
        try
        {
            for (i = 0; i < cont; i++)
            {
                observaciones = string.Empty;

                string[] campo = registro[i].Split(',');
                sucursal = campo[0];
                grupo = campo[1];
                fecha = formatoFecha(campo[2]);
                monto = Convert.ToDecimal(campo[3]);
                estatus = campo[4];
                observaciones = campo[5];
                secuencia = campo[6];

                sql = "UPDATE MP_SUC " +
                      "SET ESTATUS = '" + estatus + "', " +
                      "OBSERVACIONES = '" + observaciones + "' " +
                      "WHERE CDGEM = '" + empresa + "' " +
                      "AND CDGCO = '" + sucursal + "' " +
                      "AND CDGCLNS = '" + grupo + "' " +
                      "AND FDEPOSITO = TO_DATE('" + fecha + "','YYYY/MM/DD') " +
                      "AND CANTIDAD = " + monto + " " +
                      "AND SECUENCIA = " + secuencia;

                iRes = oE.myExecuteNonQuery(sql, CommandType.Text);

                if (iRes > 0)
                    band = true;
                else
                    return -1;
            }
            if (band)
                return 1;
            else
                return -1;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return -1;
        }
    }

    //SERVICIO ENCARGADO DE MODIFICAR EL HORARIO DE LA SOLICITUD
    [WebMethod]
    public string setModHorario(string grupo, string ciclo, int diaJunta, string horario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SPASIGNAHORARIO", CommandType.StoredProcedure,
            oP.ParamsModHorario(empresa, grupo, ciclo, diaJunta, horario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //SERVICIO ENCARGADO DE ALMACENAR LOS REGISTROS DE PAGO
    [WebMethod]
    public int setPagos(string [] registro)
    {
        string empresa = cdgEmpresa;
        string sucursal = string.Empty; 
        string grupo = string.Empty;
        string ciclo = string.Empty;
        string banco = string.Empty;
        string cuenta = string.Empty;
        string usuario = string.Empty;
        string tipoPago = string.Empty;

        DateTime fecha;
        Boolean band = false;
        decimal monto = 0;

        int i;
        int iRes;
        int cont = registro.Length;

        for (i = 0; i < cont; i++)
        {
            string[] campo = registro[i].Split(',');
            sucursal = campo[0];
            grupo = campo[1];
            ciclo = campo[2];
            fecha = Convert.ToDateTime(formatoFecha(campo[3]));
            monto = Convert.ToDecimal(campo[4]);
            banco = campo[5];
            cuenta = campo[6];
            usuario = campo[7];
            tipoPago = campo[8];

            iRes = oE.myExecuteNonQuery("spInsPagosSuc", CommandType.StoredProcedure, 
               oP.ParamsPagos(empresa, grupo, "G", cuenta, fecha, monto, usuario, sucursal, tipoPago));

            if (iRes == -1)
            {
                band = true;
            }

        }
        if (band)
            return 1;
        else
            return -1;
    }

    //SERVICIO ENCARGADO DE PROCESAR EL DICTAMEN DE LAS ALERTAS DE LAVADO
    [WebMethod]
    public string setProcesaAlerta(string alta, string sec, string tipo, string cdgFunc, string dictamen, string justifica, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_PROCESA_ALERTA", CommandType.StoredProcedure,
            oP.ParamsProcesaAlerta(empresa, alta, sec, tipo, cdgFunc, dictamen, justifica, usuario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    [WebMethod]
    public string setRegistroAjuste(string codigo, string ciclo, string clns, string fecha, decimal capital, decimal interes,
                                    decimal moratorios, string justifica, string observaciones, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_AJUSTE", CommandType.StoredProcedure,
            oP.ParamsRegistroAjuste(empresa, codigo, ciclo, clns, fecha, capital, interes, moratorios, justifica, observaciones, usuario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    [WebMethod]
    public string setRegistroDenuncia(string descripcion)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_OP_PREOCUPANTE", CommandType.StoredProcedure,
            oP.ParamsRegOpPreocupante(empresa, descripcion));
            //Invoca el metodo encargado de enviar correos electronicos
            //setEnviaEmail("", "oficialcumplimiento@credifinanciera.com", "Aviso de Denuncia", "El presente mensaje es una notificación de que ha sido registrada una Denuncia Anónima.");
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    [WebMethod]
    public string setRegistroDoc(string codigo, string repo, string archivo, string formato, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_DOC", CommandType.StoredProcedure,
                        oP.ParamsRegDoc(empresa, codigo, repo, archivo, formato, usuario));
            
            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //REGISTRA LOS AJUSTES DE COMISIONES Y SEGUROS
    [WebMethod]
    public string setRegAjusteComSeg(string codigo, string ciclo, string clns, string fecha, decimal comision, decimal seguro,
                                     string justifica, string observaciones, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_AJUSTE_COMSEG", CommandType.StoredProcedure,
            oP.ParamsRegAjusteComSeg(empresa, codigo, ciclo, clns, fecha, comision, seguro, justifica, observaciones, usuario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //REGISTRA LOS AJUSTES DE DEVENGO 
    [WebMethod]
    public string setRegAjusteDevengo(string codigo, string ciclo, string clns, string fecha, decimal interes, string usuario)
    {
        string sql = string.Empty;
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_AJUSTE_DEVENGO", CommandType.StoredProcedure,
              oP.ParamsRegAjusteDevengo(empresa, codigo, ciclo, clns, fecha, interes, usuario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    //REGISTRA LAS SOLICITUDES DE TRANSFERENCIA QUE SE REALIZAN AL AREA DE TESORERIA
    [WebMethod]
    public string setRegSolicTrans(string fecha, string usuario)
    {
        string empresa = cdgEmpresa;
        DataSet dref = new DataSet();

        int iRes = 0;
        string status = string.Empty;
        try
        {
            iRes = oE.myExecuteNonQuery(ref status, "SP_REG_SOLIC_TRANS", CommandType.StoredProcedure,
            oP.ParamsRegSolicTrans(empresa, fecha, usuario));

            return status;
        }
        catch (Exception ex)
        {
            string mensaje = ex.Message;
            return mensaje;
        }
    }

    /*
   [WebMethod]
   public string GeneraCAT(string ValorCat, int NoPagos, string Periodo)
   {
       // ValorCat es una cadena de este tipo
       // <ValorCat>-49000.00, 4695.87, 4695.87, 4695.87, 4695.87, 4695.87, 4695.87, 4695.87, 4695.87, 4695.87, 4695.87, 4695.87, 4695.91</ValorCat> 
       // <Periodo>Semanal</Periodo> <Periodo>Quincenal</Periodo> <Periodo>Mensual</Periodo> 

       int NoSemanas = 0;
       char[] sep = { ',' };
       string[] Array = ValorCat.Split(sep);
       double[] valueArray;
       valueArray = new double[NoPagos + 1];

       for (int i = 0; i < Array.Length; i++)
       {
           valueArray[i] = double.Parse(Array[i]);
       }
       if ((Periodo == "Semanal") || (Periodo == "semanas"))
           NoSemanas = 52;
       else if ((Periodo == "Quincenal") || (Periodo == "catorcenas"))
           NoSemanas = 26;
       else if ((Periodo == "Mensual") || (Periodo == "meses"))
           NoSemanas = 12;
       else if (Periodo == "trimestres")
           NoSemanas = 4;
       else if (Periodo == "semestres")
           NoSemanas = 2;

       double guess = 0.1;
       double CalcRetRate = (Financial.IRR(ref valueArray, guess)) * 100;
       string IRR = CalcRetRate.ToString("#0.000");
       double CAT = (Math.Pow(1 + (double.Parse(IRR) / 100), NoSemanas) - 1) * 100;
       return CAT.ToString("##0.0");
   }*/

    #endregion

    private string formatoFecha(string fecha)
    {
        try
        {
            string fecMod = Convert.ToDateTime(fecha.ToString()).ToString("dd/MM/yyyy");
            return fecMod;
        }
        catch (Exception e)
        {
            string error = e.Message;
            return error;
        }
    }

    private string convFormatoFecha(string fecha)
    {
        string fecMod = string.Empty;
        DateTime d;
        if(fecha != "")
            fecha = fecha.Substring(0,2) + "/" + fecha.Substring(2,2) + "/" + fecha.Substring(4,4);
            if(DateTime.TryParse(fecha, out d))
                fecMod = Convert.ToDateTime(fecha).ToString("dd/MM/yyyy");
        return fecMod;
    }
}
