using System;
namespace Payroll
{
    class Admin : Staff
    {
        private const float overtimeRate = 45.5f;
        private const float adminHourlyRate = 30f;

        public float Overtime { get; private set; }

        public Admin(string name) : base(name, adminHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160)
                Overtime = overtimeRate * (HoursWorked - 160);
            TotalPay = BasicPay + Overtime;
        }
        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nadminHourlyRate = " + adminHourlyRate + "\nHoursWorked = " + HoursWorked + "\nBasicPay = " + BasicPay + "\nOvertime = " + Overtime + "\n\nTotalPay = " + TotalPay;
        }
    }
}
