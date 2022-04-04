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

            if (targetEntity.EntityType != "/Person")
                return SaveResult.Ignored;

            // for this prototype - let's only operate on the "chris" named entity
            if (targetEntity.Name == "chris")
            {
                // how to get data parts
                // I'm happy with the DataEntries member for now
                //var parts = targetEntity.Details.Parts.OfType<DataPart>();

                // thin down from 2 to 1
                // (i.e. we already have 2 parts and we are thinking about adding a third)
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
                        targetEntity.Details.DataEntries.Remove(first);
                    }
                    else
                    {
                        return SaveResult.Ignored;
                    }
                }
            }

            return SaveResult.Success;
        }
    }
}
