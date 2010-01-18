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

// Author: api.anash@gmail.com (Anash P. Oommen)

using com.google.api.adwords.lib;
using com.google.api.adwords.v200909;

using System;
using System.IO;
using System.Net;

namespace com.google.api.adwords.samples.v200909 {
  /// <summary>
  /// This example gets all campaigns. To add a campaign, run AddCampaign.cs.
  /// </summary>
  class GetAllCampaigns : SampleBase {
    /// <summary>
    /// Returns a description about the sample code.
    /// </summary>
    public override string Description {
      get {
        return "This example gets all campaigns. To add a campaign, run AddCampaign.cs.";
      }
    }

    /// <summary>
    /// Run the sample code.
    /// </summary>
    /// <param name="user">The AdWords user object running the sample.
    /// </param>
    public override void Run(AdWordsUser user) {
      // Get the CampaignService.
      CampaignService campaignService =
          (CampaignService) user.GetService(AdWordsService.v200909.CampaignService);

      try {
        // Get all campaigns.
        CampaignPage page = campaignService.get(new CampaignSelector());

        // Display campaigns.
        if (page!= null && page.entries != null) {
         if (page.entries.Length > 0) {
           foreach (Campaign campaign in page.entries) {
             Console.WriteLine("Campaign with id = '{0}', name = '{1}' and status = '{2}'" +
               " was found.", campaign.id, campaign.name, campaign.status);
           }
         } else {
           Console.WriteLine("No campaigns were found.");
         }
        }
      } catch (Exception ex) {
        Console.WriteLine("Failed to retrieve Campaign(s). Exception says \"{0}\"", ex.Message);
      }
    }
  }
}