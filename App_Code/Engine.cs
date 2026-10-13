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
/// Summary description for Engine
/// </summary>
public class Engine
{
    public string oradb;
    private OracleConnection OracleConn; 
    private OracleDataAdapter OracleAdap;
    private OracleCommand OracleCmd;
    private Boolean IsTransaction;

    public Engine()
    {
        oradb = ConfigurationManager.AppSettings.Get("Oracle");
    }
    
    #region ConectarOracle

    public Boolean ConectarOracle(Boolean _IsTransaction)
    {
        try
        {
            OracleConn = new OracleConnection(oradb);
            OracleConn.Open();

            if (OracleConn.State == ConnectionState.Open)
                return true;

            IsTransaction = _IsTransaction;
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
        }

        return false;
    }

    #endregion

    #region DesconectarOracle

    public void DesconectarOracle()
    {
        try
        {
            OracleConn.Close();
            OracleConn.Dispose();
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
        }

        return;
    }

    #endregion

    #region myExecuteNonQuery
    /*
    public int myExecuteNonQuery(string SP, OracleParameter[] parameters)
    {        
        oCmd = new OracleCommand();
        int iRes = 0;        

        try
        {
            oCmd.Connection = ConectarOracle();
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.CommandText = SP;
            if (parameters != null)
            {
                foreach (OracleParameter oPar in parameters)    
                    oCmd.Parameters.Add(oPar);
            }
            
            iRes = oCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            iRes = -1;
        }
        finally
        {
            DesconectarOracle();
        }
        return iRes;
    }
    
    public int myExecuteNonQuery(string SP, OracleParameter[] parameters, ref OracleConnection myConn)
    {        
        oCmd = new OracleCommand();
        int iRes = 0;

        try
        {
            oCmd.Connection = myConn;                
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.CommandText = SP;
            if (parameters != null)
            {
                foreach (OracleParameter oPar in parameters)
                    oCmd.Parameters.Add(oPar);
            }           

            oCmd.ExecuteNonQuery();

            iRes = Convert.ToInt32(oCmd.Parameters["P_RESULT"].Value.ToString());
        }
        catch (Exception ex)
        {
            iRes = -1;
        }        
        return iRes;
    }

    public int myExecuteNonQuery_result(string SP, OracleParameter[] parameters, ref OracleConnection myConn)
    {
        oCmd = new OracleCommand();
        int iRes = 0;

        try
        {
            oCmd.Connection = myConn;
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.CommandText = SP;
            if (parameters != null)
            {
                foreach (OracleParameter oPar in parameters)
                    oCmd.Parameters.Add(oPar);
            }

            oCmd.ExecuteNonQuery();

            iRes = Convert.ToInt32(oCmd.Parameters["P_RESULT"].Value.ToString());
        }
        catch (Exception ex)
        {
            iRes = -1;
        }
        return iRes;
    }


    public int myExecuteNonQuery(string SQL, ref OracleConnection myConn)
    {
        oCmd = new OracleCommand();
        int iRes = 0;

        try
        {
            oCmd.Connection = myConn;
            oCmd.CommandType = CommandType.Text;
            oCmd.CommandText = SQL;            

            iRes = oCmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            iRes = -1;
        }        
        return iRes;
    }

    #endregion

    #region myExecuteDataReader

    public int myExecuteDataReader(string SP, OracleParameter[] parameters, ref OracleDataReader drd, ref OracleConnection myConn)
    {
        oCmd = new OracleCommand();
        int iRes = 0;
        try
        {
            oCmd.Connection = myConn;
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.CommandText = SP;
            if (parameters != null)
            {
                foreach (OracleParameter oPar in parameters)
                    oCmd.Parameters.Add(oPar);
            }

            drd = oCmd.ExecuteReader();
            
            return 1;
        }
        catch (Exception ex)
        {
            iRes = -1;
        }
        return iRes;
    }
    #endregion

    #region myExecuteDS

    public int myExecuteDS(string SP, OracleParameter[] parameters, ref DataSet dsResultado)
    {
        int iRes = 0;        
        oCmd = new OracleCommand();
        oDad = new OracleDataAdapter();
        dsResultado = new DataSet();
        
        try
        {
            oCmd.Connection = ConectarOracle();
            oCmd.CommandType = CommandType.StoredProcedure;
            oCmd.CommandText = SP;

            foreach (OracleParameter par in parameters)
                oCmd.Parameters.Add(par);            

            oDad.SelectCommand = oCmd;

            oDad.Fill(dsResultado);

            if (dsResultado.Tables[0].Rows.Count >= 1)
                iRes = 1;
            else
                iRes = 0;
        }
        catch (Exception ex)
        {
            iRes = -1;
        }
        finally
        {
            DesconectarOracle();
        }
        return iRes;
    }
    #endregion

    #region myExecuteScalar
    public int myExecuteScalar(string SQL, ref OracleConnection myConn)
    {
        oCmd = new OracleCommand();
        int iRes = 0;

        try
        {
            oCmd.Connection = myConn;
            oCmd.CommandType = CommandType.Text;
            oCmd.CommandText = SQL;

            iRes = (int)oCmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            iRes = -1;
        }
        return iRes;
    }

    #endregion

    #region getXMLFromProcedure

    public string getXMLFromProcedure(string nameProc, string parameters)
    {
        int count = 0;
        string[] paramList;
        string xml = "";

        try
        {
            ConectarOracle();
            oCmd = new OracleCommand(nameProc, oConn);
            oCmd.CommandType = CommandType.StoredProcedure;
        }
        catch (Exception ex)
        {
            oConn.Close();
            return "-1";
        }

        paramList = parameters.Split('|');

        for (count = 0; count < paramList.Length; count++)
        {
            oCmd.Parameters.Add("param" + count, OracleDbType.Varchar2, ParameterDirection.Input).Value = paramList[count];
        }
        oCmd.Parameters.Add("Result", OracleDbType.Clob, ParameterDirection.Output);
        count = 0;
        try
        {
            OracleParameter paramHavingClobInIt;
            oCmd.ExecuteNonQuery();
            paramHavingClobInIt = oCmd.Parameters["Result"];
            xml = (paramHavingClobInIt.Value as Oracle.DataAccess.Types.OracleClob).Value;


        }
        catch (Exception)
        {
            count = -1;
        }
        finally
        {
            oConn.Close();
        }

        return xml.ToString();
    }
    */
    #endregion

