using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareHardwareAssetTracker
{
    public class AssetManager
    {
        // This list stores all asset objects in the system
        private List<Asset> assets = new List<Asset>();

        // Adds a new asset to the system
        public void AddAsset()
        {
            Console.WriteLine("\n *** Add New Asset ***");

            Console.Write("Enter asset name: ");
            string assetName = Console.ReadLine();

            Console.Write("Enter asset type: ");
            string assetType = Console.ReadLine();

            Console.Write("Enter assigned user: ");
            string assignedTo = Console.ReadLine();

            Console.Write("Enter asset status (Active, In Repair, Retired, Missing): ");
            string status = Console.ReadLine();

            // Create a new asset object 
            Asset newAsset = new Asset(assetName, assetType, assignedTo, status);

            // Add the new asset to the list
            assets.Add(newAsset);

            Console.WriteLine("Asset added successfully!");
        }

        // Displays all assets in the system
        public void ViewAllAssets()
        {
            Console.WriteLine("\n *** All Assets ***");

            if (assets.Count == 0)
            {
                Console.WriteLine("No assets have been added yet.");
                return;
            }

            for (int i = 0; i < assets.Count; i++)
            {
                Console.WriteLine($"\nAsset #{i + 1}");
                Console.WriteLine($"Name: {assets[i].AssetName}");
                Console.WriteLine($"Type: {assets[i].AssetType}");
                Console.WriteLine($"Assigned To: {assets[i].AssignedTo}");
                Console.WriteLine($"Status: {assets[i].Status}");
                Console.WriteLine($"Date Added: {assets[i].DateAdded}");
            }
        }

        // Searches assets by name, type, or assigned user
        public void SearchAssets()
        {
            Console.WriteLine("\n *** Search Assets ***");

            Console.Write("Enter search term (name, type, or assigned user): ");
            string searchTerm = Console.ReadLine();

            bool found = false;

            foreach (Asset asset in assets)
            {
                // This allows the user to search by name, type, or assigned user
                bool nameMatches = asset.AssetName.ToLower().Contains(searchTerm.ToLower());
                bool typeMatches = asset.AssetType.ToLower().Contains(searchTerm.ToLower());
                bool userMatches = asset.AssignedTo.ToLower().Contains(searchTerm.ToLower());

                if (nameMatches || typeMatches || userMatches)
                {
                    Console.WriteLine("\nAsset Found:");
                    Console.WriteLine($"Name: {asset.AssetName}");
                    Console.WriteLine($"Type: {asset.AssetType}");
                    Console.WriteLine($"Assigned To: {asset.AssignedTo}");
                    Console.WriteLine($"Status: {asset.Status}");
                    Console.WriteLine($"Date Added: {asset.DateAdded}");

                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching assets found.");
            }
        }

        // Updates the status of an existing asset.
        public void UpdateAssetStatus()
        {
            Console.WriteLine("\n--- Update Asset Status ---");

            // Check if there are any assets in the list.
            if (assets.Count == 0)
            {
                Console.WriteLine("There are no assets to update.");
                return;
            }

            // Display the current assets with numbers.
            DisplayAssetSummary();

            Console.Write("\nEnter the asset number to update: ");

            // Read the user's input and remove extra spaces.
            string input = Console.ReadLine().Trim();

            // Attempt to convert the user's input into an integer.
            bool isValidNumber = int.TryParse(input, out int assetNumber);

            // If conversion fails, stop the method.
            if (!isValidNumber)
            {
                Console.WriteLine($"'{input}' is not a valid number.");
                return;
            }

            // Convert the user-friendly number into a list index.
            int index = assetNumber - 1;

            // Verify the number exists in the list.
            if (index >= 0 && index < assets.Count)
            {
                Console.Write("Enter new status: ");
                string newStatus = Console.ReadLine();

                // Update the asset status.
                assets[index].Status = newStatus;

                Console.WriteLine($"Status updated for '{assets[index].AssetName}'.");
            }
            else
            {
                Console.WriteLine("That asset number does not exist.");
            }
        }

        // Deletes an asset from the system
        public void DeleteAsset()
        {
            Console.WriteLine("\n *** Delete Asset ***");

            if (assets.Count == 0)
            {
                Console.WriteLine("There are no assets to delete.");
                return;
            }

            DisplayAssetSummary();

            Console.Write("\nEnter the number of the asset you want to delete: ");
            string input = Console.ReadLine();

            bool isValidNumber = int.TryParse(input, out int assetNumber);

            if (!isValidNumber)
            {
                Console.WriteLine("Invalid input. Please enter a valid asset number.");
                return;
            }

            int index = assetNumber - 1;

            if (index >= 0 && index < assets.Count)
            {
                string deleteAssetName = assets[index].AssetName;

                assets.RemoveAt(index);

                Console.WriteLine($"Asset '{deleteAssetName}' has been deleted.");

            }
            else
            {
                Console.WriteLine("That asset number does not exist. Please try again.");
            }
        }

        // Helper method used by update and delete methods to display a summary of assets with numbers for selection
        private void DisplayAssetSummary()
        {
            Console.Write("\nAvailable Assets:\n");

            for (int i = 0; i < assets.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {assets[i].AssetName} | Type: {assets[i].AssetType} | Assigned To: {assets[i].AssignedTo} | Status: {assets[i].Status}");
            }
        }

    }
}
