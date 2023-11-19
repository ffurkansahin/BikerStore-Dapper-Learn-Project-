using BikerStoreWUI.Models.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStoreWUI.Repositories
{
    public class BrandRepository : BaseRepository, IBaseRepository<Brand>
    {
        public int DeleteData(Brand dataItem)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAllData()
        {
            List<Brand> dataItemList = new List<Brand>();
            string query = "SELECT * FROM [DapperLearn].[production].[brands]";
            dataItemList = connection.Query<Brand>(query).ToList();

            return dataItemList;
        }

        public Brand GetDataById(int dataItemId)
        {
            Brand dataItemBrand = null;
            string query = $"SELECT * FROM [DapperLearn].[production].[brands] where brand_id ={dataItemId}";
            dataItemBrand = connection.QueryFirstOrDefault<Brand>(query);

            return dataItemBrand;
        }

        public int InsertData(Brand dataItem)
        {
            throw new NotImplementedException();
        }

        public int UpdateData(Brand dataItem)
        {
            throw new NotImplementedException();
        }
    }
}
