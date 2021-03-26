using CodingExercise.DataAccess.Data;
using System.Collections.Generic;
using System.Linq;

namespace CodingExercise.DataAccess.Services
{
    public class MonthService : BaseClass
    {
        public List<Month> get()
        {
            return _entities.Months.ToList();
        }

    }
}
