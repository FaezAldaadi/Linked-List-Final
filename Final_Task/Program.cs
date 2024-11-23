namespace Final_Task
{
    class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double FirstExam { get; set; }
        public double SecondExam { get; set; }
        public double Avg { get; set; }
        public string Grade { get; set; }
        public Node Next { get; set; }

        public Node(int id, string name, double firstExam, double secondExam)
        {
            Id = id;
            Name = name;
            FirstExam = firstExam;
            SecondExam = secondExam;
            Avg = CalcAvg();
            Grade = DetermineGrade(Avg);
            Next = null;
        }

        // حساب المجموع
        private double CalcAvg()
        {
            return (FirstExam + SecondExam) / 2;
        }

        private string DetermineGrade(double Avg)
        {
            if (Avg < 50) return "Failed";
            else if (Avg < 65) return "Good";
            else if (Avg < 85) return "Very Good";
            else return "Excellent";
        }
    }
    class StudentLinkedList
    {
        private Node head;

        // إضافة طالب إلى اللائحة مع المحافظة على الترتيب
        public void AddStudent(int id, string name, double firstExam, double secondExam)
        {
            Node newNode = new Node(id, name, firstExam, secondExam);

            if (head == null || newNode.Avg < head.Avg)
            {
                newNode.Next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null && current.Next.Avg < newNode.Avg)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }
        // عرض بيانات جميع الطلاب
        public void DisplayStudents()
        {
            if (head == null)
            {
                Console.WriteLine("The list is empty");
                return;
            }

            Node current = head;
            while (current != null)
            {
                Console.WriteLine($"Number: {current.Id}, Name: {current.Name}, " +
                                  $"Exam number one: {current.FirstExam}, Exam number two: {current.SecondExam}, " +
                                  $"result: {current.Avg}, apprecication: {current.Grade}");
                current = current.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentLinkedList studentList = new StudentLinkedList();

            
            //studentList.AddStudent(1, "Yasser", 70, 80);
            //studentList.AddStudent(2, "Faez", 90, 95);
            //studentList.AddStudent(3, "Mohamed", 50, 60);
            //studentList.AddStudent(4, "Noor", 30, 40);
            //studentList.AddStudent(5, "Ahmed", 65, 90);
            //studentList.AddStudent(6, "Samy", 40, 79);

            while (true)
            {
                    // طلب إدخال بيانات الطالب او ايقاف الادخال
                    Console.Write("enter number student or enter \"end\" to stop entry ");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "end") break;

                    int id = int.Parse(input);

                    Console.Write("Enter student name :");
                    string name = Console.ReadLine();

                    Console.Write("Enter the first exam mark :");
                    double firstExam = double.Parse(Console.ReadLine());

                    Console.Write("Enter the second exam mark :");
                    double secondExam = double.Parse(Console.ReadLine());
                    // إضافة الطالب إلى اللائحة
                    studentList.AddStudent(id, name, firstExam, secondExam);

                    Console.WriteLine("The student has been added successfully\n");
            }


            Console.WriteLine("Student data :");
            studentList.DisplayStudents();
        }
    }
}
