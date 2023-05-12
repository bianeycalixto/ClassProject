using ClassProject.Model;

namespace ClassProject
{
    public class Program
    {
        //initilizate class variables to be used in processing
        private static Students students = new Students();
        private static List<Appointment> appointment = new List<Appointment>();
        private static List<StudentAppointment> studentAppointments = new List<StudentAppointment>();
        private static List<Professor> Professors = new List<Professor>();
        private static Student authenticatedStudent;

        private static Student student;
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing...");
            Initialize();
            Menu();
        }

        static void Initialize() //initialize local variables, including professors and students already in the system
        {
            var c1 = new Student
            {
                FirstName = "Kambiz",
                LastName = "Saffari",
                Username = "kambiz",
                Password = "1234"
            };
            var c2 = new Student
            {
                FirstName = "Terence",
                LastName = "Ow",
                Username = "terence",
                Password = "2345"
            };

            students.students.Add(c1);
            students.students.Add(c2); //add students to list

            var p1 = new Professor
            {
                FirstName = "Angela",
                LastName = "Sorby",
                Subject = "English"
            };

            var p2 = new Professor
            {
                FirstName = "John",
                LastName = "Schaaf",
                Subject = "Math",
            };

            var p3 = new Professor
            {
                FirstName = "Todd",
                LastName = "Bangura",
                Subject = "Chemistry",
            };

            var p4 = new Professor
            {
                FirstName = "Clifton",
                LastName = "Ellis",
                Subject = "Coding",
            };

            var p5 = new Professor
            {
                FirstName = "Michael",
                LastName = "Johns",
                Subject = "Physics",
            };

            Professors.Add(p1);
            Professors.Add(p2);
            Professors.Add(p3);
            Professors.Add(p4);
            Professors.Add(p5); //add profesors to list
        }

        static void Menu()
        {
            bool done = false;

            while (!done) //the main menu loops until the user presses q, which sets the boolean to true, exiting the loop
            {
                Console.WriteLine("Options: \r\n Login: 1 \r\n Logout: 2 \r\n Sign Up: 3 \r\n Create Appointment: 4 \r\n Show Appointment: 5 \r\n Clear Screen: c \r\n Quit: q");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice) //the choice from the user is parsed and the proper submenu is opened
                {
                    case "1":
                        LoginMenu(); //login menu; prompts for username and password, autheniticates user
                        break;
                    case "2":
                        LogoutMenu(); //clears the authenticated user role, locking the other features
                        break;
                    case "3":
                        SignUpMenu(); //allows for the creation of a new account 
                        break;
                    case "4":
                        var p1 = new Professor(); //scheduling for appointments
                        Console.Write("What subject do you need help with: 1 = English, 2 = Math, 3 = Chemistry, 4 = Coding, 5 = Physics"); //user chooses the subject that they need help with
                        string ans = Console.ReadLine();
                        switch (ans)
                        { //anser is parsed and professor that given subject is chosen and assigned
                            case "1":
                                p1 = Professors[1];
                                break;
                            case "2":
                                p1 = Professors[2];
                                break;
                            case "3":
                                p1 = Professors[3];
                                break;
                            case "4":
                                p1 = Professors[4];
                                break;
                            case "5":
                                p1 = Professors[5];
                                break;
                            default:
                                Console.WriteLine("Sorry, no profesors available for given subject...");
                                break;
                        }
                        Console.Write("How many days away would you like to schedule?"); //they choose how many days away they would like the meeting to be
                        int days = Convert.ToInt32(Console.ReadLine());
                        var apt = MakeAppointment(days, p1); //creates the appointment using the specified days and the professor relevant to the subject
                        var ca3 = new StudentAppointment(authenticatedStudent, apt, p1);
                        studentAppointments.Add(ca3); //adds the appointment to the list that the student has 
                        break;
                    case "5":
                        GetCurrentAppointmentsMenu(); //prints out the current list of appointments for the logged in student
                        break;
                    case "c":
                        Console.Clear(); //clears the console 
                        break;
                    case "q":
                        done = true; //exits the loop
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

            }

        }


        static void LoginMenu()
        {
            if (authenticatedStudent == null) //only starts if no one is logged in, else just breaks
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                authenticatedStudent = students.Authenticate(username, password); //verifies username and password with what user enters
                if (authenticatedStudent != null)
                {
                    Console.WriteLine($"Welcome {authenticatedStudent.FirstName}");
                }
                else
                {
                    Console.WriteLine("invalid username or password");
                }
            }
            else
            {
                Console.WriteLine($"You are already logged in as {authenticatedStudent.Username}");
            }
        }

        static void LogoutMenu() //logs out the user 
        {
            authenticatedStudent = null;
            Console.WriteLine("Logged out!");
        }

        static void SignUpMenu() //creates a new student struct that is then added to the Students list  
        {
            //takes in all necesary infor and adds to the model
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string LastName = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            var newStudent = new Student
            {
                FirstName = firstName,
                LastName = LastName,
                Username = username,
                Password = password
            };

            students.students.Add(newStudent);

            Console.WriteLine("Profile created!");

        }


        static void GetCurrentAppointmentsMenu() //prints out the list of appointments assigned to the student that is logged in. 
        {
            if (authenticatedStudent == null)
            {
                Console.WriteLine("You are not logged in.");
                return;
            }

            var appointmentList = studentAppointments.Where(o => o.student.Username == authenticatedStudent.Username);

            if (appointmentList.Count() == 0)
            {
                Console.WriteLine("0 appointment found.");
            }
            else
            {
                foreach (var appointmnet in appointmentList) //if count of appointments is greater than 0, loops through all of them and prints out the date, time, professor and subject 
                {
                    Console.WriteLine("Chosen appointment: " + appointmnet.appointment.date + " with " + appointmnet.appointment.prof.FirstName + " " + appointmnet.appointment.prof.LastName + ". Subject: " + appointmnet.appointment.prof.Subject);
                }
            }
        }

        static Appointment MakeAppointment(int days, Professor p1) //makes the appointment and returns it
        {
            var apt = new Appointment(days, p1);
            return apt;

        }



    }
}