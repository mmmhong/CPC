﻿namespace NLC.CPC.IService
{
    public interface IDownload
    {
        /// <summary>
        /// 下载患者列表
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="connStr"></param>
        /// <returns></returns>
        void downloadPatient();

        /// <summary>
        /// 下载患者病历
        /// </summary>
        /// <returns></returns>
        void downloadRecord();

        /// <summary>
        /// 将患者病历下载存储为字典
        /// </summary>
        void downloadDataToDictionary();
    }
}
