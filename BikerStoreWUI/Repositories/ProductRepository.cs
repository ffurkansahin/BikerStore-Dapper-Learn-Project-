using BikerStoreWUI.Models.StoreProcedure;
using BikerStoreWUI.Models.ViewModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStoreWUI.Repositories
{
    public class ProductRepository : BaseRepository, IBaseRepository<UpdateProductSP>
    {
        public int DeleteData(UpdateProductSP dataItem)
        {
            var SpParams = new { id = dataItem.product_id };
            return connection.Execute("DeleteProductById", SpParams, commandType: System.Data.CommandType.StoredProcedure);
        }


        public int InsertData(UpdateProductSP dataItem)
        {
            var SpParams = new { productName=dataItem.product_name,brandId=dataItem.brand_id,categoryId=dataItem.brand_id,modelYear=dataItem.model_year,listPrice=dataItem.list_price };
            return connection.Execute("InsertProduct", SpParams, commandType: System.Data.CommandType.StoredProcedure);
        }

        public int UpdateData(UpdateProductSP dataItem)
        {
            return connection.Execute("UpdateProduct", dataItem, commandType:System.Data.CommandType.StoredProcedure);
        }

        public List<ProductListViewModel> GetAllDataList()
        {
            List<ProductListViewModel> dataItemList = new List<ProductListViewModel>();
            string query = @"select
P.product_id,B.brand_name,C.category_name,P.product_name,P.model_year,P.list_price from production.products P
inner join production.brands B on P.brand_id = B.brand_id
inner join production.categories C on P.category_id=C.category_id";
            dataItemList = connection.Query<ProductListViewModel>(query).ToList();

            return dataItemList;
        }
        public UpdateProductSP GetDataById(int dataItemId)
        {
            UpdateProductSP dataItem = null;
            string query = $"select * from production.products where product_id = {dataItemId}";
            dataItem = connection.QueryFirstOrDefault<UpdateProductSP>(query);
            return dataItem;

        }








        public List<UpdateProductSP> GetAllData()
        {
            throw new NotImplementedException();
        }

    }
}
