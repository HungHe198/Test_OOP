using System;
using System.Collections;

namespace EmailProcessorWithArrayList
{
    // ✅ Lớp đại diện một chuỗi có thể chứa email
    class EmailEntry
    {
        public string Original { get; }

        public EmailEntry(string original)
        {
            Original = original;
        }

        public bool IsValid()
        {
            return Original.Contains("@");
        }

        public string GetProcessed()
        {
            int lastAt = Original.LastIndexOf("@");

            if (lastAt <= 0)
                return "@...";

            string before = Original.Substring(0, lastAt).Replace("@", "");
            return before + "@...";
        }
    }

    // ✅ Lớp xử lý danh sách Email sử dụng ArrayList
    class EmailProcessor
    {
        private ArrayList originalList;

        public EmailProcessor(ArrayList list)
        {
            originalList = list;
        }

        public ArrayList GetProcessedList()
        {
            ArrayList processed = new ArrayList();

            foreach (object item in originalList)
            {
                string str = item.ToString();
                EmailEntry entry = new EmailEntry(str);

                if (entry.IsValid())
                {
                    processed.Add(entry.GetProcessed());
                }
            }

            return processed;
        }
    }

    // ✅ Lớp nhập liệu sử dụng ArrayList
    class InputHandler
    {
        public ArrayList ReadFromKeyboard()
        {
            ArrayList list = new ArrayList();

            Console.Write("Nhập số lượng phần tử: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Số lượng không hợp lệ.");
                return list;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Nhập phần tử thứ {i + 1}: ");
                string input = Console.ReadLine();

                if (input.Contains("@"))
                {
                    list.Add(input);
                }
                else
                {
                    Console.WriteLine("Không chứa ký tự '@', bỏ qua.");
                }
            }

            return list;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Danh sách mặc định
            ArrayList defaultList = new ArrayList
            {
                "OOP",
                "NetCore",
                "List",
                "HashSet",
                "tran.the.dung@vsi-international.com",
                "dungtt@gmail.com",
                "d@ung@vsi-international.com",
                "VietSoftw@re@vsi-international.com",
                "@@@gmail.com"
            };

            EmailProcessor processor1 = new EmailProcessor(defaultList);
            ArrayList result1 = processor1.GetProcessedList();

            Console.WriteLine(" Danh sách xử lý từ dữ liệu mặc định:");
            foreach (string item in result1)
            {
                Console.WriteLine(item);
            }

            // Nhập từ bàn phím
            InputHandler inputHandler = new InputHandler();
            ArrayList manualList = inputHandler.ReadFromKeyboard();

            EmailProcessor processor2 = new EmailProcessor(manualList);
            ArrayList result2 = processor2.GetProcessedList();

            Console.WriteLine("\n Danh sách xử lý từ dữ liệu nhập tay:");
            foreach (string item in result2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
