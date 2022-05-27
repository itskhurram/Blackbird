﻿namespace Blackbird.Domain.Interfaces {
    public interface ICategoryRepository {
        Task<IList<Category>> GetAllCategories(bool? isActive = null);
    }
}
