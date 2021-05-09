using System;
using System.Linq;

namespace testCSharp
{
	class Program
	{
		public static string[,] payments;
		public static string[,] employees2;
		public static string username="";

		public static string[,] Re2Dimension(string[,] OldArray, int arr1stDimLength)
		{
			// declare a larger array
			string[,] NewArray = new string[arr1stDimLength, OldArray.GetLength(1)];

			// determine if we are shrinking or enlarging
			const int FirstDimension = 0;
			const int SecondDimension = 1;
			int xMax = 0;
			int yMax = 0;
			
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
			Console.WriteLine("5- Calculate annual bonus");
			Console.WriteLine("6- display all Employees information");
			Console.WriteLine("8- Exit to main menu");

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
			homeForm();
			
			                                 //id|  name    |  password |  comnfirmation | emp t | phone|   interval | category | points | salary
			employees2 = new string[3, 10] {  {"1", "rama_x", "a12345678", "Authanticated"  ,"1"," 012345610" ,"5"       ,"A",     "80"  , "10000"}, 
				                             {"2","mohamed_xx","b12345678","Authanticated" ,"1", "012345678" ,"5"       ,"B",     "100", "10000"} ,
				                             {"3","salem_4a", "c12345678", "Authanticated" ,"2", "010023456" ,"2"       ,"c",     "80", "10000"}};

										   //id | name   | payments | confirmation |requ |i
			payments = new string[7, 6] {  {"1", "rama_x", "10"     ,"Y"           ,"0" ,"1"},
										   {"1", "rama_x", "20"     ,"N"           ,"0" ,"2"},
										   {"1", "rama_x", "40"     ,"Y"           ,"1" ,"3"},
										   { "2","mohamed_xx", "10" ,"Y"           ,"1" ,"4"},
										   { "2","mohamed_xx", "10" ,"N"           ,"1" ,"5"},
										   { "3","salem_4a", "30"   ,"N"           ,"0" ,"6"},
										   { "3","salem_4a", "30"   ,"N"           ,"0" ,"7"}};

			//Console.WriteLine("New Combos size: {0}", employees2.Length.ToString());

			accountDetermination(employees2  , inputType());
		}
		public static void homeForm() {
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("_______________________Welcome______________________\n");
			Console.WriteLine("Please Select Account Type....... \n");
			Console.WriteLine("1- Employer");
			Console.WriteLine("2- Employee");
			Console.WriteLine("3- Exit to main menu");
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
				AuthenticatePayment();
			}
			else if (operationType == 3) {
				calculateAvarageOfPayments();
			}
			else if (operationType == 4)
			{
				calculateTotalSalaryOfTheMonth();
			}
			else if (operationType == 5)
			{
				calculateAnnualBonus();
			}
			else if (operationType == 6)
			{
				displayEmployeesInfo();
			}
			else if (operationType == 8)
			{
				homeForm();
				accountDetermination(employees2, inputType());
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
				Console.WriteLine("please Enter the payment number");
				displayAuthenticationStutus(username , Console.ReadLine());
			}
			else if (operationType == 2)
			{
				displayYourPointsInfo(username);
			}
			else if (operationType == 3)
			{
				displayCoworkerPointsInfo();
			}
			else if (operationType == 4)
			{
				calculateTotalSalary();
			}
			else if (operationType == 5)
			{
				addPayments();
			}
			else
			{
				Console.WriteLine("Invilid number plese try another one....");
				employeeAccountOperation(inputType());
			}
		}

		public static void AuthenticatePayment() {
			displayPaymentsStutus();
			Console.WriteLine("Please Select which of payment you want to Authenticate .....");
			
			string numberOfPayment = Console.ReadLine();
			for (int j = 0; j < payments.GetLength(0); j++)
			{
				
				if (payments[j, 5].Equals(numberOfPayment)) {
					Console.WriteLine("Write Y for Yes");
					Console.WriteLine("Write N for No");
					string confirmation = Console.ReadLine();
					payments[j, 5] = confirmation;
				}

			}

			Console.WriteLine("Authenticated succefully");
			goBackIntoMainMenu(2);

		}

