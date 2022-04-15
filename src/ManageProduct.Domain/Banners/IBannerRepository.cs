using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ManageProduct.Banners
{
    public interface IBannerRepository: IRepository<Banner, Guid>
    {
        Task<List<Banner>> GetListAsync(
                    string filterText = null,
                    string name = null,
                    string sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            CancellationToken cancellationToken = default);
    }
}
