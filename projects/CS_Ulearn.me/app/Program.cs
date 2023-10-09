namespace app
{
    internal class Program
    {
        public static void Main()
        {
            string[] input = new string[]
            {
                "решИла нЕ Упрощать и зашифРОВАтЬ Все послаНИЕ\r\n",
                "дАже не Старайся нИЧЕГО у тЕбя нЕ получится с расшифРОВкой\r\n","Сдавайся НЕ твоего ума Ты не споСОбЕн Но может быть\r\n","если особенно упорно подойдешь к делу\r\n\r\n",
                "будет Трудно конечнО\r\n","Код ведЬ не из простых\r\n","очень ХОРОШИЙ код\r\n","то у тебя все получится\r\n","и я буДу Писать тЕбЕ еще\r\n\r\n", "чао"
            };
            Console.WriteLine(DecodeMessage(input));
        }

        private static string DecodeMessage(string[] lines)
        {
            string text = "";
            foreach (string line in lines)
            {
                text += line;
            }
            Console.WriteLine(text);
            return $"";
        }
    }
}