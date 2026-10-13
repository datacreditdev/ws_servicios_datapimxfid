<%@ WebHandler Language="C#" Class="Uploader" %>

using System.Web;
using System.Web.UI;
using System.Data;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System;
using System.IO;
using System.Net;
using System.Web.Configuration;

public class Uploader : IHttpHandler 
{
    public void ProcessRequest(HttpContext _context) 
    {
        string uploadDir = ConfigurationManager.AppSettings.Get("dirExp");
        string directorio = _context.Request["directorio"];
								
        if (_context.Request.Files.Count == 0)
        {
            _context.Response.Write("<result><status>Error</status><message>No files selected</message></result>");
            return;
        }

        foreach(string fileKey in _context.Request.Files)
        {
            HttpPostedFile file = _context.Request.Files[fileKey];
            try        
            {
                if (!Directory.Exists(uploadDir + "\\" + directorio))
                    Directory.CreateDirectory(uploadDir + "\\" + directorio); 
                string fileName = uploadDir + "\\" + directorio + "\\" + file.FileName;
                file.SaveAs(fileName);
                _context.Response.Write("<result><status>Success</status><message>Upload completed</message></result>");
            }       
            catch (Exception Ex)        
            {            
                string msg = Ex.Message;
                _context.Response.Write("<result><status>Error</status><message>" + msg + "</message></result>");       
            }    
        }        
    }
 
    public bool IsReusable 
	{
        get { return true; }
    }
}