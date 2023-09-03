using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDVDScreenSaver
{
    static class ImagesModel
    {
        private static readonly string DEFAULT_IMG = "../../resources/khaleesi.jpg";

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
            allImagePaths.Add(DEFAULT_IMG);
            activeImagePaths.Add(DEFAULT_IMG);

            return true;
        }
    }
}
