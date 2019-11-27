using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������
/// </summary>
public class ChannelConfigEntity {
    /// <summary>
    /// ������
    /// </summary>
    public short ChannelId;

    /// <summary>
    /// �ڲ��汾��
    /// </summary>
    public short InnerVersion;

    /// <summary>
    /// ������ʱ��
    /// </summary>
    public long ServerTime;

    /// <summary>
    /// ��Դ�汾��
    /// </summary>
    public string SourceVersion;

    /// <summary>
    /// ��Դ��ַ
    /// </summary>
    public string SourceUrl;

    /// <summary>
    /// ��ֵ��ַ
    /// </summary>
    public string RechargeUrl;

    /// <summary>
    /// TDAppId
    /// </summary>
    public string TDAppId;

    /// <summary>
    /// �Ƿ���ͳ��
    /// </summary>
    public bool IsOpenTD;

    /// <summary>
    /// ��ֵ���������
    /// </summary>
    public short PayServerNo;

    private string m_RealSourceUrl;
    /// <summary>
    /// ��ʵ��Դ��ַ
    /// </summary>
    public string RealSourceUrl
    {
        get
        {
            if (string.IsNullOrEmpty(m_RealSourceUrl))
            {
                string buildTarget = string.Empty;
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
                buildTarget = "Windows";
#elif UNITY_ANDROID
                buildTarget = "Android";
#elif UNITY_IPHONE
                buildTarget = "iOS";
#endif
                m_RealSourceUrl = string.Format("{0}{1}/{2}/",SourceUrl,SourceVersion,buildTarget);
            }
            return m_RealSourceUrl;
        }
    }
}
