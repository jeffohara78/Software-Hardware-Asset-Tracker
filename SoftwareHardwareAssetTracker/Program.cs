/* Jeff O'Hara
 * Software and Hardware Asset Tracker
 * 2024-06-01
 * 
 * This program is designed to track software and hardware assets within an organization. 
 * It allows users to add, update, and view asset information, as well as generate reports on asset usage and inventory.
 */
using System;

namespace SoftwareHardwareAssetTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create one AssetManager object
            AssetManager manager = new AssetManager();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n=== Asset Tracker ===");
                Console.WriteLine("1. Add asset");
                Console.WriteLine("2. View all assets");
                Console.WriteLine("3. Search assets");
                Console.WriteLine("4. Update asset status");
                Console.WriteLine("5. Delete asset");
                Console.WriteLine("6. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    manager.AddAsset();
                }
                else if (choice == "2")
                {
                    manager.ViewAllAssets();
                }
                else if (choice == "3")
                {
                    manager.SearchAssets();
                }
                else if (choice == "4")
                {
                    manager.UpdateAssetStatus();
                }
                else if (choice == "5")
                {
                    manager.DeleteAsset();
                }
                else if (choice == "6")
                {
                    running = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }
        }
    }
}