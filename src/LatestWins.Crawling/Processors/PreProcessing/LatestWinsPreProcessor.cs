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

            //metadataToMerge.Properties["mergeTimeStamp"] = DateTimeOffset.UtcNow.ToString();

            if (targetEntity.EntityType != "/Person")
                return SaveResult.Ignored;

            // for this prototype - let's only operate on the "chris" named entity
            if (targetEntity.Name == "chris")
            {
                // okay... we already have 2 data parts and we are thinking of adding a third...
                // let's delete as many old data parts as possible

                // TODO: we need to handle the case were we have only one existing data part... perhaps guard the second part as indicated?

                //var parts = targetEntity.Details.Parts.OfType<DataPart>();
                if (targetEntity.Details.DataEntries.Count == 2)
                {
                    var it = targetEntity.Details.DataEntries.GetEnumerator();
                    it.MoveNext();
                    var first = it.Current;
                    it.MoveNext();
                    var second = it.Current;

                    if (first.ProcessedEntityData.ModifiedDate > second.ProcessedEntityData.ModifiedDate)
                    {
                        targetEntity.Details.DataEntries.Remove(second);
                    }
                    else
                    {
                        targetEntity.Details.DataEntries.Remove(first);
                    }

                    // TODO: put me in a Count == 1 clause?

                    it = targetEntity.Details.DataEntries.GetEnumerator();
                    it.MoveNext();
                    first = it.Current;

                    if (dataToMerge.ProcessedEntityData.ModifiedDate > first.ProcessedEntityData.ModifiedDate)
                    {
                        targetEntity.Details.DataEntries.Remove(first);
                    }
                    else
                    {
                        return SaveResult.Ignored;
                    }

                    {
                        // this happens later in the common code
                        //MappingProcessing.CreateMappings(targetEntity);
                        //VersionHistoryProcessing.CreateChangeHistory(targetEntity);
                        //VersionHistoryProcessing.CreateChangeHistoryEdges(targetEntity, context);
                    }
                }
            }

            return SaveResult.Success;
        }
    }
}
