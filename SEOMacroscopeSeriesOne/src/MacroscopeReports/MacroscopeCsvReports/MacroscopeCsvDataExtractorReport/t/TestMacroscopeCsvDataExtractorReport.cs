﻿/*

  This file is part of SEOMacroscope.

  Copyright 2019 Jason Holland.

  The GitHub repository may be found at:

    https://github.com/nazuke/SEOMacroscope

  Foobar is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  Foobar is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details.

  You should have received a copy of the GNU General Public License
  along with Foobar.  If not, see <http://www.gnu.org/licenses/>.

*/

using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace SEOMacroscope
{

  [TestFixture]
  public class TestMacroscopeCsvDataExtractorReport : Macroscope
  {

    /**************************************************************************/

    [Test]
    public void TestWriteCsv ()
    {
      MacroscopeJobMaster JobMaster = new MacroscopeJobMaster( MacroscopeConstants.RunTimeMode.LIVE );
      MacroscopeDataExtractorCssSelectors DataExtractorCssSelectors = new MacroscopeDataExtractorCssSelectors( 1 );
      MacroscopeDataExtractorRegexes DataExtractorRegexes = new MacroscopeDataExtractorRegexes( 1 );
      MacroscopeDataExtractorXpaths DataExtractorXpaths = new MacroscopeDataExtractorXpaths( 1 );
      MacroscopeCsvDataExtractorReport ReportFile = new MacroscopeCsvDataExtractorReport( NewDataExtractorCssSelectors: DataExtractorCssSelectors, NewDataExtractorRegexes: DataExtractorRegexes, NewDataExtractorXpaths: DataExtractorXpaths );
      List<MacroscopeCsvDataExtractorReport.OutputWorksheet> SelectedOutputWorksheets = new List<MacroscopeCsvDataExtractorReport.OutputWorksheet>();
      SelectedOutputWorksheets.Add( MacroscopeCsvDataExtractorReport.OutputWorksheet.CSS_SELECTORS );
      SelectedOutputWorksheets.Add( MacroscopeCsvDataExtractorReport.OutputWorksheet.REGEXES );
      SelectedOutputWorksheets.Add( MacroscopeCsvDataExtractorReport.OutputWorksheet.XPATHS );
      foreach ( MacroscopeCsvDataExtractorReport.OutputWorksheet SelectedOutputWorksheet in SelectedOutputWorksheets )
      {
        string Filename = string.Join( ".", Path.GetTempFileName(), ".csv" );
        ReportFile.WriteCsv( JobMaster: JobMaster, SelectedOutputWorksheet: SelectedOutputWorksheet, OutputFilename: Filename );
        Assert.IsTrue( File.Exists( Filename ) );
        File.Delete( Filename );
      }
    }

    /**************************************************************************/

  }

}
