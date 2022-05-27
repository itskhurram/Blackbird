using Blackbird.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackbird.Application.Interfaces {
    public interface ICategoryService {
        public Task<IList<Category>> GetAllCategories(bool? isActive = null);

    }
}
