using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class PrescriptionDto
    {
        public String abcd {get; set; }

        public string prescriptionid { get; set; }

        public string pharmacyId { get; set; }

        public virtual PrescriptionInfo prescription { get; set; }

        public PrescriptionInfo GetNewprescriptionInfo()
        {
            prescription.abcd = abcd;
            prescription.prescriptionid = prescriptionid;
            prescription.pharmacyId = pharmacyId;
            return prescription;
        }

        public List<PrescriptionDetail> GetNewPrescriptionDetail()
        {
            var prescriptionDetaillist = prescription.list;
            foreach (var prescriptionDetail in prescriptionDetaillist)
            {
                prescriptionDetail.abcd = abcd;
                prescriptionDetail.prescriptionid = prescriptionid;
            }
            return prescriptionDetaillist;
        }
    }
}