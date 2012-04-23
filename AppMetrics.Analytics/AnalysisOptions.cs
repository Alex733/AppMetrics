﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMetrics.Analytics
{
	public enum LocationSliceType { None, Countries, CountriesAndCities }
	public enum ReportType { LatencySummaries, LatencyDistribution, JitterDistribution,
		StreamingLatencySummaries, StreamingLatencyDistribution, Exceptions }

	public class AnalysisOptions
	{
		public string ApplicationKey = "";

		public TimeSpan Period = TimeSpan.FromDays(1);

		public bool SliceByFunction = true;

		public LocationSliceType SliceByLocation = LocationSliceType.CountriesAndCities;
		public bool LocationIncludeOverall = true;

		public HashSet<string> CountryFilter = new HashSet<string>();
		public bool FilterByCountries { get { return CountryFilter.Count > 0; } }

		public ReportType ReportType;

		public override bool Equals(object obj)
		{
			var that = obj as AnalysisOptions;
			if (that == null)
				return false;

			var res = (ApplicationKey == that.ApplicationKey) && Period == that.Period &&
				SliceByLocation == that.SliceByLocation && LocationIncludeOverall == that.LocationIncludeOverall &&
				SliceByFunction == that.SliceByFunction && CountryFilter.SequenceEqual(that.CountryFilter);
			return res;
		}

		public override int GetHashCode()
		{
			return ApplicationKey.GetHashCode() ^ Period.GetHashCode() ^ CountryFilter.Count ^ 
				SliceByLocation.GetHashCode() ^ LocationIncludeOverall.GetHashCode() ^ SliceByFunction.GetHashCode();
		}

		public void Validate()
		{
			if (string.IsNullOrEmpty(ApplicationKey))
				throw new ArgumentException();
			if (SliceByLocation == LocationSliceType.None && CountryFilter.Count > 0)
				throw new ArgumentException();
		}
	}
}
