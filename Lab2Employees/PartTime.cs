using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Employees
{
    internal class PartTime : Employee
    {
        // Field
        private double rate;
        private double hours;

        // Properties
        public double Rate { get { return rate; } set {  rate = value; } }
        public double Hours { get { return hours; } set { hours = value; } }    

        // Constructors
        public PartTime () 
        {
            
        }
        public PartTime (string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
        this.Rate = rate;
        this.Hours = hours;
        }
        public override double GetPay()
        {
            double weeklyPay = Rate * Hours;
            return weeklyPay;
        }

        public void ToString()
        {

        }

    }
}
