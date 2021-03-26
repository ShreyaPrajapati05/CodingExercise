using CodingExercise.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CodingExercise.Models
{
    // RegionSaleModel Class
    public class RegionSaleModel
    {
        #region public properties

        /// <summary>
        /// MonthId
        /// </summary>
        [Required(ErrorMessage = "Please select Month.")]
        public int MonthId { get; set; }

        /// <summary>
        /// State ID
        /// </summary>
        [Required(ErrorMessage = "Please select State.")]
        public int StateId { get; set; }

        /// <summary>
        /// Sales
        /// </summary>
        public int Sales { get; set; }

        /// <summary>
        /// State List
        /// </summary>
        public List<State> StateList { get; set; }

        /// <summary>
        /// Month List
        /// </summary>
        public List<Month> MonthList { get; set; }

        /// <summary>
        /// Region Sale List
        /// </summary>
        public List<RegionSale> RegionSaleList { get; set; }
       
        /// <summary>
        /// Average List
        /// </summary>
        public List<double> AverageList
        {
            get { return getAverageList(); }
        }

        /// <summary>
        /// Total List
        /// </summary>
        public List<int> TotalList
        {
            get { return getTotalList(); }
        }

        /// <summary>
        /// Median List
        /// </summary>
        public List<int> MedianList
        {
            get
            { return getMediaList(); }
        }
        #endregion

        #region private method

        /// <summary>
        /// Get total list of all month state vise
        /// </summary>
        /// <returns> total list</returns>
        private List<int> getTotalList()
        {
            List<int> result = new List<int>();
            foreach (State state in StateList)
            {
                result.Add(RegionSaleList.Where(rs => rs.StateId == state.Id).Sum(S => S.Sales));
            }
            return result;
        }

        /// <summary>
        /// Get Median list of all month state vise
        /// </summary>
        /// <returns>List of Median</returns>
        private List<int> getMediaList()
        {
            List<int> result = new List<int>();
            foreach (State state in StateList)
            {
                int[] monthList1 = new int[12];
                foreach(Month month in MonthList)
                {
                    RegionSale model = RegionSaleList.AsEnumerable().Where(rs => rs.StateId == state.Id && rs.MonthId == month.Id).FirstOrDefault();
                    monthList1[month.Id-1] = model == null ? 0: model.Sales;
                    
                }
                Array.Sort(monthList1);
                result.Add((monthList1[(monthList1.Length / 2)-1] + monthList1[monthList1.Length / 2] )/ 2);
            }
            return result;
        }

        /// <summary>
        /// Get Average list of all month state vise
        /// </summary>
        /// <returns>List of Avg</returns>
        private List<double> getAverageList()
        {
            List<double> result = new List<double>();
            foreach(State state in StateList)
            {
                result.Add(Math.Round((RegionSaleList.Where(rs => rs.StateId == state.Id).Sum(S => S.Sales)) / (double)MonthList.Count,1));
            }
            return result;
        }
        #endregion
    }
}