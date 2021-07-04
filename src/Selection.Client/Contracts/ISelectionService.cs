using Selection.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selection.Client.Contracts
{
    public interface ISelectionService
    {
        Task<IEnumerable<SelectionModel>> GetSelections();

    }
}
