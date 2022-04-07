using System.Text;
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
            var result = new StringBuilder();

            result.Append((char)GridChars.TopLeftCorner);
            int columnsCount = Columns.Count;

            // Добавление верхней границы
            foreach (var column in this.Columns)
            {
                for (int i = 0; i < column.Width; i++)
                    result.Append((char)GridChars.RowSeparator);

                if (--columnsCount > 0)
                    result.Append((char)GridChars.RowSeparator);
            }

            result.Append((char)GridChars.TopRightCorner + Environment.NewLine);

            // Добавление названия таблицы
            int totalLineLength = result.Length;
            columnsCount = Columns.Count;
            result.Append((char)GridChars.ColumnSeparator + Helper.СutString(tableName, totalLineLength - 4, Align.Center) + (char)GridChars.ColumnSeparator + Environment.NewLine);

            result.Append((char)GridChars.LeftSeparator);

            foreach (var column in this.Columns)
            {
                for (int i = 0; i < column.Width; i++)
                    result.Append((char)GridChars.RowSeparator);

                if (--columnsCount > 0)
                    result.Append((char)GridChars.TopSeparator);
            }

            result.Append((char)GridChars.RightSeparator + Environment.NewLine);

            // Добавление названий столбцов
            foreach (var column in this.Columns)
            {
                result.Append((char)GridChars.ColumnSeparator + column.ToString());
            }

            result.Append((char)GridChars.ColumnSeparator + Environment.NewLine);

            // Добавление нижней границы
            columnsCount = Columns.Count;

            result.Append((char)GridChars.LeftSeparator);
            foreach (var column in this.Columns)
            {
                for (int i = 0; i < column.Width; i++)
                    result.Append((char)GridChars.RowSeparator);

                if (--columnsCount > 0)
                    result.Append((char)GridChars.CenterSeparator);
            }

            result.Append((char)GridChars.RightSeparator + Environment.NewLine);

            return result.ToString();
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
