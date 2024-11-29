using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registr8.Interfaces
{
    public interface IPlatformPickerService
    {
        Task<int?> ShowPickerAsync(string title, List<PickerItem> items);
    }
}
