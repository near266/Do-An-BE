using Firebase.Auth;
using Firebase.Storage;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Modules.Dtos;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private static string ApiKey = "AIzaSyDj-qSdyDbuZL4G_vemnjfXmBVT0H_B488";
        private static string Bucket = "doan-vuquangnam.appspot.com";
        private static string AuthEmail = "namnam@gmail.com";
        private static string AuthPassword = "Abc@1234";
        //[HttpPost("upload")]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    if (file == null || file.Length == 0)
        //    {
        //        return BadRequest("File is required.");
        //    }

        //    try
        //    {
        //        // Đường dẫn tới tệp JSON chứa khóa dịch vụ Firebase
        //        string credentialFilePath = "E:\\DoAn\\BEDoAN\\doan-vuquangnam-firebase-adminsdk-4418f-aff89ea4b8.json";
        //        FileStream ms;

        //        // Tên của bucket Firebase Storage
        //        string bucketName = "doan-vuquangnam.appspot.com";

        //        // Tên của tệp cần tải lên
        //        string fileName = file.FileName;

        //        // Khởi tạo StorageClient với tệp JSON khóa dịch vụ Firebase
        //        var storage = StorageClient.Create(await GoogleCredential.FromFileAsync(credentialFilePath, CancellationToken.None));


        //        // Tạo đường dẫn đến tệp trên Firebase Storage
        //        string objectName = "folder/" + fileName; // Thay đổi "folder/" thành đường dẫn bạn muốn tải tệp lên


        //        //return Ok("File uploaded successfully.");
        //        if (Path.GetExtension(fileName).ToLower() == ".pdf" || Path.GetExtension(fileName).ToLower() == ".png")
        //        {
        //            // Tải tệp lên Firebase Storage
        //            using (var stream = file.OpenReadStream())
        //            {
        //                // Tạo objectReference


        //                // Upload tệp
        //                await storage.UploadObjectAsync(bucketName, objectName, "image/png", stream);
        //                var objectReference = storage.GetBucket(bucketName).;
        //                return Ok(aa);
        //            }
        //        }
        //        else
        //        {
        //            return BadRequest("Only .pdf and .png files are allowed.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading file: {ex.Message}");
        //    }
        //}
        [HttpPost("uploadV2")]
        public async Task<IActionResult> UploadV2(IFormFile file)
        {
            var res = new ResponseFireBase();
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required.");
            }

            try
            {
                // Đường dẫn tới tệp JSON chứa khóa dịch vụ Firebase
                using (var stream = file.OpenReadStream())
                {
                    // Đoạn mã xử lý tải tệp lên Firebase Storage
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
                    var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

                    // Bạn có thể sử dụng CancellationTokenSource để hủy tải lên giữa chừng
                    var cancellation = new CancellationTokenSource();

                    var task = new FirebaseStorage(
                        Bucket,
                        new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true // Khi bạn hủy tải lên, ngoại lệ được ném. Mặc định không có ngoại lệ nào được ném
                        })
                        .Child("CDN")
                        .Child(file.FileName) // Sử dụng tên của tệp từ yêu cầu HTTP
                        .PutAsync(stream, cancellation.Token);
                             await task;

                    res.getInfoUri = "https://firebasestorage.googleapis.com/v0/b/doan-vuquangnam.appspot.com/o/CDN%2F" + file.FileName;
                    res.stringConnect = res.getInfoUri + "?alt=media&token=";
                    return Ok(res);

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading file: {ex.Message}");
            }
        }
    }
}

