using System;
using Oracle.DataAccess.Client;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Collections;

/// <summary>
/// Summary description for DBAccess
/// </summary>
public class DBAccess
{
    public string msgErr;
    public string oradb;
    OracleConnection dbCon;
    OracleCommand dbCmd = new OracleCommand();
    OracleDataAdapter dbDa = new OracleDataAdapter();
    OracleConnection dbConTran = new OracleConnection();
    OracleCommand dbCmdTran = new OracleCommand();
    OracleTransaction dbTran;

    public DBAccess()
    {
        oradb = ConfigurationManager.AppSettings.Get("Oracle");
    
    }

    private int Conectar()
    {
        int result = -1;
        try
        {
            dbCon = new OracleConnection(oradb);
            dbCon.Open();
            result = 1;
        }
        catch (Exception ex)
        {
            this.msgErr = ex.Message;
            result = -1;
        }
        return result;
    }

    private void Desconectar()
    {
        if (dbCon.State == ConnectionState.Open)
        {
            dbCon.Close();
            dbCon.Dispose();
        }
    }

    public int GetDataFromProcedure(string ProcName, OracleParameter[] Params, ref DataTable dt)
    {
        int result = -1;

        if (Conectar() != -1)
        {
            try
            {
                dbCmd.Connection = dbCon;
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = ProcName;

                if (Params != null)
                {
                    foreach (OracleParameter par in Params)
                        dbCmd.Parameters.Add(par);
                }

                dbDa.SelectCommand = dbCmd;
                dbDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                    this.msgErr = "No se encontraron registros en la base de datos";
                }

            }
            catch (Exception ex)
            {
                this.msgErr = ex.Message;
                result = -1;
            }
            finally
            {
                Desconectar();
            }

        }

