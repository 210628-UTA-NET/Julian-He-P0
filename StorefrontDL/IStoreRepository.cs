using StorefrontModels;
using System.Collections.Generic;
using System;

namespace StorefrontDL{

    public interface IStoreRepository{
        //Gets all stores and lists them out
        List<Storefront> GetAllStores();
        Storefront GetStorefront(Storefront store);

        Storefront AddStore(Storefront store);
    }
}