		public static void addEmployee()
		{
			
			string pass = "";
			bool check = true;
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

						pass = Console.ReadLine();
						if (IsValidPassword(pass))
						{
							check = false;
						}
						else {
							Console.WriteLine("this password is invalid");
							check = true;
						}

						while (check) {
							
							pass = Console.ReadLine();
							if (IsValidPassword(pass))
							{
								
								check = false;
							}
							else
							{
								Console.WriteLine("this password is invalid");
								check = true;
							}
						}

					}
					else if (j == 3)
					{
						Console.WriteLine("Enter Employee Authentication status");
					} else if (j == 4)
					{
						Console.WriteLine("Enter Employee Type");

					}
					else if (j == 5)
					{
						Console.WriteLine("Enter Phone Number");
					}
					else if (j == 6)
					{
						Console.WriteLine("Enter Interval");
					}
					else if (j == 7)
					{
						Console.WriteLine("Enter Category");
					}
					else if (j == 8)
					{
						Console.WriteLine("Enter number of points");
					}
					else if (j == 9)
					{
						Console.WriteLine("Enter Employee Salary");
					}

					if (j == 2)
					{
						employees2[i, j] = pass;
					}
					else { 
					employees2[i, j] = Console.ReadLine();
					}

				}
			}
			Console.WriteLine("Employees Added succesfully...");

			goBackIntoMainMenu(2);


		}

		public static void goBackIntoMainMenu(int type) {
			Console.WriteLine("Press enter to go back into main menu");

			Console.ReadLine();
			if (type == 1) {
				homeForm();
				accountDetermination(employees2, inputType());
			} else if (type == 2) {
				displayEmployerOperation(username);
				employerAccountOperation(inputType());

			} else if (type == 3) {
				displayEmployeeOperation();
				employeeAccountOperation(inputType());
			}
			
		}

		public static void spreateLine() {
			Console.WriteLine();
			Console.WriteLine("--------------------------------------------------------------");
			Console.WriteLine();
		}
		public static void addPayments()
		{
			spreateLine();
			Console.WriteLine("How many days you want to add ? ");
			int daysCount = Convert.ToInt32(Console.ReadLine());
			
			payments = Re2Dimension(payments, 3 + daysCount);

			for (int i = 3; i < payments.GetLength(0); i++)
			{
				
				for (int j = 0; j < payments.GetLength(1); j++)
				{
					if (j == 0)
					{
						Console.WriteLine("Enter your Id");
					}
					else if (j == 1)
					{
						Console.WriteLine("Enter your username");
					}
					else if (j == 2)
					{
						Console.WriteLine("Enter payment for day number # " + (i - 2));
					}
					else if (j == 3)
					{
						payments[i, 3] = "N";
						continue;
					}
					else if (j == 4)
					{
						Console.WriteLine("Do you want to request this payment?  ");
						Console.WriteLine();
						Console.WriteLine("1- Yes");
						Console.WriteLine("2- No");

					} else if (j == 5) {
						payments[i, 5] = Convert.ToString((Convert.ToInt32(payments[i, 5])+1) );
						continue;
					}

					payments[i, j] = Console.ReadLine();

				}
			}
			goBackIntoMainMenu(3);

		}

		public static void calculateTotalSalary()
		{
			spreateLine();
			int iteration = 0;
			int sum = 0;
			int result = 0;
			for (int i = 0; i < employees2.GetLength(0); i++)
			{


				Console.WriteLine("ID : " + employees2[i, 0] +
					" | " + "Name : " + employees2[i, 1] +
					" | " + "Phone : " + employees2[i, 5] +
					" | " + "Auth" + employees2[i, 3] +
					" | " + "Type : " + employees2[i, 4] +
					" | " + "Employee Interval : " + employees2[i, 6] +
					" | " + "Category : " + employees2[i, 7] +
					" | " + "Points : " + employees2[i, 8] +
					" | " + "Salary" + employees2[i, 9]);

				for (int j = 0; j < payments.GetLength(0); j++)
				{
					if (payments[j, 0].Equals(employees2[i, 0]))
					{
						iteration++;
						sum += Convert.ToInt32(payments[j, 2]);

						Console.WriteLine("payment for day number " + j + " ==> " + payments[j, 2]);

					}

				}
				result = sum / iteration;
				Console.WriteLine("The Avarge of payments is for " + employees2[i, 1] + " ==> " + result);
				Console.WriteLine("The Salary of Employee : " + employees2[i, 1] + " ==> " + ((Convert.ToInt32(employees2[i, 9]) * 30)) + result);
				iteration = 0;
				sum = 0;
				result = 0;


				spreateLine();

			}
			goBackIntoMainMenu(3);

		}
		public static void calculateTotalSalaryOfTheMonth() {
			spreateLine();
			int iteration = 0;
			int sum = 0;
			int result = 0;
			for (int i = 0; i < employees2.GetLength(0); i++)
			{


				Console.WriteLine("ID : " + employees2[i, 0] +
					" | " + "Name : " + employees2[i, 1] +
					" | " + "Phone : " + employees2[i, 5] +
					" | " + "Auth" + employees2[i, 3] +
					" | " + "Type : " + employees2[i, 4] +
					" | " + "Employee Interval : " + employees2[i, 6] +
					" | " + "Category : " + employees2[i, 7] +
					" | " + "Points : " + employees2[i, 8] +
					" | " + "Salary" + employees2[i, 9]);

				for (int j = 0; j < payments.GetLength(0); j++)
				{
					if (payments[j, 0].Equals(employees2[i, 0]))
					{
						iteration++;
						sum += Convert.ToInt32(payments[j, 2]);

						Console.WriteLine("payment for day number " + j + " ==> " + payments[j, 2]);

					}

				}
				result = sum / iteration;
				Console.WriteLine("The Avarge of payments is for " + employees2[i, 1] + " ==> " + result);
				Console.WriteLine("The Salary of Employee : " + employees2[i, 1] + " ==> "+ (( Convert.ToInt32( employees2[i,9]) * 30))+result );
				iteration = 0;
				sum = 0;
				result = 0;


				spreateLine();

			}
			goBackIntoMainMenu(2);

		}
		public static void calculateAnnualBonus() {
			spreateLine();
			double newSalary = 0;
			for (int i = 0; i < employees2.GetLength(0); i++)
			{
				if (!employees2[i, 7].Equals("A") && Convert.ToInt32(employees2[i, 6])>3)
				{
					if (Convert.ToInt32(employees2[i, 8]) >= 80)
					{
						newSalary = Convert.ToDouble(employees2[i, 8] + (2 * Convert.ToDouble(employees2[i, 8]) ));
						employees2[i, 9] = Convert.ToString(newSalary);
					}
					else if (Convert.ToInt32(employees2[i, 8]) >= 65 && Convert.ToInt32(employees2[i, 8]) <= 79)
					{
						newSalary = Convert.ToDouble(employees2[i, 8]+(1.5 * Convert.ToDouble(employees2[i, 8]) ));
						employees2[i, 9] = Convert.ToString(newSalary);
					}
					else if (Convert.ToInt32(employees2[i, 8]) >= 50 && Convert.ToInt32(employees2[i, 8]) <= 64)
					{
						newSalary = Convert.ToInt32(employees2[i, 8] + (2 * Convert.ToDouble(employees2[i, 8]) ));
						employees2[i, 9] = Convert.ToString(newSalary);
					}
					else if (Convert.ToInt32(employees2[i, 8]) <= 50) { 
					
					}
				}
				else { 
				
				}
				newSalary = 0;
				
			}

			displayEmployeesInfo();
			spreateLine();
			goBackIntoMainMenu(2);
		}


		public static void calculateAvarageOfPayments() {
			spreateLine();
			int iteration = 0;
			int sum = 0;
			int result = 0;
			for (int i = 0; i < employees2.GetLength(0); i++)
			{


				Console.WriteLine("ID : " + employees2[i, 0] +
					" | " + "Name : " + employees2[i, 1] +
					" | " +"Phone : " + employees2[i, 5] + 
					" | " + "Auth" + employees2[i, 3] +
					" | " + "Type : " + employees2[i, 4] +
					" | "+ "Employee Interval : "+ employees2[i,6]+
					" | "+ "Category : "+ employees2[i,7]+
					" | "+ "Points : "+ employees2[i,8]+
					" | "+ "Salary"+ employees2[i,9]);

				for (int j = 0; j < payments.GetLength(0); j++)
				{
					if (payments[j, 0].Equals(employees2[i, 0]))
					{
						iteration++;
						sum += Convert.ToInt32(payments[j,2]);
						
						Console.WriteLine("payment for day number " + j + " ==> " + payments[j, 2]);
						
					}
					
				}
				result = sum / iteration;
				Console.WriteLine("The Avarge of payments is for " + employees2[i, 1] + " ==> " + result);
				iteration = 0;
				sum = 0;
				result = 0;
				spreateLine();

			}
			goBackIntoMainMenu(2);
		}
		public static void displayYourPointsInfo(string username)
		{
			spreateLine();
			for (int i = 0; i < employees2.GetLength(0); i++)
			{

				if (employees2[i, 1].Equals(username)) {
					Console.WriteLine("ID : " + employees2[i, 0] +
						" | " + "Name : " + employees2[i, 1] +	
						" | Category : " + employees2[i, 7] +
						" | " + "Points : " + employees2[i, 8] 
						);

					for (int j = 0; j < payments.GetLength(0); j++)
					{
						if (payments[j, 0].Equals(employees2[i, 0]))
						{
							Console.WriteLine("payment for day number " + j + " ==> " + payments[j, 2]);
						}
					}
				}

				
				spreateLine();

			}

			goBackIntoMainMenu(3);
		}
		public static void displayCoworkerPointsInfo()
		{
			spreateLine();
			for (int i = 0; i < employees2.GetLength(0); i++)
			{

					Console.WriteLine("ID : " + employees2[i, 0] +
						" | " + "Name : " + employees2[i, 1] +
						" | Category : " + employees2[i, 7] +
						" | " + "Points : " + employees2[i, 8]
						);

					for (int j = 0; j < payments.GetLength(0); j++)
					{
						if (payments[j, 0].Equals(employees2[i, 0]))
						{
							Console.WriteLine("payment for day number " + j + " ==> " + payments[j, 2]);
						}
					}
				spreateLine();
			}

				spreateLine();

			goBackIntoMainMenu(3);

		}

		public static void displayPaymentsStutus() {
			for (int i = 0; i < employees2.GetLength(0); i++)
			{
				Console.WriteLine("ID : " + employees2[i, 0] +
						" | " + "Name : " + employees2[i, 1] +
						" | " + "Phone : " + employees2[i, 5] +
					    " | Category : " + employees2[i, 7] 
						);
				for (int j = 0; j < payments.GetLength(0); j++)
				{

					if (payments[j, 0].Equals(employees2[i, 0]))
					{
						string rquestStutus = payments[j, 4].Equals("0") ? "Without Request" : "Request is done";
						Console.WriteLine("payment number : " + (j + 1) + " : " + payments[j, 2] + " | Confirmation : " +
							payments[j, 3] + " request stutus :  " + rquestStutus);
					}


				}
				spreateLine();
			}
		}
		public static void displayAuthenticationStutus(string username ,string paymentNumber)
		{
			spreateLine();
		
			for (int j = 0; j < payments.GetLength(0); j++)
			{

				if (payments[j, 1].Equals(username) && payments[j,5].Equals(paymentNumber))
				{
					string rquestStutus = payments[j, 4].Equals("0") ? "Without Request" : "Request is done";
					Console.WriteLine("payment number : " + paymentNumber + " | The amount is : " + payments[j, 2] + " | Confirmation : " +
						payments[j, 3] + " | request stutus :  " + rquestStutus);
				}


			}
			goBackIntoMainMenu(3);
		}
		public static void displayEmployeesInfo()
		{
			spreateLine();
			for (int i = 0; i < employees2.GetLength(0); i++)
			{

			
					Console.WriteLine("ID : "+ employees2[i, 0]+
						" | "+"Name : "+ employees2[i,1]+
						" | "+"Phone : "+employees2[i,5]+
						" | "+"Auth : " + employees2[i, 3] +
						" | "+"Type : "+employees2[i,4]+"\n"
						+"Category : "+employees2[i,7] +
						" | "+ "Interval : "+ employees2[i,6] +
						" | "+"Points : "+employees2[i,8]+
						" | " + "Salary : " + employees2[i, 9]);

				for (int j = 0; j < payments.GetLength(0); j++) {
					if (payments[j, 0].Equals(employees2[i, 0]))
					{
						Console.WriteLine("payment for day number " + j + " ==> " + payments[j, 2]);
					}
				}
				spreateLine();

			}
			goBackIntoMainMenu(2);
		}
		
		public static void employeeLogin(string[,] array,string id , string pass ,int accountType) {
			
			int iterations = 0;
			if (IsValidPassword(pass))
			{
				for (int i = 0; i < array.GetLength(0); i++)
				{

					Console.WriteLine(" \n");

					if (array[i, 1].Equals(id) && array[i, 2].Equals(pass))
					{
						if (accountType == 1)
						{
							if (!array[i, 4].Equals("2"))
							{
								iterations++;
								username = id;
								displayEmployerOperation(array[i, 1]);
								employerAccountOperation(inputType());
								goto LoopEnd;
							}
							else
							{
								Console.WriteLine("This account is an Employee Account please select correct account type\n");
								Console.WriteLine("Please Select Account Type....... \n");
								accountDetermination(employees2, inputType());
							}

							//Console.WriteLine(array[i, j, 1] + "  " + array[i, j, 1]);
						}
						else if (accountType == 2)
						{
							if (!array[i, 4].Equals("1"))
							{
								username = id;
								iterations++;
								displayEmployeeOperation();
								employeeAccountOperation(inputType());
							}
							else
							{
								Console.WriteLine("This account is an Employer Account please select correct account type\n");
								Console.WriteLine("Please Select Account Type....... \n");
								accountDetermination(employees2, inputType());
							}

						}

					}
				}
			LoopEnd:
				Console.WriteLine("");

				if (iterations < 1)
				{
					Console.WriteLine("Invilid user name or password ....\n");
					Console.WriteLine("Please try another user name or password ....");
					employeeLogin(array, inputUsername(), inputPass(), accountType);

				}
			}
			else {
				Console.WriteLine("The password does not fulfill the conditions ....");
				Console.WriteLine("Please try another user name or password ....");
				employeeLogin(array, inputUsername(), inputPass(), accountType);
			}	
			
		}

		static bool IsLetter(char c)
		{
			return (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z');
		}

		static bool IsDigit(char c)
		{
			return c >= '0' && c <= '9';
		}

		static bool IsSymbol(char c)
		{
			return c > 32 && c < 127 && !IsDigit(c) && !IsLetter(c);
		}

		static bool IsFirstIndexIsCharacter(string pass)
		{
			 pass.Substring(0, 1);
			if (pass.Substring(0, 1).Equals("a") || pass.Substring(0, 1).Equals("b") ||
				pass.Substring(0, 1).Equals("c") || pass.Substring(0, 1).Equals("d") ||
				pass.Substring(0, 1).Equals("e") || pass.Substring(0, 1).Equals("f") ||
				pass.Substring(0, 1).Equals("g") || pass.Substring(0, 1).Equals("h") ||
				pass.Substring(0, 1).Equals("i") || pass.Substring(0, 1).Equals("j") ||
				pass.Substring(0, 1).Equals("k") || pass.Substring(0, 1).Equals("l") ||
				pass.Substring(0, 1).Equals("m") || pass.Substring(0, 1).Equals("n") ||
				pass.Substring(0, 1).Equals("o") || pass.Substring(0, 1).Equals("p") ||
				pass.Substring(0, 1).Equals("q") || pass.Substring(0, 1).Equals("r") ||
				pass.Substring(0, 1).Equals("s") || pass.Substring(0, 1).Equals("t") ||
				pass.Substring(0, 1).Equals("u") || pass.Substring(0, 1).Equals("v") ||
				pass.Substring(0, 1).Equals("w") || pass.Substring(0, 1).Equals("x") ||
				pass.Substring(0, 1).Equals("y") || pass.Substring(0, 1).Equals("z") ||
				pass.Substring(0, 1).Equals("A") || pass.Substring(0, 1).Equals("B") ||
				pass.Substring(0, 1).Equals("c") || pass.Substring(0, 1).Equals("D") ||
				pass.Substring(0, 1).Equals("E") || pass.Substring(0, 1).Equals("F") ||
				pass.Substring(0, 1).Equals("G") || pass.Substring(0, 1).Equals("H") ||
				pass.Substring(0, 1).Equals("I") || pass.Substring(0, 1).Equals("J") ||
				pass.Substring(0, 1).Equals("K") || pass.Substring(0, 1).Equals("L") ||
				pass.Substring(0, 1).Equals("M") || pass.Substring(0, 1).Equals("N") ||
				pass.Substring(0, 1).Equals("O") || pass.Substring(0, 1).Equals("P") ||
				pass.Substring(0, 1).Equals("Q") || pass.Substring(0, 1).Equals("R") ||
				pass.Substring(0, 1).Equals("S") || pass.Substring(0, 1).Equals("T") ||
				pass.Substring(0, 1).Equals("U") || pass.Substring(0, 1).Equals("V") ||
				pass.Substring(0, 1).Equals("W") || pass.Substring(0, 1).Equals("X") ||
				pass.Substring(0, 1).Equals("Y") || pass.Substring(0, 1).Equals("Z"))
			{
				return true;
			}
			else {
				return false;
			}
			
		}

		static bool IsValidPassword(string password)
		{
			return
			   password.Any(c => IsLetter(c)) &&
			   password.Any(c => IsDigit(c)) &&
			  // password.Any(c => IsSymbol(c))&&
			   password.Length >= 8&&
			   IsFirstIndexIsCharacter(password);
		}

	}
}
