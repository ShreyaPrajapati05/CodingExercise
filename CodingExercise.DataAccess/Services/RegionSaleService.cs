using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CodingExercise.DataAccess.Data;

namespace CodingExercise.DataAccess.Services
{
    public class RegionSaleService : BaseClass
    {
        /// <summary>
        /// get all sales data
        /// </summary>
        /// <returns></returns>
        public List<RegionSale> getAll()
        {
            return _entities.RegionSales.ToList();
        }

        /// <summary>
        /// Get By State and Month
        /// </summary>
        /// <param name="monthId"></param>
        /// <param name="stateId"></param>
        /// <returns></returns>
        public RegionSale getById(int? monthId, int? stateId)
        {
            return _entities.RegionSales.Where(m => m.MonthId == monthId && m.StateId == stateId).FirstOrDefault();
        }

        /// <summary>
        /// Insert Data
        /// </summary>
        /// <param name="regionSale"></param>
        /// <returns></returns>
        public void Insert(RegionSale regionSale)
        {
            _entities.RegionSales.Add(regionSale);
            _entities.SaveChanges();
        }

        /// <summary>
        /// Update Data
        /// </summary>
        /// <param name="regionSale"></param>
        /// <returns></returns>
        public void Update(RegionSale regionSale)
        {
            _entities.Entry(regionSale).State = EntityState.Modified;
            _entities.SaveChanges();
        }

        /// <summary>
        /// Save Data
        /// </summary>
        /// <param name="regionSale"></param>
        /// <returns></returns>
        public void save(RegionSale regionSale)
        {
            RegionSale regionSaleDB = getById(regionSale.MonthId, regionSale.StateId);

            if (regionSaleDB != null)
            {
                regionSaleDB.Sales = regionSale.Sales;
                Update(regionSaleDB);
            }
            else
            {
                Insert(regionSale);
            }
        }
    }
}
