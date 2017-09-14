using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Specialized;

namespace SFYWebApi
{
    public partial class MBHTWDGJ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayData();
            }
        }

        public void DisplayData()
        {
            if (Request["uCode"] != null && Request["mType"] != null)
            {
                string uCode = Request["uCode"].ToString();
                string vefyCode = System.Configuration.ConfigurationManager.AppSettings["uCode"];//接口接入验证码

                if (1 == 1)
                {
                    if (Request["mType"] == "mOrderSearch" && uCode == vefyCode)
                    {
                        //byte[] buffer = Encoding.Default.GetBytes(wdgjV3API.mOrderSearch());
                        //string strDest = Encoding.GetEncoding("gb2312").GetString(buffer);
                        //Response.Clear();

                        Response.Write(wdgjV3API.mOrderSearch());
                        Response.End();
                    }

                    else if (Request["mType"] == "mGetOrder" && uCode == vefyCode)
                    {
                        string OrderNO = Request["OrderNO"].ToString();
                        byte[] buffer = Encoding.Default.GetBytes(wdgjV3API.mGetOrder(OrderNO));
                        string strDest = Encoding.GetEncoding("gb2312").GetString(buffer);
                        Response.Clear();

                        Response.ContentType = "text/xml";
                        Response.Write("<?xml version='1.0' encoding='UTF-8'?>" + strDest);

                        Response.End();

                    }
                    else if (Request["mType"] == "mSndGoods" && uCode == vefyCode)
                    {
                        string OrderID = Request["OrderID"].ToString();
                        string OrderNO = Request["OrderNO"].ToString();
                        string SndStyle = Request["SndStyle"].ToString();
                        string BillID = Request["BillID"].ToString();
                        string CustomerID = Request["CustomerID"].ToString();
                        string xml = wdgjV3API.mSndGoods(OrderNO, SndStyle, BillID, CustomerID,OrderID);
                        Response.Write(xml);
                        Response.End();
                    }
                    else
                    {
                        Response.Write(wdgjV3API.xml(0, "canshu error"));
                        Response.End();
                    }
                }
                else
                {
                    Response.Write(wdgjV3API.xml(0, "uCode Error"));
                    Response.End();
                }
            }
            else
            {
                Response.Write(wdgjV3API.xml(0, "uCode Error or uCode is null"));
                Response.End();
            }
        }
    }
}
