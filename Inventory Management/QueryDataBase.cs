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


        public QueryDataBase(EQUInventoryEntities context)
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


        public List<dynamic> GetRecordsContainingKeyword(string keyword)
        {
            try
            {
                var SpecificRecords = _eQU.Records
                    .Where(q => q.Category.CategoryName == keyword)
                    .Select(q => new
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
                    })
                    .AsEnumerable() 
                    .Cast<dynamic>()
                    .ToList();

                return SpecificRecords;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<dynamic>();
            }
        }


        public List<dynamic> GetRecordsByLocation(string keyword)
        {
            try
            {
                var Locations = _eQU.Records
                    .Where(q => q.Location.LocationName == keyword)
                    .Select(q => new
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
                    })
                    .AsEnumerable()
                    .Cast<dynamic>()
                    .ToList();

                return Locations;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<dynamic>();
            }
        }
        public List<dynamic> GetRecordsByType(string keyword)
        {
            try
            {
                var Types = _eQU.Records
                    .Where(q => q.ItemType.TypeName == keyword)
                    .Select(q => new
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
                    })
                    .AsEnumerable()
                    .Cast<dynamic>()
                    .ToList();

                return Types;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<dynamic>();
            }
        }

    }
}





