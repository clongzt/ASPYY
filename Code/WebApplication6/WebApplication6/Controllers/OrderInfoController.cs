using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication6.App_Start;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class OrderInfoController : ApiController
    {
        [Route("api/orderinfo/update")]
        public Object PostUpdate([FromBody] string strorderInfoDto)
        {
            //OrderInfoDto
            var orderInfoDto = JsonConvert.DeserializeObject<OrderInfoDto>(strorderInfoDto); 
            using (var db = new BloggingContext())
            {
                try
                {
                    string msg="";
                    if (!CheckOrderId(orderInfoDto.abcd, db,out msg))
                    {
                        var result2 = new
                        {
                            accepted = false,
                            message = msg

                        };
                        return result2; ;
                    }

                    var orderInfo = getOrderInfo(orderInfoDto);
                    db.OrderInfos.Add(orderInfo);

                    var invoce = getInoviceInfo(orderInfoDto);
                    db.InvoiceInfos.Add(invoce);

                    var de = getDeliveryInfo(orderInfoDto);
                    db.DeliveryInfos.Add(de);

                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {

                        throw ex;
                    }
                   
                    var result = new
                    {
                        accepted = true,
                        message = ""

                    };
                    return    result;;
                    
                }
                catch (Exception e)
                {
                    var result = new
                    {
                        accepted = false,
                        message = e.Message

                    };
                     LogHelper.Default.WriteWarning(e.Message,e);
                       return result;;
                }
            }
        }

        private bool CheckRecord(String abcd,BloggingContext db,out string message)
        {
            message = "";
            var query = from b in db.OrderInfos
                        where b.abcd == abcd
                        select b;
            var orderInfos = query.ToList();
            if (orderInfos.Count > 0)
            {
                message = "订单表中存在" + abcd + "的记录";
                return false;
            }

            var query2 = from b in db.InvoiceInfos
                        where b.abcd == abcd
                        select b;
             var invoices = query2.ToList();
             if (invoices.Count > 0)
             {
                 message = "发票信息表中存在" + abcd + "的记录";
                 return false;
             }


             var query3 = from b in db.DeliveryInfos
                        where b.abcd == abcd
                        select b;
             var deliverys = query3.ToList();
             if (deliverys.Count > 0)
            {
                message = "deliverys信息表中存在" + abcd + "的记录";
                return false;
            }
             return true;
        }

         private bool CheckOrderId(String orderid,BloggingContext db,out string message)
        {
            message = "";
            var query = from b in db.OrderInfos
                        where b.orderid == orderid
                        select b;
            var orderInfos = query.ToList();
            if (orderInfos.Count > 0)
            {
                message = "订单表中存在订单" + orderid + "的记录";
                return false;
            }
             return true;

        private OrderInfo getOrderInfo(OrderInfoDto dto)
        {
            var result = new OrderInfo();
            result.abcd = dto.abcd;
            result.orderid = dto.orderid;
            result.prescriptionid = dto.prescriptionid;
            result.fee = dto.fee;
            result.ybfee = (dto.ybfee);
            result.ybpay = (dto.ybpay);
            result.thirdpay = (dto.thirdpay);
            result.type = dto.type;
            result.paymentstandard = dto.paymentstandard;
            result.pharmacyId = dto.pharmacyId;
            result.createtime = DateTime.Now;
            return result;
        }

        private double convertStrToDouble(string value)
        {
            double result=0d;
            double.TryParse(value, out result);
            return result;
        }

        private decimal convertStrTodec(string value)
        {
            decimal result = 0.00m;
            decimal.TryParse(value, out result);
            return result;
        }

        private InvoiceInfo getInoviceInfo(OrderInfoDto orderInfoDto)
        {
            var result = orderInfoDto.invoice;
            result.abcd = orderInfoDto.abcd;
            result.orderid = orderInfoDto.orderid;
            result.prescriptionid = orderInfoDto.prescriptionid;
            result.createtime = DateTime.Now;
            return result;
        }

        private DeliveryInfo getDeliveryInfo(OrderInfoDto orderInfoDto)
        {
            var result = orderInfoDto.delivery;
            result.abcd = orderInfoDto.abcd;
            result.orderid = orderInfoDto.orderid;
            result.prescriptionid = orderInfoDto.prescriptionid;
            result.createtime = DateTime.Now;
            return result;
        }




        [Route("api/orderinfo/cancle")]
        public Object PostCancel([FromBody] string strcancelDto)
        {
            //OrderInfoCancellationDto

            var cancelDto = JsonConvert.DeserializeObject<OrderInfoCancellationDto>(strcancelDto); 

             var result = getCancelResult(cancelDto);
            using (var db = new BloggingContext())
            {
                try
                {
                    var query = from b in db.OrderInfos
                                where b.orderid == cancelDto.orderid
                                select b;
                    var orderInfos = query.ToList();
                    if (orderInfos.Count > 0)
                    {
                        var orderInfo = orderInfos[0];
                        orderInfo.transType = cancelDto.transType;
                        orderInfo.source = cancelDto.source;
                        orderInfo.opid = cancelDto.opid;
                        orderInfo.note = cancelDto.note;
                        orderInfo.pharmacyId = cancelDto.pharmacyId;
                        orderInfo.status=4;
                    }
                    else
                    {
                        throw new Exception("不存在订单号为：" + cancelDto.orderid + "的订单。");
                    }

                    
                    db.SaveChanges();

                    return result;
                }
                catch (Exception e)
                {
                   result.message=e.Message;
                    result.accepted=false;
                    result.status=5;
                      LogHelper.Default.WriteWarning(e.Message,e);
                    return result;
                }
            }
        }

        private CancellationOrderResultIfno getCancelResult(OrderInfoCancellationDto cancelDto)
        {
            var result = new CancellationOrderResultIfno();
            result.abcd = cancelDto.abcd;
            result.orderid = cancelDto.orderid;
            result.accepted = true;
            result.status = 4;
            return result;
        }

    
    }
}