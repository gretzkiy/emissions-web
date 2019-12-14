using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using EmissionsLibrary;

namespace EmissionsWeb
{
    /// <summary>
    /// Сводное описание для EmissionsWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку. 
    // [System.Web.Script.Services.ScriptService]
    public class EmissionsWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Привет всем!";
        }

        [WebMethod]
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        [WebMethod]
        public string TestMethod(TransferData[] transferData)
        {
            try
            {
                return transferData[0].value;
            }
            catch
            {
                return "error in testmethod";
            }
        }

        [WebMethod]
        public void UploadData(TransferData[] data)
        {
            try
            {
                var currentData = (HashSet<TransferData>)HttpContext.Current.Application["Measurements"];
                currentData.UnionWith(data);
                
                HttpContext.Current.Application.Lock();
                Application["Measurements"] = currentData;
                HttpContext.Current.Application.UnLock();
            }
            catch { }
        } 
    }
}
