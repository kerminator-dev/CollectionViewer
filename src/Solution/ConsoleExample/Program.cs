using CollectionViewer.Model;
using CollectionViewer;

var entities = new List<IEntity>()
{
    new Person(1, "John", 23),
    new Person(2, "John", 30),
    new Person(3, "Steve", 24),
    new Person(41414, "Alex Stone", 20),
    new Person(6211, "John", 23),
    new Person(512, "Steve", 30),
    new Person(153, "Steve", 24),
    new Person(4, "Alex", 20),
    new Person(6121, "Dan Stone", 23),
    new Person(6122, "Steve", 30000),
};

var header = new Header
(
    columns: new List<Column>()
    {
        new Column("ID", width: 20, align: Enums.Align.Left),
        new Column("Name", align: Enums.Align.Center),
        new Column("Age", align: Enums.Align.Right),
    }
);

var table = new Table
(
    header: header,
    entities: entities,
    name: "My table"
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