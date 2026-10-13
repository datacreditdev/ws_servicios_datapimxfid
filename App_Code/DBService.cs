using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;

/// <summary>
/// Descripción breve de DBService
/// </summary>
public class DBService
{
    public DBAccess db = new DBAccess();
    string ParamsFile = "";

    public DBService(string XmlPath)
    {
        ParamsFile = XmlPath;
    }

    public DataSet DataSetFromProcedure(string ProcName, ArrayList Parameters)
    {
        DataSet ds = new DataSet("ROOT");
        int r = db.GetDataFromProcedure(ProcName, db.ParamsBuilder(ParamsFile, ProcName, Parameters), ref ds);
        if (r == -1)
        {
            ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "ERROR";
            dt.Columns.Add("STATUS");
            dt.Columns.Add("ERROR");
            DataRow dr = dt.NewRow();
            dr["STATUS"] = "-1";
            dr["ERROR"] = db.msgErr;
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
        }
        return ds;

    }

    public DataTable DataTableFromProcedure(string ProcName, ArrayList Parameters)
    {
        DataTable dt = new DataTable("Table");
        int r = db.GetDataFromProcedure(ProcName, db.ParamsBuilder(ParamsFile, ProcName, Parameters), ref dt);
        if (r == -1)
        {
            dt = new DataTable("Table");
            dt.TableName = "ERROR";
            dt.Columns.Add("STATUS");
            dt.Columns.Add("ERROR");
            DataRow dr = dt.NewRow();
            dr["STATUS"] = "-1";
            dr["ERROR"] = db.msgErr;

            dt.Rows.Add(dr);
        }

        return dt;
    }

    public DataSet DataSetFromQuery(string sql)
    {
        DataSet dsQuery = new DataSet("ROOT");
        int r = db.GetDataSetFromQuery(sql, ref dsQuery);

        if (r == -1)
        {
            DataTable dt = new DataTable();
            dt.TableName = "ERROR";
            dt.Columns.Add("STATUS");
            dt.Columns.Add("ERROR");
            DataRow dr = dt.NewRow();
            dr["STATUS"] = "-1";
            dr["ERROR"] = db.msgErr;
            dt.Rows.Add(dr);
            dsQuery.Tables.Add(dt);
        }

        return dsQuery;
    }

    public DataTable DataTableFromQuery(string sql)
    {
        DataTable dt = new DataTable("Table");
        int r = db.GetDataTableFromQuery(sql, ref dt);
        if (r == -1)
        {
            dt.TableName = "ERROR";
            dt.Columns.Add("STATUS");
            dt.Columns.Add("ERROR");
            DataRow dr = dt.NewRow();
            dr["STATUS"] = "-1";
            dr["ERROR"] = db.msgErr;

            dt.Rows.Add(dr);
        }

        return dt;
    }

    public string XMLFromProcedure(string ProcName, ArrayList Parameters)
    {
        DataSet ds = new DataSet("ROOT");
        int r = db.GetDataFromProcedure(ProcName, db.ParamsBuilder(ParamsFile, ProcName, Parameters), ref ds);
        if (r == -1)
        {
            ds = new DataSet("ROOT");
            DataTable dt = new DataTable();
            dt.TableName = "ERROR";
            dt.Columns.Add("STATUS");
            dt.Columns.Add("ERROR");
            DataRow dr = dt.NewRow();
            dr["STATUS"] = "-1";
            dr["ERROR"] = db.msgErr;
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
        }
        return ds.GetXml();
    }

    public string XMLFromQuery(string sql)
    {
        DataSet ds = new DataSet("ROOT");
        int r = db.GetDataSetFromQuery(sql, ref ds);
        if (r == -1)
        {
            ds = new DataSet("ROOT");
            DataTable dt = new DataTable();
            dt.TableName = "ERROR";
            dt.Columns.Add("STATUS");
            dt.Columns.Add("ERROR");
            DataRow dr = dt.NewRow();
            dr["STATUS"] = "-1";
            dr["ERROR"] = db.msgErr;
            dt.Rows.Add(dr);
            ds.Tables.Add(dt);
        }
        return ds.GetXml();
    }

    public string ExecuteNonQueryProcedure(string ProcName, ArrayList Parameters)
    {
        int result = -1;
        result = db.ExecuteProcedure(ProcName, db.ParamsBuilder(this.ParamsFile, ProcName, Parameters));

        if (result == -1)
        {
            return "-1|" + db.msgErr;
        }

        return result.ToString();
    }

    public string ExecuteNonQueryProcedureWithTransaction(string ProcName, ArrayList Parameters)
    {
        int result = -1;
        result = db.ExecuteProcedure(ProcName, db.ParamsBuilder(this.ParamsFile, ProcName, Parameters),1);
        

        if (result == -1)
        {
            return "-1|" + db.msgErr;
        }

        return result.ToString();
    }

    public string ExecuteNonQueryProcedureWithTransaction(string ProcName)
    {
        int result = -1;
        result = db.ExecuteProcedure(ProcName);


        if (result == -1)
        {
            return "-1|" + db.msgErr;
        }
        else
        {
            result = 1;
        }

        return result.ToString();
    }

    public string ExecuteNonQuerySQL(string sql)
    {
        int result = -1;
        result = db.ExecuteSQL(sql);
        if (result == -1)
        {
            return "-1|" + db.msgErr;
        }
        return result.ToString();
    }

    public string OpenTran(/*string nombre*/)
    {
        int result = -1;
        result = db.OpenTransaction(/*nombre*/);
        if (result == -1)
        {
            return "-1|" + db.msgErr;
        }
        return result.ToString();
    }

    public string CommitTran(/*string nombre*/)
    {
        int result = -1;
        result = db.CommitTransaction(/*nombre*/);
        if (result == -1)
        {
            return "-1|" + db.msgErr;
        }
        return result.ToString();
    }

    public string RollbackTran(/*string nombre*/)
    {
        int result = -1;
        result = db.RollbackTransaction(/*nombre*/);
        if (result == -1)
        {
            return "-1|" + db.msgErr;
        }
        return result.ToString();
    }

}
