using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IPhotoLogic
    {
        List<PhotoDto> GetAllPhotos();
        PhotoDto AddPhotos(PhotoDto z);
        List<PhotoDto> AddPhotosrlist(List<PhotoDto> z);

    }
}
