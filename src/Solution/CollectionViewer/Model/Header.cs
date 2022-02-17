using static CollectionViewer.Enums;

namespace CollectionViewer.Model
{
    /// <summary>
    /// Заголовок таблицы
    /// </summary>
    public class Header
    {
        /// <summary>
        /// Столбцы
        /// </summary>
        public IReadOnlyList<Column> Columns { get; internal set; }

        public Header(IReadOnlyList<Column> columns)
        {
            Columns = columns;
        }

        /// <summary>
        /// Преобразовать заголовок таблицы в string
        /// </summary>
        /// <param name="tableName">Название таблицы</param>
        /// <returns>Заголовок таблицы в string</returns>
        public string ToString(string tableName)
        {
            // Можно было бы всё раскидать по методам по типу string GetTopBorder()/GetColumnNames()/GetTableName(),
            // Но будет путанница

            string result = ((char)GridChars.TopLeftCorner).ToString();
            int columnsCount = Columns.Count;

            // Добавление верхней границы
            foreach (var column in this.Columns)
            {
                for (int i = 0; i < column.Width; i++)
                    result += (char)GridChars.RowSeparator;

                if (--columnsCount > 0)
                    result += (char)GridChars.RowSeparator;
            }

            result += (char)GridChars.TopRightCorner + Environment.NewLine;

            // Добавление названия таблицы
            int totalLineLength = result.Length;
            columnsCount = Columns.Count;
            result += (char)GridChars.ColumnSeparator + Helper.СutString(tableName, totalLineLength - 4, Align.Center) + (char)GridChars.ColumnSeparator + Environment.NewLine;

            result += (char)GridChars.LeftSeparator;

            foreach (var column in this.Columns)
            {
                for (int i = 0; i < column.Width; i++)
                    result += (char)GridChars.RowSeparator;

                if (--columnsCount > 0)
                    result += (char)GridChars.TopSeparator;
            }

            result += (char)GridChars.RightSeparator + Environment.NewLine;

            // Добавление названий столбцов
            foreach (var column in this.Columns)
            {
                result += (char)GridChars.ColumnSeparator + column.ToString();
            }

            result += (char)GridChars.ColumnSeparator + Environment.NewLine;

            // Добавление нижней границы
            columnsCount = Columns.Count;

            result += (char)GridChars.LeftSeparator;
            foreach (var column in this.Columns)
            {
                for (int i = 0; i < column.Width; i++)
                    result += (char)GridChars.RowSeparator;

                if (--columnsCount > 0)
                    result += (char)GridChars.CenterSeparator;
            }

            result += (char)GridChars.RightSeparator + Environment.NewLine;

            return result;
        }

        /// <summary>
        /// Преобразовать заголовок таблицы в xml string
        /// </summary>
        /// <returns>xml строка</returns>
        public string ToXml()
        {
            string result = $"<header>";

            foreach (var column in Columns)
            {
                result += "\t" + column.ToXml() + Environment.NewLine;
            }

            result += "</header>";

            return result;
        }
    }
}
