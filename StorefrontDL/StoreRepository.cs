
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using StorefrontModels;


namespace StorefrontDL
{
    public class Repository : IStoreRepository
    {
        private const string _filePath = "./../StorefrontDL/Database/Storefront.json";
        private string _jsonString;

        public Storefront AddStore(Storefront store)
        {
            List<Storefront> storelist = this.GetAllStores();
            storelist.Add(store);
            String jsonserialized = JsonSerializer.Serialize(storelist, new JsonSerializerOptions{WriteIndented=true});
            string filename = "Storefront.json";
            File.WriteAllText(filename, jsonserialized);
            return store; 
        }

        public List<Storefront> GetAllStores()
        {
            try
            {
                _jsonString = File.ReadAllText(_filePath);
            }
            catch (System.Exception)
            {
                throw new Exception("File path is invalid");
            }

            //This will return a list of restaurant from the jsonString that came from 
            return JsonSerializer.Deserialize<List<Storefront>>(_jsonString);
        }

        public Storefront GetStorefront(Storefront store)
        {
            string storename = store.Name;
            string storeaddress = store.Address;
            List<Storefront> storelist = this.GetAllStores();
            Storefront found = null;
            foreach (Storefront storefront in storelist){
                if(storename == storefront.Name && storeaddress == storefront.Address){
                    found= storefront;
                    break;
                }
            }
            return found;
        }
    }
}