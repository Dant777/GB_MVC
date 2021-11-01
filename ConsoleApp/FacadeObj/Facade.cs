using System.Collections.Generic;

namespace ConsoleApp.FacadeObj
{
    public class Facade
    {
        private readonly AggregateJsonProduct _aggregateJsonProduct;
        private readonly DBClass _db;

        public Facade(AggregateJsonProduct aggregateJsonProduct, DBClass db)
        {
            _aggregateJsonProduct = aggregateJsonProduct;
            _db = db;
        }

        public void AddInDB(string jsonFilePath)
        {
            if (!string.IsNullOrEmpty(jsonFilePath))
            {
                _db.Add(_aggregateJsonProduct.CreateWorkEntities(jsonFilePath));
            }
        }

        public void AddInDB(List<string> listJsonFilePath)
        {
            if (listJsonFilePath.Count != 0)
            {
                foreach (var jsonPath in listJsonFilePath)
                {
                    _db.Add(_aggregateJsonProduct.CreateWorkEntities(jsonPath));
                }
            }
        }
    }
}