using OfficeInvent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for OfficeInventWebservice
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class OfficeInventWebservice : System.Web.Services.WebService
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();
    public class CustomChart
    {
        public string name { get; set; }
        public int x { get; set; }
        public decimal y { get; set; }
        public decimal z { get; set; }
    }




    [WebMethod]
    public object StockByCategoryPie(string type)
    {
        try
        {
            var customPgharmList = new List<CustomChart>();

            foreach (var categoryObj in _db.Categories)
            {
                var pharmacies = new List<Stock>();

                //if (type == "1")
                //{
                //    pharmacies = _db.Tickets.Where(m => m.Status == (int)status).ToList();
                //}
                //else if (type == "2")
                //{
                //    pharmacies = _db.Tickets.Where(m => m.Status == (int)status).ToList();
                //}
                //else if (type == "3")
                //{
                //    pharmacies = _db.Tickets.Where(m => m.Status == (int)status).ToList();
                //}
                //else
                //{
                pharmacies = _db.Stocks.Where(m => m.CategoryId == categoryObj.CategoryId).ToList();
                // }
                var customStd1 = new CustomChart();
                customStd1.name = categoryObj.Name.ToString();
                customStd1.x = pharmacies.Count();
                customPgharmList.Add(customStd1);

            }
            var js = new JavaScriptSerializer();
            return new
            {
                catJson = js.Serialize(customPgharmList)
            };
        }

        catch (Exception ex)
        {

            return new
            {

                Error = "An error occurred , Please contact administrator"

            };
        }




    }




}
