﻿using System.Collections.Generic;
using System.Drawing;
namespace BabaIsYou.Map {
	public class Sprite {
		public string Name;
		public bool IsRoot;
		public Dictionary<int, SpriteImage> Images = new Dictionary<int, SpriteImage>();

		public Sprite(string name, bool isRoot) {
			Name = name;
			IsRoot = isRoot;
		}
		public Sprite Copy(string name) {
			Sprite sprite = new Sprite(name, IsRoot);
			sprite.Images = Images;
			return sprite;
		}
		public int MaxIndex {
			get {
				int max = 0;
				foreach (int key in Images.Keys) {
					int id = (key - 1) / 3;
					if (id > max) {
						max = id;
					}
				}
				return max;
			}
		}
		public SpriteImage this[int index, int sub] {
			get {
				SpriteImage img;
				if (Images.TryGetValue(index * 3 + sub, out img)) {
					return img;
				} else if (Images.TryGetValue(index * 3 + sub + (sub < 3 ? 1 : -2), out img)) {
					return img;
				} else if (Images.TryGetValue(index * 3 + sub + 1 + (sub + 1 < 3 ? 1 : -2), out img)) {
					return img;
				}
				return null;
			}
			set {
				int key = index * 3 + sub;
				if (Images.ContainsKey(key)) {
					Images[key] = value;
				} else {
					Images.Add(key, value);
				}
			}
		}
		public override string ToString() {
			return $"{Name} [{Images.Count}]";
		}
	}
	public class SpriteImage {
		public Bitmap Image;
		public string Name;

		public SpriteImage(Bitmap image, string fileName) {
			Image = image;
			Name = fileName;
		}
		public override string ToString() {
			return Name;
		}
	}
}