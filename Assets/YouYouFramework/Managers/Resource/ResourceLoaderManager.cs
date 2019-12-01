using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYouFramework
{
    /// <summary>
    /// ��Դ���ع�����
    /// </summary>
    public class ResourceLoaderManager : ManagerBase, IDisposable
    {
        /// <summary>
        /// ��Դ��Ϣ�ֵ�
        /// </summary>
        private Dictionary<AssetCategory, Dictionary<string, AssetEntity>> m_AssetInfoDic;

        public ResourceLoaderManager()
        {
            m_AssetInfoDic = new Dictionary<AssetCategory, Dictionary<string, AssetEntity>>();

            //��Ϸһ��ʼʱ��ʼ�������ֵ�
            var enumerator = Enum.GetValues(typeof(AssetCategory)).GetEnumerator();
            while (enumerator.MoveNext())
            {
                AssetCategory assetCategory = (AssetCategory)enumerator.Current;
                m_AssetInfoDic[assetCategory] = new Dictionary<string, AssetEntity>();
            }
        }

        /// <summary>
        /// ��ʼ����Դ��Ϣ
        /// </summary>
        public void InitAssetInfo()
        {
            byte[] buffer = GameEntry.Resource.ResourceManager.LocalAssetManager.GetFileBuffer(ConstDefine.AssetInfoName);
            if (buffer == null)
            {
                //�����д��û�� ��ô�ʹ�ֻ������ȡ
                GameEntry.Resource.ResourceManager.StreamingAssetsManager.ReadAssetBundle(ConstDefine.AssetInfoName, (byte[] buff) =>
                 {
                     if (buff == null)
                     {
                         //���ֻ����Ҳû�У���CDN��ȡ
                         string url = string.Format("{0}{1}", GameEntry.Data.SysDataManager.CurrChannelConfig.RealSourceUrl, ConstDefine.AssetInfoName);
                         GameEntry.Http.SendData(url, OnLoadAssetInfoFromCDN, isGetData: true);
                     }
                     else
                     {
                         InitAssetInfo(buff);
                     }
                 });
            }
            else
            {
                Debug.Log(3);
                InitAssetInfo(buffer);
            }
        }

        /// <summary>
        /// ��CDN������Դ��Ϣ
        /// </summary>
        /// <param name="args"></param>
        private void OnLoadAssetInfoFromCDN(HttpCallBackArgs args)
        {
            if (!args.HasError)
            {
                InitAssetInfo(args.Data);
            }
            else
            {
                GameEntry.Log(LogCategory.Resource, args.Value);
            }
        }

        /// <summary>
        /// ��ʼ����Դ��Ϣ����ֵ�ֵ�
        /// </summary>
        /// <param name="buffer"></param>
        private void InitAssetInfo(byte[] buffer)
        {
            buffer = ZlibHelper.DeCompressBytes(buffer);

            MMO_MemoryStream ms = new MMO_MemoryStream(buffer);
            int len = ms.ReadInt();
            int depLen = 0;
            for (int i = 0; i < len; i++)
            {
                AssetEntity entity = new AssetEntity();
                entity.Category = (AssetCategory)ms.ReadByte();
                entity.AssetFullName = ms.ReadUTF8String();
                entity.AssetBundleName = ms.ReadUTF8String();
                depLen = ms.ReadInt();
                if (depLen > 0)
                {
                    entity.DependsAssetList = new List<AssetDependsEntity>();
                    for (int j = 0; j < depLen; j++)
                    {
                        AssetDependsEntity dep = new AssetDependsEntity();
                        dep.Category = (AssetCategory)ms.ReadByte();
                        dep.AssetFullName = ms.ReadUTF8String();
                        entity.DependsAssetList.Add(dep);
                    }
                }

                m_AssetInfoDic[entity.Category][entity.AssetFullName] = entity;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
