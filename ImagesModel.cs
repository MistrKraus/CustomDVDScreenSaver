using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDVDScreenSaver
{
    static class ImagesModel
    {
        private static readonly string DEFAULT_IMG_1 = "../../resources/khaleesi.jpg";
        private static readonly string DEFAULT_IMG_2 = "../../resources/blue_circle.png";

        private static List<string> allImagePaths = new List<string>();
        public static List<string> AllImagePaths
        {
            get
            {
                return allImagePaths;
            }
        }

        public static List<string> activeImagePaths = new List<string>();
        public static List<string> ActiveImagePaths
        {
            get
            {
                return activeImagePaths;
            }
        }

        public static List<Image> images = new List<Image>();
        public static List<Image> Images
        {
            get
            {
                return images;
            }
        }

        /// <summary>
        /// Load all active images
        /// Return not loaded images
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        ///     09/23 PK - Created (Issue#2)
        /// </remarks>
        public static IList<string> LoadActiveImages(int imageHeight)
        {
            IList<string> notLoadedImages = new List<string>();

            foreach (string path in activeImagePaths)
            {
                try
                {
                    Image img = Image.FromFile(Path.Combine(Directory.GetCurrentDirectory(), path));
                    double ratio = img.Width / (double)img.Height;

                    int height = imageHeight;
                    int width = (int)(height * ratio);

                    images.Add(new Bitmap(img, width, height));
                }
                catch (Exception e)
                {
                    notLoadedImages.Add(path);
                }
            }

            return notLoadedImages;
        }

        /// <summary>
        /// Add image path to the all image list
        /// If there already is this image return false
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static bool AddToAllList(string imagePath)
        {
            if (allImagePaths.Contains(imagePath))
            {
                return false;
            }

            allImagePaths.Add(imagePath);

            return true;
        }

        /// <summary>
        /// Add image path to the active image list
        /// If there already is this image return false
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static bool AddToActiveList(string imagePath)
        {
            if (activeImagePaths.Contains(imagePath))
            {
                return false;
            }

            activeImagePaths.Add(imagePath);

            return true;
        }

        /// <summary>
        /// Remove image path from the active image list
        /// If there isn't this image return false
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static bool RemoveFromActiveList(string imagePath)
        {
            activeImagePaths.Remove(imagePath);

            return true;
        }
        
        /// <summary>
        /// Remove image path from the all image list
        /// If there isn't this image return false
        /// If image is in the active image list return false
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static bool RemoveFromAllList(string imagePath)
        {
            if (activeImagePaths.Contains(imagePath))
            {
                return false;
            }

            allImagePaths.Remove(imagePath);

            return true;
        }

        /// <summary>
        /// Load list of default images
        /// </summary>
        /// <returns></returns>
        public static bool LoadDefaultImages()
        {
            allImagePaths.Add(DEFAULT_IMG_1);
            allImagePaths.Add(DEFAULT_IMG_2);
            activeImagePaths.Add(DEFAULT_IMG_1);
            activeImagePaths.Add(DEFAULT_IMG_2);

            return true;
        }
    }
}
