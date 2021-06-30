  
using System.Collections.Generic;
using StorefrontDL;
using StorefrontModels;

namespace RRBL
{
    public class RestaurantBL : IStorefrontBL
    {
        /// <summary>
        /// We are defining the dependenices this class needs in the constructor
        /// We do it this way (with interfaces) because we can easily switch out the implementation of RRDL when we want to change data source 
        /// (change from file system into database stored in the cloud)
        /// </summary>
        private IStoreRepository _repo;
        public RestaurantBL(IStoreRepository p_repo)
        {
            _repo = p_repo;
        }
        public List<Storefront> GetAllStores()
        {
            return _repo.GetAllStores();
        }
    }
}