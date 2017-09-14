using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFYWebApi
{
    public class Orders
    {
        public string OrderNO { get; set; }//订单号
        public string DateTime { get; set; }//成交时间
        public string BuyerID { get; set; }//客户id
        public string BuyerName { get; set; }//客户昵称
        public string Country { get; set; }//国家
        public string Province { get; set; }//省
        public string City { get; set; }//市
        public string Town { get; set; }//区县
        public string Adr { get; set; }//详细地址
        public string Zip { get; set; }//邮编
        public string Email { get; set; }//邮箱
        public string Phone { get; set; }//联系电话
        public double Total { get; set; }//订单总额
        public double Postage { get; set; }//邮费
        public string PayAccount { get; set; }//支付方式
        public string PayID { get; set; }//支付编号
        public string LogisticsName { get; set; }//发货方式
        public string Chargetype { get; set; }//结算方式
        public string CustomerRemark { get; set; }//客户备注
        public string InvoiceTitle { get; set; }//发票抬头
        public string Remark { get; set; }//客服备注
        public string Item { get; set; }//商品明细
    }

    public class Item
    {
        public string GoodsID { get; set; }//库存编码
        public string GoodsName { get; set; }//货品名称
        public string GoodsSpec { get; set; }//货品规格
        public string Count { get; set; }//数量
        public string Price { get; set; }//单价

    }

}
