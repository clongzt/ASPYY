using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Http;
using WebApplication6.App_Start;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class PrescriptionInfoController : ApiController
    {
        [Route("api/prescriptioninfo/update2")]
        public Object PostUpdate([FromBody] PrescriptionDto lymb_prescription)
        {

            var result = getResult(lymb_prescription);
            using (var db = new BloggingContext())
            {
                try
                {
                    PrescriptionInfo preInfo = lymb_prescription.GetNewprescriptionInfo();
                    db.prescriptionInfo.Add(preInfo);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {

                        throw ex;
                    }

                    var details = lymb_prescription.GetNewPrescriptionDetail();
                    db.prescriptionDetail.AddRange(details);
                    db.SaveChanges();

                    var pharmacyId = lymb_prescription.pharmacyId;
                    int state = 1;
                    if (!String.IsNullOrEmpty(pharmacyId))
                    {
                        state = db.Database.SqlQuery<int>("select state from lymb_prescription_state where pharmacyId='" + pharmacyId+"'").FirstOrDefault();
                        if (state != 2)
                        {
                            state = 1;
                        }
                    }
                    result.state = state;
                    return result;
                    ;
                }
                catch (Exception e)
                {
                    result.message = e.Message;
                    //return JsonConvert.SerializeObject(result);
                    return result;
                }
            }
        }

        [Route("api/prescriptioninfo/update")]
        public Object PostUpdate2([FromBody] String strlymb_prescription)
        {
            //var recontent = Request.Content.ReadAsStringAsync().Result;
            //StreamReader reader = new StreamReader(request.GetRequestStream() );
            //string recontent = reader.ReadToEnd();

            var lymb_prescription = JsonConvert.DeserializeObject<PrescriptionDto>(strlymb_prescription); 
            var result = getResult(lymb_prescription);
            using (var db = new BloggingContext())
            {
                try
                {
                    string msg="";
                    if (!checkPrescriptionid(lymb_prescription.prescriptionid, db,out msg))
                    {
                         LogHelper.Default.WriteError(msg);
                        result.accepted = false;
                        result.message = msg;
                        return result;
                    }
                    PrescriptionInfo preInfo = lymb_prescription.GetNewprescriptionInfo();
                    db.prescriptionInfo.Add(preInfo);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                    {

                        throw ex;
                    }

                    var details = lymb_prescription.GetNewPrescriptionDetail();
                    db.prescriptionDetail.AddRange(details);
                    db.SaveChanges();

                    var pharmacyId = lymb_prescription.pharmacyId;
                    int state = 1;
                    if (!String.IsNullOrEmpty(pharmacyId))
                    {
                        state = db.Database.SqlQuery<int>("select state from lymb_prescription_state where pharmacyId='" + pharmacyId + "'").FirstOrDefault();
                        if (state != 2)
                        {
                            state = 1;
                        }
                    }
                    result.state = state;
                    return result;
                    ;
                }
                catch (Exception e)
                {
                    result.message = e.Message;
                    //return JsonConvert.SerializeObject(result);
                    LogHelper.Default.WriteError(e.Message,e);
                    return result;
                }
            }
        }

        private bool checkRecord(String abcd, BloggingContext db, out string message)
        {
            message = "";
            var query = from b in db.prescriptionInfo
                        where b.abcd == abcd
                        select b;
            var orderInfos = query.ToList();
            if (orderInfos.Count > 0)
            {
                message = "验方表中存在" + abcd + "的记录";
                return false;
            }

            var query2 = from b in db.prescriptionDetail
                         where b.abcd == abcd
                         select b;
            var invoices = query2.ToList();
            if (invoices.Count > 0)
            {
                message = "详情信息表中存在" + abcd + "的记录";
                return false;
            }
            return true;
        private bool checkPrescriptionid(String prescriptionid, BloggingContext db, out string message)
        {
            message = "";
            var query = from b in db.prescriptionInfo
                        where b.prescriptionid == prescriptionid
                        select b;
            var orderInfos = query.ToList();
            if (orderInfos.Count > 0)
            {
                message = "验方表中存在" + prescriptionid + "的记录";
                return false;
            }
            return true;
        }



        private PrescriptionInfoResultInfo getResult(PrescriptionDto lymb_prescription)
        {
            var resultInfo = new PrescriptionInfoResultInfo();
            resultInfo.abcd = lymb_prescription.abcd;
            resultInfo.prescriptionid = lymb_prescription.prescriptionid;
           
             DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            resultInfo.time=  (long)(DateTime.Now - startTime).TotalSeconds * 1000;
            return resultInfo;
        }


    }
}