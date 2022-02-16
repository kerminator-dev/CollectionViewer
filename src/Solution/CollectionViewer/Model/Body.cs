namespace CollectionViewer.Model
{
    /// <summary>
    /// "Тело" таблицы, содержащее в себе список объектов
    /// И представляющее собой строки таблицы
    /// </summary>
    public class Body
    {
        /// <summary>
        /// Коллекция из объектов с данными, они же записи и строки
        /// </summary>
        public IReadOnlyList<IEntity> Entities { get; private set; }

        /// <summary>
        /// "Тело" таблицы, содержащее в себе список объектов
        /// И представляющее собой строки таблицы
        /// </summary>
        /// <param name="entities">Коллекция IReadOnlyList<IEntity></param>
        public Body(IReadOnlyList<IEntity> entities)
        {
            Entities = entities;
        }

        /// <summary>
        /// Преобразовать все Entities в string
        /// </summary>
        /// <param name="header">Заголовок таблицы</param>
        /// <returns>Entities, преобразованные в string</returns>
        public string ToString(in Header header)
        {
            string result = string.Empty;

            foreach (var entity in Entities)
            {
                result += entity.ToString(header) + Environment.NewLine;
            }

            return result;
        }

        /// <summary>
        /// Преобразовать все Entities в xml
        /// </summary>
        /// <param name="header">Заголовок таблицы</param>
        /// <returns>Entities, преобразованные в .xml string</returns>
        public string ToXml(in Header header)
        {
            string result = "<body>";

            foreach (var entity in Entities)
            {
                result += entity.ToXml(header) + Environment.NewLine;
            }

            result += "</body>";

            return result;
        }
    }
}
