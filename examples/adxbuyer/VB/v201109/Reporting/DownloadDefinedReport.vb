﻿' Copyright 2011, Google Inc. All Rights Reserved.
'
' Licensed under the Apache License, Version 2.0 (the "License");
' you may not use this file except in compliance with the License.
' You may obtain a copy of the License at
'
'     http://www.apache.org/licenses/LICENSE-2.0
'
' Unless required by applicable law or agreed to in writing, software
' distributed under the License is distributed on an "AS IS" BASIS,
' WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
' See the License for the specific language governing permissions and
' limitations under the License.

' Author: api.anash@gmail.com (Anash P. Oommen)

Imports Google.Api.Ads.AdWords.Lib
Imports Google.Api.Ads.AdWords.Util.Reports

Imports System
Imports System.Collections.Generic
Imports System.IO

Namespace Google.Api.Ads.AdWords.Examples.VB.v201109
  ''' <summary>
  ''' This code example gets and downloads a report from an existing report definition.
  ''' </summary>
  Public Class DownloadDefinedReport
    Inherits ExampleBase
    ''' <summary>
    ''' Main method, to run this code example as a standalone application.
    ''' </summary>
    ''' <param name="args">The command line arguments.</param>
    Public Shared Sub Main(ByVal args As String())
      Dim codeExample As ExampleBase = New DownloadDefinedReport
      Console.WriteLine(codeExample.Description)
      Try
        codeExample.Run(New AdWordsUser, codeExample.GetParameters, Console.Out)
      Catch ex As Exception
        Console.WriteLine("An exception occurred while running this code example. {0}", _
            ExampleUtilities.FormatException(ex))
      End Try
    End Sub

    ''' <summary>
    ''' Returns a description about the code example.
    ''' </summary>
    Public Overrides ReadOnly Property Description() As String
      Get
        Return "This code example gets and downloads a report from an existing report definition."
      End Get
    End Property

    ''' <summary>
    ''' Gets the list of parameter names required to run this code example.
    ''' </summary>
    ''' <returns>
    ''' A list of parameter names for this code example.
    ''' </returns>
    Public Overrides Function GetParameterNames() As String()
      Return New String() {"REPORT_DEFINITION_ID", "OUTPUT_FILE_NAME"}
    End Function

    ''' <summary>
    ''' Runs the code example.
    ''' </summary>
    ''' <param name="user">The AdWords user.</param>
    ''' <param name="parameters">The parameters for running the code
    ''' example.</param>
    ''' <param name="writer">The stream writer to which script output should be
    ''' written.</param>
    Public Overrides Sub Run(ByVal user As AdWordsUser, ByVal parameters As  _
        Dictionary(Of String, String), ByVal writer As TextWriter)
      Dim reportDefinitionId As Long = Long.Parse(parameters("REPORT_DEFINITION_ID"))
      Dim fileName As String = parameters("OUTPUT_FILE_NAME")
      Dim filePath As String = (ExampleUtilities.GetHomeDir() & Path.DirectorySeparatorChar & _
          fileName)

      Try
        ' Download the report.
        Dim utilities As New ReportUtilities(user)
        ' If you know that your report is small enough to fit in memory, then
        ' you can instead use
        ' ClientReport report = new ReportUtilities(user).GetClientReport(reportDefinitionId);
        '
        ' ' Get the text report directly if you requested a text format
        ' ' (e.g. xml)
        ' string reportText = report.Text;
        '
        ' ' Get the binary report if you requested a binary format
        ' ' (e.g. gzip)
        ' byte[] reportBytes = report.Contents;
        '
        ' ' Deflate a zipped binary report for further processing.
        ' string deflatedReportText = Encoding.UTF8.GetString(
        '     MediaUtilities.DeflateGZipData(report.Contents));
        utilities.DownloadClientReport(Of Long)(reportDefinitionId, filePath)
        writer.WriteLine("Report with definition id '{0}' was downloaded to '{1}'.", _
            reportDefinitionId, filePath)
      Catch ex As Exception
        Throw New System.ApplicationException("Failed to download report.", ex)
      End Try
    End Sub
  End Class
End Namespace