using StudentsWebApi.Domain.Common;

namespace StudentsWebApi.Domain.ValueObjects
{
    public class PersonName : ValueObject
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return LastName;
        }
    }
}
