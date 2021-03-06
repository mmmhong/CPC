﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLC.CPC.IService
{
    public interface IMigration
    {
        /// <summary>
        /// 监听消息队列，获取已完成的患者ID
        /// </summary>
        /// <returns></returns>
        bool DoMigration();
        
        /// <summary>
        /// 根据ID号转移数据
        /// </summary>
        /// <param name="id"></param>
        void MirgrationById(string id);

        void test();
    }
}
