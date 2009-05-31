// Copyright 2009, Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections;
using System.Collections.Specialized;

using com.google.api.adwords.lib;
using com.google.api.adwords.samples.v13;
using com.google.api.adwords.samples.v200902;
using com.google.api.adwords.samples.both;

namespace com.google.api.adwords.samples {
  /// <summary>
  /// The Main class for this application.
  /// </summary>
  class Program {
    /// <summary>
    /// A map to hold the code samples to be executed.
    /// </summary>
    static OrderedDictionary sampleMap = new OrderedDictionary(
        StringComparer.InvariantCultureIgnoreCase);

    /// <summary>
    /// A flag to keep track of whether help message was shown earlier.
    /// </summary>
    private static bool helpShown = false;

    /// <summary>
    /// Static constructor to initialize the sample map.
    /// </summary>
    static Program() {
      // Add v13 samples.
      sampleMap.Add("v13.AccountServiceDemo", new AccountServiceDemo());
      sampleMap.Add("v13.AccountServiceNoConfigDemo", new AccountServiceNoConfigDemo());
      sampleMap.Add("v13.CampaignServiceDemo", new CampaignServiceDemo());
      sampleMap.Add("v13.CampaignServiceWebsiteDemo", new CampaignServiceWebsiteDemo());
      sampleMap.Add("v13.GetCampaignIdsDemo", new GetCampaignIdsDemo());
      sampleMap.Add("v13.GetAdGroupIdsDemo", new GetAdGroupIdsDemo());
      sampleMap.Add("v13.AdServiceDemo", new AdServiceDemo());
      sampleMap.Add("v13.GetAdIdsDemo", new GetAdIdsDemo());
      sampleMap.Add("v13.KeywordToolDemo", new KeywordToolDemo());
      sampleMap.Add("v13.KeywordEstimateDemo", new KeywordEstimateDemo());
      sampleMap.Add("v13.CheckKeywordTrafficDemo", new CheckKeywordTrafficDemo());
      sampleMap.Add("v13.SiteSuggestionServiceDemo", new SiteSuggestionServiceDemo());
      sampleMap.Add("v13.InfoServiceDemo", new InfoServiceDemo());
      sampleMap.Add("v13.ReportServiceKeywordDemo", new ReportServiceKeywordDemo());
      sampleMap.Add("v13.ReportServiceStructureDemo", new ReportServiceStructureDemo());
      sampleMap.Add("v13.DownloadReportAsCsvDemo", new DownloadReportAsCsvDemo());
      sampleMap.Add("v13.DownloadReportAsXmlDemo", new DownloadReportAsXmlDemo());
      sampleMap.Add("v13.BackupSandboxDemo", new BackupSandboxDemo());
      sampleMap.Add("v13.RestoreSandboxDemo", new RestoreSandboxDemo());

      // Add v200902 samples.
      sampleMap.Add("v200902.AddCampaign", new AddCampaign());
      sampleMap.Add("v200902.AddCampaignTarget", new AddCampaignTarget());
      sampleMap.Add("v200902.AddNegativeCampaignPlacement", new AddNegativeCampaignPlacement());
      sampleMap.Add("v200902.AddAdGroup", new AddAdGroup());
      sampleMap.Add("v200902.AddImageAd", new AddImageAd());
      sampleMap.Add("v200902.AddTextAd", new AddTextAd());
      sampleMap.Add("v200902.GetAllAds", new GetAllAds());
      sampleMap.Add("v200902.UpdateAd", new UpdateAd());
      sampleMap.Add("v200902.AddAdGroupKeyword", new AddAdGroupKeyword());
      sampleMap.Add("v200902.GetActiveCriteria", new GetActiveCriteria());

      // Add combined examples.
      sampleMap.Add("both.UsingKeywordSuggestionDemo", new UsingKeywordSuggestionDemo());
    }

    /// <summary>
    /// The main method.
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args) {
      if (args.Length == 0) {
        ShowUsage();
        return;
      }

      AdWordsUser user = new AdWordsUser();

      if (string.Compare(args[0], "--all", true) == 0) {
        foreach (string key in sampleMap.Keys) {
          SampleBase sample = (SampleBase)sampleMap[key];
          Console.WriteLine(sample.Description);
          sample.Run(user);
          Console.WriteLine("Press [Enter] to continue");
          Console.ReadLine();
        }
      } else {
        foreach (string cmdArgs in args) {
          if (sampleMap.Contains(cmdArgs)) {
            SampleBase sample = (SampleBase)sampleMap[cmdArgs];
            Console.WriteLine(sample.Description);
            sample.Run(user);
            Console.WriteLine("Press [Enter] to continue");
            Console.ReadLine();
          } else {
            ShowUsage();
          }
        }
      }
    }
    /// <summary>
    /// Prints program usage message.
    /// </summary>
    private static void ShowUsage() {
      if (helpShown) {
        return;
      } else {
        helpShown = true;
      }
      Console.WriteLine("Runs AdWords API code samples");
      Console.WriteLine("Usage :");
      Console.WriteLine("google-adwordsapi-dotnet-samples.exe or " +
          "google-adwordsapi-dotnet-samples.exe  --help\nPrints this help message.\n");
      Console.WriteLine("google-adwordsapi-dotnet-samples  --all\nRun all code samples.\n");
      Console.WriteLine("google-adwordsapi-dotnet-samples samplename1 [samplename2 ...]\n" +
          "Run specific code samples. Samplename can be one of the following:\n");
      foreach (string key in sampleMap.Keys) {
        Console.WriteLine(key);
      }
    }
  }
}