    #region ExecuteDS

    public int ExecuteDS(ref DataSet ds, string sQuery, CommandType ctType, OracleParameter[] colParameters)
    {
        try
        {
            if (!ConectarOracle(false))
                return -1;

            if (OracleConn.State == ConnectionState.Open)
            {
                OracleCmd = new OracleCommand(sQuery, OracleConn);
                OracleCmd.CommandTimeout = 0;

                OracleAdap = new OracleDataAdapter();
                OracleCmd.CommandType = ctType;
                if (colParameters != null)
                    OracleCmd.Parameters.Add(colParameters);
                OracleAdap.SelectCommand = OracleCmd;
                OracleAdap.Fill(ds);

                return 1;
            }
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
        }
        finally
        {
            DesconectarOracle();
        }
        return -2;
    }
    
    public int ExecuteDS(ref DataSet ds, string sQuery, CommandType ctType)
    {
        try
        {
            if (!ConectarOracle(false))
                return -1;

            if (OracleConn.State == ConnectionState.Open)
            {
                OracleCmd = new OracleCommand(sQuery, OracleConn);
                OracleCmd.CommandTimeout = 0;

                OracleAdap = new OracleDataAdapter();
                OracleCmd.CommandType = ctType;
                OracleAdap.SelectCommand = OracleCmd;
                OracleAdap.Fill(ds);
                return 1;
            }
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
        }
        finally
        {
            DesconectarOracle();
        }
        return -2;
    }

