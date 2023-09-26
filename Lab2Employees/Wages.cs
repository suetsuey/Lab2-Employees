using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Employees
{
    internal class Wages : Employee
    {
        // Field
        private double rate;
        private double hours;

        // Properties
        public double Rate {  get { return rate; } set {  rate = value; } }
        public double Hours { get { return hours; } set { hours = value; } }

        // Constructor
        public Wages() 
        { 
        
        }
        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Rate = rate;
            this.Hours = hours;
        }

        // Methods
        public override double GetPay()
        {
            if (Hours < 40)
            {
                double weeklyPay = Rate * Hours;
                return weeklyPay;
            }
            else
            {
                double overTime = Hours - 40;
                double weeklyPay = Rate * 40 + Rate * 1.5 * overTime;
                return weeklyPay;
            }
            
        }

        public void ToString()
        {

        }
    }
}
