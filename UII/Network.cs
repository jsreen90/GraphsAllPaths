using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UII
{

    class Node
    {
        private string m_place;
        private List<KeyValuePair<string, int>> m_nodedata = new List<KeyValuePair<string, int>>();
        private bool m_hasreached;
        public string NodeName
        {
            get { return m_place; }
            set { m_place = value; }
        }

        public List<KeyValuePair<string, int>> nodedata
        {
            get { return m_nodedata; }
            set { m_nodedata = value; }
        }
        public bool hasreached
        { get { return m_hasreached; } set { m_hasreached = value; } }
        

       
        
    }
}
