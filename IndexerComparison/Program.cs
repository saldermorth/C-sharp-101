namespace IndexerComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vanlig lista

            List<Student> studenter = new();
            studenter.Add(null); // Tillåtet
            studenter.Add(new Student("Anna"));
            studenter.Add(new Student("Anna")); // Dubblett tillåten



            // Egen lista med Indexer 
            var lista = new StudentList();
            lista.LäggTill(new Student("Anna"));
           // lista.LäggTill(new Student("Anna")); //  Kastar fel – dubblett

            Console.WriteLine(lista[0].Namn); // Anna
            Console.WriteLine("Antal: " + lista.Antal); // Antal: 1
        }
    }

    public class Student
    {
        public string Namn { get; }
        public Student(string namn) => Namn = namn;
    }

    public class StudentList
    {
        private readonly List<Student> _studenter = new();

        // Lägg till med kontroll
        public void LäggTill(Student student)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student));

            if (_studenter.Any(s => s.Namn == student.Namn))
                throw new InvalidOperationException("Dubbletter är inte tillåtna.");

            _studenter.Add(student);
        }

        // Läs-åtkomst via indexer
        public Student this[int index] => _studenter[index];

        // Antal studenter
        public int Antal => _studenter.Count;
    }
}