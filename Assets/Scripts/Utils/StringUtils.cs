namespace Utils
{
    public static class StringUtils
    {
        public static int GetIntByText(this string text)
        {
            var str = text.Split(' ')[0];
            
            switch (str)
            {
                case "Перший": return 1;
                case "Другий": return 2;
                case "Третій": return 3;
                case "Четвертий": return 4;
                case "П'ятий": return 5;
                case "Шостий": return 6;
                case "Сьомий": return 7;
                case "Восьмий": return 8;
                case "Дев'ятий": return 9;
                case "Десятий": return 10;
                case "Одинадцятий": return 11;
                case "Дванадцятий": return 12;
            }

            return 13;
        }
    }
}
