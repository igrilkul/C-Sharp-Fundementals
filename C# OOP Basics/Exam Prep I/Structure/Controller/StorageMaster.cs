using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster
{
    class StorageMaster
    {
        private List<Product> products;
        private List<Storage> storages;
        private ProductFactory productFactory;
        private StorageFactory storageFactory;
        private Vehicle selectedVehicle;

        public StorageMaster()
        {
            this.products = new List<Product>();
            this.storages = new List<Storage>();
            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            Product product = productFactory.CreateProduct(type, price);
            this.products.Add(product);

            string result = $"Added {type} to pool";
            return result;
        }

        public string RegisterStorage(string type, string name)
        {
            Storage storage = storageFactory.CreateStorage(type, name);
            storages.Add(storage);

            string result = $"Registered {name}";
            return result;
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storages.FirstOrDefault(x => x.Name == storageName);
            this.selectedVehicle = storage.GetVehicle(garageSlot);

            string result = $"Selected {this.selectedVehicle.GetType().Name}";
            return result;
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            int loadedCounter = 0;
            foreach(string productName in productNames)
            {
                if (!selectedVehicle.IsFull)
                {
                    Product product = products.LastOrDefault(p => p.GetType().Name == productName);
                    if (product != null)
                    {
                        selectedVehicle.LoadProduct(product);
                        products.Remove(product);
                        loadedCounter++;
                    }
                    else
                    {
                        throw new InvalidOperationException($"{productName} is out of stock!");
                    }
                }
                else
                {
                    break;
                }
                
            }

            string result = 
                $"Loaded {loadedCounter}/{productNames.Count()} products into {selectedVehicle.GetType().Name}";
            return result;
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if(storages.FindIndex(s=>s.Name==sourceName)<0)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }

            if (storages.FindIndex(s => s.Name == destinationName) < 0)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            Storage sourceStorage = storages.First(s => s.Name == sourceName);
            Storage destinationStorage = storages.First(s => s.Name == destinationName);
            int destinationGarageSlot=sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            string result =
                $"Sent {destinationStorage.GetVehicle(destinationGarageSlot).GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
            return result;
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            Storage storage = storages.First(s => s.Name == storageName);

            if(storage.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }

            Vehicle vehicle = storage.GetVehicle(garageSlot);
            int productsInVehicle = vehicle.Trunk.Count;
            int unloadedProductsCount=storage.UnloadVehicle(garageSlot);

            string result =
                $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
            return result;
        }

        public string GetStorageStatus(string storageName)
        {
            Storage storage = storages.First(s => s.Name == storageName);

            //Products
            Dictionary<string, int> productTypes = new Dictionary<string, int>();

            foreach(var product in storage.Products)
            {
                string productName = product.GetType().Name;
                if (!productTypes.ContainsKey(productName))
                {
                    productTypes.Add(productName, 1);
                }
                else
                {
                    productTypes[productName]++;
                }
            }

            var sortedProducts=productTypes.OrderByDescending(x => x.Value).ThenBy(y => y.Key);
            string productsString = GetProductsString(sortedProducts);
            double storedWeight = storage.Products.Sum(p => p.Weight);

            string productsStatus = $"Stock ({storedWeight}/{storage.Capacity}): {productsString}";

            //string[] productsAsStrings = productTypes
            //    .OrderByDescending(p => p.Value)
            //    .ThenBy(p => p.Key)
            //    .Select(kvp => $"{kvp.Key} ({kvp.Value})")
            //    .ToArray();

            //Garage
            string garageString = GetGarageString(storage);
            string garageStatus = $"Garage: {garageString}";

            //string[] garageString = storage.Garage
            //    .Select(g => g == null ? "empty" : g.GetType().Name)
            //    .ToArray();

            //Result
            string result = productsStatus + Environment.NewLine + garageStatus;
            return result;
        }

        private string GetGarageString(Storage storage)
        {
            String[] garageToStrings = new String[storage.GarageSlots];
            int index = 0;
            foreach(var car in storage.Garage)
            {
                if(car==null)
                {
                    garageToStrings[index++] = "empty";
                }
                else
                {
                    garageToStrings[index++] = car.GetType().Name;
                }
            }
            string result = $"[{string.Join('|', garageToStrings)}]";
            return result;
        }

        private string GetProductsString(IOrderedEnumerable<KeyValuePair<string, int>> sortedProducts)
        {
            string[] productsAsStrings = new string[sortedProducts.Count()];
            int index = 0;
            foreach(var kvp in sortedProducts)
            {
                productsAsStrings[index++] = $"{kvp.Key} ({kvp.Value})";
            }
            string result = $"[{string.Join(", ", productsAsStrings)}]";
            return result;
        }

        public string GetSummary()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var storage in storages.OrderByDescending(p=>p.Products.Sum(x=>x.Price)))
            {
                double totalMoney = storage.Products.Sum(p => p.Price);
                sb.Append($"{storage.Name}:");
                sb.AppendLine($"\nStorage worth: ${totalMoney:F2}");
            }
            return sb.ToString();
        }

    }
}
