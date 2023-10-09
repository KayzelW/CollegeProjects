using System;

namespace CS_Ulearn.me
{
    public class Class1
    {
        public static void Main()
        {
            string[] input = new string[]
            {
                "реш»ла н≈ ”прощать и зашиф–ќ¬јт№ ¬се послаЌ»≈\r\n",
                "дјже не —тарайс€ н»„≈√ќ у т≈б€ н≈ получитс€ с расшиф–ќ¬кой\r\n","—давайс€ Ќ≈ твоего ума “ы не спо—ќб≈н Ќо может быть\r\n","если особенно упорно подойдешь к делу\r\n\r\n",
                "будет “рудно конечнќ\r\n"," од вед№ не из простых\r\n","очень ’ќ–ќЎ»… код\r\n","то у теб€ все получитс€\r\n","и € буƒу ѕисать т≈б≈ еще\r\n\r\n", "чао"
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
