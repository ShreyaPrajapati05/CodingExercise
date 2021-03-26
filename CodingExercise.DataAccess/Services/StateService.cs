using CodingExercise.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingExercise.DataAccess.Services
{
    public class StateService : BaseClass
    {
        public List<State> get()
        {
            return _entities.States.ToList();
        }
    }
}
