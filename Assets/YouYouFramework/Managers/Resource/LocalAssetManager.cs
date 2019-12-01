using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace YouYouFramework
{
    /// <summary>
    /// ��д��������
    /// </summary>
    public class LocalAssetManager
    {
        public string LocalVersionFilePath
        {
            get { return string.Format("{0}/{1}",Application.persistentDataPath, ConstDefine.VersionFileName); }
        }

        /// <summary>
        /// ��ȡ��д���汾�ļ��Ƿ����
        /// </summary>
        /// <returns></returns>
        public bool GetVersionFileExists()
        {
            return File.Exists(LocalVersionFilePath);
        }

        /// <summary>
        /// ��ȡ�����ļ��ֽ�����
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] GetFileBuffer(string path)
        {
            return IOUtil.GetFileBuffer(string.Format("{0}/{1}",Application.persistentDataPath, path));
        }

        /// <summary>
        /// ������Դ�汾��
        /// </summary>
        /// <param name="version"></param>
        public void SetResourceVersion(string version)
        {
            PlayerPrefs.SetString(ConstDefine.ResourceVersion, version);
        }

        /// <summary>
        /// ����汾�ļ�
        /// </summary>
        /// <param name="m_LocalAssetsVersionDic"></param>
        public void SaveVersionFile(Dictionary<string, AssetBundleInfoEntity> dic)
        {
            string json = JsonMapper.ToJson(dic);
            IOUtil.CreateTextFile(LocalVersionFilePath, json);
        }

        /// <summary>
        /// ���ؿ�д����Դ����Ϣ
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public Dictionary<string, AssetBundleInfoEntity> GetAssetBundleVersionList(ref string version)
        {
            version = PlayerPrefs.GetString(ConstDefine.ResourceVersion);
            string json = IOUtil.GetFileText(LocalVersionFilePath);
            return JsonMapper.ToObject<Dictionary<string, AssetBundleInfoEntity>>(json);
        }
    }
}