        return result;
    }

    public int GetDataFromProcedure(string ProcName, OracleParameter[] Params, ref DataSet ds)
    {
        int result = -1;

        if (Conectar() != -1)
        {
            try
            {
                dbCmd.Connection = dbCon;
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = ProcName;
                if (Params != null)
                {
                    foreach (OracleParameter par in Params)
                        dbCmd.Parameters.Add(par);
                }

                dbDa.SelectCommand = dbCmd;
                dbDa.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                    this.msgErr = "No se encontraron registros en la base de datos";
                }

            }
            catch (Exception ex)
            {
                this.msgErr = ex.Message;
                result = -1;
            }
            finally
            {
                if (dbCon.State == ConnectionState.Open)
                    dbCon.Close();
            }
        }

        return result;
    }

    public int ExecuteProcedure(string ProcName, OracleParameter[] Params)
    {
        int result = -1;

        if (Conectar() != -1)
        {
            try
            {
                dbCmd.Connection = dbCon;
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.CommandText = ProcName;

                if (Params != null)
                {
                    foreach (OracleParameter par in Params)
                        dbCmd.Parameters.Add(par);
                }

                result = dbCmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                msgErr = "DB Error: " + ex.Message;
                result = -1;
            }
            finally
            {
                Desconectar();
            }
        }

        return result;
    }

    public int ExecuteSQL(string sql)
    {
        int result = -1;

        if (Conectar() != -1)
        {
            try
            {
                dbCmd.Connection = dbCon;
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql;

                result = dbCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                msgErr = ex.Message;
                result = -1;
            }
            finally
            {
                Desconectar();
            }
        }

        return result;
    }

    public int GetDataSetFromQuery(string sql, ref DataSet dsQuery)
    {
        int result = -1;

        if (Conectar() != -1)
        {
            try
            {
                dbCmd.Connection = dbCon;
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql;
                dbDa.SelectCommand = dbCmd;
                dbDa.Fill(dsQuery);

                if (dsQuery.Tables[0].Rows.Count > 0)
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                    this.msgErr = "No se encontraron registros en la base de datos";
                }
            }
            catch (Exception ex)
            {
                msgErr = ex.Message;
                result = -1;
            }
            finally
            {
                Desconectar();
            }
        }

        return result;
    }

    public int GetDataTableFromQuery(string sql, ref DataTable dtQuery)
    {
        int result = -1;

        if (Conectar() != -1)
        {
            try
            {
                dbCmd.Connection = dbCon;
                dbCmd.CommandType = CommandType.Text;
                dbCmd.CommandText = sql;

                dbDa.SelectCommand = dbCmd;

                dbDa.Fill(dtQuery);
                if (dtQuery.Rows.Count > 0)
                {
                    result = 1;
                }
                else
                {
                    result = -1;
                    this.msgErr = "No se encontraron registros en la base de datos";
                }
            }
            catch (Exception ex)
            {
                msgErr = ex.Message;
                result = -1;
            }
            finally
            {
                Desconectar();
            }
        }

        return result;
    }


    public int ExecuteProcedure(string ProcName)
    {
        int result = -1;

        try
        {
            //dbCmdTran.Connection = dbCon;
            //dbCmdTran = new SqlCommand();
            dbCmdTran.CommandType = CommandType.StoredProcedure;
            dbCmdTran.CommandText = ProcName;

            result = dbCmdTran.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            msgErr = "DB Error: " + ex.Message;
            result = -1;
        }
        finally
        {
            Desconectar();
        }


        return result;
    }

    public int ExecuteProcedure(string ProcName, OracleParameter[] Params, int trans)
    {
        int result = -1;

            try
            {
                //dbCmdTran.Connection = dbCon;
                //dbCmdTran = new SqlCommand();
                dbCmdTran.CommandType = CommandType.StoredProcedure;
                dbCmdTran.CommandText = ProcName;
                
                if (Params != null)
                {
                    foreach (OracleParameter par in Params)
                        dbCmdTran.Parameters.Add(par);
                }

                result = dbCmdTran.ExecuteNonQuery();
                dbCmdTran.Parameters.Clear();
            }
            catch (Exception ex)
            {
                msgErr = "DB Error: " + ex.Message;
                result = -1;
            }
            finally
            {
                Desconectar();
            }
        

        return result;
    }

    public int OpenTransaction(/*string nombreTran*/)
    {
        int result = -1;

        try
        {
            string Program_Oracle = "LOCALHOST";
            string Program_Port = "1521";
            string Program_ServiceName = "OPPORT";

            string oradb = "Data Source=(DESCRIPTION=" +
                      "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=" + Program_Oracle + ")(PORT=" + Program_Port + ")))" +
                      "(CONNECT_DATA=(SERVICE_NAME=" + Program_ServiceName + ")));" +
                      "User Id=OPPORT;Password=OPPORT21;Validate Connection=true;";

            dbConTran = new OracleConnection(oradb);
            dbConTran.Open();
            dbTran = dbConTran.BeginTransaction(/*IsolationLevel.Serializable, nombreTran*/);
            dbCmdTran.Connection = dbConTran;
            //dbCmdTran.Transaction = dbTran;
            result = 1;

        }
        catch (Exception ex)
        {
            msgErr = "DB Error: " + ex.Message;
            result = -1;
        }
        finally
        {
            Desconectar();
        }

        return result;
    }

    public int CommitTransaction(/*string nombreTran*/)
    {
        int result = -1;

        try
        {
            dbTran.Commit();
            result = 1;

        }
        catch (Exception ex)
        {
            msgErr = "DB Error: " + ex.Message;
            result = -1;
        }

        return result;

    }

    public int RollbackTransaction(/*string nombreTran*/)
    {
        int result = -1;

        try
        {
            dbTran.Rollback();
            result = 1;

        }
        catch (Exception ex)
        {
            msgErr = "DB Error: " + ex.Message;
            result = -1;
        }

        return result;
    }


    internal OracleParameter[] ParamsBuilder(string rutaParametros, string ProcName, ArrayList Parameters)
    {
        if (Parameters == null)
        {
            return null;
        }

        OracleParameter[] _Parameters = new OracleParameter[Parameters.Count];

        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(rutaParametros);
        XmlNodeList xNode = xDoc.GetElementsByTagName("PROCEDURES");
        XmlNodeList Proc = ((XmlElement)xNode[0]).GetElementsByTagName("PROCEDURE");

        string nParam = "";
        string nParamType = "";
        string nParamDir = "";
        try
        {
            foreach (XmlElement nodo in Proc)
            {
                string nNombre = nodo.GetAttribute("name");
                if (nNombre == ProcName)
                {
                    XmlNodeList _ProcParams = nodo.GetElementsByTagName("PARAMETER");
                    foreach (XmlElement nodoParam in _ProcParams)
                    {
                        nParam += nodoParam.GetAttribute("name") + "|";
                        nParamType += nodoParam.GetAttribute("type") + "|";
                        nParamDir += nodoParam.GetAttribute("direction") + "|";
                    }
                    break;
                }
            }

            nParam = nParam.Substring(0, nParam.Length - 1);
            nParamType = nParamType.Substring(0, nParamType.Length - 1);
            nParamDir = nParamDir.Substring(0, nParamDir.Length - 1);


            string[] _nParamNames = nParam.Split('|');
            string[] _nParamTypes = nParamType.Split('|');
            string[] _nParamDir = nParamDir.Split('|');

            for (int k = 0; k < _Parameters.Length; k++)
            {
                _Parameters[k] = new OracleParameter();
                _Parameters[k].ParameterName = _nParamNames[k];
                _Parameters[k].OracleDbType = DbTypeConverter(_nParamTypes[k]);
                if (_nParamDir[k] == "in")
                {
                    _Parameters[k].Value = Parameters[k];
                    _Parameters[k].Direction = ParameterDirection.Input;
                }
                else if (_nParamDir[k] == "out")
                {
                    _Parameters[k].Direction = ParameterDirection.Output;
                }
                else if (_nParamDir[k] == "io")
                {
                    _Parameters[k].Value = Parameters[k];
                    _Parameters[k].Direction = ParameterDirection.InputOutput;
                }
            }
        }
        catch (Exception ex)
        {
            this.msgErr = ex.Message;
            _Parameters = null;
        }

        return _Parameters;
    }

    public OracleDbType DbTypeConverter(String type)
    {
        OracleDbType tipo = OracleDbType.Varchar2;

        switch (type)
        {
            
            case "BFile":
                tipo = OracleDbType.BFile;
                break;
            case "Blob":
                tipo = OracleDbType.Blob;
                break;
            case "Byte":
                tipo = OracleDbType.Byte;
                break;
            case "Char":
                tipo = OracleDbType.Char;
                break;
            case "Clob":
                tipo = OracleDbType.Clob;
                break;
            case "Date":
                tipo = OracleDbType.Date;
                break;
            case "Decimal":
                tipo = OracleDbType.Decimal;
                break;
            case "Double":
                tipo = OracleDbType.Double;
                break;
            case "Int16":
                tipo = OracleDbType.Int16;
                break;
            case "Int32":
                tipo = OracleDbType.Int32;
                break;
            case "Int64":
                tipo = OracleDbType.Int64;
                break;
            case "IntervalDS":
                tipo = OracleDbType.IntervalDS;
                break;
            case "IntervalYM":
                tipo = OracleDbType.IntervalYM;
                break;
            case "Long":
                tipo = OracleDbType.Long;
                break;
            case "LongRaw":
                tipo = OracleDbType.LongRaw;
                break;
            case "NChar":
                tipo = OracleDbType.NChar;
                break;
            case "NClob":
                tipo = OracleDbType.NClob;
                break;
            case "NVarChar2":
                tipo = OracleDbType.NVarchar2;
                break;
            case "Raw":
                tipo = OracleDbType.Raw;
                break;
            case "RefCursor":
                tipo = OracleDbType.RefCursor;
                break;
            case "Single":
                tipo = OracleDbType.Single;
                break;
            case "TimeStamp":
                tipo = OracleDbType.TimeStamp;
                break;
            case "TimeStampLTZ":
                tipo = OracleDbType.TimeStampLTZ;
                break;
            case "TimeStampTZ":
                tipo = OracleDbType.TimeStampTZ;
                break;
            case "Varchar2":
                tipo = OracleDbType.Varchar2;
                break;
            case "XmlType":
                tipo = OracleDbType.XmlType;
                break;
            default:
                tipo = OracleDbType.Varchar2;
                break;
        }

        return tipo;
    }

}
