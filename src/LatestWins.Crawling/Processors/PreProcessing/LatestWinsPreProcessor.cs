using System;
using System.Collections.Generic;
using System.Text;

using CluedIn.Core;
using CluedIn.Core.Data;
using CluedIn.Core.Data.Parts;
using CluedIn.Core.Processing;
using CluedIn.Processing.Models.Utilities;
using CluedIn.Processing.Processors;
using CluedIn.Processing.Processors.PreProcessing;

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

            // to protect us from ourselves we ignore these types
            if ((targetEntity.EntityType == "/Organization") ||
                (targetEntity.EntityType == "/Infrastructure/User") ||
                (targetEntity.EntityType == "/Person")
                )
            {
                return SaveResult.Ignored;
            }

            // how to get data parts
            // I'm happy with the DataEntries member for now
            //var parts = targetEntity.Details.Parts.OfType<DataPart>();

            // thin down from 2 to 1
            // (i.e. we already have 2 parts and we are thinking about adding a third)
            // this case is unlikely since we already thin down at 1 data part
            // however, if this plugin is loaded later then we would have more parts
            // TODO: to make this production, you would need to handle Count > 1 generically
            // which is probably just a for loop till only one data part is left
            if (targetEntity.Details.DataEntries.Count == 2)
            {
                var it = targetEntity.Details.DataEntries.GetEnumerator();
                it.MoveNext();
                var first = it.Current;
                it.MoveNext();
                var second = it.Current;

                if (first.ProcessedEntityData.ModifiedDate > second.ProcessedEntityData.ModifiedDate)
                {
                    metadataToMerge.Properties["LatestWins_LastAction_ExplainLog"] = "2 Parts. Removed Older Second Part " + second.PartId + ". ";
                    targetEntity.Details.DataEntries.Remove(second);
                }
                else
                {
                    metadataToMerge.Properties["LatestWins_LastAction_ExplainLog"] = "2 Parts. Removed Older First Part " + first.PartId + ". ";
                    targetEntity.Details.DataEntries.Remove(first);
                }
            }

            // thin down from the one we want to merge with the existing 1
            // covers the case where we had 2 and also the case where we only have 1
            if (targetEntity.Details.DataEntries.Count == 1)
            {
                var it = targetEntity.Details.DataEntries.GetEnumerator();
                it.MoveNext();
                var first = it.Current;

                if (dataToMerge.ProcessedEntityData.ModifiedDate > first.ProcessedEntityData.ModifiedDate)
                {
                    metadataToMerge.Properties["LatestWins_LastAction_ExplainLog"] = "1 Part. Removed Older Existing Part " + first.PartId + ". ";
                    targetEntity.Details.DataEntries.Remove(first);
                }
                else
                {
                    // probably not logged since we have ignored...
                    metadataToMerge.Properties["LatestWins_LastAction_ExplainLog"] = "1 Part. Kept it since new part was older. ";
                    return SaveResult.Ignored;
                }
            }

            return SaveResult.Success;
        }
    }
}
