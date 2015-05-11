using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingmentEntityFramework
{
    enum Command
    {
        QUIT = 0,
        CONTINUE,
        CLEAR,
        SELECT_DEPARTMENT,
        SELECT_TRAINEE,
        SELECT_COURSE,
        SELECT_ENROLMENT,
        INSERT_DEPARTMENT,
        INSERT_TRAINEE,
        INSERT_COURSE,
        INSERT_ENROLMENT,
        UPDATE_DEPARTMENT,
        UPDATE_TRAINEE,
        UPDATE_COURSE,
        UPDATE_ENROLMENT,
        DELETE_DEPARTMENT,
        DELETE_TRAINEE,
        DELETE_COURSE,
        DELETE_ENROLMENT,
        DETAILS_DEPARTMENT,
        DETAILS_TRAINEE,
        DETAILS_COURSE,
        DETAILS_ENROLMENT

    }
    class Program
    {
        static VirtualTraineesDbEntities db = new VirtualTraineesDbEntities();
        static void Main(string[] args)
        {
            Command comand = Command.CONTINUE;
            do
            {
                switch (comand)
                {
                    case Command.QUIT:
                        break;
                    case Command.CONTINUE:
                        ShowComand();
                        break;
                    case Command.CLEAR:
                        Console.Clear();
                        break;
                    case Command.SELECT_DEPARTMENT:
                        ShowDepartment();
                        break;
                    case Command.SELECT_TRAINEE:
                        ShowTrainee();
                        break;
                    case Command.SELECT_COURSE:
                        ShowCourse();
                        break;
                    case Command.SELECT_ENROLMENT:
                        ShowEnrolment();
                        break;
                    case Command.INSERT_DEPARTMENT:
                        InsertDepartment();
                        break;
                    case Command.INSERT_TRAINEE:
                        InsertTrainee();
                        break;
                    case Command.INSERT_COURSE:
                        InsertCourse();
                        break;
                    case Command.INSERT_ENROLMENT:
                        InsertEnrolment();
                        break;
                    case Command.UPDATE_DEPARTMENT:
                        UpdateDepartment();
                        break;
                    case Command.UPDATE_TRAINEE:
                        UpdateTrainee();
                        break;
                    case Command.UPDATE_COURSE:
                        UpdateCourse();
                        break;
                    case Command.UPDATE_ENROLMENT:
                        UpdateEnrolment();
                        break;
                    case Command.DELETE_DEPARTMENT:
                        DeleteDepartment();
                        break;
                    case Command.DELETE_TRAINEE:
                        DeleteTrainee();
                        break;
                    case Command.DELETE_COURSE:
                        DeleteCourse();
                        break;
                    case Command.DELETE_ENROLMENT:
                        DeleteEnrolment();
                        break;
                    case Command.DETAILS_DEPARTMENT:
                        DetailsDepartment();
                        break;
                    case Command.DETAILS_TRAINEE:
                        DetailsTrainee();
                        break;
                    case Command.DETAILS_COURSE:
                        DetailsCourse();
                        break;
                    case Command.DETAILS_ENROLMENT:
                        DetailsEnrolment();
                        break;
                    default:
                        Console.WriteLine("Your input selection is wrong\n");
                        break;
                }
                Console.WriteLine("Please input your selection...");
                var readLine = Console.ReadLine();
                int input = string.IsNullOrEmpty(readLine) ? 0 : Convert.ToInt16(readLine);
                comand = (Command)input;
            } while (comand!=Command.QUIT);

            Console.WriteLine("Press any key to quit");
            Console.Read();
        }

        private static void DetailsEnrolment()
        {
            Console.WriteLine("Please enter your Enrolment Id to shoe details:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Enrollment enrollment = db.Enrollments.Find(id);
            Console.WriteLine("\nEnrolment Id: " + enrollment.Id + "\n" + "Enrolment TraineeId: " + enrollment.TraineeId + "\n" + "Enrolment CourseId: " + enrollment.CourseId);
        }

        private static void DetailsCourse()
        {
            Console.WriteLine("Please enter your Course Id to show details:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Course course = db.Courses.Find(id);
            Console.WriteLine("\nCourse Id: " + course.Id + "\n" + "Course Name: " + course.Name + "\n" + "Course Credit: " + course.Credit);
        }

        private static void DetailsTrainee()
        {
            Console.WriteLine("Please enter your Trainee Id to show details:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Trainee trainee = db.Trainees.Find(id);
            Console.WriteLine("\nTrainee Id: " + trainee.Id + "\n" + "Trainee Name: " + trainee.Name + "\n" + "Trainee Adress: " + trainee.Adress + "\n" + "Trainee Phone: "+trainee.Phone+ "\n" + "Trainee Dep_Id: "+trainee.DepartmentId);
        }

        private static void DetailsDepartment()
        {
            Console.WriteLine("Please enter your department Id to show details:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Department department = db.Departments.Find(id);
            Console.WriteLine("\nDepartment Id: "+department.Id+"\n"+"Department Name: "+department.Name+"\n"+"EntryAt: "+department.EntryAt);
        }

        private static void DeleteEnrolment()
        {
            ShowEnrolment();
            Console.WriteLine("Please enter your Enrolment Id:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
            Console.WriteLine("Enrolment deleted successfully.\n");
            ShowEnrolment();
        }

        private static void DeleteCourse()
        {
            ShowCourse();
            Console.WriteLine("Please enter your Course Id to delete:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            Console.WriteLine("Course deleted successfully.\n");
            ShowCourse();
        }

        private static void DeleteTrainee()
        {
            ShowTrainee();
            Console.WriteLine("Please enter your Trainee Id to delete:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Trainee trainee = db.Trainees.Find(id);
            db.Trainees.Remove(trainee);
            db.SaveChanges();
            Console.WriteLine("Trainee deleted successfully.\n");
            ShowTrainee();
        }

        private static void DeleteDepartment()
        {
            ShowDepartment();
            Console.WriteLine("Please enter your department Id to delete:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            Console.WriteLine("Department deleted successfully.\n");
            ShowDepartment(); 
        }

        private static void UpdateEnrolment()
        {
            ShowEnrolment();
            Console.WriteLine("Please enter your Enrolment Id:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Enrollment enrollment = db.Enrollments.Find(id);
            Console.WriteLine("Input new TraineeId: " + enrollment.TraineeId + "\t and CoaurseId of Enrolment:" + enrollment.CourseId);
            string traineeId = Console.ReadLine();
            int trId = int.Parse(traineeId);
            enrollment.TraineeId = trId;
            string courseId = Console.ReadLine();
            int courId = int.Parse(courseId);
            enrollment.CourseId = courId;
            db.SaveChanges();
            Console.WriteLine("Enrolment Updated.\n");
            ShowEnrolment();
        }

        private static void UpdateCourse()
        {
            ShowCourse();
            Console.WriteLine("Please enter your Course Id:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Course course = db.Courses.Find(id);
            Console.WriteLine("Input new name of the course:" + course.Name);
            course.Name = Console.ReadLine();
            db.SaveChanges();
            Console.WriteLine("Trainee Updated.\n");
            ShowCourse();
        }

        private static void UpdateTrainee()
        {
            ShowTrainee();
            Console.WriteLine("Please enter your Trainee Id:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Trainee trainee = db.Trainees.Find(id);
            Console.WriteLine("Input new name of the trainee:" + trainee.Name);
            trainee.Name = Console.ReadLine();
            db.SaveChanges();
            Console.WriteLine("Trainee Updated.\n");
            ShowTrainee();
        }

        private static void UpdateDepartment()
        {
            Console.WriteLine("Please enter your department Id:");
            string strId = Console.ReadLine();
            int id = int.Parse(strId);
            Department department = db.Departments.Find(id);
            Console.WriteLine("Input new name of the department:"+department.Name);
            department.Name = Console.ReadLine();
            db.SaveChanges();
            Console.WriteLine("Department Updated.\n");
            ShowDepartment();
        }

        private static void InsertEnrolment()
        {
            ShowEnrolment();
            Enrollment enrollment=new Enrollment();
            Console.WriteLine("Pleaze enter your Enrolment Id.");
            var input=Console.ReadLine();
            if (input != null) enrollment.Id = int.Parse(input);
            Console.WriteLine("Pleaze enter your Trainee_Id.");
            var str = Console.ReadLine();
            if (str != null) enrollment.TraineeId = int.Parse(str);
            Console.WriteLine("Pleaze enter your Course_Id.");
            var line = Console.ReadLine();
            if (line != null) enrollment.CourseId = int.Parse(line);            
            db.Enrollments.Add(enrollment);
            db.SaveChanges();
            Console.WriteLine("Enrolment saved.\n");
            ShowEnrolment();

        }

        private static void InsertCourse()
        {
            ShowCourse();
            Course course=new Course();
            string input;
            Console.WriteLine("Pleaze enter your Course Id.");
                do
                {
                     input = Console.ReadLine();
                    try
                    {
                        if (input != null)
                            course.Id = Int32.Parse(input); ;
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    
                } while (input != null);
            Console.WriteLine("Pleaze enter your Course Name.");
            course.Name = Console.ReadLine();
            Console.WriteLine("Pleaze enter your Course Credit.");
            var str = Console.ReadLine();
            if (str!=null)
            {
                course.Credit = int.Parse(str);
            }
            db.Courses.Add(course);
            db.SaveChanges();
            Console.WriteLine("Course saved.\n");
            ShowCourse();
        }

        private static void InsertTrainee()
        {
            ShowTrainee();
            Trainee trainee=new Trainee();
            string input;
            Console.WriteLine("Pleaze enter your Trainee Id.");
            do
            {
                input = Console.ReadLine();
                try
                {
                   if (input != null)
                    {
                        trainee.Id = Int32.Parse(input);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (input!=null);
            
            Console.WriteLine("Pleaze enter your Trainee Name.");
            trainee.Name = Console.ReadLine();
            Console.WriteLine("Pleaze enter your Adress.");
            trainee.Adress = Console.ReadLine();
            Console.WriteLine("Pleaze enter your Phone.");
            trainee.Phone = Console.ReadLine();
            Console.WriteLine("Pleaze enter your DepartmentId.");
            var str = Console.ReadLine();
            if (str != null)
            {
                trainee.DepartmentId = Int32.Parse(str);
            }
            db.Trainees.Add(trainee);
            db.SaveChanges();
            Console.WriteLine("Trainee saved \n");
            ShowTrainee();

        }

        private static void InsertDepartment()
        {
            ShowDepartment();
            Department department=new Department();
            string input;
            Console.WriteLine("Pleaze enter your department Id.");
            //Debug.Assert(input != null, "Department id is null, Insert Department Id");
            do
            {
                input = Console.ReadLine();
                try
                {
                    if (input != null)
                    {
                        department.Id = Int32.Parse(input);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (input != null);
            Console.WriteLine("Pleaze enter your department name.");
            department.Name = Console.ReadLine();
            department.EntryAt = DateTime.Now;
            db.Departments.Add(department);
            db.SaveChanges();
            Console.WriteLine("Department Saved, All Departments shown below.\n");
            ShowDepartment();
        }

        private static void ShowEnrolment()
        {
            List<Enrollment> enrollments = db.Enrollments.OrderBy(x => x.TraineeId).ToList();
            Console.WriteLine("TraineeId:" + "\t" + "CourseId:");
            foreach (Enrollment enrollment in enrollments)
            {
                Console.WriteLine("\t "+enrollment.TraineeId+"\t\t"+enrollment.CourseId);
            }
        }

        private static void ShowCourse()
        {
            List<Course> courses = db.Courses.OrderBy(x => x.Name).ToList();
            foreach (Course course in courses)
            {
                Console.WriteLine(course.Name);
            }

        }

        private static void ShowTrainee()
        {
            List<Trainee> trainees = db.Trainees.OrderBy(x => x.Name).ToList();
            foreach (Trainee trainee in trainees)
            {
                Console.WriteLine(trainee.Name);
            }
        }

        private static void ShowDepartment()
        {
            List<Department> departments = db.Departments.OrderBy(x => x.EntryAt).ToList();
            foreach (Department department in departments)
            {
                Console.WriteLine(department.Name);
            }
        }

        private static void ShowComand()
        {
            string[] names = Enum.GetNames(typeof(Command));
            foreach (string name in names)
            {
                Console.WriteLine(string.Format("{0}-{1}",name, (int)Enum.Parse(typeof(Command),name)));
            }
        }
    }
}
