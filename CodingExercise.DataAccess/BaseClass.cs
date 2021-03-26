using CodingExercise.DataAccess.Data;

namespace CodingExercise.DataAccess
{
    public class BaseClass
    {
        public CarSalesEntities _entities;
        public BaseClass()
        {
            _entities = new CarSalesEntities();
        }
    }

}
