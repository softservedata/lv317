using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace lv317.Tools
{
    public class CSVReader : IExternalReader
    {
        private const string PATH_SEPARATOR = "\\";
        //private const string FOLDER_UP = "\\..";
        private const string FOLDER_DATA = "ExternalData";
        private const char CSV_SPLIT_BY = ';';
        public string Filename { get; private set; }
        public string Path { get; private set; }

        public CSVReader(string filename)
        {
            Filename = filename;
            Path = System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase).Substring(6);
            Path = Path.Remove(Path.IndexOf("bin")) + FOLDER_DATA + PATH_SEPARATOR + filename;
            //MessageBox.Show("Path.GetDirectoryName(Assembly.GetAssembly(typeof(CSVReader)).CodeBase): "
            //    + Path, "Full PATH ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public IList<IList<string>> GetAllCells()
        {
            return GetAllCells(Path);
        }

        public IList<IList<string>> GetAllCells(string path)
        {
            Path = path;
            IList<IList<string>> allCells = new List<IList<string>>();
            string row;
            //
            using (StreamReader streamReader = new StreamReader(path))
            {
                while ((row = streamReader.ReadLine()) != null)
                {
                    allCells.Add(row.Split(CSV_SPLIT_BY).ToList());
                }
            }
            return allCells;
        }

        public string GetConnection()
        {
            return Path;
        }
    }
}

