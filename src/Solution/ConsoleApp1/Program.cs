using CollectionViewer.Model;

List<IEntity> entities = new()
{
    new Person(1, "Вася", 23),
    new Person(2, "Александр", 30),
    new Person(3, "Steve", 24),
    new Person(4, "Alex", 20),
    new Person(1, "Вася", 23),
    new Person(2, "Александр", 30),
    new Person(3, "Steve", 24),
    new Person(4, "Alex", 20),
    new Person(1, "D", 23),
    new Person(2, "Александаааааfffffffffffffffffffр", 30),
    new Person(3, "Steve", 24),
    new Person(4, "Alex", 20),
};

var header = new Header
(
    columns: new List<Column>()
    {
        new Column("ID", width: 10, align: Enums.Align.Center),
        new Column("Name", align: Enums.Align.Center),
        //new Column("Age", align: Enums.Align.Right)
        // Если не добавлять столбцы, то они сами добавятся с названием 'No name', автоматической шириной и выравниванием по умолчанию
    }
);

var table = new Table
(
    header: header,
    entities: entities,
    name: "People table"
);

Console.WriteLine(table.ToString());
class Person : IEntity
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(int id, string name, int age)
    {
        ID = id;
        Name = name;
        Age = age;
    }

    /// <summary>
    /// Реализация интерфейс IEntity
    /// Быстрый доступ ко всем полям этого класса
    /// </summary>
    /// <returns>Коллекция значений из полей, преобразованных в string</returns>
    public IReadOnlyList<string> ToPropsList()
    {
        return new List<string>()
        {
            this.ID.ToString(),
            this.Name,
            this.Age.ToString(),
        };
    }
}