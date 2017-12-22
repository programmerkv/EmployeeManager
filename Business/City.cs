namespace EmployeeManager.Business
{
    public class City
    {
        public City(string name)
        {
            Name = name;
        }

        public City(int id, string name, int noe = 0)
        {
            Id = id;
            Name = name;
            Noe = noe;
        }

        public int Id { get; private set; }
        public string Name { get; set; }
        public int Noe { get; }

        //================================================

        public void __SetId(int id)
        {
            Id = id;
        }
    }
}