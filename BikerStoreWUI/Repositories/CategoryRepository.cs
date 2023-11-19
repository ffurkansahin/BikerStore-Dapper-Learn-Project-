using BikerStoreWUI.Models.Database;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStoreWUI.Repositories
{
    public class CategoryRepository : BaseRepository, IBaseRepository<Category>
    {
        public int DeleteData(Category dataItem)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAllData()
        {
            List<Category> dataItemList = new List<Category>();
            string query = "SELECT * FROM [DapperLearn].[production].[categories]";
            dataItemList = connection.Query<Category>(query).ToList();

            return dataItemList;
        }

        public Category GetDataById(int dataItemId)
        {
            Category dataItemCategory = null;
            string query = $"SELECT * FROM [DapperLearn].[production].[categories] where category_id = {dataItemId}";
            dataItemCategory = connection.QueryFirstOrDefault<Category>(query);

            return dataItemCategory;
        }

        public int InsertData(Category dataItem)
        {
            throw new NotImplementedException();
        }

        public int UpdateData(Category dataItem)
        {
            throw new NotImplementedException();
        }
    }
}
