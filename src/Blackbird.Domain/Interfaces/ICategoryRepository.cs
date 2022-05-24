namespace Blackbird.Domain.Interfaces {
    public interface ICategoryRepository {
        Task<IList<Category>> GetAllLeads(bool? isActive = null);
    }
}
