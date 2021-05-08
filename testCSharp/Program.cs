﻿using System;

namespace testCSharp
{
	class Program
	{
		public static string[,,] employees;
		public static string[,] employees2;

		public static string[,] Re2Dimension(string[,] OldArray, int arr1stDimLength)
		{
			// declare a larger array
			string[,] NewArray = new string[arr1stDimLength, OldArray.GetLength(1)];

			// determine if we are shrinking or enlarging
			const int FirstDimension = 0;
			const int SecondDimension = 1;
			const int ThirdDimension = 2;
			int xMax = 0;
			int yMax = 0;
			int zMax = 0;
			yMax = OldArray.GetUpperBound(SecondDimension) + 1;
			
			// determine if we are shrinking or enlarging columns
			if (OldArray.GetUpperBound(FirstDimension) < (arr1stDimLength - 1))
				xMax = OldArray.GetUpperBound(FirstDimension) + 1;
			else
				xMax = arr1stDimLength;
			
				for (int x = 0; x < xMax; x++)
				{
					for (int y = 0; y < yMax; y++)
					{
						NewArray[x, y] = OldArray[x, y];
						//	Console.Write("[{0}]", NewArray[x, y, z]);
					}
					//Console.Write("\n");
				}
				///Console.Write("\n\n");
			

			return NewArray;
		}

		static void Main(string[] args)
		{
			init();
		}

		public static void displayEmployerOperation(string nameOfEmployer) {
			Console.WriteLine("__________________________  Welcome "+nameOfEmployer +" ________________________________\n");
			Console.WriteLine("1- Add Employee");
			Console.WriteLine("2- Authentication of Employee payments");
			Console.WriteLine("3- Calculate the avarage of payments");
			Console.WriteLine("4- Calculate  Employees sallary");
			Console.WriteLine("5- display all Employees information");
			Console.WriteLine("6- display all Employees information at specific month");
			Console.WriteLine("7- Exit to main menu");

		}
		public static void displayEmployeeOperation()
		{
			Console.WriteLine("1- knowing that Authenticatoin is done by manager");
			Console.WriteLine("2- knowing count of points that obtained it in current year");
			Console.WriteLine("3- knowing count of points that coworkers obtained it in current year");
			Console.WriteLine("4- knowing the salary");
			Console.WriteLine("5- Add payments");
			Console.WriteLine("6- Exit");
		}
		public static void init() {
			Console.WriteLine("_______________________Welcome______________________\n");
			Console.WriteLine("Please Select Account Type....... \n");
			Console.WriteLine("1- Employer");
			Console.WriteLine("2- Employee");
			Console.WriteLine("3- Exit to main menu");

			employees2 = new string[3, 5] {  {"1", "rama_x", "123456", "Authanticated","1" }, {"2","mohamed_xx", "98765431", "Authanticated","1"} ,
				{ "3","salem_4a", "123456", "Authanticated","1" }};
			//Console.WriteLine("New Combos size: {0}", employees2.Length.ToString());

			accountDetermination(employees2  , inputType());
		}

		public static void accountDetermination(string[,] array  , int accountType) {

			if (accountType == 1)
			{
				employeeLogin(array, inputUsername(), inputPass(), accountType);

			}
			else if (accountType == 2)
			{
				employeeLogin(array, inputUsername(), inputPass(), accountType);
			}
			else if (accountType == 3)
			{
				Console.WriteLine("Thanks for using our System......");
			}
			else {
				Console.WriteLine("Invilid number plese try another one....");
				accountDetermination(array , inputType());
			}

		}

		public static int inputType() {
			return Convert.ToInt32(Console.ReadLine());
		}

		public static string inputUsername()
		{
			Console.WriteLine("Please enter username");

			return Console.ReadLine();
		}

		public static string inputPass()
		{
			Console.WriteLine("Please enter password");
			return Console.ReadLine();
		}

		public static void employerAccountOperation(int operationType) {

			if (operationType == 1)
			{
				addEmployee();
			}
			else if (operationType == 2)
			{

			}
			else if (operationType == 3) {
			
			}
			else if (operationType == 4)
			{

			}
			else if (operationType == 5)
			{

			}
			else if (operationType == 6)
			{

			}
			else if (operationType == 7)
			{

			}
			else
			{
				Console.WriteLine("Invilid number plese try another one....");
				employerAccountOperation(inputType());
			}
		}

		public static void employeeAccountOperation(int operationType)
		{
			if (operationType == 1)
			{

			}
			else if (operationType == 2)
			{

			}
			else if (operationType == 3)
			{

			}
			else if (operationType == 4)
			{

			}
			else if (operationType == 5)
			{

			}
			else if (operationType == 6)
			{

			}
			else
			{
				Console.WriteLine("Invilid number plese try another one....");
				employerAccountOperation(inputType());
			}
		}

		public static void addEmployee()
		{
			Console.WriteLine("How many employee you want to add ? ");
			int employee_size = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(employees2.GetLength(1));
			employees2 = Re2Dimension(employees2, 3 + employee_size);

			for (int i = 3; i < employees2.GetLength(0); i++)
			{
				Console.WriteLine("Enter the Employee number : " + (i-3));
				for (int j = 0; j < employees2.GetLength(1); j++)
				{
					if (j == 0) {
						Console.WriteLine("Enter Employee Id");
					} else if (j == 1) {
						Console.WriteLine("Enter Employee username");
					}
					else if (j == 2)
					{
						Console.WriteLine("Enter Employee password");
					}
					else if (j == 3)
					{
						Console.WriteLine("Enter Employee Authentication status");
					} else if (j == 4)
					{
						Console.WriteLine("Enter Employee Type");

					}
					employees2[i, j] = Console.ReadLine();

				}
			}

		}

		public static void displayEmployeeInfo()
		{
			for (int i = 0; i < employees2.GetLength(0); i++)
			{

				for (int j = 0; j < employees2.GetLength(1); j++)
				{
					Console.WriteLine(employees2[i, j]);

				}
			}
		}
		
		
		public static void employeeLogin(string[,] array,string id , string pass ,int accountType) {
			int iterations = 0;
			for (int i = 0; i < array.GetLength(0); i++)
			{
				
					Console.WriteLine(" \n");
				
				if (array[i,  1].Equals(id) && array[i, 2].Equals(pass))
				{
					if (accountType == 1)
					{
						iterations++;
						displayEmployerOperation(array[i,1]);
						employerAccountOperation(inputType());
						goto LoopEnd;
						//Console.WriteLine(array[i, j, 1] + "  " + array[i, j, 1]);
					}
					else if (accountType == 2) {
						iterations++;
						displayEmployeeOperation();
						employeeAccountOperation(inputType());
					}

			}
			}
		LoopEnd:
			Console.WriteLine("");

			if (iterations < 1)
			{
				Console.WriteLine("Invilid user name or password ....");
			}
			
			
		}


	}
}