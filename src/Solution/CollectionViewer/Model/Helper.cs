using static CollectionViewer.Model.Enums;

namespace CollectionViewer.Model
{
    /// <summary>
    /// Класс-помощник
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Обрезать строку в соответствии с указанной длиной length
        /// Если length > str.Length, то к str добавляются пробелы
        /// </summary>
        /// <param name="str">Строка</param>
        /// <param name="length">Ожидаемая длина строки</param>
        /// <param name="align">Выравнивание строки по горизонтали</param>
        /// <returns>Обрезанная строка в соответствии с указанной длиной length</returns>
        public static string СutString(string str, int length, Align align = Align.Left)
        {
            string result = string.Empty;

            // Добавление строки str посимвольно, пока не привысится лимит length
            for (int i = 0; i < str.Length; i++)
            {
                if (i == length)
                    break;

                result += str[i];
            }

            // Выравнивание строки по горизонтали
            switch (align)
            {
                case Align.Left:
                    return result.PadRight(length, ' ');
                case Align.Center:
                    int PadLeft; // Отступ слева от значения result
                    int PadRight; // Отступ справа от значения result
                    double pad = (double)(length - result.Length) / 2; 

                    if (pad % 1 == 0)
                    {
                        PadLeft = (int)pad;
                        PadRight = (int)pad;
                    }
                    else
                    {
                        PadLeft = (int)pad;
                        PadRight = PadLeft + 1;
                    }

                    PadLeft += result.Length;
                    PadRight += PadLeft;

                    return result.PadLeft(PadLeft, ' ').PadRight(PadRight, ' ');
                case Align.Right:
                    return result.PadLeft(length, ' ');
                default:
                    return result.PadLeft(length, ' ');
            }
        }
    }
}
