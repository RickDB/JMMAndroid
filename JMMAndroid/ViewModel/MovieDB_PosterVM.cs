﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JMMAndroid.ImageManagement;


namespace JMMAndroid.ViewModel
{
	public class MovieDB_PosterVM
	{
		public int MovieDB_PosterID { get; set; }
		public string ImageID { get; set; }
		public int MovieId { get; set; }
		public string ImageType { get; set; }
		public string ImageSize { get; set; }
		public string URL { get; set; }
		public int ImageWidth { get; set; }
		public int ImageHeight { get; set; }
		public int Enabled { get; set; }

		public string FullImagePathPlain
		{
			get
			{
                if (string.IsNullOrEmpty(URL)) return "";

                string fname = URL;
                fname = URL.Replace("/", @"\").TrimStart('\\');
                return Path.Combine(Utils.GetMovieDBImagePath(), fname);
			}
		}

		public string FullImagePath
		{
			get
			{
				if (string.IsNullOrEmpty(FullImagePathPlain)) return FullImagePathPlain;

				if (!File.Exists(FullImagePathPlain))
				{
					ImageDownloadRequest req = new ImageDownloadRequest(ImageEntityType.MovieDB_Poster, this, false);
					MainActivity.imageHelper.DownloadImage(req);
					if (File.Exists(FullImagePathPlain)) return FullImagePathPlain;
				}

				return FullImagePathPlain;
			}
		}

		private bool isImageDefault = false;
		public bool IsImageDefault
		{
			get { return isImageDefault; }
			set { isImageDefault = value; }
		}

		public MovieDB_PosterVM(JMMServerBinary.Contract_MovieDB_Poster contract)
		{
			this.MovieDB_PosterID = contract.MovieDB_PosterID;
			this.ImageID = contract.ImageID;
			this.MovieId = contract.MovieId;
			this.ImageType = contract.ImageType;
			this.ImageSize = contract.ImageSize;
			this.URL = contract.URL;
			this.ImageWidth = contract.ImageWidth;
			this.ImageHeight = contract.ImageHeight;
			this.Enabled = contract.Enabled;
		}
	}
}
