using static TableViewer.Enums;

namespace TableViewer
{
    public class Column
    {
        /// <summary>
        /// Название столбца
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Выравнивание по горизонтали
        /// </summary>
        public Align Align { get; private set; }

        /// <summary>
        /// Ширина (длина столбца в символах)
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Столбец
        /// </summary>
        /// <param name="name">Название столбца</param>
        /// <param name="width">Ширина столбца. По умолчанию -1 - автоматическое определение в соответствии с данными из IEntities</param>
        /// <param name="align">Выравнивание записей</param>
        public Column(string name, int width = -1, Align align = Align.Center)
        {
            Name = name;
            Width = width;
            Align = align;
        }

        /// <summary>
        /// Преобразовать название столбца в строку в соответствии с его шириной и выравниванием align
        /// </summary>
        /// <returns>Название столбца</returns>
        public override string ToString()
        {
            return Helper.СutString(this.Name, this.Width, this.Align);
        }

        /// <summary>
        /// Обвноить ширину столбцов
        /// Если пользователь указал ширину столбца как -1, то находится 
        /// максимальная длина строки среди записей, соответствующих этому столбцу
        /// </summary>
        /// <param name="properties">Спиоск записей, соответствующих этому столбцу</param>
        public void UpdateWidth(IReadOnlyList<string> properties)
        {
            // Поиск строки с максимальной длиной
            int maxValueLength = this.Name.Length;

            if (this.Width < 0)
            {
                for (int i = 0; i < properties.Count; i++)
                {
                    if (properties[i].Length > maxValueLength)
                    {
                        maxValueLength = properties[i].Length;
                    }
                }

                // Добавление 2 для пробелов слева и справа
                this.Width = maxValueLength + 2;
            }
        }

        /// <summary>
        /// Преобразование столбца в xml string
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            return $"<column Name='{this.Name}' Align='{this.Align}' Width='{this.Width}' />";
        }
    }
}
