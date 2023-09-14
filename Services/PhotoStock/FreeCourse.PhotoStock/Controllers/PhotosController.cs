using FreeCourse.PhotoStock.Dtos;
using FreeCourse.Shared.ControllerBases;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.PhotoStock.Controllers
{
    
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo,CancellationToken cancellationToken)
        {
            if(photo!=null && photo.Length>0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream,cancellationToken);
                }

                var returnPath="photos/"+photo.FileName;

                PhotoDto photoDto = new() { Url=returnPath};

                return CreateActionResult(Response<PhotoDto>.Success(photoDto, 200));
            }
            return CreateActionResult(Response<NoContent>.Fail("Fotoğraf Yüklenmedi",400));
        }


        [HttpDelete]
        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
            if(!System.IO.File.Exists(path))
            {
                return CreateActionResult(Response<NoContent>.Fail("Böyle bir fotoğraf bulunamadı", 404));
            }
            System.IO.File.Delete(path);
            return CreateActionResult(Response<NoContent>.Success(204));
        }
    }
}
