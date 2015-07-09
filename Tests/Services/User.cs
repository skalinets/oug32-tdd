namespace Tests.Services
{
    public class User
    {
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Address1: {1}, Address2: {2}, City: {3}, Age: {4}", Name, Address1, Address2, City, Age);
        }
    }
}