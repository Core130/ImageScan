using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
namespace ImageScann.BLL
{
    /// <summary>
    /// 奥普斯凯扫描仪
    /// </summary>
    public class OpskyBillOcrEngine
    {
        private const string DLLName = @"OPSKY_Dll\billOcr.dll";
        private bool bIsInit = false;
        [DllImport(DLLName, EntryPoint = "InitRecogForm", CharSet = CharSet.Unicode)]
        public static extern int pInitRecogForm(string strUserID, string DllPath = null);
        [DllImport(DLLName, EntryPoint = "LoadTemplates", CharSet = CharSet.Unicode)]
        public static extern int pLoadTemplates(string strTemplate);
        [DllImport(DLLName, EntryPoint = "SetFormTypes", CharSet = CharSet.Unicode)]
        public static extern int pSetFormTypes(int[] TypeArray, int ArraySize);
        [DllImport(DLLName, EntryPoint = "LoadImages", CharSet = CharSet.Unicode)]
        public static extern int pLoadImages(string strImgName);
        [DllImport(DLLName, EntryPoint = "RecognizeForm", CharSet = CharSet.Unicode)]
        public static extern int pRecognizeForm(out int nCellCount, out int nTemplateType);
        [DllImport(DLLName, EntryPoint = "RecogUserDefinedForm", CharSet = CharSet.Unicode)]
        public static extern int pRecogUserDefinedForm(string strImgName, string strModName, out int nCellCount);
        [DllImport(DLLName, EntryPoint = "RecogBuildInForm", CharSet = CharSet.Unicode)]
        public static extern int pRecogBuildInForm(string strImgName, int nModID, out int nCellCount);
        [DllImport(DLLName, EntryPoint = "UninitRecogForm", CharSet = CharSet.Unicode)]
        public static extern int pUninitRecogForm();
        [DllImport(DLLName, EntryPoint = "GetRecognizeResult", CharSet = CharSet.Unicode)]
        public static extern int pGetRecognizeResult(int nFieldIndex, char[] strBuffer, out int nBufferLen);
        [DllImport(DLLName, EntryPoint = "GetFieldName", CharSet = CharSet.Unicode)]
        public static extern int pGetFieldName(int nFieldIndex, char[] strBuffer, out int nBufferLen);
        [DllImport(DLLName, EntryPoint = "GetCellPos", CharSet = CharSet.Unicode)]
        public static extern int pGetCellPos(int nFieldIndex, out int nLeft, out int nTop, out int nRight, out int nBottom);
        [DllImport(DLLName, EntryPoint = "GetCellType", CharSet = CharSet.Unicode)]
        public static extern int pGetCellType(int nFieldIndex, out int nFontType);
        [DllImport(DLLName, EntryPoint = "GetCharInfo", CharSet = CharSet.Unicode)]
        public static extern int pGetCharInfo(int nFieldIndex, int nCharIndex, out int nLeft, out int nTop, out int nRight,
                                                out int nBottom, out int[] SimWord, out int[] SimDist);
        [DllImport(DLLName, EntryPoint = "GetTemplateName", CharSet = CharSet.Unicode)]
        public static extern int pGetTemplateName(out string strBuffer, out int nBufferLen);
        [DllImport(DLLName, EntryPoint = "GetTemplateCode", CharSet = CharSet.Unicode)]
        public static extern int pGetTemplateCode(out string strBuffer, out int nBufferLen);
        [DllImport(DLLName, EntryPoint = "GetResultByTxt", CharSet = CharSet.Unicode)]
        public static extern int pGetResultByTxt(string strFileName);
        [DllImport(DLLName, EntryPoint = "GetResultByXml", CharSet = CharSet.Unicode)]
        public static extern int pGetResultByXml(string strFileName);
        [DllImport(DLLName, EntryPoint = "AcquireNewImage", CharSet = CharSet.Unicode)]
        public static extern int pAcquireNewImage(string strImgName);
        [DllImport(DLLName, EntryPoint = "AcquireAndRecogImage", CharSet = CharSet.Unicode)]
        public static extern int pAcquireAndRecogImage(string strImgName, out int nCellCount, out int nModID);
        [DllImport(DLLName, EntryPoint = "SetDeviceParams", CharSet = CharSet.Unicode)]
        public static extern int pSetDeviceParams(int nImgColorType, int nRes, int nLeft,
                                                    int nTop, int nRight, int nBottom);
        [DllImport(DLLName, EntryPoint = "SetDeviceAdvancedParams", CharSet = CharSet.Unicode)]
        public static extern int pSetDeviceAdvancedParams(int nParaType, int nParaValue);
        [DllImport(DLLName, EntryPoint = "IsHavePaper", CharSet = CharSet.Unicode)]
        public static extern bool pIsHavePaper();
        [DllImport(DLLName, EntryPoint = "IfHavePaper", CharSet = CharSet.Unicode)]
        public static extern bool pIfHavePaper();
        [DllImport(DLLName, EntryPoint = "UpLoadFileToServer", CharSet = CharSet.Unicode)]
        public static extern int pUpLoadFileToServer(string strServerAdd, string strFileName);
        [DllImport(DLLName, EntryPoint = "DeleteLocalFile", CharSet = CharSet.Unicode)]
        public static extern int pDeleteLocalFile(string strLocalFile);

