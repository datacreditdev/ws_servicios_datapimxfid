using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Oracle.DataAccess.Client;

/// <summary>
/// Summary description for Parameters
/// </summary>
public class Parameters
{
    public Parameters()
    {
    }
    
    #region ORACLE_PARAMETERS

    public OracleParameter[] ParamsAccionAcred(int tipo, string empresa, string usuario, string grupo, string codigo, string coord, string nombre, 
                                               string segNombre, string aPaterno, string aMaterno, string sexo, DateTime fecha, string paisNac, 
                                               string entFedNac, string nac, string rfc, string curp, string ife, string fiel, string calle, string noInt, 
                                               string noExt, string entreCalles, string telefono, string codPostal, string pais, string entFed, string nomEntFed, 
                                               string munic, string nomMunic, string localidad, string nomLocalidad, string colonia, string nomColonia, string edoCivil/*, 
                                               string nivelEsc, int depend, int marca, int enano, decimal cantEnano*/, string asesor, string recuperador,
                                               string calleNeg, string noIntNeg, string noExtNeg, string entreCallesNeg, string telefonoNeg, string paisNeg, string entFedNeg, 
                                               string municNeg, string localidadNeg, string coloniaNeg, string tipoPers, string[] repLegal, string giro, string origen, 
                                               string destino, string otroDesRec, string pep, string[] propReal, string[] provRec, string figura, string nomCom, string telefono2, 
                                               string email1, string email2, string contacto1, string telCon1, string emailCon1, string contacto2, string telCon2, string emailCon2, 
                                               string finalidad, string instFiduc, string patFid, string aport, string actVul, string[] fideicomit, string[] fideicomis, 
                                               string[] delegado, string[] apodLegal, string[] secOrgGob, string[] nomOrgGob, string[] fecNacOrgGob, string[] tipoComOrgGob, int commit)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMBRE1", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMBRE2", OracleDbType.Varchar2),
                                               new OracleParameter("pPRIMAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pSEGAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pSEXO", OracleDbType.Varchar2),
                                               new OracleParameter("pNACIMIENTO", OracleDbType.Date),
                                               new OracleParameter("pNACIOPAI", OracleDbType.Varchar2),
                                               new OracleParameter("pNACIOEF", OracleDbType.Varchar2),
                                               new OracleParameter("pNACIONALIDAD", OracleDbType.Varchar2),
                                               new OracleParameter("pRFC", OracleDbType.Varchar2),
                                               new OracleParameter("pCURP", OracleDbType.Varchar2),
                                               new OracleParameter("pIFE", OracleDbType.Varchar2),
                                               new OracleParameter("pCALLE", OracleDbType.Varchar2),
                                               new OracleParameter("pNOINT", OracleDbType.Varchar2),
                                               new OracleParameter("pNOEXT", OracleDbType.Varchar2),
                                               new OracleParameter("pENTRECALLES", OracleDbType.Varchar2),
                                               new OracleParameter("pTELEFONO", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPOSTAL", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPAI", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMEF", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMMU", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMLO", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMCOL", OracleDbType.Varchar2),
                                               new OracleParameter("pCALLENEG", OracleDbType.Varchar2),
                                               new OracleParameter("pNOINTNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pNOEXTNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pENTRECALLESNEG", OracleDbType.Varchar2), 
                                               new OracleParameter("pTELEFONONEG", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPAINEG", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGEFNEG", OracleDbType.Varchar2), 
                                               new OracleParameter("pCDGMUNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGLONEG", OracleDbType.Varchar2), 
                                               new OracleParameter("pCDGCOLNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pEDOCIVIL", OracleDbType.Varchar2),
                                               /*new OracleParameter("pNIVESCOLAR", OracleDbType.Varchar2),
                                               new OracleParameter("pNODEPEND", OracleDbType.Int32),
                                               new OracleParameter("pMARCA", OracleDbType.Int32),
                                               new OracleParameter("pENANO", OracleDbType.Int32),               
                                               new OracleParameter("pCANTENANO", OracleDbType.Decimal),*/
                                               new OracleParameter("pCDGOCPE", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPRPE", OracleDbType.Varchar2), 
                                               new OracleParameter("pTIPOPERS", OracleDbType.Varchar2),
                                               new OracleParameter("pT_REPLEGAL", OracleDbType.Varchar2),
                                               new OracleParameter("pGIRO", OracleDbType.Varchar2),
                                               new OracleParameter("pORIREC", OracleDbType.Varchar2), 
                                               new OracleParameter("pDESTREC", OracleDbType.Varchar2),
                                               new OracleParameter("pOTRODESREC", OracleDbType.Varchar2),
                                               new OracleParameter("pPEP", OracleDbType.Varchar2), 
                                               new OracleParameter("pT_PROPREAL", OracleDbType.Varchar2),
                                               new OracleParameter("pT_PROVREC", OracleDbType.Varchar2), 
                                               new OracleParameter("pACTUALIZAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pACTUALIZACPE", OracleDbType.Varchar2),
                                               new OracleParameter("pACTUALIZARPE", OracleDbType.Varchar2),
                                               new OracleParameter("pFIGURA", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMCOM", OracleDbType.Varchar2),
                                               new OracleParameter("pFIEL", OracleDbType.Varchar2),
                                               new OracleParameter("pTELEFONO2", OracleDbType.Varchar2),
                                               new OracleParameter("pEMAIL1", OracleDbType.Varchar2),
                                               new OracleParameter("pEMAIL2", OracleDbType.Varchar2),
                                               new OracleParameter("pCONTACTO1", OracleDbType.Varchar2),
                                               new OracleParameter("pTELCON1", OracleDbType.Varchar2),
                                               new OracleParameter("pEMAILCON1", OracleDbType.Varchar2),
                                               new OracleParameter("pCONTACTO2", OracleDbType.Varchar2),
                                               new OracleParameter("pTELCON2", OracleDbType.Varchar2),
                                               new OracleParameter("pEMAILCON2", OracleDbType.Varchar2),
                                               new OracleParameter("pFINALIDAD", OracleDbType.Varchar2),
                                               new OracleParameter("pINSTFIDUC", OracleDbType.Varchar2),
                                               new OracleParameter("pPATFID", OracleDbType.Varchar2),
                                               new OracleParameter("pAPORT", OracleDbType.Varchar2),
                                               new OracleParameter("pACTVUL", OracleDbType.Varchar2),
                                               new OracleParameter("pT_FIDEICOMIT", OracleDbType.Varchar2),
                                               new OracleParameter("pT_FIDEICOMIS", OracleDbType.Varchar2), 
                                               new OracleParameter("pT_DELEGADO", OracleDbType.Varchar2),
                                               new OracleParameter("pT_APODLEGAL", OracleDbType.Varchar2),
                                               new OracleParameter("pT_SECORGGOB", OracleDbType.Varchar2),
                                               new OracleParameter("pT_NOMORGGOB", OracleDbType.Varchar2), 
                                               new OracleParameter("prmT_FECNACORGGOB", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_TIPOCOMORGGOB", OracleDbType.Varchar2),
                                               new OracleParameter("pOpera", OracleDbType.Int32),
                                               new OracleParameter("pCOMMIT", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[45].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[51].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[52].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[73].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[74].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[75].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[76].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[77].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[78].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[79].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[80].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = coord;
        OracleParameters[4].Value = nombre;
        OracleParameters[5].Value = segNombre;
        OracleParameters[6].Value = aPaterno;
        OracleParameters[7].Value = aMaterno;
        OracleParameters[8].Value = sexo;
        OracleParameters[9].Value = fecha;
        OracleParameters[10].Value = paisNac;
        OracleParameters[11].Value = entFedNac;
        OracleParameters[12].Value = nac;
        OracleParameters[13].Value = rfc;
        OracleParameters[14].Value = curp;
        OracleParameters[15].Value = ife;
        OracleParameters[16].Value = calle;
        OracleParameters[17].Value = noInt;
        OracleParameters[18].Value = noExt;
        OracleParameters[19].Value = entreCalles;
        OracleParameters[20].Value = telefono;
        OracleParameters[21].Value = codPostal;
        OracleParameters[22].Value = pais;
        OracleParameters[23].Value = entFed;
        OracleParameters[24].Value = nomEntFed;
        OracleParameters[25].Value = munic;
        OracleParameters[26].Value = nomMunic;
        OracleParameters[27].Value = localidad;
        OracleParameters[28].Value = nomLocalidad;
        OracleParameters[29].Value = colonia;
        OracleParameters[30].Value = nomColonia;
        OracleParameters[31].Value = calleNeg;
        OracleParameters[32].Value = noIntNeg;
        OracleParameters[33].Value = noExtNeg;
        OracleParameters[34].Value = entreCallesNeg;
        OracleParameters[35].Value = telefonoNeg;
        OracleParameters[36].Value = paisNeg;
        OracleParameters[37].Value = entFedNeg;
        OracleParameters[38].Value = municNeg;
        OracleParameters[39].Value = localidadNeg;
        OracleParameters[40].Value = coloniaNeg;
        OracleParameters[41].Value = edoCivil;
        /*OracleParameters[42].Value = nivelEsc;
        OracleParameters[43].Value = depend;
        OracleParameters[44].Value = marca;
        OracleParameters[45].Value = enano;
        OracleParameters[46].Value = cantEnano;*/
        OracleParameters[42].Value = asesor;
        OracleParameters[43].Value = recuperador;
        OracleParameters[44].Value = tipoPers;
        OracleParameters[45].Value = repLegal;
        OracleParameters[46].Value = giro;
        OracleParameters[47].Value = origen;
        OracleParameters[48].Value = destino;
        OracleParameters[49].Value = otroDesRec;
        OracleParameters[50].Value = pep;
        OracleParameters[51].Value = propReal;
        OracleParameters[52].Value = provRec;
        OracleParameters[53].Value = usuario;
        OracleParameters[54].Value = usuario;  
        OracleParameters[55].Value = usuario;
        OracleParameters[56].Value = figura;
        OracleParameters[57].Value = nomCom;
        OracleParameters[58].Value = fiel;
        OracleParameters[59].Value = telefono2;
        OracleParameters[60].Value = email1;
        OracleParameters[61].Value = email2;
        OracleParameters[62].Value = contacto1;
        OracleParameters[63].Value = telCon1;
        OracleParameters[64].Value = emailCon1;
        OracleParameters[65].Value = contacto2;
        OracleParameters[66].Value = telCon2;
        OracleParameters[67].Value = emailCon2;
        OracleParameters[68].Value = finalidad;
        OracleParameters[69].Value = instFiduc;
        OracleParameters[70].Value = patFid;
        OracleParameters[71].Value = aport;
        OracleParameters[72].Value = actVul;
        OracleParameters[73].Value = fideicomit;
        OracleParameters[74].Value = fideicomis;
        OracleParameters[75].Value = delegado;
        OracleParameters[76].Value = apodLegal;
        OracleParameters[77].Value = secOrgGob;
        OracleParameters[78].Value = nomOrgGob;
        OracleParameters[79].Value = fecNacOrgGob;
        OracleParameters[80].Value = tipoComOrgGob;
        OracleParameters[81].Value = tipo;
        OracleParameters[82].Value = commit;

        OracleParameters[83].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionActividad(string empresa, string sector, string giro, string codigo, string nombre, string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGSE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGGI", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = sector;
        OracleParameters[2].Value = giro;
        OracleParameters[3].Value = codigo;
        OracleParameters[4].Value = nombre;
        OracleParameters[5].Value = usuario;
        OracleParameters[6].Value = tipo;
        OracleParameters[7].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionAcuerdoAcred(int tipo, string empresa, string grupo, string ciclo, string clns, DateTime fecha, 
                                                      string acred, decimal monto, decimal pagoReal, string estatus, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmTIPOMOV", OracleDbType.Int32),
                                               new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmFMOVTO", OracleDbType.Date),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),         
                                               new OracleParameter("prmPARCIALIDAD", OracleDbType.Decimal),
                                               new OracleParameter("prmPAGOREAL", OracleDbType.Decimal),
                                               new OracleParameter("prmESTATUS", OracleDbType.Varchar2),
                                               new OracleParameter("prmUSUARIO", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = tipo;
        OracleParameters[1].Value = empresa;
        OracleParameters[2].Value = grupo;
        OracleParameters[3].Value = ciclo;
        OracleParameters[4].Value = clns;
        OracleParameters[5].Value = fecha;
        OracleParameters[6].Value = acred;
        OracleParameters[7].Value = monto;
        OracleParameters[8].Value = pagoReal;
        OracleParameters[9].Value = estatus;
        OracleParameters[10].Value = usuario;
        OracleParameters[11].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionAcuerdoGrupo(int tipo, string empresa, string grupo, string ciclo, string clns, DateTime fecha, decimal monto,
                                                      decimal pagoReal, string estatus, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmTIPOMOV", OracleDbType.Int32),
                                               new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmFMOVTO", OracleDbType.Date),
                                               new OracleParameter("prmPARCIALIDAD", OracleDbType.Decimal),
                                               new OracleParameter("prmPAGOREAL", OracleDbType.Decimal),
                                               new OracleParameter("prmESTATUS", OracleDbType.Varchar2),
                                               new OracleParameter("prmUSUARIO", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = tipo;
        OracleParameters[1].Value = empresa;
        OracleParameters[2].Value = grupo;
        OracleParameters[3].Value = ciclo;
        OracleParameters[4].Value = clns;
        OracleParameters[5].Value = fecha;
        OracleParameters[6].Value = monto;
        OracleParameters[7].Value = pagoReal;
        OracleParameters[8].Value = estatus;
        OracleParameters[9].Value = usuario;
        OracleParameters[10].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionBitacoraOp(string empresa, string grupo, string ciclo, string coord, string actividad, string usuario, string acred)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGACT", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200) };
        
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = coord;
        OracleParameters[4].Value = actividad;
        OracleParameters[5].Value = usuario;
        OracleParameters[6].Value = acred;
        OracleParameters[7].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionCancCheque(int tipo, string empresa, string coord, string cuenta, string[] grupo,
                                                    string[] ciclo, string[] clns, string[] acred, string[] cheque, string[] chequera,
                                                    string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CICLO", OracleDbType.Varchar2), 
                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_NOCHEQUE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmT_CHEQUERA", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[3].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[4].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[5].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[6].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[7].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[8].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = coord;
        OracleParameters[2].Value = cuenta;
        OracleParameters[3].Value = grupo;
        OracleParameters[4].Value = clns;
        OracleParameters[5].Value = ciclo;
        OracleParameters[6].Value = acred;
        OracleParameters[7].Value = cheque;
        OracleParameters[8].Value = chequera;
        OracleParameters[9].Value = usuario;
        OracleParameters[10].Value = tipo;
        OracleParameters[11].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionChequera(int tipo, string empresa, string coord, string cuenta, string chequera, 
                                                  string fecha, string chqIni, string chqFin, string estatus,
                                                  string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("pCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("pFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("pCHQINI", OracleDbType.Varchar2),
                                               new OracleParameter("pCHQFIN", OracleDbType.Varchar2),
                                               new OracleParameter("pESTATUS", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("pTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = coord;
        OracleParameters[2].Value = cuenta;
        OracleParameters[3].Value = chequera;
        OracleParameters[4].Value = fecha;
        OracleParameters[5].Value = chqIni;
        OracleParameters[6].Value = chqFin;
        OracleParameters[7].Value = estatus;
        OracleParameters[8].Value = usuario;
        OracleParameters[9].Value = tipo;
        OracleParameters[10].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionCiclo(int tipo, string empresa, string tipoProd, string prod, string ciclo,
                                               int plazo, decimal montoMax, decimal tasa, string cumpMonto)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGTPC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPRC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmPLAZO", OracleDbType.Int32),
                                               new OracleParameter("prmMONTOMAX", OracleDbType.Decimal),
                                               new OracleParameter("prmTASA", OracleDbType.Decimal),
                                               new OracleParameter("prmCUMPMONTO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = tipoProd;
        OracleParameters[2].Value = prod;
        OracleParameters[3].Value = ciclo;
        OracleParameters[4].Value = plazo;
        OracleParameters[5].Value = montoMax;
        OracleParameters[6].Value = tasa;
        OracleParameters[7].Value = cumpMonto;
        OracleParameters[8].Value = tipo;
        OracleParameters[9].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionCol(int tipo, string entFed, string munic, string localidad, string codigo, string colonia, string codPostal, string pobreza)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCOLONIA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPOSTAL", OracleDbType.Varchar2),
                                               new OracleParameter("prmPOBREZA", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = entFed;
        OracleParameters[1].Value = munic;
        OracleParameters[2].Value = localidad;
        OracleParameters[3].Value = codigo;
        OracleParameters[4].Value = colonia;
        OracleParameters[5].Value = codPostal;
        OracleParameters[6].Value = pobreza;
        OracleParameters[7].Value = tipo;
        OracleParameters[8].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    /*public OracleParameter[] ParamsAccionControl(int tipo, string empresa, string grupo, string ciclo, int semana,
                                                 decimal pagoTeoGpo, decimal pagoRealGpo, decimal aportGpo, decimal devGpo, 
                                                 decimal ahorroGpo, decimal moraGpo, string observacion, string[] acred, 
                                                 decimal[] pagoTeo, decimal[] pagoReal, decimal[] aport, decimal[] devolucion, 
                                                 decimal[] ahorro, string[] asist, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEMANA", OracleDbType.Int32),
                                               new OracleParameter("prmPAGOTEO", OracleDbType.Decimal),
                                               new OracleParameter("prmPAGOREAL", OracleDbType.Decimal),
                                               new OracleParameter("prmAPORT", OracleDbType.Decimal),
                                               new OracleParameter("prmDEVOLUCION", OracleDbType.Decimal),
                                               new OracleParameter("prmAHORRO", OracleDbType.Decimal),
                                               new OracleParameter("prmMORA", OracleDbType.Decimal),
                                               new OracleParameter("prmOBS", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_PAGOTEO", OracleDbType.Decimal),
                                               new OracleParameter("prmT_PAGOREAL", OracleDbType.Decimal),
                                               new OracleParameter("prmT_APORT", OracleDbType.Decimal),
                                               new OracleParameter("prmT_DEVOLUCION", OracleDbType.Decimal),
                                               new OracleParameter("prmT_AHORRO", OracleDbType.Decimal),
                                               new OracleParameter("prmT_ASIST", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32), 
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[11].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[12].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[13].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[14].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[15].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[16].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[17].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = semana;
        OracleParameters[4].Value = pagoTeoGpo;
        OracleParameters[5].Value = pagoRealGpo;
        OracleParameters[6].Value = aportGpo;
        OracleParameters[7].Value = devGpo;
        OracleParameters[8].Value = ahorroGpo;
        OracleParameters[9].Value = moraGpo;
        OracleParameters[10].Value = observacion;

        OracleParameters[11].Value = acred;
        OracleParameters[12].Value = pagoTeo;
        OracleParameters[13].Value = pagoReal;
        OracleParameters[14].Value = aport;
        OracleParameters[15].Value = devolucion;
        OracleParameters[16].Value = ahorro;
        OracleParameters[17].Value = asist;

        OracleParameters[18].Value = usuario;
        OracleParameters[19].Value = tipo;

        OracleParameters[20].Direction = ParameterDirection.Output;      

        return OracleParameters;
    }*/
    
    public OracleParameter[] ParamsAccionControl(int tipo, string empresa, string grupo, string ciclo, int semana,
                                                 decimal pagoTeoGpo, decimal pagoRealGpo, decimal aportGpo, decimal devGpo, 
                                                 decimal ahorroGpo, decimal multaGpo, decimal moraGpo, string observacion, string[] acred, 
                                                 decimal[] pagoTeo, decimal[] pagoReal, decimal[] aport, decimal[] devolucion, 
                                                 decimal[] ahorro, decimal[] multa, string[] asist, string fecha, string sec, 
                                                 string tipoReg, string fechaAnt, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEMANA", OracleDbType.Int32),
                                               new OracleParameter("prmPAGOTEO", OracleDbType.Decimal),
                                               new OracleParameter("prmPAGOREAL", OracleDbType.Decimal),
                                               new OracleParameter("prmAPORT", OracleDbType.Decimal),
                                               new OracleParameter("prmDEVOLUCION", OracleDbType.Decimal),
                                               new OracleParameter("prmAHORRO", OracleDbType.Decimal),
                                               new OracleParameter("prmMULTA", OracleDbType.Decimal),
                                               new OracleParameter("prmMORA", OracleDbType.Decimal),
                                               new OracleParameter("prmOBS", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_PAGOTEO", OracleDbType.Decimal),
                                               new OracleParameter("prmT_PAGOREAL", OracleDbType.Decimal),
                                               new OracleParameter("prmT_APORT", OracleDbType.Decimal),
                                               new OracleParameter("prmT_DEVOLUCION", OracleDbType.Decimal),
                                               new OracleParameter("prmT_AHORRO", OracleDbType.Decimal),
                                               new OracleParameter("prmT_MULTA", OracleDbType.Decimal),
                                               new OracleParameter("prmT_ASIST", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEC", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOREG", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECANT", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32), 
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[12].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[13].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[14].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[15].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[16].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[17].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[18].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[19].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = semana;
        OracleParameters[4].Value = pagoTeoGpo;
        OracleParameters[5].Value = pagoRealGpo;
        OracleParameters[6].Value = aportGpo;
        OracleParameters[7].Value = devGpo;
        OracleParameters[8].Value = ahorroGpo;
        OracleParameters[9].Value = multaGpo;
        OracleParameters[10].Value = moraGpo;
        OracleParameters[11].Value = observacion;

        OracleParameters[12].Value = acred;
        OracleParameters[13].Value = pagoTeo;
        OracleParameters[14].Value = pagoReal;
        OracleParameters[15].Value = aport;
        OracleParameters[16].Value = devolucion;
        OracleParameters[17].Value = ahorro;
        OracleParameters[18].Value = multa;
        OracleParameters[19].Value = asist;

        OracleParameters[20].Value = fecha;
        OracleParameters[21].Value = sec;
        OracleParameters[22].Value = tipoReg;
        OracleParameters[23].Value = fechaAnt;

        OracleParameters[24].Value = usuario;
        OracleParameters[25].Value = tipo;

        OracleParameters[26].Direction = ParameterDirection.Output;      

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionCoord(int tipo, string empresa, string codReg, string codigo, string coord, string gerente, string calle, 
                                               string entFed, string munic, string localidad, string colonia, string telefono, string iva)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGRG", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCOORD", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCALLE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("prmTELEFONO", OracleDbType.Varchar2),
                                               new OracleParameter("prmIVA", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codReg;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = coord;
        OracleParameters[4].Value = gerente;
        OracleParameters[5].Value = calle;
        OracleParameters[6].Value = entFed;
        OracleParameters[7].Value = munic;
        OracleParameters[8].Value = localidad;
        OracleParameters[9].Value = colonia;
        OracleParameters[10].Value = telefono;
        OracleParameters[11].Value = iva;
        OracleParameters[12].Value = tipo;
        OracleParameters[13].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionCredRevolvente(int tipo, string empresa, string acred, string autorizado, string inicio, string fin,
                                                        decimal monto, string fecLim, string autoriza)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmAUTORIZADO", OracleDbType.Varchar2),
                                               new OracleParameter("prmINICIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIN", OracleDbType.Varchar2),
                                               new OracleParameter("prmMONTO", OracleDbType.Decimal),
                                               new OracleParameter("prmFINPRC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = acred;
        OracleParameters[2].Value = autorizado;
        OracleParameters[3].Value = inicio;
        OracleParameters[4].Value = fin;
        OracleParameters[5].Value = monto;
        OracleParameters[6].Value = fecLim;
        OracleParameters[7].Value = autoriza;
        OracleParameters[8].Value = tipo;
        OracleParameters[9].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionCuentaBancaria(string empresa, string instBanc, string sucBanc, string codigo, string numero, string tipoCta, 
                                                        string cuentaAsoc, string nombre, string titular, string favor, decimal saldo, string moneda, 
                                                        string tipoMov, string activa, string clabe, string swift, string edoCta, string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGIB", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGSB", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNUMERO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOCTA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCBASOC", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTITULAR", OracleDbType.Varchar2), 
                                               new OracleParameter("prmFAVOR", OracleDbType.Varchar2),
                                               new OracleParameter("prmSALDO", OracleDbType.Decimal),
                                               new OracleParameter("prmCDGMO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOCTA", OracleDbType.Varchar2),
                                               new OracleParameter("prmACTIVA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLABE", OracleDbType.Varchar2),
                                               new OracleParameter("prmSWIFT", OracleDbType.Varchar2),
                                               new OracleParameter("prmEDOCTA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = instBanc;
        OracleParameters[2].Value = sucBanc;
        OracleParameters[3].Value = codigo;
        OracleParameters[4].Value = numero;
        OracleParameters[5].Value = tipoCta;
        OracleParameters[6].Value = cuentaAsoc;
        OracleParameters[7].Value = nombre;
        OracleParameters[8].Value = titular;
        OracleParameters[9].Value = favor;
        OracleParameters[10].Value = saldo;
        OracleParameters[11].Value = moneda;
        OracleParameters[12].Value = tipoMov;
        OracleParameters[13].Value = activa;
        OracleParameters[14].Value = clabe;
        OracleParameters[15].Value = swift;
        OracleParameters[16].Value = edoCta;
        OracleParameters[17].Value = usuario;
        OracleParameters[18].Value = tipo;
        OracleParameters[19].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionDispersion(int tipo, string empresa, string codigo, string ciclo, string acred, string tipoCred, string metodo,
                                                    string banco, string cuenta, string concepto, decimal monto, string fecha, string motivo, 
                                                    string reportado, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMETODO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGBANCO", OracleDbType.Varchar2),  
                                               new OracleParameter("prmCUENTA", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCONCEPTO", OracleDbType.Varchar2), 
                                               new OracleParameter("prmMONTO", OracleDbType.Decimal),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMOTIVO", OracleDbType.Varchar2),
                                               new OracleParameter("prmREPORTADO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = acred;
        OracleParameters[4].Value = tipoCred;
        OracleParameters[5].Value = metodo;
        OracleParameters[6].Value = banco;
        OracleParameters[7].Value = cuenta;
        OracleParameters[8].Value = concepto;
        OracleParameters[9].Value = monto;
        OracleParameters[10].Value = fecha;
        OracleParameters[11].Value = motivo;
        OracleParameters[12].Value = reportado;
        OracleParameters[13].Value = usuario;
        OracleParameters[14].Value = tipo;
        OracleParameters[15].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionDisposicion(string empresa, string orgFond, string lineaCred, string codigo, string contrato, 
                                                     string descripcion, string disposicion, decimal cantidad, int plazo, string pagoCap,  
                                                     string pagoInt, int graciaCap, int graciaInt, string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGORF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCONTRATO", OracleDbType.Varchar2),
                                               new OracleParameter("prmDESC", OracleDbType.Varchar2), 
                                               new OracleParameter("prmDISP", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCANTIDAD", OracleDbType.Decimal),
                                               new OracleParameter("prmPLAZO", OracleDbType.Int32),
                                               new OracleParameter("prmPAGOCAP", OracleDbType.Varchar2),
                                               new OracleParameter("prmPAGOINT", OracleDbType.Varchar2),
                                               new OracleParameter("prmGRACIACAP", OracleDbType.Int32),
                                               new OracleParameter("prmGRACIAINT", OracleDbType.Int32),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = orgFond;
        OracleParameters[2].Value = lineaCred;
        OracleParameters[3].Value = codigo;
        OracleParameters[4].Value = contrato;
        OracleParameters[5].Value = descripcion;
        OracleParameters[6].Value = disposicion;
        OracleParameters[7].Value = cantidad;
        OracleParameters[8].Value = plazo;
        OracleParameters[9].Value = pagoCap;
        OracleParameters[10].Value = pagoInt;
        OracleParameters[11].Value = graciaCap;
        OracleParameters[12].Value = graciaInt;
        OracleParameters[13].Value = usuario;
        OracleParameters[14].Value = tipo;
        OracleParameters[15].Direction = ParameterDirection.Output;


        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionGiro(string empresa, string sector, string codigo, string nombre, string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGSE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = sector;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = nombre;
        OracleParameters[4].Value = usuario;
        OracleParameters[5].Value = tipo;
        OracleParameters[6].Direction = ParameterDirection.Output;


        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionGrupo(int tipo, string empresa, string codigo, string nombre, DateTime fecha, string coord, 
                                               string codPostal, string entidad, string munic, string localidad, string colonia,
                                               string promotor, string recup)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pTIPO", OracleDbType.Int32),
                                               new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("pFECHA", OracleDbType.Date),
                                               new OracleParameter("pCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPRPE", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGACPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = tipo;
        OracleParameters[1].Value = empresa;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = nombre;
        OracleParameters[4].Value = fecha;
        OracleParameters[5].Value = coord;
        OracleParameters[6].Value = entidad;
        OracleParameters[7].Value = munic;
        OracleParameters[8].Value = localidad;
        OracleParameters[9].Value = colonia;
        OracleParameters[10].Value = promotor;
        OracleParameters[11].Value = recup;
        OracleParameters[12].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionImpCheque(string empresa, string coord, string cuenta, string grupo,
                                                   string ciclo, string[] acred, string[] cheque, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2), 
                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_NOCHEQUE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[5].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[6].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = coord;
        OracleParameters[2].Value = cuenta;
        OracleParameters[3].Value = grupo;
        OracleParameters[4].Value = ciclo;
        OracleParameters[5].Value = acred;
        OracleParameters[6].Value = cheque;
        OracleParameters[7].Value = usuario;
        OracleParameters[8].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionInst(int tipo, string empresa, string codigo, string descripcion, string tipoInst)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmDESC", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOINST", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = tipo;
        OracleParameters[1].Value = empresa;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = descripcion;
        OracleParameters[4].Value = tipoInst;
        OracleParameters[5].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionInstBancaria(int tipo, string empresa, string codigo, string nombre)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = tipo;
        OracleParameters[1].Value = empresa;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = nombre;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionLineaCred(string empresa, string orgFond, string codigo, string contrato, 
                                                   string descripcion, string otorgada, string instrumento, decimal cantidad, 
                                                   int plazo, decimal montoMax, int periodoRep, string pagoCap, string pagoInt, 
                                                   int graciaCap, int graciaInt, string tipoCred, string tipoRec, string recursos, 
                                                   string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGORF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCONTRATO", OracleDbType.Varchar2),     
                                               new OracleParameter("prmDESC", OracleDbType.Varchar2),
                                               new OracleParameter("prmOTORGADA", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCDGTI", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCANTIDAD", OracleDbType.Decimal),
                                               new OracleParameter("prmPLAZO", OracleDbType.Int32),
                                               new OracleParameter("prmMONTOMAX", OracleDbType.Decimal), 
                                               new OracleParameter("prmPERIODOREP", OracleDbType.Int32), 
                                               new OracleParameter("prmPAGOCAP", OracleDbType.Varchar2),
                                               new OracleParameter("prmPAGOINT", OracleDbType.Varchar2),
                                               new OracleParameter("prmGRACIACAP", OracleDbType.Int32),
                                               new OracleParameter("prmGRACIAINT", OracleDbType.Int32),
                                               new OracleParameter("prmTIPOCRED", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOREC", OracleDbType.Varchar2),
                                               new OracleParameter("prmRECURSOS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = orgFond;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = contrato;
        OracleParameters[4].Value = descripcion;
        OracleParameters[5].Value = otorgada;
        OracleParameters[6].Value = instrumento;
        OracleParameters[7].Value = cantidad;
        OracleParameters[8].Value = plazo;
        OracleParameters[9].Value = montoMax;
        OracleParameters[10].Value = periodoRep;
        OracleParameters[11].Value = pagoCap;
        OracleParameters[12].Value = pagoInt;
        OracleParameters[13].Value = graciaCap;
        OracleParameters[14].Value = graciaInt;
        OracleParameters[15].Value = tipoCred;
        OracleParameters[16].Value = tipoRec;
        OracleParameters[17].Value = recursos;
        OracleParameters[18].Value = usuario;
        OracleParameters[19].Value = tipo;
        OracleParameters[20].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionLoc(int tipo, string entFed, string munic, string codigo, string localidad, string cdgTel, string tipoLoc)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmLOCALIDAD", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGTEL", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOLOC", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = entFed;
        OracleParameters[1].Value = munic;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = localidad;
        OracleParameters[4].Value = cdgTel;
        OracleParameters[5].Value = tipoLoc;
        OracleParameters[6].Value = tipo;
        OracleParameters[7].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionModMesaDir(string empresa, string grupo, string ciclo, string presidente, string tesorero,
                                                   string secretario, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmPRESIDENTE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTESORERO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSECRETARIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = presidente;
        OracleParameters[4].Value = tesorero;
        OracleParameters[5].Value = secretario;
        OracleParameters[6].Value = usuario;
        OracleParameters[7].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionModOrdenPago(string empresa, string grupo, string ciclo, string[] acred, string[] chqAcred, string usuario, string cuenta, string estatus)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_NOCHEQUE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("prmESTATUS", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[3].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[4].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = acred;
        OracleParameters[4].Value = chqAcred;
        OracleParameters[5].Value = usuario;
        OracleParameters[6].Value = cuenta;
        OracleParameters[7].Value = estatus;
        OracleParameters[8].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionModPrn(string empresa, string cdgclns, string ciclo, string clns, string fecha, int tipo, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cdgclns;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = clns;
        OracleParameters[4].Value = fecha;
        OracleParameters[5].Value = tipo;
        OracleParameters[6].Value = usuario;
        OracleParameters[7].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionModTasaInt(string empresa, string codigo, string ciclo, string clns, decimal tasa, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = clns;
        OracleParameters[4].Value = tasa;
        OracleParameters[5].Value = usuario;
        OracleParameters[6].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionOrdenPago(string empresa, string cdgclns, string grupo, string cdgAcred, string ciclo, string clns, string [] acred, 
                                                   string [] chqAcred, string fecha, string usuario, string cuenta, string autorizado, string secuencia)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_NOCHEQUE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("prmAUTORCRR", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEC", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[6].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[7].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cdgclns;
        OracleParameters[2].Value = grupo;
        OracleParameters[3].Value = cdgAcred;
        OracleParameters[4].Value = ciclo;
        OracleParameters[5].Value = clns;
        OracleParameters[6].Value = acred;
        OracleParameters[7].Value = chqAcred;
        OracleParameters[8].Value = fecha;
        OracleParameters[9].Value = usuario;
        OracleParameters[10].Value = cuenta;
        OracleParameters[11].Value = autorizado;
        OracleParameters[12].Value = secuencia;
        OracleParameters[13].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionOrgFond(string empresa, string codigo, string nombre, string segNombre, string aPaterno,
                                                 string aMaterno, string calle, string entFed, string munic, 
                                                 string localidad, string colonia, string telefono, string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE1", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE2", OracleDbType.Varchar2),
                                               new OracleParameter("prmPRIMAPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmSEGAPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCALLE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLO", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("prmTELEFONO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = nombre;
        OracleParameters[3].Value = segNombre;
        OracleParameters[4].Value = aPaterno;
        OracleParameters[5].Value = aMaterno;
        OracleParameters[6].Value = calle;
        OracleParameters[7].Value = entFed;
        OracleParameters[8].Value = munic;
        OracleParameters[9].Value = localidad;
        OracleParameters[10].Value = colonia;
        OracleParameters[11].Value = telefono;
        OracleParameters[12].Value = usuario;
        OracleParameters[13].Value = tipo;
        OracleParameters[14].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionProd(int tipo, string empresa, string tipoProdCred, string codigo, string nombre, string moneda,
                                              string tipoCred, string valido, decimal montoMinimo, decimal montoMaximo, string baseCalc,
                                              string periodicidad, int multPerio, int diaEsp, int pagoCapital, int pagoInteres, int duracion,
                                              string fijaPer, string fijaMultPer, string fijaPGC, string fijaPGI, string fijaPlazo,
                                              /*string perPagoCap, string fijaPagoCap, string perCapital, int multPerCap,*/ string metodoCobro, 
                                              string formaDist, string instrumento, decimal interes, string fijaMCI, string fijaFDI, 
                                              string fijaTas, string tasaFija, string factorTasa, string aplican, string metodoAplic,
                                              string fijaMAP, string fijaRec, string formaEntre, string fijaEnt, string[] tipoMov, 
                                              decimal[] montoCom, decimal[] porcCom, string[] tipoCargo, string[] opcional, int[] orden, 
                                              string[] artefacto)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOPROD", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOCRED", OracleDbType.Varchar2),
                                               new OracleParameter("prmVALIDO", OracleDbType.Varchar2),
                                               new OracleParameter("prmMONTOMIN", OracleDbType.Decimal),
                                               new OracleParameter("prmMONTOMAX", OracleDbType.Decimal),
                                               new OracleParameter("prmBASECALC", OracleDbType.Varchar2),
                                               new OracleParameter("prmPERIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmMULTPER", OracleDbType.Int32),
                                               new OracleParameter("prmDIAESP", OracleDbType.Int32),
                                               new OracleParameter("prmPAGOCAP", OracleDbType.Int32),
                                               new OracleParameter("prmPAGOINT", OracleDbType.Int32),
                                               new OracleParameter("prmPLAZO", OracleDbType.Int32),
                                               new OracleParameter("prmFIJAPER", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAMULTPER", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAPAGOCAP", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAPAGOINT", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAPLAZO", OracleDbType.Varchar2),
                                               /*new OracleParameter("prmPERPAGOCAP", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAPERCAP", OracleDbType.Varchar2),
                                               new OracleParameter("prmPERCAPITAL", OracleDbType.Varchar2),
                                               new OracleParameter("prmMULTPERCAP", OracleDbType.Int32),*/
                                               new OracleParameter("prmMETCOBRO", OracleDbType.Varchar2),
                                               new OracleParameter("prmFORMADIST", OracleDbType.Varchar2),
                                               new OracleParameter("prmINSTRUMENTO", OracleDbType.Varchar2),
                                               new OracleParameter("prmINTERES", OracleDbType.Decimal),
                                               new OracleParameter("prmFIJAMCI", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAFDI", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJATAS", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASAFIJA", OracleDbType.Varchar2),
                                               new OracleParameter("prmFACTORTASA", OracleDbType.Varchar2),
                                               new OracleParameter("prmAPLICAN", OracleDbType.Varchar2),
                                               new OracleParameter("prmMETAPLIC", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAMAP", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAREC", OracleDbType.Varchar2),
                                               new OracleParameter("prmFORMAENTRE", OracleDbType.Varchar2),
                                               new OracleParameter("prmFIJAENT", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_TIPOMOV", OracleDbType.Varchar2),
                                               new OracleParameter("prmMONTOCOM", OracleDbType.Decimal),
                                               new OracleParameter("prmPORCCOM", OracleDbType.Decimal),
                                               new OracleParameter("prmTIPOCARGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmOPCIONAL", OracleDbType.Varchar2),
                                               new OracleParameter("prmORDEN", OracleDbType.Int32),
                                               new OracleParameter("prmARTEFACTO", OracleDbType.Varchar2), 
                                               new OracleParameter("prmTIPO", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[36].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[37].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[38].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[39].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[40].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[41].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[42].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = tipoProdCred;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = nombre;
        OracleParameters[4].Value = moneda;
        OracleParameters[5].Value = tipoCred;
        OracleParameters[6].Value = valido;
        OracleParameters[7].Value = montoMinimo;
        OracleParameters[8].Value = montoMaximo;
        OracleParameters[9].Value = baseCalc;
        OracleParameters[10].Value = periodicidad;
        OracleParameters[11].Value = multPerio;
        OracleParameters[12].Value = diaEsp;
        OracleParameters[13].Value = pagoCapital;
        OracleParameters[14].Value = pagoInteres;
        OracleParameters[15].Value = duracion;
        OracleParameters[16].Value = fijaPer;
        OracleParameters[17].Value = fijaMultPer;
        OracleParameters[18].Value = fijaPGC;
        OracleParameters[19].Value = fijaPGI;
        OracleParameters[20].Value = fijaPlazo;
        /*OracleParameters[21].Value = perPagoCap;
        OracleParameters[22].Value = fijaPagoCap;
        OracleParameters[23].Value = perCapital;
        OracleParameters[24].Value = multPerCap;*/
        OracleParameters[21].Value = metodoCobro;
        OracleParameters[22].Value = formaDist;
        OracleParameters[23].Value = instrumento;
        OracleParameters[24].Value = interes;
        OracleParameters[25].Value = fijaMCI;
        OracleParameters[26].Value = fijaFDI;
        OracleParameters[27].Value = fijaTas;
        OracleParameters[28].Value = tasaFija;
        OracleParameters[29].Value = factorTasa;
        OracleParameters[30].Value = aplican;
        OracleParameters[31].Value = metodoAplic;
        OracleParameters[32].Value = fijaMAP;
        OracleParameters[33].Value = fijaRec;
        OracleParameters[34].Value = formaEntre;
        OracleParameters[35].Value = fijaEnt;
        OracleParameters[36].Value = tipoMov;
        OracleParameters[37].Value = montoCom;
        OracleParameters[38].Value = porcCom;
        OracleParameters[39].Value = tipoCargo;
        OracleParameters[40].Value = opcional;
        OracleParameters[41].Value = orden;
        OracleParameters[42].Value = artefacto;
        OracleParameters[43].Value = tipo;
        OracleParameters[44].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionProy(string empresa, string tipoProy, string acred, string codigo, string nombre, DateTime fecha, string texto, 
                                              string giro, string sector, string actEco, string tipo, string grupo, string nomEmp, string rfc, string tamano)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOPROY", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Date),
                                               new OracleParameter("prmTEXTO", OracleDbType.Varchar2),
                                               new OracleParameter("prmGIRO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSECTOR", OracleDbType.Varchar2),
                                               new OracleParameter("prmACTECO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCGDNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMEMP", OracleDbType.Varchar2),
                                               new OracleParameter("prmRFC", OracleDbType.Varchar2),
                                               new OracleParameter("prmTAMANO", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = tipoProy;
        OracleParameters[2].Value = acred;
        OracleParameters[3].Value = codigo;
        OracleParameters[4].Value = nombre;
        OracleParameters[5].Value = fecha;
        OracleParameters[6].Value = texto;
        OracleParameters[7].Value = giro;
        OracleParameters[8].Value = sector;
        OracleParameters[9].Value = actEco;
        OracleParameters[10].Value = tipo;
        OracleParameters[11].Value = grupo;
        OracleParameters[12].Value = nomEmp;
        OracleParameters[13].Value = rfc;
        OracleParameters[14].Value = tamano;
        OracleParameters[15].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionEntPrnMas(string empresa, string grupo, string ciclo, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = usuario;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionEvSolic(string empresa, string cdgclns, string cdgns, string cdgcl, string ciclo, string periodicidad, decimal cantSolic, decimal cantAutor, string diaJunta, int desfasePago, decimal tasa,
                                               decimal cat, int plazo, decimal pagoCapital, decimal pagoInteres, string instCred, string factorTasa, string metodoAplic, string metCobro, string distInt, 
                                               string deposita, string situacion, string aplican, string entrega, string solicitud, string tipoProd, string prodCred, string moneda, string contrato, string presidente,
                                               string tesorero, string secretario, string usuario, string formaEnt, string nombreCheq, int multPerio, int diaEsp, string sucursal, string promotor, string tasaFija, string depositaSC,
                                               string domicilia, string[] acred, decimal[] montos, string[] proyInv, string[] situacionAcred, string[] rechazo, decimal[] cantAutorAcred, string calle, string entFed, 
                                               string munic, string localidad, string colonia, string horario, string reunion, string autorCrr, string secuencia, string aval, string naturaleza, string credRel/*, string[] excepcion, string observacion, string[] excAcred, string[] lstAcred,
                                               string[] obsAcred*/)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmPERIODICIDAD", OracleDbType.Varchar2),
                                               new OracleParameter("prmCANTSOLIC", OracleDbType.Decimal),
                                               new OracleParameter("prmCANTAUTOR", OracleDbType.Decimal),
                                               new OracleParameter("prmDIAJUNTA", OracleDbType.Varchar2),
                                               new OracleParameter("prmDESFASEPAGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASA", OracleDbType.Decimal),
                                               new OracleParameter("prmCAT", OracleDbType.Decimal),
                                               new OracleParameter("prmDURACION", OracleDbType.Varchar2),
                                               new OracleParameter("prmPERIGRCAP", OracleDbType.Varchar2),
                                               new OracleParameter("prmPERIGRINT", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGTI", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASARECTAS", OracleDbType.Varchar2),
                                               new OracleParameter("prmMETRECA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMCI", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGFDI", OracleDbType.Varchar2),
                                               new OracleParameter("prmDEPOSITA", OracleDbType.Varchar2),
                                               new OracleParameter("prmSITUACION", OracleDbType.Varchar2),
                                               new OracleParameter("prmMODOAPLICARECA", OracleDbType.Varchar2),
                                               new OracleParameter("prmINICIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSOLICITUD", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGTPC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPCR", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCONTRATO", OracleDbType.Varchar2),
                                               new OracleParameter("prmPRESIDENTE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTESORERO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSECRETARIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmACTUALIZARPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmFORMAENTREGA", OracleDbType.Varchar2),
                                               new OracleParameter("prmMULTPER", OracleDbType.Varchar2),
                                               new OracleParameter("prmDIAESP", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNSPI_SN", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCO", OracleDbType.Varchar2),
                                               //PENDIENTE VERIFICAR ORIGEN DE CAMPO
                                               new OracleParameter("prmCDGOCPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPRPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmPLAZOSOL", OracleDbType.Varchar2),

                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CANTSOLIC", OracleDbType.Decimal),
                                               new OracleParameter("prmT_CANTAUTOR", OracleDbType.Decimal),
                                               new OracleParameter("prmT_SITUACION", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_RECHAZO", OracleDbType.Varchar2),
                                               
                                               new OracleParameter("prmCLNSPI_SC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmDOMICILIA", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASARECFIJ", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CDGPI", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRECH", OracleDbType.Varchar2),
                                               new OracleParameter("prmLUGARCALLE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("prmHORARIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmREUNION", OracleDbType.Varchar2),
                                               new OracleParameter("prmAUTORCRR", OracleDbType.Varchar2), 
                                               new OracleParameter("prmSEC", OracleDbType.Varchar2),  

                                               new OracleParameter("prmAVAL", OracleDbType.Varchar2),
                                               new OracleParameter("prmNATURALEZA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCREDREL", OracleDbType.Varchar2),

                                               /*new OracleParameter("prmCDGEXC", OracleDbType.Varchar2),
                                               new OracleParameter("prmOBSERVACION", OracleDbType.Varchar2), 
                                               new OracleParameter("prmEXCACRED", OracleDbType.Varchar2),
                                               new OracleParameter("prmLSTACRED", OracleDbType.Varchar2),
                                               new OracleParameter("prmOBSACRED", OracleDbType.Varchar2),*/
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[41].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[42].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[43].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[44].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[45].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        
        OracleParameters[50].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        /*OracleParameters[55].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[57].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[58].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[59].CollectionType = OracleCollectionType.PLSQLAssociativeArray;*/

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cdgclns;
        OracleParameters[2].Value = cdgns;
        OracleParameters[3].Value = cdgcl;
        OracleParameters[4].Value = ciclo;
        OracleParameters[5].Value = periodicidad;
        OracleParameters[6].Value = cantSolic;
        OracleParameters[7].Value = cantAutor;
        OracleParameters[8].Value = diaJunta;
        OracleParameters[9].Value = desfasePago;
        OracleParameters[10].Value = tasa;
        OracleParameters[11].Value = cat;
        OracleParameters[12].Value = plazo;
        OracleParameters[13].Value = pagoCapital;
        OracleParameters[14].Value = pagoInteres;
        OracleParameters[15].Value = instCred;
        OracleParameters[16].Value = factorTasa;
        OracleParameters[17].Value = metodoAplic;
        OracleParameters[18].Value = metCobro;
        OracleParameters[19].Value = distInt;
        OracleParameters[20].Value = deposita;
        OracleParameters[21].Value = situacion;
        OracleParameters[22].Value = aplican;
        OracleParameters[23].Value = entrega;
        OracleParameters[24].Value = solicitud;
        OracleParameters[25].Value = tipoProd;
        OracleParameters[26].Value = prodCred;
        OracleParameters[27].Value = moneda;
        OracleParameters[28].Value = contrato;
        OracleParameters[29].Value = presidente;
        OracleParameters[30].Value = tesorero;
        OracleParameters[31].Value = secretario;
        OracleParameters[32].Value = usuario;
        OracleParameters[33].Value = formaEnt;
        OracleParameters[34].Value = multPerio;
        OracleParameters[35].Value = diaEsp;
        OracleParameters[36].Value = deposita;
        OracleParameters[37].Value = sucursal;
        //VERIFICAR ORIGEN DE CAMPO
        OracleParameters[38].Value = promotor;
        OracleParameters[39].Value = promotor;
        OracleParameters[40].Value = plazo;

        OracleParameters[41].Value = acred;
        OracleParameters[42].Value = montos;
        OracleParameters[43].Value = cantAutorAcred;
        OracleParameters[44].Value = situacionAcred;
        OracleParameters[45].Value = rechazo;

        OracleParameters[46].Value = depositaSC;
        OracleParameters[47].Value = deposita;
        OracleParameters[48].Value = domicilia;
        OracleParameters[49].Value = tasaFija;

        OracleParameters[50].Value = proyInv;

        OracleParameters[51].Value = nombreCheq;
        OracleParameters[52].Value = calle;
        OracleParameters[53].Value = entFed;
        OracleParameters[54].Value = munic;
        OracleParameters[55].Value = localidad;
        OracleParameters[56].Value = colonia;
        OracleParameters[57].Value = horario;
        OracleParameters[58].Value = reunion;
        OracleParameters[59].Value = autorCrr;

        OracleParameters[60].Value = secuencia;

        OracleParameters[61].Value = aval;
        OracleParameters[62].Value = naturaleza;
        OracleParameters[63].Value = credRel;

        /*OracleParameters[55].Value = excepcion;
        OracleParameters[56].Value = observacion;
        OracleParameters[57].Value = excAcred;
        OracleParameters[58].Value = lstAcred;
        OracleParameters[59].Value = obsAcred;*/

        OracleParameters[64].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionFideicomiso(string empresa, string codigo, string numero, string fecha, string[] secParte,
                                                     string[] nomParte, string[] figParte, string fines, string[] secMiemCM, 
                                                     string[] miemCM, string presCM, string secCM, string[] secMiemCT, string[] miemCT, 
                                                     string presCT, string secCT, string[] secDF, string[] nomDF, string[] cargoDF, 
                                                     string[] telDF, string[] emailDF, string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNUMERO", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_SECPARTE", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_PARTE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmT_FIGURA", OracleDbType.Varchar2), 
                                               new OracleParameter("prmFINES", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_SECMIEMCM", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_MIEMCM", OracleDbType.Varchar2),
                                               new OracleParameter("prmPRESCM", OracleDbType.Varchar2),
                                               new OracleParameter("prmSECCM", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_SECMIEMCT", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_MIEMCT", OracleDbType.Varchar2),
                                               new OracleParameter("prmPRESCT", OracleDbType.Varchar2),
                                               new OracleParameter("prmSECCT", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_SECDF", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_NOMDF", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CARGODF", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_TELDF", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_EMAILDF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[4].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[5].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[6].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[8].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[9].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[12].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[13].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[16].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[17].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[18].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[19].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[20].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = numero;
        OracleParameters[3].Value = fecha;
        OracleParameters[4].Value = secParte;
        OracleParameters[5].Value = nomParte;
        OracleParameters[6].Value = figParte;
        OracleParameters[7].Value = fines;
        OracleParameters[8].Value = secMiemCM;
        OracleParameters[9].Value = miemCM;
        OracleParameters[10].Value = presCM;
        OracleParameters[11].Value = secCM;
        OracleParameters[12].Value = secMiemCT;
        OracleParameters[13].Value = miemCT;
        OracleParameters[14].Value = presCT;
        OracleParameters[15].Value = secCT;
        OracleParameters[16].Value = secDF;
        OracleParameters[17].Value = nomDF;
        OracleParameters[18].Value = cargoDF;
        OracleParameters[19].Value = telDF;
        OracleParameters[20].Value = emailDF;
        OracleParameters[21].Value = usuario;
        OracleParameters[22].Value = tipo;
        OracleParameters[23].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionGarantia(int tipo, string empresa, string cdgclns, string clns, string sec, string tipoGtia, string articulo, decimal valorNominal, 
                                                  decimal valorContable, string tipoProp, string descripcion, string factura, string activa, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEC", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOGTIA", OracleDbType.Varchar2),
                                               new OracleParameter("prmARTICULO", OracleDbType.Varchar2),
                                               new OracleParameter("prmVALORNOMINAL", OracleDbType.Varchar2),
                                               new OracleParameter("prmVALORCONTABLE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOPROP", OracleDbType.Varchar2),
                                               new OracleParameter("prmDESCRIPCION", OracleDbType.Varchar2),
                                               new OracleParameter("prmFACTURA", OracleDbType.Varchar2),
                                               new OracleParameter("prmACTIVA", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cdgclns;
        OracleParameters[2].Value = clns;
        OracleParameters[3].Value = sec;
        OracleParameters[4].Value = tipoGtia;
        OracleParameters[5].Value = articulo;
        OracleParameters[6].Value = valorNominal;
        OracleParameters[7].Value = valorContable;
        OracleParameters[8].Value = tipoProp;
        OracleParameters[9].Value = descripcion;
        OracleParameters[10].Value = factura;
        OracleParameters[11].Value = activa;
        OracleParameters[12].Value = tipo;
        OracleParameters[13].Value = usuario;
        OracleParameters[14].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionParamsOper(string empresa, decimal montoMax, decimal tipoCambio, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmMONTOMAX", OracleDbType.Varchar2),
                                               new OracleParameter("prmCAMBIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = montoMax;
        OracleParameters[2].Value = tipoCambio;
        OracleParameters[3].Value = usuario;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionPersona(int tipo, string empresa, string usuario, string codigo, string nombre,
                                               string segNombre, string aPaterno, string aMaterno, string figura, string nomCom, string sexo, 
                                               string fecha, string nacPais, string nacEntFed, string nac, string rfc, string curp, string ife, 
                                               string fiel, string edoCivil, string email1, string email2, string telefono, string telefono2, 
                                               string calle, string noExt, string noInt, string entreCalles, string pais, string dirEntFed, 
                                               string munic, string localidad, string colonia, string calleNeg, string noIntNeg, string noExtNeg, 
                                               string entreCallesNeg, string paisNeg, string entFedNeg, string municNeg, string localidadNeg, 
                                               string coloniaNeg, string tipoPers, string[] repLegal, string giro, string origen, string destino, 
                                               string otroDesRec, string pep, string[] propReal, string[] provRec, string puesto, string puestoDesc, 
                                               string periodo, string puestoFam, string nomFam, string parentescoFam, string puestoDescFam,
                                               string periodoFam, int commit)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMBRE1", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMBRE2", OracleDbType.Varchar2),
                                               new OracleParameter("pPRIMAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pSEGAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pFIGURA", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMCOM", OracleDbType.Varchar2),
                                               new OracleParameter("pNACIMIENTO", OracleDbType.Varchar2),
                                               new OracleParameter("pIFE", OracleDbType.Varchar2),
                                               new OracleParameter("pRFC", OracleDbType.Varchar2),
                                               new OracleParameter("pCURP", OracleDbType.Varchar2),
                                               new OracleParameter("pSEXO", OracleDbType.Varchar2),
                                               new OracleParameter("pNACIOPAI", OracleDbType.Varchar2),
                                               new OracleParameter("pNACIOEF", OracleDbType.Varchar2),
                                               new OracleParameter("pNACIONALIDAD", OracleDbType.Varchar2),
                                               new OracleParameter("pFIEL", OracleDbType.Varchar2),
                                               new OracleParameter("pEDOCIVIL", OracleDbType.Varchar2),
                                               new OracleParameter("pTELEFONO", OracleDbType.Varchar2),
                                               new OracleParameter("pTELEFONO2", OracleDbType.Varchar2),
                                               new OracleParameter("pEMAIL1", OracleDbType.Varchar2),
                                               new OracleParameter("pEMAIL2", OracleDbType.Varchar2),
                                               new OracleParameter("pTIPOPERS", OracleDbType.Varchar2),
                                               new OracleParameter("pT_REPLEGAL", OracleDbType.Varchar2),
                                               new OracleParameter("pCALLE", OracleDbType.Varchar2),
                                               new OracleParameter("pNOEXT", OracleDbType.Varchar2),
                                               new OracleParameter("pNOINT", OracleDbType.Varchar2),
                                               new OracleParameter("pENTRECALLES", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPAIS", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("pCALLENEG", OracleDbType.Varchar2),
                                               new OracleParameter("pNOEXTNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pNOINTNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pENTRECALLESNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPAISNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGEFNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGMUNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGLONEG", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCOLNEG", OracleDbType.Varchar2),
                                               new OracleParameter("pGIRO", OracleDbType.Varchar2),
                                               new OracleParameter("pORIREC", OracleDbType.Varchar2), 
                                               new OracleParameter("pDESTREC", OracleDbType.Varchar2),
                                               new OracleParameter("pOTRODESREC", OracleDbType.Varchar2),
                                               new OracleParameter("pPEP", OracleDbType.Varchar2), 
                                               new OracleParameter("pT_PROPREAL", OracleDbType.Varchar2),
                                               new OracleParameter("pT_PROVREC", OracleDbType.Varchar2),
                                               new OracleParameter("pPUESTO", OracleDbType.Varchar2),
                                               new OracleParameter("pPUESTODESC", OracleDbType.Varchar2),
                                               new OracleParameter("pPERIODO", OracleDbType.Varchar2),
                                               new OracleParameter("pPUESTOFAM", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMFAM", OracleDbType.Varchar2),
                                               new OracleParameter("pPARENTESCOFAM", OracleDbType.Varchar2), 
                                               new OracleParameter("pPUESTODESCFAM", OracleDbType.Varchar2),
                                               new OracleParameter("pPERIODOFAM", OracleDbType.Varchar2),
                                               new OracleParameter("pACTUALIZAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pOpera", OracleDbType.Int32),
                                               new OracleParameter("pCOMMIT", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[23].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[47].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[48].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = nombre;
        OracleParameters[3].Value = segNombre;
        OracleParameters[4].Value = aPaterno;
        OracleParameters[5].Value = aMaterno;
        OracleParameters[6].Value = figura;
        OracleParameters[7].Value = nomCom;
        OracleParameters[8].Value = fecha;
        OracleParameters[9].Value = ife;
        OracleParameters[10].Value = rfc;
        OracleParameters[11].Value = curp;
        OracleParameters[12].Value = sexo;
        OracleParameters[13].Value = nacPais;
        OracleParameters[14].Value = nacEntFed;
        OracleParameters[15].Value = nac;
        OracleParameters[16].Value = fiel;
        OracleParameters[17].Value = edoCivil;
        OracleParameters[18].Value = telefono;
        OracleParameters[19].Value = telefono2;
        OracleParameters[20].Value = email1;
        OracleParameters[21].Value = email2;
        OracleParameters[22].Value = tipoPers;
        OracleParameters[23].Value = repLegal;
        OracleParameters[24].Value = calle;
        OracleParameters[25].Value = noExt;
        OracleParameters[26].Value = noInt;
        OracleParameters[27].Value = entreCalles;
        OracleParameters[28].Value = pais;
        OracleParameters[29].Value = dirEntFed;
        OracleParameters[30].Value = munic;
        OracleParameters[31].Value = localidad;
        OracleParameters[32].Value = colonia;
        OracleParameters[33].Value = calleNeg;
        OracleParameters[34].Value = noExtNeg;
        OracleParameters[35].Value = noIntNeg;
        OracleParameters[36].Value = entreCallesNeg;
        OracleParameters[37].Value = paisNeg;
        OracleParameters[38].Value = entFedNeg;
        OracleParameters[39].Value = municNeg;
        OracleParameters[40].Value = localidadNeg;
        OracleParameters[41].Value = coloniaNeg;
        OracleParameters[42].Value = giro;
        OracleParameters[43].Value = origen;
        OracleParameters[44].Value = destino; 
        OracleParameters[45].Value = otroDesRec;
        OracleParameters[46].Value = pep; 
        OracleParameters[47].Value = propReal;
        OracleParameters[48].Value = provRec;
        OracleParameters[49].Value = puesto;
        OracleParameters[50].Value = puestoDesc;
        OracleParameters[51].Value = periodo;
        OracleParameters[52].Value = puestoFam;
        OracleParameters[53].Value = nomFam;
        OracleParameters[54].Value = parentescoFam;
        OracleParameters[55].Value = puestoDescFam;
        OracleParameters[56].Value = periodoFam; 
        OracleParameters[57].Value = usuario;
        OracleParameters[58].Value = tipo;
        OracleParameters[59].Value = commit;
        OracleParameters[60].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionPrn(int tipo, string usuario, string empresa, string cdgclns, string grupo, string cdgAcred, string ciclo, 
                                             string clns, decimal cantEntre, decimal cantDevol, string situacion, string entrega, string solicitud, 
                                             string[] acred, decimal[] cantEntreAcred, string[] situacionAcred, string autorizado, string sec)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCANTENTRE", OracleDbType.Decimal),
                                               new OracleParameter("prmCANTDEVOL", OracleDbType.Decimal),
                                               new OracleParameter("prmSITUACION", OracleDbType.Varchar2),
                                               new OracleParameter("prmINICIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSOLICITUD", OracleDbType.Varchar2),
                                              
                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CANTENTRE", OracleDbType.Decimal),
                                               new OracleParameter("prmT_SITUACION", OracleDbType.Varchar2),
                                               new OracleParameter("prmAUTORCRR", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEC", OracleDbType.Varchar2),
                                               
                                               new OracleParameter("prmUSUARIO", OracleDbType.Varchar2), 
                                               new OracleParameter("prmTIPO", OracleDbType.Int32), 
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[11].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[12].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[13].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cdgclns;
        OracleParameters[2].Value = grupo;
        OracleParameters[3].Value = cdgAcred;
        OracleParameters[4].Value = ciclo;
        OracleParameters[5].Value = clns;
        OracleParameters[6].Value = cantEntre;
        OracleParameters[7].Value = cantDevol;
        OracleParameters[8].Value = situacion;
        OracleParameters[9].Value = entrega;
        OracleParameters[10].Value = solicitud;

        OracleParameters[11].Value = acred;
        OracleParameters[12].Value = cantEntreAcred;
        OracleParameters[13].Value = situacionAcred;

        OracleParameters[14].Value = autorizado;
        OracleParameters[15].Value = sec;

        OracleParameters[16].Value = usuario;
        OracleParameters[17].Value = tipo;

        OracleParameters[18].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionReg(int tipo, string empresa, string codigo, string regional, string gerente, string calle, string entFed, 
                                             string munic, string localidad, string colonia, string telefono)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmREGIONAL", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCALLE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("prmTELEFONO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = regional;
        OracleParameters[3].Value = gerente;
        OracleParameters[4].Value = calle;
        OracleParameters[5].Value = entFed;
        OracleParameters[6].Value = munic;
        OracleParameters[7].Value = localidad;
        OracleParameters[8].Value = colonia;
        OracleParameters[9].Value = telefono;
        OracleParameters[10].Value = tipo;
        OracleParameters[11].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionSector(string empresa, string codigo, string nombre, string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = nombre;
        OracleParameters[3].Value = usuario;
        OracleParameters[4].Value = tipo;
        OracleParameters[5].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionSolic(int tipo, string empresa, string cdgclns, string cdgNs, string ciclo, string periodicidad, decimal cantSolic, decimal cantAutor, string diaJunta, int desfasePago, 
                                               decimal tasa, decimal cat, int plazo, decimal pagoCapital, decimal pagoInteres, string instCred, string factorTasa, string metodoAplic, string metCobro, string distInt,
                                               string deposita, string situacion, string aplican, string entrega, string solicitud, string tipoProd, string prodCred, string moneda, string contrato, string presidente, 
                                               string tesorero, string secretario, string usuario, string formaEnt, string nombreCheq, string cdgCb, string tipoDes, int multPerio, int diaEsp, string sucursal, 
                                               string promotor, string tasaFija, string depositaSC, string domicilia, string [] acred, decimal [] montos, string[] proyInv, int[] emplGenH, int[] emplGenM, 
                                               int[] emplSostH, int[] emplSostM, string calle, string entFed, string munic, string localidad, string colonia, string horario, string reunion, string autorCrr,
                                               string secuencia, string aval, string naturaleza, string[] tipoMovCom, decimal[] montoCom, decimal[] porcCom, string[] tipoCargoCom, string[] opcCom, 
                                               int[] ordenPrel, string[] artefactoPrel, string credRel)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmPERIODICIDAD", OracleDbType.Varchar2),
                                               new OracleParameter("prmCANTSOLIC", OracleDbType.Decimal),
                                               new OracleParameter("prmCANTAUTOR", OracleDbType.Decimal),
                                               new OracleParameter("prmDIAJUNTA", OracleDbType.Varchar2),
                                               new OracleParameter("prmDESFASEPAGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASA", OracleDbType.Decimal),
                                               new OracleParameter("prmCAT", OracleDbType.Decimal),
                                               new OracleParameter("prmDURACION", OracleDbType.Varchar2),
                                               new OracleParameter("prmPERIGRCAP", OracleDbType.Varchar2),
                                               new OracleParameter("prmPERIGRINT", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGTI", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASARECTAS", OracleDbType.Varchar2),
                                               new OracleParameter("prmMETRECA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMCI", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGFDI", OracleDbType.Varchar2),
                                               new OracleParameter("prmDEPOSITA", OracleDbType.Varchar2),
                                               new OracleParameter("prmSITUACION", OracleDbType.Varchar2),
                                               new OracleParameter("prmMODOAPLICARECA", OracleDbType.Varchar2),
                                               new OracleParameter("prmINICIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSOLICITUD", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGTPC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPCR", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCONTRATO", OracleDbType.Varchar2),
                                               new OracleParameter("prmPRESIDENTE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTESORERO", OracleDbType.Varchar2),
                                               new OracleParameter("prmSECRETARIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmACTUALIZARPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmFORMAENTREGA", OracleDbType.Varchar2),
                                               new OracleParameter("prmMULTPER", OracleDbType.Varchar2),
                                               new OracleParameter("prmDIAESP", OracleDbType.Int32),
                                               new OracleParameter("prmCLNSPI_SN", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCO", OracleDbType.Varchar2),
                                               //PENDIENTE VERIFICAR ORIGEN DE CAMPO
                                               new OracleParameter("prmCDGOCPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPRPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmPLAZOSOL", OracleDbType.Varchar2),

                                               new OracleParameter("prmT_CDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CANTSOLIC", OracleDbType.Decimal),
                                               
                                               new OracleParameter("prmCLNSPI_SC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmDOMICILIA", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASARECFIJ", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CDGPI", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRECH", OracleDbType.Varchar2),
                                               new OracleParameter("prmLUGARCALLE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_EMPLGENH", OracleDbType.Int32), 
                                               new OracleParameter("prmT_EMPLGENM", OracleDbType.Int32),
                                               new OracleParameter("prmT_EMPLSOSTH", OracleDbType.Int32), 
                                               new OracleParameter("prmT_EMPLSOSTM", OracleDbType.Int32),
                                               new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPODES", OracleDbType.Varchar2),

                                               new OracleParameter("prmHORARIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmREUNION", OracleDbType.Varchar2),
                                               new OracleParameter("prmAUTORCRR", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEC", OracleDbType.Varchar2),

                                               new OracleParameter("prmAVAL", OracleDbType.Varchar2),
                                               new OracleParameter("prmNATURALEZA", OracleDbType.Varchar2),

                                               new OracleParameter("prmT_TIPOMOVCOM", OracleDbType.Varchar2), 
                                               new OracleParameter("prmT_MONTOCOM", OracleDbType.Decimal),
                                               new OracleParameter("prmT_PORCCOM", OracleDbType.Decimal), 
                                               new OracleParameter("prmT_TIPOCARGOCOM", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_OPCCOM", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_ORDENPREL", OracleDbType.Int32), 
                                               new OracleParameter("prmT_ARTEFPREL", OracleDbType.Varchar2),
                                               
                                               new OracleParameter("prmCREDREL", OracleDbType.Varchar2),

                                               new OracleParameter("prmTIPO", OracleDbType.Int32), 
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[40].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[41].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[46].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[53].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[54].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[55].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[56].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[65].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[66].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[67].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[68].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[69].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[70].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[71].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cdgclns;
        OracleParameters[2].Value = cdgNs;
        OracleParameters[3].Value = ciclo;
        OracleParameters[4].Value = periodicidad;
        OracleParameters[5].Value = cantSolic;
        OracleParameters[6].Value = cantAutor;
        OracleParameters[7].Value = diaJunta;
        OracleParameters[8].Value = desfasePago;
        OracleParameters[9].Value = tasa;
        OracleParameters[10].Value = cat;
        OracleParameters[11].Value = plazo;
        OracleParameters[12].Value = pagoCapital;
        OracleParameters[13].Value = pagoInteres;
        OracleParameters[14].Value = instCred;
        OracleParameters[15].Value = factorTasa;
        OracleParameters[16].Value = metodoAplic;
        OracleParameters[17].Value = metCobro;
        OracleParameters[18].Value = distInt;
        OracleParameters[19].Value = deposita;
        OracleParameters[20].Value = situacion;
        OracleParameters[21].Value = aplican;
        OracleParameters[22].Value = entrega;
        OracleParameters[23].Value = solicitud;
        OracleParameters[24].Value = tipoProd;
        OracleParameters[25].Value = prodCred;
        OracleParameters[26].Value = moneda;
        OracleParameters[27].Value = contrato;
        OracleParameters[28].Value = presidente;
        OracleParameters[29].Value = tesorero;
        OracleParameters[30].Value = secretario;
        OracleParameters[31].Value = usuario;
        OracleParameters[32].Value = formaEnt;
        OracleParameters[33].Value = multPerio;
        OracleParameters[34].Value = diaEsp;
        OracleParameters[35].Value = deposita;
        OracleParameters[36].Value = sucursal;
        //VERIFICAR ORIGEN DE CAMPO
        OracleParameters[37].Value = promotor;
        OracleParameters[38].Value = promotor;
        OracleParameters[39].Value = plazo;

        OracleParameters[40].Value = acred;
        OracleParameters[41].Value = montos; 

        OracleParameters[42].Value = depositaSC;
        OracleParameters[43].Value = deposita;
        OracleParameters[44].Value = domicilia;
        OracleParameters[45].Value = tasaFija;

        OracleParameters[46].Value = proyInv;

        OracleParameters[47].Value = nombreCheq;
        OracleParameters[48].Value = calle;
        OracleParameters[49].Value = entFed;
        OracleParameters[50].Value = munic;
        OracleParameters[51].Value = localidad;
        OracleParameters[52].Value = colonia;

        OracleParameters[53].Value = emplGenH;
        OracleParameters[54].Value = emplGenM;
        OracleParameters[55].Value = emplSostH;
        OracleParameters[56].Value = emplSostM;

        OracleParameters[57].Value = cdgCb;
        OracleParameters[58].Value = tipoDes;

        OracleParameters[59].Value = horario;
        OracleParameters[60].Value = reunion;
        OracleParameters[61].Value = autorCrr;
        OracleParameters[62].Value = secuencia;

        OracleParameters[63].Value = aval;
        OracleParameters[64].Value = naturaleza;

        OracleParameters[65].Value = tipoMovCom; 
        OracleParameters[66].Value = montoCom; 
        OracleParameters[67].Value = porcCom; 
        OracleParameters[68].Value = tipoCargoCom;
        OracleParameters[69].Value = opcCom; 
        OracleParameters[70].Value = ordenPrel;
        OracleParameters[71].Value = artefactoPrel;

        OracleParameters[72].Value = credRel;
        OracleParameters[73].Value = tipo;

        OracleParameters[74].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionSucBancaria(string empresa, string instBanc, string codigo, string nombre, string gerente, string ejecutivo,
                                                     string calle, string entFed, string munic, string localidad, string colonia, string telefono, 
                                                     string labora, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGIB", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("prmGERENTE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmEJECUTIVO", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCALLE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLO", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCDGCOL", OracleDbType.Varchar2),
                                               new OracleParameter("prmTELEFONO", OracleDbType.Varchar2),
                                               new OracleParameter("prmLABORA", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = instBanc;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = nombre;
        OracleParameters[4].Value = gerente;
        OracleParameters[5].Value = ejecutivo;
        OracleParameters[6].Value = calle;
        OracleParameters[7].Value = entFed;
        OracleParameters[8].Value = munic;
        OracleParameters[9].Value = localidad;
        OracleParameters[10].Value = colonia;
        OracleParameters[11].Value = telefono;
        OracleParameters[12].Value = labora;
        OracleParameters[13].Value = tipo;
        OracleParameters[14].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionSuplemento(string empresa, string fideicomiso, string codigo, string clave, string fecha, string alias,
                                                     string[] cuentas, string[] secAcred, string[] acreditantes, string usuario, int tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGFID", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLAVE", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmALIAS", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_CUENTAS", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_SECACRED", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_ACRED", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[6].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[7].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[8].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fideicomiso;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = clave;
        OracleParameters[4].Value = fecha;
        OracleParameters[5].Value = alias;
        OracleParameters[6].Value = cuentas;
        OracleParameters[7].Value = secAcred;
        OracleParameters[8].Value = acreditantes;
        OracleParameters[9].Value = usuario;
        OracleParameters[10].Value = tipo;
        OracleParameters[11].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionTasa(int tipo, string empresa, string instrumento, string valDesde, decimal tasa)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGTI", OracleDbType.Varchar2),
                                               new OracleParameter("prmVALDESDE", OracleDbType.Varchar2),
                                               new OracleParameter("prmTASA", OracleDbType.Decimal),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = tipo;
        OracleParameters[1].Value = empresa;
        OracleParameters[2].Value = instrumento;
        OracleParameters[3].Value = valDesde;
        OracleParameters[4].Value = tasa;
        OracleParameters[5].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAccionTipoProd(int tipo, string empresa, string codigo, string nombre)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMBRE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = tipo;
        OracleParameters[1].Value = empresa;
        OracleParameters[2].Value = codigo;
        OracleParameters[3].Value = nombre;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAgregaAcred(string empresa, string grupo, string acred, DateTime fecha)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("pFECALTA", OracleDbType.Date),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = acred;
        OracleParameters[3].Value = fecha;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAltaConsulta(string empresa, string acred)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = acred;
        OracleParameters[2].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAltaSegConsulta(string empresa, string acred, string fecConsulta, string idBuro, string cveOtorga,
                                                   string nomOtorga, string telOtorga, string tipoContrato, string cveMoneda, decimal importe, 
                                                   string tipoRespons, string consNuevo, string resFinal)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("pFECCONS", OracleDbType.Varchar2),
                                               new OracleParameter("pIDBURO", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGOTOR", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMOTOR", OracleDbType.Varchar2),
                                               new OracleParameter("pTELOTOR", OracleDbType.Varchar2),
                                               new OracleParameter("pTIPOCONT", OracleDbType.Varchar2), 
                                               new OracleParameter("pCDGMO", OracleDbType.Varchar2),
                                               new OracleParameter("pIMPORTE", OracleDbType.Decimal),
                                               new OracleParameter("pTIPORESP", OracleDbType.Varchar2),
                                               new OracleParameter("pCONSNUEVO", OracleDbType.Varchar2),
                                               new OracleParameter("pRESFINAL", OracleDbType.Varchar2),
                                               
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = acred;
        OracleParameters[2].Value = fecConsulta;
        OracleParameters[3].Value = idBuro;
        OracleParameters[4].Value = cveOtorga;
        OracleParameters[5].Value = nomOtorga;
        OracleParameters[6].Value = telOtorga;
        OracleParameters[7].Value = tipoContrato;
        OracleParameters[8].Value = cveMoneda;
        OracleParameters[9].Value = importe;
        OracleParameters[10].Value = tipoRespons;
        OracleParameters[11].Value = consNuevo;
        OracleParameters[12].Value = resFinal;
        
        OracleParameters[13].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAltaSegCuenta(string empresa, string acred, string fecAct, string regImp, string cveOtorga,
                                                 string nomOtorga, string idSIC, string cuenta, string tipoRespons, string tipoCuenta, 
                                                 string tipoContrato, string cveMoneda, decimal valorActivo, int numPagos, string frecPagos, 
                                                 decimal montoPagar, string fecCuenta, string fecUltPago, string fecUltCompra,
                                                 string fecCierreCta, string fecRep, string modoRep, string fecCtaCero, string garantia, 
                                                 decimal credMax, decimal saldoAct, decimal limCred, decimal saldoVenc, decimal pagosVenc, 
                                                 string formaPago, string histPago, string fecRecHistPago, string fecAntHistPago, 
                                                 string cveObs, int totalPagos, int totalPagosMOP02, int totalPagosMOP03, int totalPagosMOP04, 
                                                 int totalPagosMOP05, decimal impSaldoMora, string fecSaldoMora, string MOPHistorico, 
                                                 string fecRestruc, string anio1, string anio2, string anio3, string mes1, string mes2, string mes3,
                                                 string segMes1, string segMes2, string segMes3)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("pFECACT", OracleDbType.Varchar2),
                                               new OracleParameter("pREGIMP", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGOTOR", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMOTOR", OracleDbType.Varchar2),
                                               new OracleParameter("pSIC", OracleDbType.Varchar2),
                                               new OracleParameter("pCUENTA", OracleDbType.Varchar2),
                                               new OracleParameter("pTIPORESP", OracleDbType.Varchar2),
                                               new OracleParameter("pTIPOCTA", OracleDbType.Varchar2),
                                               new OracleParameter("pTIPOCONT", OracleDbType.Varchar2), 
                                               new OracleParameter("pCDGMO", OracleDbType.Varchar2),
                                               new OracleParameter("pVALORACT", OracleDbType.Decimal),
                                               new OracleParameter("pNUMPAGOS", OracleDbType.Int32),
                                               new OracleParameter("pFRECPAGOS", OracleDbType.Varchar2),
                                               new OracleParameter("pMONTO", OracleDbType.Decimal),
                                               new OracleParameter("pFECCTA", OracleDbType.Varchar2),
                                               new OracleParameter("pFECULTPAGO", OracleDbType.Varchar2),
                                               new OracleParameter("pFECULTCOMP", OracleDbType.Varchar2),
                                               new OracleParameter("pFECFINCTA", OracleDbType.Varchar2),
                                               new OracleParameter("pFECREP", OracleDbType.Varchar2),
                                               new OracleParameter("pMODOREP", OracleDbType.Varchar2),
                                               new OracleParameter("pFECCTACERO", OracleDbType.Varchar2),
                                               new OracleParameter("pGARANTIA", OracleDbType.Varchar2),
                                               new OracleParameter("pCREDMAX", OracleDbType.Decimal),
                                               new OracleParameter("pSALDOACT", OracleDbType.Decimal),
                                               new OracleParameter("pLIMCRED", OracleDbType.Decimal),
                                               new OracleParameter("pSALDOVENC", OracleDbType.Decimal),
                                               new OracleParameter("pPAGOSVENC", OracleDbType.Decimal),
                                               new OracleParameter("pFORMAPAGO", OracleDbType.Varchar2),
                                               new OracleParameter("pHISTPAGO", OracleDbType.Varchar2),
                                               new OracleParameter("pFECRECHPAGO", OracleDbType.Varchar2),
                                               new OracleParameter("pFECANTHPAGO", OracleDbType.Varchar2),
                                               new OracleParameter("pCVEOBS", OracleDbType.Varchar2),
                                               new OracleParameter("pTOTALPAGOS", OracleDbType.Int32),
                                               new OracleParameter("pPAGOSMOP02", OracleDbType.Int32),
                                               new OracleParameter("pPAGOSMOP03", OracleDbType.Int32),
                                               new OracleParameter("pPAGOSMOP04", OracleDbType.Int32),
                                               new OracleParameter("pPAGOSMOP05", OracleDbType.Int32),
                                               new OracleParameter("pIMPSALDOMORA", OracleDbType.Decimal),
                                               new OracleParameter("pFECSALDOMORA", OracleDbType.Varchar2),
                                               new OracleParameter("pMOPHIST", OracleDbType.Varchar2),
                                               new OracleParameter("pFECREST", OracleDbType.Varchar2),

                                               new OracleParameter("pANIO1", OracleDbType.Varchar2),
                                               new OracleParameter("pANIO2", OracleDbType.Varchar2),
                                               new OracleParameter("pANIO3", OracleDbType.Varchar2),
                                               new OracleParameter("pMES1", OracleDbType.Varchar2),
                                               new OracleParameter("pMES2", OracleDbType.Varchar2),
                                               new OracleParameter("pMES3", OracleDbType.Varchar2),
                                               new OracleParameter("pSEGMES1", OracleDbType.Varchar2),
                                               new OracleParameter("pSEGMES2", OracleDbType.Varchar2),
                                               new OracleParameter("pSEGMES3", OracleDbType.Varchar2),

                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = acred;
        OracleParameters[2].Value = fecAct;
        OracleParameters[3].Value = regImp;
        OracleParameters[4].Value = cveOtorga;
        OracleParameters[5].Value = nomOtorga;
        OracleParameters[6].Value = idSIC;
        OracleParameters[7].Value = cuenta;
        OracleParameters[8].Value = tipoRespons;
        OracleParameters[9].Value = tipoCuenta;
        OracleParameters[10].Value = tipoContrato;
        OracleParameters[11].Value = cveMoneda;
        OracleParameters[12].Value = valorActivo;
        OracleParameters[13].Value = numPagos;
        OracleParameters[14].Value = frecPagos;
        OracleParameters[15].Value = montoPagar;
        OracleParameters[16].Value = fecCuenta;
        OracleParameters[17].Value = fecUltPago;
        OracleParameters[18].Value = fecUltCompra;
        OracleParameters[19].Value = fecCierreCta;
        OracleParameters[20].Value = fecRep;
        OracleParameters[21].Value = modoRep;
        OracleParameters[22].Value = fecCtaCero;
        OracleParameters[23].Value = garantia;
        OracleParameters[24].Value = credMax;
        OracleParameters[25].Value = saldoAct;
        OracleParameters[26].Value = limCred;
        OracleParameters[27].Value = saldoVenc;
        OracleParameters[28].Value = pagosVenc;
        OracleParameters[29].Value = formaPago;
        OracleParameters[30].Value = histPago;
        OracleParameters[31].Value = fecRecHistPago;
        OracleParameters[32].Value = fecAntHistPago;
        OracleParameters[33].Value = cveObs;
        OracleParameters[34].Value = totalPagos;
        OracleParameters[35].Value = totalPagosMOP02;
        OracleParameters[36].Value = totalPagosMOP03;
        OracleParameters[37].Value = totalPagosMOP04;
        OracleParameters[38].Value = totalPagosMOP05;
        OracleParameters[39].Value = impSaldoMora;
        OracleParameters[40].Value = fecSaldoMora;
        OracleParameters[41].Value = MOPHistorico;
        OracleParameters[42].Value = fecRestruc;

        OracleParameters[43].Value = anio1;
        OracleParameters[44].Value = anio2;
        OracleParameters[45].Value = anio3;
        OracleParameters[46].Value = mes1;
        OracleParameters[47].Value = mes2;
        OracleParameters[48].Value = mes3;
        OracleParameters[49].Value = segMes1;
        OracleParameters[50].Value = segMes2;
        OracleParameters[51].Value = segMes3;

        OracleParameters[52].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAltaSegDireccion(string empresa, string acred, string dir1, string dir2, string colonia, string municipio, 
                                                    string ciudad, string estado, string codPostal, string fecResid, string telefono, string ext, 
                                                    string fax, string tipoDom, string indEspDom, string fecRepDir)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("pDIR1", OracleDbType.Varchar2),
                                               new OracleParameter("pDIR2", OracleDbType.Varchar2),
                                               new OracleParameter("pCOLONIA", OracleDbType.Varchar2),
                                               new OracleParameter("pMUNIC", OracleDbType.Varchar2),
                                               new OracleParameter("pCIUDAD", OracleDbType.Varchar2),
                                               new OracleParameter("pESTADO", OracleDbType.Varchar2),
                                               new OracleParameter("pCODPOSTAL", OracleDbType.Varchar2),
                                               new OracleParameter("pFECRESID", OracleDbType.Varchar2),
                                               new OracleParameter("pTELEFONO", OracleDbType.Varchar2), 
                                               new OracleParameter("pEXT", OracleDbType.Varchar2),
                                               new OracleParameter("pFAX", OracleDbType.Varchar2),
                                               new OracleParameter("pTIPODOM", OracleDbType.Varchar2),
                                               new OracleParameter("pINDESPDOM", OracleDbType.Varchar2),
                                               new OracleParameter("pFECREPDIR", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = acred;
        OracleParameters[2].Value = dir1;
        OracleParameters[3].Value = dir2;
        OracleParameters[4].Value = colonia;
        OracleParameters[5].Value = municipio;
        OracleParameters[6].Value = ciudad;
        OracleParameters[7].Value = estado;
        OracleParameters[8].Value = codPostal;
        OracleParameters[9].Value = fecResid;
        OracleParameters[10].Value = telefono;
        OracleParameters[11].Value = ext;
        OracleParameters[12].Value = fax;
        OracleParameters[13].Value = tipoDom;
        OracleParameters[14].Value = indEspDom;
        OracleParameters[15].Value = fecRepDir;
        OracleParameters[16].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAltaSegNombre(string empresa, string acred, string primape, string segape,
                                                 string opcape, string nombre1, string nombre2, string fecNac,
                                                 string rfc, string prefPers, string subfijo, string nac,
                                                 string resid, string licencia, string edoCivil, string sexo,
                                                 string cedula, string ife, string impOtroPai, string otroPai,
                                                 int depend, string edadDepend, string fecInfoDepend, string fecDefunc)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("pPRIMAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pSEGAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pOPCAPE", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMBRE1", OracleDbType.Varchar2),
                                               new OracleParameter("pNOMBRE2", OracleDbType.Varchar2),
                                               new OracleParameter("pNACIMIENTO", OracleDbType.Varchar2),
                                               new OracleParameter("pRFC", OracleDbType.Varchar2),
                                               new OracleParameter("pPREFPERS", OracleDbType.Varchar2),
                                               new OracleParameter("pSUBFIJO", OracleDbType.Varchar2), 
                                               new OracleParameter("pNAC", OracleDbType.Varchar2),
                                               new OracleParameter("pRESID", OracleDbType.Varchar2),
                                               new OracleParameter("pLICENCIA", OracleDbType.Varchar2),
                                               new OracleParameter("pEDOCIVIL", OracleDbType.Varchar2),
                                               new OracleParameter("pSEXO", OracleDbType.Varchar2),
                                               new OracleParameter("pCEDULA", OracleDbType.Varchar2),
                                               new OracleParameter("pIFE", OracleDbType.Varchar2),
                                               new OracleParameter("pIMPOTROPAI", OracleDbType.Varchar2),
                                               new OracleParameter("pOTROPAI", OracleDbType.Varchar2),
                                               new OracleParameter("pDEPEND", OracleDbType.Int32),
                                               new OracleParameter("pEDADDEPEND", OracleDbType.Varchar2),
                                               new OracleParameter("pFECINFODEPEND", OracleDbType.Varchar2),
                                               new OracleParameter("pFECDEFUNC", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = acred;
        OracleParameters[2].Value = primape;
        OracleParameters[3].Value = segape;
        OracleParameters[4].Value = opcape;
        OracleParameters[5].Value = nombre1;
        OracleParameters[6].Value = nombre2;
        OracleParameters[7].Value = fecNac;
        OracleParameters[8].Value = rfc;
        OracleParameters[9].Value = prefPers;
        OracleParameters[10].Value = subfijo;
        OracleParameters[11].Value = nac;
        OracleParameters[12].Value = resid;
        OracleParameters[13].Value = licencia;
        OracleParameters[14].Value = edoCivil;
        OracleParameters[15].Value = sexo;
        OracleParameters[16].Value = cedula;
        OracleParameters[17].Value = ife;
        OracleParameters[18].Value = impOtroPai;
        OracleParameters[19].Value = otroPai;
        OracleParameters[20].Value = depend;
        OracleParameters[21].Value = edadDepend;
        OracleParameters[22].Value = fecInfoDepend;
        OracleParameters[23].Value = fecDefunc;
        OracleParameters[24].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAltaSegResumen(string empresa, string acred, string fecRegBuro, int numMOP07, int numMOP06, 
                                                  int numMOP05, int numMOP04, int numMOP03, int numMOP02, int numMOP01, int numMOP00, 
                                                  int numMOPUR, int numCtas, int numCtasFijos, int numCtasRev, int numCtasCer, int numCtasNeg, 
                                                  int numCtasMOP, int numCtasDisp, int numSolic, string indNvaDir, string mensaje,
                                                  string indExistDec, string cveMoneda, decimal totCredMaxRev, decimal totLimCredRev,
                                                  decimal totSdoActRev, decimal totSdoVencRev, decimal totPagosRev, int porcLimCredRev,
                                                  decimal totCredMaxFijos, decimal totSdoActFijos, decimal totSdoVencFijos, decimal impTotPagFijos,
                                                  int numMOP96, int numMOP97, int numMOP99, string fecCtaAnt, string fecCtaRec, int numTotSolicRep,
                                                  string fecRecRep, int numTotCtasCob, string fecCtaRecCob, int numTotSolicCob, string fecSolicCob)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("pFECREGBURO", OracleDbType.Varchar2),
                                               new OracleParameter("pNUMMOP07", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP06", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP05", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP04", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP03", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP02", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP01", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP00", OracleDbType.Int32), 
                                               new OracleParameter("pNUMMOPUR", OracleDbType.Int32),
                                               new OracleParameter("pNUMCTAS", OracleDbType.Int32),
                                               new OracleParameter("pNUMCTASFIJOS", OracleDbType.Int32),
                                               new OracleParameter("pNUMCTASREV", OracleDbType.Int32),
                                               new OracleParameter("pNUMCTASCER", OracleDbType.Int32),
                                               new OracleParameter("pNUMCTASNEG", OracleDbType.Int32),
                                               new OracleParameter("pNUMCTASMOP", OracleDbType.Int32),
                                               new OracleParameter("pNUMCTASDISP", OracleDbType.Int32),
                                               new OracleParameter("pNUMSOLIC", OracleDbType.Int32),
                                               new OracleParameter("pINDNVADIR", OracleDbType.Varchar2),
                                               new OracleParameter("pMENSAJE", OracleDbType.Varchar2),
                                               new OracleParameter("pINDEXISTDEC", OracleDbType.Varchar2),
                                               new OracleParameter("pCVEMONEDA", OracleDbType.Varchar2),
                                               new OracleParameter("pTOTCREDMAXREV", OracleDbType.Decimal),
                                               new OracleParameter("pTOTLIMCREDREV", OracleDbType.Decimal),
                                               new OracleParameter("pTOTSDOACTREV", OracleDbType.Decimal),
                                               new OracleParameter("pTOTSDOVENCREV", OracleDbType.Decimal),
                                               new OracleParameter("pTOTPAGREV", OracleDbType.Decimal),
                                               new OracleParameter("pPORCLIMCREDREV", OracleDbType.Int32),
                                               new OracleParameter("pTOTCREDMAXFIJOS", OracleDbType.Decimal),
                                               new OracleParameter("pTOTSDOACTFIJOS", OracleDbType.Decimal),
                                               new OracleParameter("pTOTSDOVENCFIJOS", OracleDbType.Decimal),
                                               new OracleParameter("pIMPTOTPAGFIJOS", OracleDbType.Decimal),
                                               new OracleParameter("pNUMMOP96", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP97", OracleDbType.Int32),
                                               new OracleParameter("pNUMMOP99", OracleDbType.Int32),
                                               new OracleParameter("pFECCTAANT", OracleDbType.Varchar2),
                                               new OracleParameter("pFECCTAREC", OracleDbType.Varchar2),
                                               new OracleParameter("pNUMTOTSOLICREP", OracleDbType.Int32),
                                               new OracleParameter("pFECRECREP", OracleDbType.Varchar2),
                                               new OracleParameter("pNUMTOTCTASCOB", OracleDbType.Int32),
                                               new OracleParameter("pFECCTARECCOB", OracleDbType.Varchar2),
                                               new OracleParameter("pNUMTOTSOLICCOB", OracleDbType.Int32),
                                               new OracleParameter("pFECSOLICCOB", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = acred;
        OracleParameters[2].Value = fecRegBuro;
        OracleParameters[3].Value = numMOP07;
        OracleParameters[4].Value = numMOP06;
        OracleParameters[5].Value = numMOP05;
        OracleParameters[6].Value = numMOP04;
        OracleParameters[7].Value = numMOP03;
        OracleParameters[8].Value = numMOP02;
        OracleParameters[9].Value = numMOP01;
        OracleParameters[10].Value = numMOP00;
        OracleParameters[11].Value = numMOPUR;
        OracleParameters[12].Value = numCtas;
        OracleParameters[13].Value = numCtasFijos;
        OracleParameters[14].Value = numCtasRev;
        OracleParameters[15].Value = numCtasCer;
        OracleParameters[16].Value = numCtasNeg;
        OracleParameters[17].Value = numCtasMOP;
        OracleParameters[18].Value = numCtasDisp;
        OracleParameters[19].Value = numSolic;
        OracleParameters[20].Value = indNvaDir;
        OracleParameters[21].Value = mensaje;
        OracleParameters[22].Value = indExistDec;
        OracleParameters[23].Value = cveMoneda;
        OracleParameters[24].Value = totCredMaxRev;
        OracleParameters[25].Value = totLimCredRev;
        OracleParameters[26].Value = totSdoActRev;
        OracleParameters[27].Value = totSdoVencRev;
        OracleParameters[28].Value = totPagosRev;
        OracleParameters[29].Value = porcLimCredRev;
        OracleParameters[30].Value = totCredMaxFijos;
        OracleParameters[31].Value = totSdoActFijos;
        OracleParameters[32].Value = totSdoVencFijos;
        OracleParameters[33].Value = impTotPagFijos;
        OracleParameters[34].Value = numMOP96;
        OracleParameters[35].Value = numMOP97;
        OracleParameters[36].Value = numMOP99;
        OracleParameters[37].Value = fecCtaAnt;
        OracleParameters[38].Value = fecCtaRec;
        OracleParameters[39].Value = numTotSolicRep;
        OracleParameters[40].Value = fecRecRep;
        OracleParameters[41].Value = numTotCtasCob;
        OracleParameters[42].Value = fecCtaRecCob;
        OracleParameters[43].Value = numTotSolicCob;
        OracleParameters[44].Value = fecSolicCob;
        OracleParameters[45].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAnalisisCobranza(string empresa, DateTime fecha, int tipoCart, string usuario,
                                                    string coord, string asesor, string supervisor)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("vCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("vSUCURSAL", OracleDbType.Varchar2),
                                               new OracleParameter("vASESOR", OracleDbType.Varchar2),
                                               new OracleParameter("dFECHAHASTA", OracleDbType.Date),
                                               new OracleParameter("vUSUARIO", OracleDbType.Varchar2),                                        
                                               new OracleParameter("vSUPERVISOR", OracleDbType.Varchar2),
                                               new OracleParameter("vTIPOCART", OracleDbType.Varchar2) };

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = coord;
        OracleParameters[2].Value = asesor;
        OracleParameters[3].Value = fecha;
        OracleParameters[4].Value = usuario;
        OracleParameters[5].Value = supervisor;
        OracleParameters[6].Value = tipoCart;

        return OracleParameters;
    }

    public OracleParameter[] ParamsAsignaFondeo(string empresa, string orgFond, string lineaCred, string disp,
                                                int tipo, string info, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGORF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLC", OracleDbType.Varchar2),
                                               new OracleParameter("prmDISP", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("prmCADENA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = orgFond;
        OracleParameters[2].Value = lineaCred;
        OracleParameters[3].Value = disp;
        OracleParameters[4].Value = tipo;
        OracleParameters[5].Value = info;
        OracleParameters[6].Value = usuario;
        OracleParameters[7].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsBandas(string empresa, DateTime fecha, int tipoCart, string usuario, string region,
                                           string coord, string asesor)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("vCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("dFECHAPAGOS", OracleDbType.Date),
                                               new OracleParameter("vREGION", OracleDbType.Varchar2),
                                               new OracleParameter("vSUCURSAL", OracleDbType.Varchar2),
                                               new OracleParameter("vASESOR", OracleDbType.Varchar2), 
                                               new OracleParameter("vUSUARIO", OracleDbType.Varchar2),
                                               new OracleParameter("vTIPOCAR", OracleDbType.Int32)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fecha;
        OracleParameters[2].Value = region;
        OracleParameters[3].Value = coord;
        OracleParameters[4].Value = asesor;
        OracleParameters[5].Value = usuario;
        OracleParameters[6].Value = tipoCart;

        return OracleParameters;
    }

    public OracleParameter[] ParamsBloqueaAcred(string empresa, string codigo, string accion, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmACCION", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 500)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = accion;
        OracleParameters[3].Value = usuario;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsBloqueaSolic(string empresa, string codigo, string ciclo, string clns, string accion,
                                                string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmACCION", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 500)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = clns;
        OracleParameters[4].Value = accion;
        OracleParameters[5].Value = usuario;
        OracleParameters[6].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsCargaArchivoTablaAmort(string empresa, string codigo, string ciclo, int[] noPago, string[] fecIni, 
                                                          string[] fecFin, string[] fecha, decimal[] importe, decimal[] capital, 
                                                          decimal[] interes, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_NOPAGO", OracleDbType.Int32),
                                               new OracleParameter("prmT_FECINI", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_FECFIN", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_FECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmT_IMPORTE", OracleDbType.Decimal),
                                               new OracleParameter("prmT_CAPITAL", OracleDbType.Decimal),
                                               new OracleParameter("prmT_INTERES", OracleDbType.Decimal),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[3].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[4].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[5].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[6].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[7].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[8].CollectionType = OracleCollectionType.PLSQLAssociativeArray;
        OracleParameters[9].CollectionType = OracleCollectionType.PLSQLAssociativeArray;

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = noPago;
        OracleParameters[4].Value = fecIni;
        OracleParameters[5].Value = fecFin;
        OracleParameters[6].Value = fecha;
        OracleParameters[7].Value = importe;
        OracleParameters[8].Value = capital;
        OracleParameters[9].Value = interes;
        OracleParameters[10].Value = usuario;
        OracleParameters[11].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsConciliacionGL(string empresa, string fecha, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pFECHA", OracleDbType.Date),
                                               new OracleParameter("pCDGPE", OracleDbType.Varchar2)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fecha;
        OracleParameters[2].Value = usuario;

        return OracleParameters;
    }

    public OracleParameter[] ParamsConciliacionPagos(string empresa, DateTime fecha, string coord, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pFECHA", OracleDbType.Date),
                                               new OracleParameter("pCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPE", OracleDbType.Varchar2)};


        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fecha;
        OracleParameters[2].Value = coord;
        OracleParameters[3].Value = usuario;

        return OracleParameters;
    }

    public OracleParameter[] ParamsChqImp(string empresa, string fechaIni, string fechaFin, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHAINI", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHAFIN", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fechaIni;
        OracleParameters[2].Value = fechaFin;
        OracleParameters[3].Value = usuario;
        
        return OracleParameters;
    }

    public OracleParameter[] ParamsCodigoAcred(string empresa)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Direction = ParameterDirection.Output;
        
        return OracleParameters;
    }

    public OracleParameter[] ParamsControlSecuencia(string empresa, string cuenta, string usuario, string fecha, string tipo, string info)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("pFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("pTIPO", OracleDbType.Varchar2),
                                               new OracleParameter("pINFO", OracleDbType.Varchar2),
                                               new OracleParameter("pSEC", OracleDbType.Varchar2,200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cuenta;
        OracleParameters[2].Value = usuario;
        OracleParameters[3].Value = fecha;
        OracleParameters[4].Value = tipo;
        OracleParameters[5].Value = info;
        OracleParameters[6].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsDevGarantia(string empresa, string devolucion, string grupo, string clns, string refer, 
                                               int secPago, string fecha, decimal monto, string cuenta, string cheque, 
                                               string codAcred, string acred, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOMOV", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmREFER", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmSECPAGO", OracleDbType.Int32),
                                               new OracleParameter("prmMONTO", OracleDbType.Decimal),
                                               new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmNOMCL", OracleDbType.Varchar2),
                                               new OracleParameter("prmCHEQUE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("vMENSAJE", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = devolucion;
        OracleParameters[2].Value = grupo;
        OracleParameters[3].Value = refer;
        OracleParameters[4].Value = clns;
        OracleParameters[5].Value = secPago;
        OracleParameters[6].Value = monto;
        OracleParameters[7].Value = cuenta;
        OracleParameters[8].Value = fecha;
        OracleParameters[9].Value = codAcred;
        OracleParameters[10].Value = acred;
        OracleParameters[11].Value = cheque;
        OracleParameters[12].Value = usuario;    
        OracleParameters[13].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsElimAcred(string empresa, DateTime fecha, string acred, string grupo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("pCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("pFECHA", OracleDbType.Date),
                                               new OracleParameter("pCDGCL", OracleDbType.Varchar2),
                                               new OracleParameter("pCDGNS", OracleDbType.Varchar2),
                                               new OracleParameter("pRES", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fecha;
        OracleParameters[2].Value = acred;
        OracleParameters[3].Value = grupo;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsElimGrupo(string empresa, string grupo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmGRUPO", OracleDbType.Varchar2),
                                               new OracleParameter("prmRES", OracleDbType.Varchar2, 500)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsElimProdCred(string empresa, string tipoProd, string prodCred)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGTPC", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPCR", OracleDbType.Varchar2),
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 500)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = tipoProd;
        OracleParameters[2].Value = prodCred;
        OracleParameters[3].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsElimSolic(string empresa, string grupo, string ciclo, string clns, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmUSER", OracleDbType.Varchar2), 
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 500)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = clns;
        OracleParameters[3].Value = ciclo;
        OracleParameters[4].Value = usuario;
        OracleParameters[5].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsElimSolicDisp(string empresa, string grupo, string ciclo, string clns, string autorCrr, 
                                                 string secuencia, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmAUTORCRR", OracleDbType.Varchar2),
                                               new OracleParameter("prmSECUENCIA", OracleDbType.Varchar2),
                                               new OracleParameter("prmUSER", OracleDbType.Varchar2), 
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 500)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = clns;
        OracleParameters[3].Value = ciclo;
        OracleParameters[4].Value = autorCrr;
        OracleParameters[5].Value = secuencia;
        OracleParameters[6].Value = usuario;
        OracleParameters[7].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsImpContrato(string empresa, string codigo, string ciclo, string tipoCred, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 500)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = tipoCred;
        OracleParameters[4].Value = usuario;
        OracleParameters[5].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsImpDocumento(string empresa, string codigo, string ciclo, string tipoCred, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2), 
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 500)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = tipoCred;
        OracleParameters[4].Value = usuario;
        OracleParameters[5].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsInfoGrupo(string empresa, string grupo, string ciclo, string clns)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2) };
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = clns;

        return OracleParameters;
    }

    public OracleParameter[] ParamsInfoFondeo(string empresa, int tipo, string orgFond, string lineaCred, string disp,
                                              decimal importe, decimal montoMax, string fecIni, string fecFin, string sexo,
                                              string region, string coord, string entFed, string munic, string localidad, 
                                              string usuario, string fecSaldo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGORF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLC", OracleDbType.Varchar2),
                                               new OracleParameter("prmDISP", OracleDbType.Varchar2),
                                               new OracleParameter("prmIMPORTE", OracleDbType.Decimal),
                                               new OracleParameter("prmMONTOMAX", OracleDbType.Decimal),
                                               new OracleParameter("prmFECHAINI", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHAFIN", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEXO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGRG", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGEF", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGMU", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Int32),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECSDO", OracleDbType.Varchar2), 
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 5000)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = orgFond;
        OracleParameters[2].Value = lineaCred;
        OracleParameters[3].Value = disp;
        OracleParameters[4].Value = importe;
        OracleParameters[5].Value = montoMax;
        OracleParameters[6].Value = fecIni;
        OracleParameters[7].Value = fecFin;
        OracleParameters[8].Value = sexo;
        OracleParameters[9].Value = region;
        OracleParameters[10].Value = coord;
        OracleParameters[11].Value = entFed;
        OracleParameters[12].Value = munic;
        OracleParameters[13].Value = localidad;
        OracleParameters[14].Value = tipo;
        OracleParameters[15].Value = usuario;
        OracleParameters[16].Value = fecSaldo;
        OracleParameters[17].Direction = ParameterDirection.Output;

        return OracleParameters;
    }


    public OracleParameter[] ParamsLimpiaMascarilla()
    {
        OracleParameter[] OracleParameters = {   new OracleParameter("prmMensaje", OracleDbType.Varchar2,200)};

        OracleParameters[0].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsModHorario(string empresa, string grupo, string ciclo, int diaJunta, string horario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGNS", OracleDbType.Varchar2), 
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmDIAJUNTA", OracleDbType.Int32),
                                               new OracleParameter("prmDIAJUNTA", OracleDbType.Varchar2), 
                                               new OracleParameter("vMensaje", OracleDbType.Varchar2, 5000) };
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = diaJunta;
        OracleParameters[4].Value = horario;
        OracleParameters[5].Direction = ParameterDirection.Output;

        return OracleParameters;
    }
    
    public OracleParameter[] ParamsMora(string empresa, DateTime fecha, int nivel, int tipoCart, string usuario, string region,
                                           string coord, string asesor)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("vCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("dFECHAHASTA", OracleDbType.Date),
                                               new OracleParameter("vNIVEL", OracleDbType.Int32),
                                               new OracleParameter("vUSUARIO", OracleDbType.Varchar2),
                                               new OracleParameter("vREGION", OracleDbType.Varchar2),
                                               new OracleParameter("vSUCURSAL", OracleDbType.Varchar2),
                                               new OracleParameter("vASESOR", OracleDbType.Varchar2), 
                                               new OracleParameter("vTIPOCAR", OracleDbType.Int32) };

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fecha;
        OracleParameters[2].Value = nivel;
        OracleParameters[3].Value = usuario;
        OracleParameters[4].Value = region;
        OracleParameters[5].Value = coord;
        OracleParameters[6].Value = asesor;
        OracleParameters[7].Value = tipoCart;

        return OracleParameters;
    }

    public OracleParameter[] ParamsNvoCiclo(string empresa, string codigo, string tipo)
    {
        OracleParameter[] OracleParameters = {   new OracleParameter("prmEMPRESA", OracleDbType.Varchar2),   
                                                 new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                                 new OracleParameter("prmTIPO", OracleDbType.Varchar2),
                                                 new OracleParameter("prmCICLO", OracleDbType.Varchar2,200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = tipo;
        OracleParameters[3].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsPagos(string empresa, string grupo, string tipoGrupo, string cuenta, DateTime fecha, decimal monto, string usuario, string sucursal, string tipo)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                               new OracleParameter("prmFDEPOSITO", OracleDbType.Date),
                                               new OracleParameter("prmCANTIDAD", OracleDbType.Decimal),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCO", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Varchar2) };
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = tipoGrupo;
        OracleParameters[3].Value = cuenta;
        OracleParameters[4].Value = fecha;
        OracleParameters[5].Value = monto;
        OracleParameters[6].Value = usuario;
        OracleParameters[7].Value = sucursal;
        OracleParameters[8].Value = tipo;

        return OracleParameters;
    }

    public OracleParameter[] ParamsPagosNoRecibidosDia(string empresa, DateTime fecha, int tipoCart, string usuario, string region,
                                                       string coord, string asesor)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("vCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("dFECHAHASTA", OracleDbType.Date),
                                               new OracleParameter("vUSUARIO", OracleDbType.Varchar2),
                                               new OracleParameter("vREGION", OracleDbType.Varchar2),
                                               new OracleParameter("vSUCURSAL", OracleDbType.Varchar2),
                                               new OracleParameter("vASESOR", OracleDbType.Varchar2),
                                               new OracleParameter("vTIPOCAR", OracleDbType.Int32) };
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fecha;
        OracleParameters[2].Value = usuario;
        OracleParameters[3].Value = region;
        OracleParameters[4].Value = coord;
        OracleParameters[5].Value = asesor;
        OracleParameters[6].Value = tipoCart;

        return OracleParameters;
    }

    public OracleParameter[] ParamsPrestamos(string empresa, string fecIniDesde, string fecIniHasta, string usuario, string region, 
                                             string coord, string asesor, string fecPagos, int tipoCart, int sitSaldo, int sitLiq, 
                                             int sitCart, int sitTes, int sitDev, int ciclos, string fecFinDesde, string fecFinHasta)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECINIDESDE", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECINIHASTA", OracleDbType.Varchar2),
                                               new OracleParameter("prmUSUARIO", OracleDbType.Varchar2),
                                               new OracleParameter("prmREGION", OracleDbType.Varchar2),
                                               new OracleParameter("prmSUCURSAL", OracleDbType.Varchar2),
                                               new OracleParameter("prmASESOR", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECPAGOS", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPOCAR", OracleDbType.Int32),
                                               new OracleParameter("prmSITSALDO", OracleDbType.Int32),
                                               new OracleParameter("prmSITLIQ", OracleDbType.Int32),
                                               new OracleParameter("prmSITCART", OracleDbType.Int32),
                                               new OracleParameter("prmSITTES", OracleDbType.Int32),
                                               new OracleParameter("prmSITDEV", OracleDbType.Int32),
                                               new OracleParameter("prmCICLOS", OracleDbType.Int32),
                                               new OracleParameter("prmFECFINDESDE", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECFINHASTA", OracleDbType.Varchar2)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fecIniDesde;
        OracleParameters[2].Value = fecIniHasta;
        OracleParameters[3].Value = usuario;
        OracleParameters[4].Value = region;
        OracleParameters[5].Value = coord;
        OracleParameters[6].Value = asesor;
        OracleParameters[7].Value = fecPagos;
        OracleParameters[8].Value = tipoCart;
        OracleParameters[9].Value = sitSaldo;
        OracleParameters[10].Value = sitLiq;
        OracleParameters[11].Value = sitCart;
        OracleParameters[12].Value = sitTes;
        OracleParameters[13].Value = sitDev;
        OracleParameters[14].Value = ciclos;
        OracleParameters[15].Value = fecFinDesde;
        OracleParameters[16].Value = fecFinHasta;

        return OracleParameters;
    }

    public OracleParameter[] ParamsProcesaAlerta(string empresa, string alta, string sec, string tipo, string cdgFunc, string dictamen, string justifica,
                                                 string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmALTA", OracleDbType.Varchar2),
                                               new OracleParameter("prmSEC", OracleDbType.Varchar2),
                                               new OracleParameter("prmTIPO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGFUNC", OracleDbType.Varchar2),
                                               new OracleParameter("prmDICTAMEN", OracleDbType.Varchar2),
                                               new OracleParameter("prmJUSTIFICA", OracleDbType.Clob),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 200)};
        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = alta;
        OracleParameters[2].Value = sec;
        OracleParameters[3].Value = tipo;
        OracleParameters[4].Value = cdgFunc;
        OracleParameters[5].Value = dictamen;
        OracleParameters[6].Value = justifica;
        OracleParameters[7].Value = usuario;
        OracleParameters[8].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsRegistroAjuste(string empresa, string grupo, string ciclo, string clns, string fecha, decimal capital, 
                                                  decimal interes, decimal moratorios, string justifica, string observaciones, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCAPITAL", OracleDbType.Decimal),
                                               new OracleParameter("prmINTERES", OracleDbType.Decimal),
                                               new OracleParameter("prmMORATORIOS", OracleDbType.Decimal),
                                               new OracleParameter("prmJUSTIFICA", OracleDbType.Varchar2),
                                               new OracleParameter("prmOBSERV", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = grupo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = clns;
        OracleParameters[4].Value = fecha;
        OracleParameters[5].Value = capital;
        OracleParameters[6].Value = interes;
        OracleParameters[7].Value = moratorios;
        OracleParameters[8].Value = justifica;
        OracleParameters[9].Value = observaciones;
        OracleParameters[10].Value = usuario;
        OracleParameters[11].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsRegOpPreocupante(string empresa, string descipcion)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmDESC", OracleDbType.Clob),
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = descipcion;
        OracleParameters[2].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsRegAjusteComSeg(string empresa, string codigo, string ciclo, string clns, string fecha, decimal comision,
                                                  decimal seguro, string justifica, string observaciones, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCOMISION", OracleDbType.Decimal),
                                               new OracleParameter("prmSEGURO", OracleDbType.Decimal),
                                               new OracleParameter("prmJUSTIFICA", OracleDbType.Varchar2),
                                               new OracleParameter("prmOBSERV", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = clns;
        OracleParameters[4].Value = fecha;
        OracleParameters[5].Value = comision;
        OracleParameters[6].Value = seguro;
        OracleParameters[7].Value = justifica;
        OracleParameters[8].Value = observaciones;
        OracleParameters[9].Value = usuario;
        OracleParameters[10].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsRegAjusteDevengo(string empresa, string codigo, string ciclo, string clns, string fecha,
                                                    decimal interes, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmINTERES", OracleDbType.Decimal),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = clns;
        OracleParameters[4].Value = fecha;
        OracleParameters[5].Value = interes;
        OracleParameters[6].Value = usuario;
        OracleParameters[7].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsRegDoc(string empresa, string codigo, string repo, string archivo, string formato, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmCODIGO", OracleDbType.Varchar2),
                                               new OracleParameter("prmREPO", OracleDbType.Varchar2),
                                               new OracleParameter("prmARCHIVO", OracleDbType.Varchar2),
                                               new OracleParameter("prmFORMATO", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = codigo;
        OracleParameters[2].Value = repo;
        OracleParameters[3].Value = archivo;
        OracleParameters[4].Value = formato;
        OracleParameters[5].Value = usuario;
        OracleParameters[6].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsRegSolicTrans(string empresa, string fecha, string usuario)
    {
        OracleParameter[] OracleParameters = { new OracleParameter("prmCDGEM", OracleDbType.Varchar2),
                                               new OracleParameter("prmFECHA", OracleDbType.Varchar2),
                                               new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                               new OracleParameter("prmMENSAJE", OracleDbType.Varchar2, 200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = fecha;
        OracleParameters[2].Value = usuario;
        OracleParameters[3].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsSituacionSolic(string empresa, string cdgclns, string clns)
    {
        OracleParameter[] OracleParameters = {   new OracleParameter("prmEMPRESA", OracleDbType.Varchar2),   
                                                 new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                                 new OracleParameter("prmCLNS", OracleDbType.Varchar2),       
                                                 new OracleParameter("prmMensaje", OracleDbType.Varchar2,200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cdgclns;
        OracleParameters[2].Value = clns;
        OracleParameters[3].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsValidaPagosGrals(string empresa, decimal monto, DateTime fecha, string cuenta)
    {
        OracleParameter[] OracleParameters = {   new OracleParameter("prmCDGEM", OracleDbType.Varchar2),  
                                                 new OracleParameter("prmMONTO", OracleDbType.Decimal),   
                                                 new OracleParameter("prmFECHA", OracleDbType.Date),
                                                 new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                                 new OracleParameter("prmMensaje", OracleDbType.Varchar2,1000)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = monto;
        OracleParameters[2].Value = fecha;
        OracleParameters[3].Value = cuenta;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsValidaRangoCheques(string empresa, string coord, string cuenta, string chqFin)
    {
        OracleParameter[] OracleParameters = {   new OracleParameter("prmCDGEM", OracleDbType.Varchar2),   
                                                 new OracleParameter("prmCDGCO", OracleDbType.Varchar2),
                                                 new OracleParameter("prmCDGCB", OracleDbType.Varchar2),
                                                 new OracleParameter("prmCHQFIN", OracleDbType.Varchar2),
                                                 new OracleParameter("prmMensaje", OracleDbType.Varchar2,200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = coord;
        OracleParameters[2].Value = cuenta;
        OracleParameters[3].Value = chqFin;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsValidaSituacionAcred(string empresa, string acred, string usuario)
    {
        OracleParameter[] OracleParameters = {   new OracleParameter("prmCDGEM", OracleDbType.Varchar2),   
                                                 new OracleParameter("prmCDGCL", OracleDbType.Varchar2),
                                                 new OracleParameter("prmCDGPE", OracleDbType.Varchar2),
                                                 new OracleParameter("prmMensaje", OracleDbType.Varchar2,200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = acred;
        OracleParameters[2].Value = usuario;
        OracleParameters[3].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    public OracleParameter[] ParamsValidaSituacionCredito(string empresa, string cdgclns, string ciclo, string clns)
    {
        OracleParameter[] OracleParameters = {   new OracleParameter("prmCDGEM", OracleDbType.Varchar2),   
                                                 new OracleParameter("prmCDGCLNS", OracleDbType.Varchar2),
                                                 new OracleParameter("prmCICLO", OracleDbType.Varchar2),
                                                 new OracleParameter("prmCLNS", OracleDbType.Varchar2),
                                                 new OracleParameter("prmMensaje", OracleDbType.Varchar2,200)};

        OracleParameters[0].Value = empresa;
        OracleParameters[1].Value = cdgclns;
        OracleParameters[2].Value = ciclo;
        OracleParameters[3].Value = clns;
        OracleParameters[4].Direction = ParameterDirection.Output;

        return OracleParameters;
    }

    #endregion

}
