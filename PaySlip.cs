using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Payroll
{
    class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear { JAN = 1, FEB = 2, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV, DEC }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }
        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("========================");
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);

                    if (f.GetType() == typeof(Manager))
                        sw.WriteLine("Bonus: {0:C}", ((Manager)f).Bonus);
                    else if (f.GetType() == typeof(Admin))
                        sw.WriteLine("Overtime: {0:C}", ((Admin)f).Overtime);

                    sw.WriteLine("");
                    sw.WriteLine("========================");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("========================");

                    sw.Close();
                }
            }

        }
        public void GenerateSummary(List<Staff> myStaff)
        {
            var result =
                from f in myStaff
                where f.HoursWorked < 10
                orderby f.NameOfStaff ascending
                select new { f.NameOfStaff, f.HoursWorked };

            string path = "/Users/mmd1fmt/Projects/Payroll/Payroll/bin/Debug/Report.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");
                foreach (var f in result)
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", f.NameOfStaff, f.HoursWorked);

                sw.Close();
            }
        }
        public override string ToString()
        {
            return "month = " + month + "year = " + year;
        }
    }
}