        [DllImport(DLLName, EntryPoint = "RecognizeBarcode", CharSet = CharSet.Unicode)]             //2014.7.23 xbq add
        public static extern int pRecognizeBarcode(int nBarcodeType, out int nCellCount);

        [DllImport(DLLName, EntryPoint = "GetErroInformation", CharSet = CharSet.Unicode)]             //2014.7.24 xbq add
        public static extern int pGetErroInformation(int erroID, char[] lpBuffer, out int nBufferLen);

        [DllImport(DLLName, EntryPoint = "GetTemplateGrade", CharSet = CharSet.Unicode)]             //2014.7.24 xbq add
        public static extern int pGetTemplateGrade(string lpModPath, out int IsMulti_Mod);

        [DllImport(DLLName, EntryPoint = "GetFieldNameEx", CharSet = CharSet.Unicode)]             //2014.7.24 xbq add
        public static extern int pGetFieldNameEx(char[] lpFiledName);

        //GetScannerSerialNumber
        [DllImport(DLLName, EntryPoint = "GetScannerSerialNumber", CharSet = CharSet.Unicode)]
        public static extern int pGetScannerSerialNumber(char[] lpSN);

        [DllImport(DLLName, EntryPoint = "SetERPBill", CharSet = CharSet.Unicode)]
        public static extern int pSetERPBill(bool bSetERPBill);

        [DllImport(DLLName, EntryPoint = "SetRecBankStateMent", CharSet = CharSet.Unicode)]
        public static extern int pSetRecBankStateMent(bool bBankStateMent);

        [DllImport(DLLName, EntryPoint = "VerInvoice", CharSet = CharSet.Unicode)]
        public static extern int pVerInvoice(string lpKey, string lpSecret, string lpInvoiceCode, string lpInvoiceNumber, string lpBillingDate,
                        string lpTotalAmount, string lpCheckCode);

        ~OpskyBillOcrEngine()
        {
            if (bIsInit)
            {
                UninitRecogForm();
            }
        }

