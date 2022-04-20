using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.convertos
{
   public class PhotoConvertor
    {
        public static PhotoDto ToPhotoDto(Photo z)
        {
            return new PhotoDto()
            {
                Id = z.Id,
                Routing = z.Routing,
                IdClothe=z.IdClothe,
            };
        }
        public static Photo ToPhoto(PhotoDto z)
        {
            return new Photo()
            {

                Id = z.Id,
                Routing = z.Routing
                                ,
                IdClothe = z.IdClothe
            };

        }
        public static List<PhotoDto> ToPhotoDtoList(List<Photo> z)
        {
            List<PhotoDto> zlist = new List<PhotoDto>();

            foreach (var item in z)
            {
                zlist.Add(ToPhotoDto(item));
            }
            return zlist;
        }
        public static List<Photo> ToPhotoList(List<PhotoDto> z)
        {
            List<Photo> zlist = new List<Photo>();

            foreach (var item in z)
            {
                zlist.Add(ToPhoto(item));
            }
            return zlist;
        }


    }
}
