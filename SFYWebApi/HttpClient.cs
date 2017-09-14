 
using System;  
using System.Collections.Generic;  
using System.Text;  
using System.Net;

namespace SFYWebApi
{
    /// <summary>  
    /// �̳�WebClient��  
    /// �ṩ�� URI ��ʶ����Դ�������ݺʹ� URI ��ʶ����Դ�������ݵĹ�������  
    /// ֧���� http:��https:��ftp:���� file: ������ʶ����ͷ�� URI  
    /// </summary>  
    public class HttpClient : WebClient
    {
        #region Զ��POST���ݲ���������
        /// <summary>  
        /// ����WebClient Զ��POST���ݲ���������  
        /// </summary>  
        /// <param name="strUrl">Զ��URL��ַ</param>  
        /// <param name="strParams">����</param>  
        /// <param name="RespEncode">POST���ݵı���</param>  
        /// <param name="ReqEncode">��ȡ���ݵı���</param>  
        /// <returns></returns>  
        public static string PostData(string strUrl, string strParams, Encoding RespEncode, Encoding ReqEncode)
        {
            HttpClient httpclient = new HttpClient();
            try
            {
                //��ҳ��  
                httpclient.Credentials = CredentialCache.DefaultCredentials;
                //��ָ����URI������Դ  
                byte[] responseData = httpclient.DownloadData(strUrl);
                string srcString = RespEncode.GetString(responseData);

                httpclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                string postString = strParams;
                // ���ַ���ת�����ֽ�����  
                byte[] postData = Encoding.ASCII.GetBytes(postString);
                // �ϴ����ݣ�����ҳ����ֽ�����  
                responseData = httpclient.UploadData(strUrl, "POST", postData);
                srcString = ReqEncode.GetString(responseData);

                return srcString;
            }
            catch (Exception ex)
            {
                //��¼�쳣��־  
                //�ͷ���Դ  
                httpclient.Dispose();
                return string.Empty;
            }
        }

        #endregion


        /// <summary>  
        /// ����WebClient Զ��POST XML���ݲ���������  
        /// </summary>  
        /// <param name="strUrl">Զ��URL��ַ</param>  
        /// <param name="strParams">����</param>  
        /// <param name="RespEncode">POST���ݵı���</param>  
        /// <param name="ReqEncode">��ȡ���ݵı���</param>  
        /// <returns></returns>  
        public static string PostXmlData(string strUrl, string strParams, Encoding RespEncode, Encoding ReqEncode)
        {
            HttpClient httpclient = new HttpClient();
            try
            {
                //��ҳ��  
                httpclient.Credentials = CredentialCache.DefaultCredentials;
                //��ָ����URI������Դ  
                byte[] responseData = httpclient.DownloadData(strUrl);
                string srcString = RespEncode.GetString(responseData);

                httpclient.Headers.Add("Content-Type", "text/xml");
                string postString = strParams;
                // ���ַ���ת�����ֽ�����  
                byte[] postData = Encoding.ASCII.GetBytes(postString);
                // �ϴ����ݣ�����ҳ����ֽ�����  
                responseData = httpclient.UploadData(strUrl, "POST", postData);
                srcString = ReqEncode.GetString(responseData);

                return srcString;
            }
            catch (Exception ex)
            {
                //��¼�쳣��־  
                //�ͷ���Դ  
                httpclient.Dispose();
                return string.Empty;
            }
        }
    }
}
 
  
