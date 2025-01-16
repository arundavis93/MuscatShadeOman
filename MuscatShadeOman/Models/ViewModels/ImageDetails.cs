using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MuscatShadeOman.Models.DbModel;
namespace MuscatShadeOman.Models.ViewModels
{
    public class ImageDetails
    {
        public string Title { get; set; }
        public string ParagraphContent { get; set; }
        public List<GalleryImage> galleryImageList { get; set; }
        public List<ProjectImage> projectImageList { get; set; }

        public ImageDetails(List<GalleryImage> galleryImage,GalleryImageDetail galleryImageDetails)
        {
            galleryImageList = galleryImage;
            Title = galleryImageDetails?.Title;
            ParagraphContent = galleryImageDetails?.ParagraphContent;
        }

        public ImageDetails(List<ProjectImage> projectImage, ProjectImageDetail projectImageDetails)
        {
            projectImageList = projectImage;
            Title = projectImageDetails?.Title;
            ParagraphContent = projectImageDetails?.ParagraphContent;
        }

        public ImageDetails(List<GalleryImage> galleryImage)
        {
            galleryImageList = galleryImage;
        }

        public ImageDetails(List<ProjectImage> projectImage)
        {
            projectImageList = projectImage;
        }
    }
}