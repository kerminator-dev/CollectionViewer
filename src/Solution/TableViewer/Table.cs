namespace TableViewer
{
    public class Table
    {
        /// <summary>
        /// Название таблицы
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Заголовок таблицы
        /// </summary>
        public Header Header { get; private set; }

        /// <summary>
        /// "Тело" таблицы, включающее в себе записи
        /// </summary>
        public Body Body { get; private set; }

        /// <summary>
        /// Дно таблицы
        /// </summary>
        public Footer Footer { get; private set; }

        /// <summary>
        /// Таблица
        /// </summary>
        /// <param name="entities">Коллекция сущностей таблицы</param>
        /// <param name="header">Заголовок таблицы</param>
        /// <param name="name">Название таблицы</param>
        public Table(Header header, IReadOnlyList<IEntity> entities, string name = "Table")
        {
            Header = header;
            Body = new Body(entities);
            Footer = new Footer();
            Name = name;

            // Обновление 
            UpdateColumnsCount();
            UpdateColumnWidths();
        }

        /// <summary>
        /// Обвновить ширину столбцов
        /// Если пользователь указал ширину столбца < 0, то находится 
        /// максимальная длина строки среди записей, соответствующих этому столбцу
        /// И указывается как ширина столбца
        /// </summary>
        private void UpdateColumnWidths()
        {
            IReadOnlyList<string> properties;

            for (int i = 0; i < Header.Columns.Count; i++)
            {
                // Получение всех записей, соответствующих столбцу с индексом [i]
                properties = Body.Entities.Select(e => e.ToPropsList().ElementAt(i)).ToList();

                // Обновление ширины столбца с индексом [i]
                Header.Columns[i].UpdateWidth(properties);
            }
        }

        /// <summary>
        /// Обновить кол-во столбцов
        /// Например, entity может содержать 5 полей, а было указано,
        /// что столбца 2
        /// Метод добавляет недостающие столбцы, чтобы отобразить данные из entity
        /// </summary>
        private void UpdateColumnsCount()
        {
            int propsCount = Body.Entities.FirstOrDefault().ToPropsList().Count;

            for (int i = this.Header.Columns.Count; i < propsCount; i++)
            {
                Header.Columns = Header.Columns.Append<Column>(new Column("No name", -1)).ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Преобразовать таблицу в строку
        /// </summary>
        /// <returns>Отформатированная таблица в виде строки</returns>
        public override string ToString()
        {
            return Header.ToString(this.Name) + Body.ToString(this.Header) + Footer.ToString(this.Header);
        }

        /// <summary>
        /// Преобразовать таблицу в .xnl
        /// </summary>
        /// <returns>Таблица в виде xml строки</returns>
        public string ToXml()
        {
            return $"<table Name='{this.Name}>" + Header.ToXml() + Body.ToXml(this.Header) + "</table>";
        }
    }
}
