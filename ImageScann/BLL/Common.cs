using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using NLog;

namespace ImageScann.BLL
{
    public class Common
    {
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 获取接口地址
        /// </summary>
        /// <param name="actionName">接口名称</param>
        /// <returns></returns>
        public static string GetApiUrl(string actionName)
        {
            var url = System.Configuration.ConfigurationManager.AppSettings["url"];
            if (!url.EndsWith("/")) url += "/";
            url += "ImageApi/" + actionName;
            return url;
        }

        public static string HttpPost(string url, string postDataStr)
        {
            var result = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            var postBytes = Encoding.UTF8.GetBytes(postDataStr);
            request.Method = "POST";
            request.Accept = "*/*";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
            var myRequestStream = request.GetRequestStream();
            myRequestStream.Write(postBytes, 0, postBytes.Length);
            myRequestStream.Close();
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                var myResponseStream = response.GetResponseStream();
                var myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                result = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
            }
            catch (WebException ex)
            {
                _logger.Info(string.Format("Url:{0},请求异常:{1}", url, ex.ToString()));
                result = string.Format("{{\"success\":false,\"info\":\"访问错误,{0}!\"}}", ex.Message);
            }
            return result;
        }
        /// <summary>
        /// 扫描仪返回错误提示信息
        /// </summary>
        public static Dictionary<int, string> ErrorMsg = new Dictionary<int, string> {
            {0,"Successful" },
            {1,"Unable to scan.Other process uses the scanner." },
            {2,"Invalid Image Type for Jpeg format.Please set the 'Image Type' to '256 level gray' or '24bit Color'." },
            {3,"Invalid 'Image Type' for PDF format.Please set the 'Image Type' to 'Black&White' or '256 level gray' or '24bit Color'." },
            {4,"No scanner available.Unable to proceed." },
            {5,"Failed to allocate memory." },
            {6,"The 'Image Type' in the scan setting is invalid." },
            {7,"It is available to use Separation Sheet and Patchcode,only when the Image Type is set Black&White." },
            {8,"Rollers (consumables) almost reach their life expectancy.After replacing the rollers, please execute 'Clear Counter' in User Utility." },
            {9,"Please clean the rollers.After cleaning the rollers, please execute 'Clear Counter' in User Utility." },
            {10,"It is available to use 'Separation Sheet' or 'Patchcode',when the 'Automatic Crop' is not set." },
            {11,"It is available to use 'Separation Sheet' or 'Patchcode',when the 'Deskew' is not set." },
            {12,"Failed to load Common Function library." },
            {13,"Reference Plate(Front) is dirty.Please clean the plate." },
            {14,"Reference Plate(Back) is dirty.Please clean the plate." },
            {15,"Insufficient front light error occurred.The lamp and/or scanning sensor need to be replaced." },
            {16,"Insufficient back light error occurred.The lamp and/or scanning sensor need to be replaced." },
            {17,"'Separation Sheet' and 'Patch Code' cannot be used,when the 'Image Type' is set to 'MultiStream'." },
            {18,"Image sensor cover is dirty.Please clean the image sensor cover." },
            {19,"Image sensor cover is dirty.Please clean the image sensor cover." },
            {20,"Rollers (consumables) almost reach their life expectancy.After replacing the rollers, please clear the 'replace roller' warning withthe operation panel of scanner." },
            {21,"Please clean the rollers.After cleaning the rollers, please clear the 'clean roller' warning by the operation panel of scanner." },
            {22,"No Paper!" },
            {23,"It is available to use 'Separation Sheet' or ' Patchcode',when the 'Margin' is not set." },
            {24,"Scanning section is dirty.Please clean the section." },
            {25,"It is available to use 'Separation Sheet' or 'Patchcode',when the 'Long Paper' is not set." },
            {89,"The below scan settings will be ignored." },
            {160,"The current scanner is not supported." },
            {161,"Library does not initialized!!" },
            {162,"System Error! (PacsAplIF DLL)" },
            {163,"Current scan setting includes invalid setting for current scanner." },
            {164,"Failed to open the INI-file." },
            {165,"Failed to open the INI-file." },
            {166,"Failed to open the INI-file." },
            {167,"Failed to open the INI-file." },
            {168,"Invalid section/key item.(IniFileVer/IniFileType section)" },
            {169,"Invalid function parameter" },
            {170,"Invalid file extension." },
            {171,"Current scanner does not support User control sheet." },
            {512,"Failed to open the file." },
            {513,"Failed to create a new file."}
        };
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dataNbr"></param>
        /// <param name="fileInfo"></param>
        /// <param name="imageName"></param>
        /// <param name="userID"></param>
        /// <param name="remark"></param>
        /// <param name="nums"></param>
        /// <returns></returns>
        public string UploadImage(string url, string dataNbr, string fileInfo, string imageName, string userID, string remark, string nums)
        {
            using (var client = new HttpClient())
            {
                var request = new MultipartFormDataContent();
                var fileStream = new FileStream(fileInfo, FileMode.Open, FileAccess.Read);
                request.Add(new StringContent(dataNbr), "dataNbr");
                request.Add(new StringContent(userID), "userID");
                request.Add(new StringContent(imageName), "imageName");
                request.Add(new StringContent(""), "remark");
                request.Add(new StringContent(nums), "num");
                request.Add(new StreamContent(fileStream, (int)fileStream.Length), "file", imageName);
                var result = client.PostAsync(url, request).Result;
                try
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var res = result.Content.ReadAsStringAsync().Result;
                        return res;
                    }
                    return "{\"success\":false,\"info\":\"上传接口异常\"}";
                }
                catch (Exception ex)
                {
                    _logger.Info("上传影像(NewUploadImage)异常:" + ex.ToString());
                    return "{\"success\":false}";
                }
            }
        }
    }
}
