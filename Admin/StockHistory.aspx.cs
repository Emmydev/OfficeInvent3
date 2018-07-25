using OfficeInvent.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StockHistory : System.Web.UI.Page
{
    OfficeInvent3Entities _db = new OfficeInvent3Entities();
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadStockHistory();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
    private void LoadStockHistory()
    {
        try
        {
            //if (Session["CompanyId"] == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //int companyId = int.Parse(Session["CompanyId"].ToString());
            //var inventoryList = _db.Inventories.Where(m => m.CompanyId == companyId).ToList();
            //if (!inventoryList.Any())
            //{
            //    grdInventory.DataSource = new List<Category>();
            //    grdInventory.DataBind();
            //    return;
            //}
            //grdInventory.DataSource = inventoryList;
            //grdInventory.DataBind();

            var stockHistoryList = _db.StockHistories.ToList();
            if (!stockHistoryList.Any())
            {
                grdStockHistory.DataSource = new List<StockHistory>();
                grdStockHistory.DataBind();
                return;
            }
            grdStockHistory.DataSource = stockHistoryList;
            grdStockHistory.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {

    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
    protected void BtnSave_Click(object sender, EventArgs e)
    {

    }
}