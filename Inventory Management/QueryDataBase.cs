using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management
{

    public class QueryDataBase
    {
        private EQUInventoryEntities _eQU;


        public QueryDataBase (EQUInventoryEntities context)
        {
            _eQU = context;
        }

        public List<object> GetAssetRecords()
        {
            return _eQU.Records.Select(q => new
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
            }).ToList<object>();
        }






    }
   
    

}


