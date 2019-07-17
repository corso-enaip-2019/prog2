using System;

namespace PayDay_d
{
    class PaycheckRecord
    {
        public PaycheckRecord() { }

        public PaycheckRecord(int employeeId, DateTime date, decimal paycheck)
        {
            EmployeeId = employeeId;
            Date = date;
            Paycheck = paycheck;
        }

        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public decimal Paycheck { get; set; }
    }
}