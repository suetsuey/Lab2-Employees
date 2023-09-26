using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Employees
{
    internal class Salaried : Employee
    {
        // Field
        private double salary;
        // Properties
        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        // Constructors
        public Salaried() { }
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {
            this.Salary = salary;
        }

        // Methods
        public override double GetPay()
        {
            double weeklyPay = Salary / 52;
            return weeklyPay;
        }

        public void ToString()
        {

        }

    }
}
