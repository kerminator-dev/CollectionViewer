using static CollectionViewer.Model.Enums;

namespace CollectionViewer.Model
{
    public interface IEntity
    {
        /// <summary>
        /// Получить список полей Entity, преобразованных в string
        /// </summary>
        /// <returns>Список со значениями полей типа string</returns>
        public IReadOnlyList<string> ToPropsList();

        /// <summary>
        /// Преобразовать данные из IEntity entity в строку таблицы
        /// </summary>
        /// <param name="entity">Сущность с данными</param>
        /// <returns>Строка данных IEntity entity</returns>
        public string ToString(in Header header)
        {
            var props = this.ToPropsList();
            string result = string.Empty;
            int columnWidth = 0;

            for (int i = 0; i < header.Columns.Count; i++)
            {
                columnWidth = header.Columns[i].Width;

                if (columnWidth == -1)
                {
                    result += (char)GridChars.ColumnSeparator + props[i];
                }
                else
                {
                    result += (char)GridChars.ColumnSeparator + Helper.СutString(props[i], columnWidth, header.Columns[i].Align);
                }
            }
            result += (char)GridChars.ColumnSeparator;
            return result;
        }

        /// <summary>
        /// Преобразовать данные из IEntity entity в xml
        /// </summary>
        /// <param name="header">Заголовок таблицы</param>
        /// <returns>xml</returns>
        public string ToXml(in Header header)
        {
            string result = "<entity>" + Environment.NewLine;
            IReadOnlyList<string> props = this.ToPropsList();

            for (int i = 0; i < header.Columns.Count; i++)
            {
                result += $"<property Name='{header.Columns[i].Name}' Value='{props[i]}' />" + Environment.NewLine;
            }

            result += "</entity>";
            return result;
        }
    }
}