    public int myExecuteNonQuery(string sQuery, CommandType ctType, string Connection)
    {
        try
        {
            if (!ConectarOracle(false))
                return -1;

            if (OracleConn.State == ConnectionState.Open)
            {
                OracleCmd = new OracleCommand(sQuery, OracleConn);
                OracleCmd.CommandTimeout = 0;

                OracleAdap = new OracleDataAdapter();
                OracleCmd.CommandType = ctType;
                OracleAdap.SelectCommand = OracleCmd;
                return OracleAdap.SelectCommand.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
        }
        finally
        {
            DesconectarOracle();
        }
        return -2;
    }

    public int myExecuteNonQuery(ref string status, string sQuery, CommandType ctType, OracleParameter[] colParameters)
    {
        int res;
        try
        {
            if (!ConectarOracle(false))
                return -1;

            if (OracleConn.State == ConnectionState.Open)
            {
                OracleCmd = new OracleCommand(sQuery, OracleConn);
                OracleCmd.CommandTimeout = 0;

                OracleAdap = new OracleDataAdapter();
                OracleCmd.CommandType = ctType;
                if (colParameters != null)
                {
                    for (int i = 0; i < colParameters.Length; i++)
                    {
                        OracleCmd.Parameters.Add(colParameters[i]);
                    }
                }
                OracleAdap.SelectCommand = OracleCmd;
                res = OracleAdap.SelectCommand.ExecuteNonQuery();
                status = OracleCmd.Parameters[colParameters.Length - 1].Value.ToString();

                if (res == -1)
                    return 1;
                else
                    return -1;
            }
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
            return -1;
        }
        finally
        {
            DesconectarOracle();
        }
        return -1;
    }

    public int myExecuteNonQuery(string sQuery, CommandType ctType, OracleParameter[] colParameters)
    {
        try
        {
            if (!ConectarOracle(false))
                return -1;

            if (OracleConn.State == ConnectionState.Open)
            {
                OracleCmd = new OracleCommand(sQuery, OracleConn);
                OracleCmd.CommandTimeout = 0;

                OracleAdap = new OracleDataAdapter();
                OracleCmd.CommandType = ctType;
                if (colParameters != null)
                {
                    for (int i = 0; i < colParameters.Length; i++)
                    {
                        OracleCmd.Parameters.Add(colParameters[i]);
                    }
                }
                OracleAdap.SelectCommand = OracleCmd;
                return OracleAdap.SelectCommand.ExecuteNonQuery();                
            }
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
        }
        finally
        {
            DesconectarOracle();
        }
        return -2;
    }

    public int myExecuteNonQuery(string sQuery, CommandType ctType, OracleParameter[] colParameters, ref int status)
    {
        try
        {
            if (!ConectarOracle(false))
                return -1;

            if (OracleConn.State == ConnectionState.Open)
            {
                OracleCmd = new OracleCommand(sQuery, OracleConn);
                OracleCmd.CommandTimeout = 0;

                OracleAdap = new OracleDataAdapter();
                OracleCmd.CommandType = ctType;
                if (colParameters != null)
                    OracleCmd.Parameters.Add(colParameters);
                OracleAdap.SelectCommand = OracleCmd;

                int r = OracleAdap.SelectCommand.ExecuteNonQuery();
                int.TryParse(OracleCmd.Parameters[colParameters.Length - 1].Value.ToString(),out status);
                return r;
            }
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
        }
        finally
        {
            DesconectarOracle();
        }
        return -2;
    }

    public int myExecuteNonQuery(string sQuery, CommandType ctType)
    {
        try
        {
            if (!ConectarOracle(false))
                return -1;

            if (OracleConn.State == ConnectionState.Open)
            {
                OracleCmd = new OracleCommand(sQuery, OracleConn);
                OracleCmd.CommandTimeout = 0;
               
                OracleAdap = new OracleDataAdapter();
                OracleCmd.CommandType = ctType;
                OracleAdap.SelectCommand = OracleCmd;
                return OracleAdap.SelectCommand.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            string MsgError = ex.Message;
        }
        finally
        {
            DesconectarOracle();
        }
        return -2;
    }

    #endregion

    
}
