using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lv317.Tools
{
    public interface IExternalReader
    {
        IList<IList<string>> GetAllCells();

        IList<IList<string>> GetAllCells(string path);

        string GetConnection();
    }
}
