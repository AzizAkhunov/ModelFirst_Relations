using Microsoft.Extensions.Hosting;

namespace ModelFirst.Models
{
    public class Father
    {
        public int Id { get; set; }
        public ICollection<Child> Children { get; }
    }
}
