using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    public class Student 
    {
    
        public string Name
        { 
            get; 
            private set; 
        } 


        public DateTime DateOfBirth
        {
            get;
            private set;
        
        }

        public String RollNumber
        {
            get;
            private set ; 
        }


        public Student(string name,DateTime dateOfBirth,String rollNumber)
        {
           
            ValidataInputs(name, dateOfBirth, rollNumber);  
            Name = name;
            DateOfBirth = dateOfBirth;
            RollNumber = rollNumber;

        }

        private static void ValidataInputs(string name, DateTime dateOfBirth,string rollNumber)
        {
            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException("Date of birth can not be in the future");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name can not be null or empty"); 
            }

            if (string.IsNullOrWhiteSpace(rollNumber))
            {
                throw new ArgumentNullException("Rollnumber can not be null or empty");

            }

            if (dateOfBirth == default)
            {
                throw new ArgumentNullException("dateOfbirth can not be null .");
            }

        }




        private int CalculateAge()
        {
          
            int age = DateTime.Now.Year - DateOfBirth.Year;

            return DateTime.Now < DateOfBirth.AddYears(age) ? age - 1 : age; 
        }

        public int Age => CalculateAge();
        

        public void PrintDetails()
        {
            Console.WriteLine($"Name :{Name},Date of Birth:{DateOfBirth.ToShortDateString()},RollNumber:{RollNumber},Age:{Age}");
        }


    }

    internal class Program 
    {
        static void Main(string[] args)
        {
            try
            {
                Student student1 = new Student("Mahbub limon",new DateTime(1990,3,30),"cse101");
                Student student2 = new Student("Mahbub ullah", new DateTime(2000, 3, 30), "cse102");
            
                //student details

                Console.WriteLine($"Sudent Details :");
                Console.WriteLine($"------------------------");

                student1.PrintDetails();
                student2.PrintDetails();


            }
            catch (Exception ex) 
            { 
             Console.WriteLine($"Error :{ex.Message}"); 

            }
            
        }
    }
}
