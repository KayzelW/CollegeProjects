using System;

namespace CS_Ulearn.me
{
    public class Class1
    {
        public static void Main()
        {
            string[] input = new string[]
            {
                "������ �� �������� � ����������� ��� ��������\r\n",
                "���� �� �������� ������ � ���� �� ��������� � ������������\r\n","�������� �� ������ ��� �� �� �������� �� ����� ����\r\n","���� �������� ������ ��������� � ����\r\n\r\n",
                "����� ������ �������\r\n","��� ���� �� �� �������\r\n","����� ������� ���\r\n","�� � ���� ��� ���������\r\n","� � ���� ������ ���� ���\r\n\r\n", "���"
            };
            Console.WriteLine(DecodeMessage(input));
        }

        private static string DecodeMessage(string[] lines)
        {
            var text = lines.ToString();
            Console.WriteLine(text);
            return $"";
        }
    }
}
