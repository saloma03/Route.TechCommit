 namespace Route.TechSummit.Domain.Common
{
    public class BaseEntity <Tkey> where Tkey : IEquatable<Tkey>
    {
        public required Tkey Id { get; set; }
    }
}
