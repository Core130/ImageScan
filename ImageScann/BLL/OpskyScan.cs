using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageScann.BLL
{
    public class OpskyScan
    {
        private OpskyBillOcrEngine billOcr = new OpskyBillOcrEngine();
        private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 启动扫描仪
        /// </summary>
        /// <returns></returns>
        public bool InitOpSkyScan(frmIndex frm,out string msg)
        {
            string strUserID = System.Configuration.ConfigurationManager.AppSettings["OpSky_UserId"];
            int recode = billOcr.InitForm(strUserID);
            if (0 != recode)
            {
                int nErroLength;
                char[] erroBuffer = new char[256];
                billOcr.GetErroInformation(recode, erroBuffer, out nErroLength);
                msg = new string(erroBuffer);
                return false;
            }
            else
            {
                msg = "启动成功";
                return true;
            }
        }

        /// <summary>
        /// 奥普斯凯扫描
        /// </summary>
        public string Scan(frmIndex frm)
        {            
            try
            {
                string tpImgName = "";
                int index = 0;
                string strIndex = "";
                string tmp_ImagePath = AppDomain.CurrentDomain.BaseDirectory + @"\images\";
                if (!Directory.Exists(tmp_ImagePath)) Directory.CreateDirectory(tmp_ImagePath);
                while (true)
                {
                    strIndex = "";
                    strIndex = string.Format("{0:D4}", index);
                    tpImgName = tmp_ImagePath + strIndex + ".jpg";
                    if (!File.Exists(tpImgName))
                        break;
                    index++;
                }
                bool isHavePaper = true;
                int recode = -1;               
                while (isHavePaper)
                {
                    index++;
                    strIndex = "";
                    strIndex = string.Format("{0:D4}", index);
                    tpImgName = tmp_ImagePath + strIndex + ".jpg";
                    recode = billOcr.AcquireNewImage(tpImgName);
                    if (recode == 0)
                    {
                        frm.ScanBarCode(tpImgName);
                    }
                    isHavePaper = billOcr.IsHavePaper();
                }
                return "1";
            }
            catch (Exception ex)
            {
                _logger.Info(string.Format("系统异常,{0}!", ex.ToString()));
                return string.Format("系统异常,请重新扫描,{0}!", ex.ToString());
            }           
        }

    }
}
