using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareHardwareAssetTracker
{
    // This class represents an asset for the company
    // An asset can be either a laptop, phone, monitor, or software license
    public class Asset
    {
        public string AssetName { get; set; }

        public string AssetType { get; set; }

        public string AssignedTo { get; set; }

        public string Status { get; set; }

        public DateTime DateAdded { get; set; }

        // Constructor to initialize the asset
        public Asset (string assetName, string assetType, string assignedTo, string status)
        {
            AssetName = assetName;
            AssetType = assetType;
            AssignedTo = assignedTo;
            Status = status;

            // Automatically records when the asset was added to the system
            DateAdded = DateTime.Now;
        }
    }
}
