# Purpose
To demostrate how to write a pre-merge processor.

# Basic Operation
All entities (other than `/Organization` or `/Infrastructure/User` or `/Person`) with all only the latest data part kept based on modification date. 

This is so if you are using tagging logic, only the latest information will be used to evaluate the tagging rules otherwise you can end up with older information causing an undesired tag. In hindsight, it would be better if the rules themselves would only operate on the latest data part / golden record.

For troubleshooting (to emulate explain log function) stores what happened in a property called `LatestWins_LastAction_ExplainLog`.

# References
[Main code Processors/PreProcessing/LatestWinsPreProcessor.cs](https://github.com/CluedIn-io/CluedIn.Processing.LatestWins/blob/78cbc5957d4743ebe0520c5fe49ae6b7a8e8c8fc/src/LatestWins.Crawling/Processors/PreProcessing/LatestWinsPreProcessor.cs)

[Adding a new PreProcessor](https://documentation.cluedin.net/developer/preprocessor)

[Adding a new IMergePreProcessor](https://documentation.cluedin.net/developer/imergepreprocessor)
