using static CollectionViewer.Model.Enums;

namespace CollectionViewer.Model
{
    /// <summary>
    /// Дно таблицы
    /// </summary>
    public class Footer
    {
        /// Сюда можно что-то ещё добавить

        /// <summary>
        /// Преобразовать Footer в string
        /// </summary>
        /// <param name="header">Заголовок таблицы</param>
        /// <returns>Нижняя граница таблицы</returns>
        public string ToString(Header header)
        {
            string result = string.Empty;

            // Добавление нижней границы
            int columnsCount = header.Columns.Count;

            result += (char)GridChars.BottomLeftCorner;
            foreach (var column in header.Columns)
            {
                for (int i = 0; i < column.Width; i++)
                    result += (char)GridChars.RowSeparator;

                columnsCount--;
                if (columnsCount > 0)
                    result += (char)GridChars.BottomSeparator;
            }

            result += (char)GridChars.BottomRightCorner + Environment.NewLine;

            return result;
        }
    }
}
