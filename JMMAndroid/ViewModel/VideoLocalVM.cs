﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JMMAndroid.JMMServerBinary;

namespace JMMAndroid.ViewModel
{
	public class VideoLocalVM
	{
		public int VideoLocalID { get; set; }
		public string FilePath { get; set; }
		public int ImportFolderID { get; set; }
		public string Hash { get; set; }
		public string CRC32 { get; set; }
		public string MD5 { get; set; }
		public string SHA1 { get; set; }
		public int HashSource { get; set; }
		public long FileSize { get; set; }
		public int IsWatched { get; set; }
		public int IsIgnored { get; set; }
		public DateTime? WatchedDate { get; set; }
		public DateTime DateTimeUpdated { get; set; }
        public Media Media { get; set; }
		public ImportFolderVM ImportFolder { get; set; }

		public string FullPath
		{
			get
			{
				if (BaseConfig.Settings.ImportFolderMappings.ContainsKey(ImportFolderID))
					return Path.Combine(BaseConfig.Settings.ImportFolderMappings[ImportFolderID], FilePath);
				else
					return Path.Combine(ImportFolder.ImportFolderLocation, FilePath);
			}
		}

		public string FileName
		{
			get
			{
				return Path.GetFileName(FullPath);
			}
		}

		public string FileDirectory
		{
			get
			{
				return Path.GetDirectoryName(FullPath);
			}
		}

		public string FormattedFileSize
		{
			get
			{
				return Utils.FormatFileSize(FileSize);
			}
		}

		public VideoLocalVM()
		{
		}

		public VideoLocalVM(JMMServerBinary.Contract_VideoLocal contract)
		{
			this.CRC32 = contract.CRC32;
			this.DateTimeUpdated = contract.DateTimeUpdated;
			this.FilePath = contract.FilePath;
			this.FileSize = contract.FileSize;
			this.Hash = contract.Hash;
			this.HashSource = contract.HashSource;
			this.ImportFolderID = contract.ImportFolderID;
			this.IsWatched = contract.IsWatched;
			this.IsIgnored = contract.IsIgnored;
			this.MD5 = contract.MD5;
			this.SHA1 = contract.SHA1;
			this.VideoLocalID = contract.VideoLocalID;
			this.WatchedDate = contract.WatchedDate;
		    this.Media = contract.Media;
			ImportFolder = new ImportFolderVM(contract.ImportFolder);
		}

		public int CompareTo(VideoLocalVM obj)
		{
			return FullPath.CompareTo(obj.FullPath);
		}

		public List<AnimeEpisodeVM> GetEpisodes()
		{
			List<AnimeEpisodeVM> eps = new List<AnimeEpisodeVM>();

			try
			{
				List<JMMServerBinary.Contract_AnimeEpisode> epContracts = JMMServerVM.Instance.clientBinaryHTTP.GetEpisodesForFile(this.VideoLocalID,
					JMMServerVM.Instance.CurrentUser.JMMUserID);
				foreach (JMMServerBinary.Contract_AnimeEpisode epcontract in epContracts)
				{
					AnimeEpisodeVM ep = new AnimeEpisodeVM(epcontract);
					eps.Add(ep);
				}
			}
			catch (Exception ex)
			{
				BaseConfig.MyAnimeLog.Write(ex.ToString());
			}

			return eps;
		}

		public string DefaultAudioLanguage
		{
			get
			{
				List<AnimeEpisodeVM> eps = GetEpisodes();
				if (eps.Count == 0) return string.Empty;

				return eps[0].DefaultAudioLanguage;
			}
		}

		public string DefaultSubtitleLanguage
		{
			get
			{
				List<AnimeEpisodeVM> eps = GetEpisodes();
				if (eps.Count == 0) return string.Empty;

				return eps[0].DefaultSubtitleLanguage;
			}
		}
	}
}
