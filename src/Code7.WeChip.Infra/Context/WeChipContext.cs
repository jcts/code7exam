using System.Configuration;
using System.Data.OleDb;

namespace Code7.WeChip.Infra.Context
{
    public static class WeChipContext 
    {
        private static OleDbConnection _context { get; set; }

        public static OleDbConnection Context
        {
            get
            {
                var cs = ConfigurationManager.ConnectionStrings["WeChip"].ToString();

                if (_context == null)
                {
                    _context = new OleDbConnection(cs);

                    _context.ConnectionString = cs;

                    _context.Open();

                    return _context;
                }
                else if (_context != null && _context.State == System.Data.ConnectionState.Closed)
                {
                    _context.ConnectionString = cs;

                    _context.Open();

                    return _context;
                }
                else
                    return _context;
            }
        }
    }
}
