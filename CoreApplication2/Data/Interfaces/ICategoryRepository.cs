using CoreApplication2.Data.Models;

namespace CoreApplication2.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
