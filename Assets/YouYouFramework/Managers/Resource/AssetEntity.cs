﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYouFramework
{
    /// <summary>
    /// 资源信息实体
    /// </summary>
    public class AssetEntity
    {
        /// <summary>
        /// 资源分类
        /// </summary>
        public AssetCategory Category;

        /// <summary>
        /// 资源名称
        /// </summary>
        public string AssetName;

        /// <summary>
        /// 资源完整名称
        /// </summary>
        public string AssetFullName;

        /// <summary>
        /// 所依赖的资源包
        /// </summary>
        public string AssetBundleName;

        /// <summary>
        /// 依赖资源
        /// </summary>
        public List<AssetDependsEntity> DependsAssetList;
    }
}
