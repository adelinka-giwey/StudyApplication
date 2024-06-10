using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace StudyApplication.Entities
{
    public partial class StudyEntities1
    {
        private static StudyEntities1 _context;
        public static StudyEntities1 GetContext()
        {
            if (_context is null)
                _context = new StudyEntities1();
            return _context;
        }
    }
}
