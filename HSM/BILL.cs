//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HSM
{
    using System;
    using System.Collections.Generic;
    
    public partial class BILL
    {
        public int BILL_ID { get; set; }
        public Nullable<int> ME_ID { get; set; }
        public Nullable<double> ME_Price { get; set; }
        public Nullable<int> Appointment_id { get; set; }
        public Nullable<double> Appointment_Price { get; set; }
        public Nullable<int> ID_Patient { get; set; }
        public Nullable<double> Pay_Method { get; set; }
    
        public virtual APPOINTMENT APPOINTMENT { get; set; }
        public virtual PATIENT PATIENT { get; set; }
        public virtual MEDICAL_EXAMINATIONS MEDICAL_EXAMINATIONS { get; set; }
    }
}