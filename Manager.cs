using System;
namespace Payroll
{
    class Manager : Staff
    {
        private const float managerHourlyRate = 50;
        public int Bonus { get; private set; }
        public Manager(string name) : base(name, managerHourlyRate) { }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Bonus = 1000;
            if (HoursWorked > 160)
                TotalPay = BasicPay + Bonus;
        }
        public override string ToString()
        {
            return "\nNameOfStaff = " + NameOfStaff + "\nmanagerHourlyRate = " + managerHourlyRate + "\nHoursWorked = " + HoursWorked + "\nBasicPay = " + BasicPay + "\nBonus = " + Bonus + "\n\nTotalPay = " + TotalPay;
        }
    }
}
