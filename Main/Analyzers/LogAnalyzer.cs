using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Analyzers
{
    public class LogAnalyzer
    {
        private string[] _logInfo;

        public string[] LogInfo
        {
            private get
            {
                return this._logInfo;
            }

            set
            {
                this._logInfo = value;
            }
        }

        public LogAnalyzer(string[] logInfo)
        {
            this._logInfo = logInfo;
        }

        public List<string[]> DefineGameSections()
        {
            List<string[]> list = new List<string[]>();
            List<string> auxList = null;

            foreach (string line in this._logInfo)
            {
                if (line == null || line == "")
                {
                    continue;
                }

                if (line.Contains("InitGame:"))
                {
                    auxList = new List<string>();
                    //auxList.Add(line);

                } else if (line.Contains("ShutdownGame:"))
                {
                    auxList.Add(line);
                    list.Add(auxList.ToArray());
                    auxList = null;

                    continue;
                }

                if (!(auxList == null))
                {
                    auxList.Add(line);
                }
            }

            return list;
        }
    }
}
