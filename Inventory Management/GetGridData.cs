using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{
    internal class GetGridData
    {
        private readonly EQUInventoryEntities _eQU;
        public GetGridData()
        {

            _eQU = new EQUInventoryEntities();
        }
        public List<object> GetGridViewData()
        {
            
            var query = _eQU.Records.Select(q => new
            {
                ID = q.Id,
                Asset_Tag = q.AssetTag,
                Category = q.Category.CategoryName,
                Type = q.ItemType.TypeName,
                Brand = q.Brand,
                Description = q.Description,
                Location = q.Location.LocationName,
                Serial_No = q.SerialNo,
                Status = q.Status.StatusName,
                Purchase_Date = q.PurchaseDate
            }).ToList();

            return query.Cast<object>().ToList();



        }


public class DataProcessor
    {
        private List<object> _data;

        public DataProcessor(List<object> data)
        {
            _data = data;
        }

        public Dictionary<string, int> CalculateCategoryCounts(List<string> categories)
        {
            Dictionary<string, int> categoryCounts = new Dictionary<string, int>();

            if (_data != null && _data.Any())
            {
                foreach (var category in categories)
                {
                    int count = _data.Cast<dynamic>().Count(d => d.Category == category);
                    categoryCounts.Add(category, count);
                }
            }

            return categoryCounts;
        }
    }


}
}
