using ClassProject.Model;

//git commands: 

//git status
//git add .
//git commit -m "did things"
//git push origin head

//git checkout delopment
//git pull origin delopment

namespace ClassProject
{
    public class Program
    {
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

        static void Initialize()
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
            students.students.Add(c2);

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
            Professors.Add(p5);
        }

        static void Menu()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine("Options: \r\n Login: 1 \r\n Logout: 2 \r\n Sign Up: 3 \r\n Create Appointment: 4 \r\n Show Appointment: 5 \r\n Clear Screen: c \r\n Quit: q");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        LoginMenu();
                        break;
                    case "2":
                        LogoutMenu();
                        break;
                    case "3":
                        SignUpMenu();
                        break;
                    case "4":
                        var p1 = new Professor();
                        Console.Write("What subject do you need help with: 1 = English, 2 = Math, 3 = Chemistry, 4 = Coding, 5 = Physics; ");
                        string ans = Console.ReadLine();
                        switch (ans)
                        {
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
                        Console.Write("How many days away would you like to schedule?");
                        int days = Convert.ToInt32(Console.ReadLine());
                        var apt = MakeAppointment(days, p1);
                        var ca3 = new StudentAppointment(authenticatedStudent, apt, p1);
                        studentAppointments.Add(ca3);
                        break;
                    case "5":
                        GetCurrentAppointmentsMenu();
                        break;
                    case "c":
                        Console.Clear();
                        break;
                    case "q":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }

            }

        }


        static void LoginMenu()
        {
            if (authenticatedStudent == null)
            {
                Console.Write("Enter your username: ");
                string username = Console.ReadLine();
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();
                authenticatedStudent = students.Authenticate(username, password);
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

        static void LogoutMenu()
        {
            authenticatedStudent = null;
            Console.WriteLine("Logged out!");
        }

        static void SignUpMenu()
        {
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


        static void GetCurrentAppointmentsMenu()
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
                foreach (var appointmnet in appointmentList)
                {
                    Console.WriteLine("Chosen appointment: " + appointmnet.appointment.date + " with " + appointmnet.appointment.prof.FirstName + " " + appointmnet.appointment.prof.LastName + ". Subject: " + appointmnet.appointment.prof.Subject);
                }
            }
        }

        static Appointment MakeAppointment(int days, Professor p1)
        {
            var apt = new Appointment(days, p1);
            return apt;

        }



    }
}