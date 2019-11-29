using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YouYouFramework
{
    /// <summary>
    /// ��־����
    /// </summary>
    public enum LogCategory
    {
        /// <summary>
        /// ��ͨ��־
        /// </summary>
        Normal,

        /// <summary>
        /// ������־
        /// </summary>
        Procedure,

        /// <summary>
        /// ��Դ��־
        /// </summary>
        Resource,

        /// <summary>
        /// Э����־
        /// </summary>
        Proto
    }

    /// <summary>
    /// ��Դ����
    /// </summary>
    public enum AssetCategory
    {
        /// <summary>
        /// ����
        /// </summary>
        Audio,
        /// <summary>
        /// �Զ���shader
        /// </summary>
        CusShaders,
        /// <summary>
        /// ���
        /// </summary>
        DataTable,
        /// <summary>
        /// ��Ч��Դ
        /// </summary>
        EffectSources,
        /// <summary>
        /// ��ɫ��ЧԤ��
        /// </summary>
        RoleEffectPrefab,
        /// <summary>
        /// UI��ЧԤ��
        /// </summary>
        UIEffectPrefab,
        /// <summary>
        /// ��ɫԤ��
        /// </summary>
        RolePrefab,
        /// <summary>
        /// ��ɫ��Դ
        /// </summary>
        RoleSources,
        /// <summary>
        /// ����
        /// </summary>
        Scenes,
        /// <summary>
        /// ����
        /// </summary>
        UIFont,
        /// <summary>
        /// UIԤ��
        /// </summary>
        UIPrefab,
        /// <summary>
        /// UI��Դ
        /// </summary>
        UIRes,
        /// <summary>
        /// Lua�ű�
        /// </summary>
        xLuaLogic
    }
}
