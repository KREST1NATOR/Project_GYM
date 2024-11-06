using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project_GYM.Infrastructure.Database
{
    public class JobTitleRepository
    {
        private readonly Context _context;

        public JobTitleRepository(Context context)
        {
            _context = context;
        }

        public List<JobTitleEntity> GetJobTitles()
        {
            return _context.JobTitles.ToList();
        }
    }
}