        public int InitForm(string strUserID)
        {
            int initCode = -1;
            initCode = pInitRecogForm(strUserID, null);
            if (0 != initCode)
            {
                return initCode;
            }
            bIsInit = true;
            return initCode;
        }
        public int LoadTemplate(string strTemplateName)
        {
            return pLoadTemplates(strTemplateName);
        }
        public int SetFormTypes(int[] TypeArray, int nTypeSize)
        {
            return pSetFormTypes(TypeArray, nTypeSize);
        }
        public int LoadImage(string strImgName)
        {
            return pLoadImages(strImgName);
        }
        public int RecognizeForm(out int nCellCount, out int nTemplateType)
        {
            return pRecognizeForm(out nCellCount, out nTemplateType);
        }
        public int RecogUserDefinedForm(string strImgName, string strModName, out int nCellCount)
        {
            return pRecogUserDefinedForm(strImgName, strModName, out nCellCount);
        }
        public int RecogBuildInForm(string strImgName, int nModID, out int nCellCount)
        {
            return pRecogBuildInForm(strImgName, nModID, out nCellCount);
        }
        public int UninitRecogForm()
        {
            return pUninitRecogForm();
        }
        public int GetRecognizeResult(int nFieldIndex, char[] strBuffer, out int nBufferLen)
        {
            return pGetRecognizeResult(nFieldIndex, strBuffer, out nBufferLen);
        }
        public int GetFieldName(int nFieldIndex, char[] strBuffer, out int nBufferLen)
        {
            return pGetFieldName(nFieldIndex, strBuffer, out nBufferLen);
        }
        public int GetCellPos(int nFieldIndex, out int nLeft, out int nTop, out int nRight, out int nBottom)
        {
            return pGetCellPos(nFieldIndex, out nLeft, out nTop, out nRight, out nBottom);
        }
        public int GetCellType(int nFieldIndex, out int nFontType)
        {
            return pGetCellType(nFieldIndex, out nFontType);
        }
        public int GetCharInfo(int nFieldIndex, int nCharIndex, out int nLeft, out int nTop, out int nRight,
                                                out int nBottom, out int[] SimWord, out int[] SimDist)
        {
            return pGetCharInfo(nFieldIndex, nCharIndex, out nLeft, out nTop,
                                   out nRight, out nBottom, out SimWord, out SimDist);
        }
        public int GetTemplateName(out string strBuffer, out int nBufferLen)
        {
            return pGetTemplateName(out strBuffer, out nBufferLen);
        }
        public int GetTemplateCode(out string strBuffer, out int nBufferLen)
        {
            return pGetTemplateCode(out strBuffer, out nBufferLen);
        }
        public int GetResultByTxt(string strFileName)
        {
            return pGetResultByTxt(strFileName);
        }
        public int GetResultByXml(string strFileName)
        {
            return pGetResultByXml(strFileName);
        }
        public int AcquireNewImage(string strImgName)
        {
            return pAcquireNewImage(strImgName);
        }
        public int AcquireAndRecogImage(string strImgName, out int nCellCount, out int nModID)
        {
            return pAcquireAndRecogImage(strImgName, out nCellCount, out nModID);
        }
        public int SetDeviceParams(int nImgColorType, int nRes, int nLeft,
                                      int nTop, int nRight, int nBottom)
        {
            return pSetDeviceParams(nImgColorType, nRes, nLeft, nTop, nRight, nBottom);
        }
        public int SetDeviceAdvancedParams(int nParaType, int nParaValue)
        {
            return pSetDeviceAdvancedParams(nParaType, nParaValue);
        }
        public bool IsHavePaper()
        {
            return pIsHavePaper();
        }
        public bool IfHavePaper()
        {
            return pIfHavePaper();
        }
        public int UpLoadFileToServer(string strServerAdd, string strFileName)
        {
            return pUpLoadFileToServer(strServerAdd, strFileName);
        }
        public int DeleteLocalFile(string strLocalFile)
        {
            return pDeleteLocalFile(strLocalFile);
        }

        public int RecognizeBarcode(int nBarcodeType, out int nCellCount)
        {
            return pRecognizeBarcode(nBarcodeType, out nCellCount);
        }

        public int GetFieldNameEx(char[] lpFiledName)
        {
            return pGetFieldNameEx(lpFiledName);
        }

        public int GetTemplateGrade(string lpModPath, out int IsMulti_Mod)
        {
            return pGetTemplateGrade(lpModPath, out IsMulti_Mod);
        }
        public int GetScannerSerialNumber(char[] lpSN)
        {
            return pGetScannerSerialNumber(lpSN);
        }
        public int SetERPBill(bool bSetERPBill)
        {
            return pSetERPBill(bSetERPBill);
        }
        public int SetRecBankStateMent(bool bBankStateMent)
        {
            return pSetRecBankStateMent(bBankStateMent);
        }
        public int VerInvoice(string lpKey, string lpSecret, string lpInvoiceCode, string lpInvoiceNumber, string lpBillingDate, string lpTotalAmount, string lpCheckCode)
        {
            return pVerInvoice(lpKey, lpSecret, lpInvoiceCode, lpInvoiceNumber, lpBillingDate, lpTotalAmount, lpCheckCode);
        }
        public int GetErroInformation(int erroID, char[] lpBuffer, out int nBufferLen)
        {
            return pGetErroInformation(erroID, lpBuffer, out nBufferLen);
        }
    }
}
