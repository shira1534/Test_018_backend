using Dal.Models;
using DTO;
using DTO.convertos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhotoLogic : IPhotoLogic
    {
        private ClothesContext _context;
        public PhotoLogic(ClothesContext context)
        {
            _context = context;
        }


        public PhotoDto AddPhotos(PhotoDto z)
        {
            try
            {
                z.Id = 0;
                Photo zz = PhotoConvertor.ToPhoto(z);
                _context.Photos.Add(zz);

                _context.SaveChanges();
                return PhotoConvertor.ToPhotoDto(zz);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<PhotoDto> AddPhotosrlist(List<PhotoDto> z)
        {
            try
            {
                // z.Id = 0;
                List<Photo> zz = PhotoConvertor.ToPhotoList(z);
                for (int i = 0; i < zz.Count; i++)
                {
                    _context.Photos.Add(zz[i]);
                    _context.SaveChanges();

                }


                return PhotoConvertor.ToPhotoDtoList(zz);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<PhotoDto> GetAllPhotos()
        {
            return PhotoConvertor.ToPhotoDtoList(_context.Photos.ToList());
        }

        
    }
}
