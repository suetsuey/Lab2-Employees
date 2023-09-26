using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Security;

namespace Lab2Employees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("employees.txt");
            //Create a list of employees
            List<Employee> employeesList = new List<Employee>();

            foreach (string line in lines)
            {
                string[] columns = line.Split(':');
                string id = columns[0];
                string name = columns[1];
                string address = columns[2];
                string phone = columns[3];
                long sin = Convert.ToInt32(columns[4]);
                string dob = columns[5];
                string dept = columns[6];

                char firstDigitOfId = id[0];
                if (firstDigitOfId == '0' || firstDigitOfId == '1' || firstDigitOfId == '2' || firstDigitOfId == '3' || firstDigitOfId == '4')
                {
                    double salary = Convert.ToDouble(columns[7]);
                    //Create the Salaried object
                    Salaried salaried = new Salaried(id, name, address, phone, sin, dob, dept, salary);

                    // Add Salaried to employees
                    employeesList.Add(salaried);
                }
                else if (firstDigitOfId == '5' || firstDigitOfId == '6' || firstDigitOfId == '7')
                {
                    double rate = Convert.ToDouble(columns[7]);
                    double hours = Convert.ToDouble(columns[8]);
                    
                    Wages wages = new Wages(id, name, address, phone, sin, dob, dept, rate, hours);

                    employeesList.Add(wages);
                }
                else
                {
                    double rate = Convert.ToDouble(columns[7]);
                    double hours = Convert.ToDouble(columns[8]);

                    PartTime partTime = new PartTime(id, name, address, phone, sin, dob, dept, rate, hours);

                    employeesList.Add(partTime);
                }
            }

            // Do steps B-E
            // Calculate and return the average weekly pay for all employees
            double totalWeeklyPay = 0;
            int numOfEmployee = employeesList.Count;
            double averagePay = 0;

            foreach (Employee employee in employeesList)
            {
                totalWeeklyPay += employee.GetPay();
            }
            
            averagePay = totalWeeklyPay / numOfEmployee;
            Console.WriteLine("The average weekly pay for all employees is: $" + averagePay);

            // Calculate and name the highest weekly pay for the wage employees
            double maxPay = 0;
            string maxName = "";
            foreach (Employee employee in employeesList)
            {
                if (employee is Wages)
                {
                    if (employee.GetPay() > maxPay)
                    {
                        maxPay = employee.GetPay();
                        maxName = employee.Name;
                    }
                }
            }
            Console.WriteLine("The highest weekly pay for the wage employee is " + maxName + " for $" + maxPay);

            // Calculate and name the lowest weekly pay for the salary employees
            double minPay = 9999;
            string minName = "";
            foreach (Employee employee in employeesList)
            {
                if (employee is Salaried)
                {
                    if (employee.GetPay() < minPay)
                    {
                        minPay = employee.GetPay();
                        minName = employee.Name;
                    }
                }
            }
            Console.WriteLine("The lowest weekly pay for the salaried employee is " + minName + " for $" + minPay);

            // Percentage of the company's employees fall into each category
            double salariedCount = 0;
            double wageCount = 0;
            double ptCount = 0;
            foreach (Employee employee in employeesList)
            {
                if (employee is Salaried)
                {
                    salariedCount += 1;
                }
                else if (employee is Wages)
                {
                    wageCount += 1;
                }
                else
                {
                    ptCount += 1;
                }
            }
            double salariedRatio = salariedCount / numOfEmployee;
            double wagesRatio = wageCount / numOfEmployee;
            double partTimeRatio = ptCount / numOfEmployee;
            Console.WriteLine("The percentage of salaried employees is: " + salariedRatio.ToString("P"));
            Console.WriteLine("The percentage of wage employees is: " + wagesRatio.ToString("P"));
            Console.WriteLine("The percentage of parttime employees is: " + partTimeRatio.ToString("P"));




        }
    }
}