using System;
using System.Collections.Generic;
using System.Text;

using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Core.Data.Parts;
using CluedIn.Core.Processing;
using CluedIn.Processing.Models.Utilities;

namespace CluedIn.Crawling.LatestWins.Processors.PreProcessing
{
    public class LatestWinsPreProcessor : PropertyUtility<IEntityMetadataPart>, IMergePreProcessor
    {
        public bool Accepts(ExecutionContext context, IEnumerable<IEntityCode> codes)
        {
            return true;
        }

        public SaveResult Process(ExecutionContext context, IEntityMetadataPart metadataToMerge, IDataPart dataToMerge, Entity targetEntity)
        {
            if (dataToMerge == null)
                return SaveResult.Ignored;

            //metadataToMerge.Properties["mergeTimeStamp"] = DateTimeOffset.UtcNow.ToString();

            return SaveResult.Success;
        }
    }
}
