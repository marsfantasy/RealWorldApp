using System;
using System.Collections.Generic;
using System.Text;

namespace RealWorldApp.Models
{
   public class Detect
    {
        public class MasterData
        {
            public string DetectDateByYYYY { get; set; }
            public string DetectDateByYYYYMM { get; set; }
            public string DetectDateByYYYYMMDD { get; set; }
            public Detectdata DetectData { get; set; }
            public Data[] Datas { get; set; }
        }

        public class Detectdata
        {
            public string DetectID { get; set; }
            public DateTime DetectDate { get; set; }
            public DateTime RefValueDate { get; set; }
            public object DetectSerialID { get; set; }
            public string PatientID { get; set; }
            public object DoctorID { get; set; }
            public object MedicalTechnologistID { get; set; }
            public string SourceOrgID { get; set; }
            public object DetectOrgID { get; set; }
            public string DetectKind { get; set; }
            public bool IsNHI { get; set; }
            public string DetectStatus { get; set; }
        }

        public class Data
        {
            public string DetectTypeCode { get; set; }
            public string DetectTypeName { get; set; }
            public Data1[] Datas { get; set; }
        }

        public class Data1
        {
            public Detectitemdata DetectItemData { get; set; }
            public Detectitemrefvaluedata DetectItemRefValueData { get; set; }
        }

        public class Detectitemdata
        {
            public string DetailID { get; set; }
            public string DetectValue { get; set; }
            public string DetailItemID { get; set; }
            public string DetectTypeCode { get; set; }
            public string DetectTypeName { get; set; }
            public string DetailItemCode { get; set; }
            public string ENGName { get; set; }
            public string CHTName { get; set; }
            public object CHSName { get; set; }
            public object ENGDesc { get; set; }
            public object CHTDesc { get; set; }
            public object CHSDesc { get; set; }
            public object OrganizationID { get; set; }
            public object StartDate { get; set; }
            public object EndDate { get; set; }
            public string Unit { get; set; }
            public object ValueType { get; set; }
            public object NormalColorTag { get; set; }
            public object AbnormalColorTag { get; set; }
        }

        public class Detectitemrefvaluedata
        {
            public string DetailItemRefValueID { get; set; }
            public object StartAgeYear { get; set; }
            public object StartAgeMonth { get; set; }
            public object StartAgeDay { get; set; }
            public object ExpiredDateTime { get; set; }
            public string MaleLow { get; set; }
            public string MaleUp { get; set; }
            public object MaleNegativeLow { get; set; }
            public object MaleNegativeUp { get; set; }
            public object MalePositiveLow { get; set; }
            public object MalePositiveUp { get; set; }
            public object MaleNormalList { get; set; }
            public object MaleAbnormalList { get; set; }
            public object MaleENGDesc { get; set; }
            public string MaleCHTDesc { get; set; }
            public object MaleCHSDesc { get; set; }
            public string FemaleLow { get; set; }
            public string FemaleUp { get; set; }
            public object FemaleNegativeLow { get; set; }
            public object FemaleNegativeUp { get; set; }
            public object FemalePositiveLow { get; set; }
            public object FemalePositiveUp { get; set; }
            public object FemaleNormalList { get; set; }
            public object FemaleAbnormalList { get; set; }
            public object FemaleENGDesc { get; set; }
            public string FemaleCHTDesc { get; set; }
            public object FemaleCHSDesc { get; set; }
            public string DetectItemRefValueDescription { get; set; }
            public string DetectItemRefValueExtID { get; set; }
        }
    }
}
