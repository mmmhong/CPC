using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace 解析患者列表
{
    class Program
    {
        static void Main(string[] args)
        {
            save s = new save();
            s.SaveDate();


            string str2 = string.Empty;
            FileStream fs = new FileStream("D:\\c.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs,Encoding.Default);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string str1 = sr.ReadLine();
            while(str1!=null)
            {
                str2 += str1 + "\n";
                str1 = sr.ReadLine();
            }
            sr.Close();
            fs.Close();



            //string str = "{\"Success\":true,\"Result\":[{\"UNIQUE_ID\":\"2512369\",\"ID\":\"1384d418 - be23 - 48ad - b503 - b7f45517f924\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"谢有生\",\"GENDER\":\"男\",\"AGE_VALUE\":\"57\",\"REGISTER_DATE\":\"2018 / 3 / 6 8:46:00\",\"ATTACK_TIME\":\"2018 - 02 - 24T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"1038490\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 03 - 06 08:51:48 由 胡彬 更新了急救信息；2018 - 03 - 06 08:53:40 由 胡彬 更新了胸痛诊疗信息；2018 - 03 - 06 09:03:34 由 胡彬 更新了患者转归信息；2018 - 03 - 06 09:03:34 由 胡彬 填报完成；\",\"COMING_WAY_CODE\":\"1\",\"FIRST_MC_TIME\":\"2018 - 02 - 24T22: 07:00\",\"VESTING_DATE\":\"2018 - 02 - 24T22: 07:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":0,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2512330\",\"ID\":\"f9efbf8c - a8b3 - 45b1 - 94ef - 37ddd0697b4e\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"王玉兰\",\"GENDER\":\"女\",\"AGE_VALUE\":\"63\",\"REGISTER_DATE\":\"2018 / 3 / 6 8:32:00\",\"ATTACK_TIME\":\"2018 - 02 - 24T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"NSTEMI\",\"INPATIENT_ID\":\"706024\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 03 - 06 08:44:52 由 胡彬 更新了急救信息；2018 - 03 - 06 08:46:13 由 胡彬 更新了胸痛诊疗信息；2018 - 03 - 06 09:02:50 由 胡彬 更新了患者转归信息；2018 - 03 - 06 09:02:50 由 胡彬 填报完成；\",\"COMING_WAY_CODE\":\"1\",\"FIRST_MC_TIME\":\"2018 - 02 - 24T15: 58:00\",\"VESTING_DATE\":\"2018 - 02 - 24T15: 58:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"2\",\"ECG_IMAGE_COUNT\":0,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2512305\",\"ID\":\"ef7f42a6 - 7211 - 4f25 - a4ac - 3318cebaa5ed\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"宋雪海\",\"GENDER\":\"男\",\"AGE_VALUE\":\"36\",\"REGISTER_DATE\":\"2018 / 3 / 6 8:23:00\",\"ATTACK_TIME\":\"2018 - 02 - 26T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"1155312\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 03 - 06 08:29:06 由 胡彬 更新了急救信息；2018 - 03 - 06 08:31:19 由 胡彬 更新了胸痛诊疗信息；2018 - 03 - 06 08:32:35 由 胡彬 更新了急救信息；2018 - 03 - 06 08:32:44 由 胡彬 更新了胸痛诊疗信息；2018 - 03 - 06 09:01:59 由 胡彬 更新了患者转归信息；2018 - 03 - 06 09:01:59 由 胡彬 填报完成；2018 - 03 - 06 09:02:04 由 胡彬 更新了患者转归信息；\",\"COMING_WAY_CODE\":\"3\",\"FIRST_MC_TIME\":\"2018 - 02 - 26T03: 55:00\",\"VESTING_DATE\":\"2018 - 02 - 26T03: 55:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":1,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2512286\",\"ID\":\"f619e3b2 - 5ad4 - 4a05 - 8167 - b44de3d1048c\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"徐殿魁\",\"GENDER\":\"男\",\"AGE_VALUE\":\"84\",\"REGISTER_DATE\":\"2018 / 3 / 6 8:12:00\",\"ATTACK_TIME\":\"2018 - 03 - 04T00: 00:00\",\"STATUS\":\"填报中\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"673107\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 03 - 06 08:22:32 由 胡彬 更新了急救信息；2018 - 03 - 06 08:24:33 由 胡彬 更新了胸痛诊疗信息；2018 - 03 - 06 08:24:40 由 胡彬 更新了胸痛诊疗信息；\",\"COMING_WAY_CODE\":\"3\",\"FIRST_MC_TIME\":\"2018 - 03 - 05T08: 54:00\",\"VESTING_DATE\":\"2018 - 03 - 05T08: 54:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":1,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2512271\",\"ID\":\"af28649d - d971 - 4440 - a880 - 78795c090648\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"徐巧玲\",\"GENDER\":\"女\",\"AGE_VALUE\":\"50\",\"REGISTER_DATE\":\"2018 / 3 / 6 8:00:00\",\"ATTACK_TIME\":\"2018 - 03 - 04T00: 00:00\",\"STATUS\":\"填报中\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"1214539\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 03 - 06 08:12:39 由 胡彬 更新了急救信息；\",\"COMING_WAY_CODE\":\"2\",\"FIRST_MC_TIME\":\"2018 - 03 - 05T08: 16:00\",\"VESTING_DATE\":\"2018 - 03 - 05T08: 16:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":1,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2425217\",\"ID\":\"050e4d96 - 5c3f - 4d4d - b75b - 93deae958dca\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"蒋建奎\",\"GENDER\":\"男\",\"AGE_VALUE\":\"47\",\"REGISTER_DATE\":\"2018 / 2 / 5 13:55:00\",\"ATTACK_TIME\":\"2018 - 02 - 02T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"850700\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 02 - 05 14:12:59 由 胡彬 更新了急救信息；2018 - 02 - 05 14:17:29 由 胡彬 更新了胸痛诊疗信息；2018 - 02 - 05 14:20:55 由 胡彬 更新了胸痛诊疗信息；2018 - 02 - 05 15:14:36 由 胡彬 更新了急救信息；2018 - 03 - 06 09:01:03 由 胡彬 更新了患者转归信息；2018 - 03 - 06 09:01:03 由 胡彬 填报完成；2018 - 03 - 06 09:01:08 由 胡彬 更新了患者转归信息；\",\"COMING_WAY_CODE\":\"3\",\"FIRST_MC_TIME\":\"2018 - 02 - 05T10: 51:00\",\"VESTING_DATE\":\"2018 - 02 - 05T10: 51:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":1,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2425150\",\"ID\":\"180ade3d - 4c9d - 428c - 8f28 - f9d9cb16535d\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"王增生\",\"GENDER\":\"男\",\"AGE_VALUE\":\"64\",\"REGISTER_DATE\":\"2018 / 2 / 5 13:41:00\",\"ATTACK_TIME\":\"2018 - 02 - 03T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"NSTEMI\",\"INPATIENT_ID\":\"669584\",\"HELP_DATE\":\"2018 / 2 / 3 3:50:00\",\"EMERGENCY_LOG\":\"2018 - 02 - 05 13:53:36 由 胡彬 更新了急救信息；2018 - 02 - 05 13:54:13 由 胡彬 更新了胸痛诊疗信息；2018 - 02 - 05 15:15:07 由 胡彬 更新了急救信息；2018 - 03 - 06 09:00:02 由 胡彬 更新了患者转归信息；2018 - 03 - 06 09:00:02 由 胡彬 填报完成；2018 - 03 - 06 09:00:09 由 胡彬 更新了患者转归信息；2018 - 03 - 06 09:04:44 由 胡彬 更新了患者转归信息；2018 - 03 - 06 09:06:25 由 胡彬 更新了患者转归信息；2018 - 03 - 06 09:07:01 由 胡彬 更新了患者转归信息；\",\"COMING_WAY_CODE\":\"1\",\"FIRST_MC_TIME\":\"2018 - 02 - 03T03: 52:00\",\"VESTING_DATE\":\"2018 - 02 - 03T03: 52:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"2\",\"ECG_IMAGE_COUNT\":1,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2372034\",\"ID\":\"92116994 - fb46 - 45ec - 9303 - 1d3f810266da\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"王林水\",\"GENDER\":\"男\",\"AGE_VALUE\":\"65\",\"REGISTER_DATE\":\"2018 / 1 / 29 11:08:00\",\"ATTACK_TIME\":\"2018 - 01 - 27T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"1207975\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 01 - 29 11:17:16 由 胡彬 更新了急救信息；2018 - 01 - 29 11:18:15 由 胡彬 更新了胸痛诊疗信息；2018 - 01 - 29 13:41:59 由 胡彬 更新了胸痛诊疗信息；2018 - 03 - 06 08:59:09 由 胡彬 更新了患者转归信息；2018 - 03 - 06 08:59:09 由 胡彬 填报完成；2018 - 03 - 06 08:59:15 由 胡彬 更新了患者转归信息；\",\"COMING_WAY_CODE\":\"2\",\"FIRST_MC_TIME\":\"2018 - 01 - 27T01: 15:00\",\"VESTING_DATE\":\"2018 - 01 - 27T01: 15:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":0,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2347439\",\"ID\":\"dbe9ebe7 - ed7f - 4922 - aa99 - 0468aa415b64\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"倪士庆\",\"GENDER\":\"男\",\"AGE_VALUE\":\"62\",\"REGISTER_DATE\":\"2018 / 1 / 22 13:59:00\",\"ATTACK_TIME\":\"2018 - 01 - 19T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"1075593\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 01 - 22 14:06:48 由 胡彬 更新了急救信息；2018 - 01 - 22 14:08:27 由 胡彬 更新了胸痛诊疗信息；2018 - 01 - 22 14:08:31 由 胡彬 更新了胸痛诊疗信息；2018 - 01 - 29 13:49:54 由 胡彬 更新了患者转归信息；2018 - 01 - 29 13:49:54 由 胡彬 填报完成；2018 - 01 - 29 13:49:58 由 胡彬 更新了患者转归信息；\",\"COMING_WAY_CODE\":\"2\",\"FIRST_MC_TIME\":\"2018 - 01 - 19T19: 25:00\",\"VESTING_DATE\":\"2018 - 01 - 19T19: 25:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":0,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2322370\",\"ID\":\"ac96f5e8 - ac55 - 4d82 - bd7c - 723818d135ff\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"黎国珊\",\"GENDER\":\"男\",\"AGE_VALUE\":\"82\",\"REGISTER_DATE\":\"2018 / 1 / 15 13:56:00\",\"ATTACK_TIME\":\"2018 - 01 - 13T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"1041920\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 01 - 15 14:06:40 由 胡彬 更新了急救信息；2018 - 01 - 15 14:08:27 由 胡彬 更新了胸痛诊疗信息；2018 - 01 - 29 13:51:04 由 胡彬 更新了患者转归信息；2018 - 01 - 29 13:51:20 由 胡彬 填报完成；\",\"COMING_WAY_CODE\":\"3\",\"FIRST_MC_TIME\":\"2018 - 01 - 13T19: 22:00\",\"VESTING_DATE\":\"2018 - 01 - 13T19: 22:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":1,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"2319455\",\"ID\":\"760cd496 - 1c50 - 47a3 - b35e - 67e0f37a5b3b\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"胡国香\",\"GENDER\":\"女\",\"AGE_VALUE\":\"56\",\"REGISTER_DATE\":\"2018 / 1 / 15 9:23:00\",\"ATTACK_TIME\":\"2018 - 01 - 12T00: 00:00\",\"STATUS\":\"填报完成\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":\"719946\",\"HELP_DATE\":null,\"EMERGENCY_LOG\":\"2018 - 01 - 15 09:43:57 由 胡彬 更新了急救信息；2018 - 01 - 15 13:46:14 由 胡彬 更新了胸痛诊疗信息；2018 - 01 - 29 13:52:44 由 胡彬 更新了患者转归信息；2018 - 01 - 29 13:52:44 由 胡彬 填报完成；\",\"COMING_WAY_CODE\":\"3\",\"FIRST_MC_TIME\":\"2018 - 01 - 12T17: 04:00\",\"VESTING_DATE\":\"2018 - 01 - 12T17: 04:00\",\"IS_PROBLEM\":false,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":1,\"PROBLEM_REASON\":\"\"},{\"UNIQUE_ID\":\"T2303109\",\"ID\":\"d79692db - 8638 - 4d60 - 9f2c - 8cea83858a6a\",\"HOSPITAL_ID\":\"837af969 - 8f84 - 423d - a5ef - bb4c28d9d354\",\"NAME\":\"测2\",\"GENDER\":\"女\",\"AGE_VALUE\":\"55\",\"REGISTER_DATE\":\"2018 / 1 / 5 17:59:00\",\"ATTACK_TIME\":\"2018 - 01 - 05T12: 59:00\",\"STATUS\":\"填报中\",\"CP_DIAGNOSIS_CODE\":\"STEMI\",\"INPATIENT_ID\":null,\"HELP_DATE\":\"2018 / 1 / 5 13:10:00\",\"EMERGENCY_LOG\":\"2018 - 01 - 09 19:06:27 由 API更新2018-01 - 26 11:58:57 由 钟泽 更新了急救信息；2018 - 01 - 29 10:15:02 由 7017 更新了急救信息；2018 - 01 - 29 10:33:42 由 7017 更新了急救信息；2018 - 01 - 29 14:26:32 由 钟泽 更新了急救信息；2018 - 02 - 02 19:23:32 由 7017 更新了急救信息；2018 - 02 - 02 19:51:17 由 7017 更新了急救信息；2018 - 02 - 08 14:37:59 由 7017 更新了急救信息；2018 - 02 - 08 16:55:05 由 钟泽 更新了急救信息；2018 - 02 - 11 18:41:09 由 7017 更新了急救信息；\",\"COMING_WAY_CODE\":\"1\",\"FIRST_MC_TIME\":\"2018 - 01 - 05T14: 48:00\",\"VESTING_DATE\":\"2018 - 01 - 05T14: 48:00\",\"IS_PROBLEM\":true,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"ECG_IMAGE_COUNT\":3,\"PROBLEM_REASON\":\"标准版: FMC2ECG 超过60分钟；基层版FMC2ECG 超过60分钟；生命体征中“呼吸”大于40；生命体征中“脉搏”大于150\"}],\"TotalCount\":114,\"ErrorMessage\":null}";

            List<string> list = GetAllPatientId(str2);

            string strPat = "{ \"Success\":true,\"Result\":{ \"Regmodel\":{ \"UNIQUE_ID\":\"2512369\",\"ID\":\"1384d418-be23-48ad-b503-b7f45517f924\",\"HOSPITAL_ID\":\"837af969-8f84-423d-a5ef-bb4c28d9d354\",\"CITIZEN_CARD\":null,\"IDCARD\":\"330182196107260050\",\"NAME\":\"谢有生\",\"GENDER\":\"1\",\"AGE_VALUE\":\"57\",\"AGE_UNIT\":null,\"CONTACT_PHONE\":\"18072903302\",\"OUTPATIENT_ID\":\"1038490\",\"INPATIENT_ID\":\"1038490\",\"ATTACK_ADDRESS\":\"叶家社区王家村32号\",\"ATTACK_TIME\":\"2018-02-24 00:00\",\"ATTACK_ZONE\":\"19到24点\",\"IS_NULL_ATTACK_DETAIL_TIME\":true,\"IS_HELP\":false,\"IS_PERSISTENT\":true,\"IS_INTERMITTENT\":false,\"IS_LAXATION\":false,\"IS_BELLYACHE\":false,\"IS_DYSPNEA\":false,\"IS_SHOCK\":false,\"IS_HEART_ATTACK\":false,\"IS_MALIGNANT_ARRHYTHMIA\":false,\"IS_CPR\":false,\"IS_OTHER\":false,\"IS_HEMORRHAGE\":false,\"COMING_WAY_CODE\":\"1\",\"CP_DIAGNOSIS_CODE\":\"2\",\"CREATE_ACCOUNT\":\"胡彬\",\"CREATE_NAME\":\"胡彬\",\"CREATE_DATE\":\"2018-03-06 08:47\",\"UPDATE_NAME\":null,\"UPDATE_DATE\":\"2018-03-06 08:51\",\"STATUS\":\"11\",\"REGISTER_DATE\":\"2018-03-06 08:46\",\"IS_DELETE\":\"1\",\"HELP_DATE\":null,\"HELP_CODE\":null,\"EHR_ID\":null,\"IS_SOURCE\":null,\"VESTING_DATE\":\"2018-02-24 22:07\",\"IS_PROBLEM\":false,\"PROBLEM_REASON\":\"\",\"CPCID\":null,\"IN_REG_INTERVAL\":226.65,\"LEAVE_GD_INTERVAL\":null},\"EmergenModel\":{ \"ID\":\"e5a5e03c-98ad-41d1-b10d-84343eae610a\",\"REGISTER_ID\":\"1384d418-be23-48ad-b503-b7f45517f924\",\"DISPATCH_UNIT_CODE\":\"2\",\"DISPATCH_UNIT_NAME\":null,\"IS_BYPASS_EMERGENCY\":\"2\",\"BYPASS_EMERGENCY_CODE\":null,\"ARRIVED_EMERGENCY_TIME\":\"2018-02-24 22:07\",\"IS_BYPASS_CCU\":\"1\",\"ARRIVED_CCU_DATE\":null,\"IS_NETWORD_HOSPITAL\":false,\"HOSPITAL_NAME\":null,\"DEPARTMENT\":null,\"OUTHOSPITAL_VISIT_TIME\":null,\"TRANSFER_TIME\":null,\"AMBULANCE_ARRIVED_TIME\":null,\"LEAVE_OUTHOSPITAL_TIME\":null,\"ARRIVED_SCENE_TIME\":\"2018-02-24 21:30\",\"ARRIVED_HOSPITAL_TIME\":\"2018-02-24 22:07\",\"INHOSPITAL_ADMISSION_TIME\":\"2018-02-24 22:07\",\"ATTACK_DEPARTMENT\":null,\"CONSULTATION_TIME\":null,\"LEAVE_DEPARTMENT_TIME\":null,\"FIRST_MC_CODE\":\"3\",\"FIRST_MC_NAME\":null,\"FIRST_DOCTOR_NAME\":\"罗科峰\",\"FIRST_MC_TIME\":\"2018-02-24 22:07\",\"PHEP_ECG_TIME\":null,\"INHOSPITAL_ECG_TIME\":\"2018-02-24 22:12\",\"ECG_DIAGNOSE_TIME\":\"2018-02-24 22:13\",\"IS_REMOTE_ECGTRAN\":\"2\",\"CONSCIOUSNESS_TYPE\":\"清醒\",\"RESPIRATION_RATE\":\"20\",\"PULSE_RATE\":null,\"HEART_RATE\":\"59\",\"BLOOD_PRESSURE\":\"97/68\",\"KILLIP_LEVEL\":\"2\",\"SAMPLING_TIME\":\"2018-02-24 22:07\",\"REPORT_TIME\":\"2018-02-24 22:34\",\"CTNI_VALUE\":\"小于40\",\"CTNI_STATUS\":null,\"CTNT_STATUS\":null,\"CR_VALUE\":\"72.8\",\"CP_DIAGNOSIS_CODE\":\"2\",\"DIAGNOSIS_TIME\":\"2018-02-24 22:13\",\"DIAGNOSIS_DOCTOR_NAME\":\"胡彬\",\"ARRHYTHMIA\":false,\"DCM\":false,\"ICM\":false,\"HCM\":false,\"CARDITIS\":false,\"CHD\":false,\"AVHD\":false,\"OMI\":false,\"AP\":false,\"PALPITATE\":false,\"AF\":false,\"HYPERTENSION\":false,\"HF\":false,\"ATRIALFLUTTER\":false,\"VPC\":false,\"APB\":false,\"ST\":false,\"ACS_DELIVERY_TIME\":\"2018-02-24 22:14\",\"ASPIRIN_DOSE\":\"300\",\"ACS_DRUG_TYPE\":\"1\",\"ACS_DRUG_DOSE\":\"300\",\"IS_THROMBOLYSIS\":\"0\",\"THROMBOLYSIS_TYPE\":null,\"START_AGREE_TIME\":null,\"SIGN_AGREE_TIME\":null,\"THROM_START_TIME\":null,\"THROM_END_TIME\":null,\"THROM_DRUG_TYPE\":null,\"THROM_DRUG_CODE\":null,\"IS_REPATENCY\":null,\"THROM_RESULT_DESC\":null,\"IS_ARREST\":false,\"IS_CHANGE\":false,\"IS_RISE\":false,\"GRACE_VALUE\":0.0,\"RISK_LAMINATION\":null,\"DIAGNOSIS_DESC\":null,\"OUTCOME_DESC\":null,\"PATIENT_CASE_NOTE\":null,\"CREATE_ACCOUNT\":\"胡彬\",\"CREATE_NAME\":\"胡彬\",\"CREATE_DATE\":\"2018-03-06 08:51\",\"UPDATE_NAME\":null,\"UPDATE_DATE\":null,\"PHEP_FILE_NAME\":null,\"IN_FILE_NAME\":null,\"TRAN_DATE\":\"2018-02-24 22:13\",\"CP_DIAGNOSIS_NAME\":null,\"BYPASS_EMERGENCY_LEAVE_TIME\":\"2018-02-24 22:43\",\"KILLIP_UNIT\":null,\"HANDLE_TIME\":null,\"PATIENT_OUTCOME\":null,\"DOCTOR_NAME\":null,\"IS_ANTICOAGULATION\":\"2\",\"SCREENING\":\"0\",\"IS_DIRECT\":null,\"EMERGENCY_LOG\":\"2018-03-06 08:51:48 由 胡彬 更新了急救信息；2018-03-06 08:53:40 由 胡彬 更新了胸痛诊疗信息；2018-03-06 09:03:34 由 胡彬 更新了患者转归信息；2018-03-06 09:03:34 由 胡彬 填报完成；\",\"CTNI_UNIT\":\"1\",\"CR_UNIT\":\"1\",\"THROM_TREATMENT_PLACE\":null,\"HANDLE_WAY\":null,\"PHEP_ECG_IMAGE_BASE64\":null,\"IS_REMOTE_ECGTRAN_CHECKED\":\"1\",\"INHOSPITAL_ECG_IMAGE_BASE64\":null,\"ANTICOAGULATION_DATE\":null,\"ANTICOAGULATION_DRUG\":null,\"ANTICOAGULATION_UNIT\":null,\"RD\":false,\"DSD\":false,\"NSD\":false,\"PD\":false,\"MD\":false,\"SSD\":false,\"OTHER\":false,\"CTNT_UNIT\":null,\"CTNT_VALUE\":null},\"OutModel\":{ \"ID\":null,\"REGISTER_ID\":null,\"CP_DIAGNOSIS_CODE\":null,\"CP_DIAGNOSIS_NAME\":null,\"DIAGNOSIS_TIME\":null,\"IS_HEART_FAILURE\":null,\"HOD\":0.0,\"TOTAL_COST\":0.0,\"OUTCOME_CODE\":null,\"OUTCOME_NAME\":null,\"LEAVE_TIME\":null,\"TREATMENT_RESULT_CODE\":null,\"TREATMENT_RESULT_NAME\":null,\"HAND_TIME\":null,\"HAND_HOSPITAL_NAME\":null,\"DEATH_TIME\":null,\"DEATH_CAUSE_CODE\":null,\"DEATH_CAUSE_DESC\":null,\"REMARK\":null,\"MEDICAL_DESC\":null,\"IS_NET_HOSPITAL\":false,\"IS_TRANS_PCI\":null,\"NO_TRANS_PCI_REASON\":null,\"IS_DIRECT_CATHETER\":null,\"CREATE_ACCOUNT\":null,\"CREATE_NAME\":null,\"CREATE_DATE\":null,\"UPDATE_NAME\":null,\"UPDATE_DATE\":null,\"TRANSFER_DATE\":null,\"ADMISSION_DEPT\":null,\"TRANSFER_REASON\":null,\"OUT_GRUG_DAPT\":false,\"OUT_GRUG_ACEIORARB\":false,\"OUT_DRUG_STATINS\":false,\"OUT_DRUG_RETARDANT\":false},\"DiagTreatModel\":{ \"ID\":null,\"REGISTER_ID\":null,\"CP_DIAGNOSIS_CODE\":null,\"CP_DIAGNOSIS_NAME\":null,\"FIRST_TREATMENT_TIME\":null,\"IS_EMPCI\":false,\"IS_THROMBOLYSIS_DT\":false,\"IS_REPCI\":false,\"IS_TPCI\":false,\"IS_EMRADIOGRAPHY\":false,\"IS_ELPCI\":false,\"IS_ELRADIOGRAPHY\":false,\"IS_CABG\":false,\"IS_NOREPERFUSION\":false,\"IS_REPOTHER\":false,\"OTHER_TREATMENT_MEASURE\":null,\"DOCTOR_NAME\":null,\"INTERVENTION_PERSON\":null,\"DECISION_OPERATION_TIME\":null,\"START_CONDUIT_TIME\":null,\"START_AGREE_TIME\":null,\"SIGN_AGREE_TIME\":null,\"ACTIVATE_CONDUIT_TIME\":null,\"ARRIVE_CONDUIT_TIME\":null,\"START_PUNCTURE_TIME\":null,\"SUCCESS_PUNCTURE_TIME\":null,\"START_RADIOGRAPHY_TIME\":null,\"END_RADIOGRAPHY_TIME\":null,\"AGAIN_SIGN_AGREE_TIME\":null,\"BALLOON_EXPANSION_TIME\":null,\"START_OPERATION_TIME\":null,\"END_OPERATION_TIME\":null,\"DTWOB_TIME\":null,\"IS_DELAY\":false,\"DIAGNOSIS_UNIT_CODE_DT\":null,\"THROM_START_TIME_DT\":null,\"THROM_END_TIME_DT\":null,\"THROM_DRUG_TYPE_DT\":null,\"THROM_DRUG_CODE_DT\":null,\"IS_REPATENCY_DT\":false,\"THROM_RESULT_DESC_DT\":null,\"PREOPERATIVE_TIMI_LEVEL\":null,\"POSTOPERATIVE_TIMI_LEVEL\":null,\"DECISION_CABG_TIME\":null,\"START_CABG_TIME\":null,\"END_CABG_TIME\":null,\"PERFUSION_MEASURE_CODE\":null,\"PERFUSION_MEASURE_DESC\":null,\"CREATE_ACCOUNT\":null,\"CREATE_NAME\":null,\"CREATE_DATE\":null,\"UPDATE_NAME\":null,\"UPDATE_DATE\":null,\"START_INTERVENTION_DATE\":null,\"END_INTERVENTION_DATE\":null,\"DELAY_REASON\":null,\"RISK_LAMINATION\":null,\"SIGN_OPERATE_AGREE_TIME\":null,\"START_OPERATE_AGREE_TIME\":null,\"OPERATION_RESULT\":null,\"STAND_RID_DATE\":null,\"START_TREATE_DATE\":null,\"CCU_INTO_DATE\":null,\"TREATMENT_STRATEGY_CODE\":null,\"INTERLAYER_TYPE\":null,\"ECC_CONSULTATION_DATE\":null,\"IMCD_NOTICE_DATE\":null,\"IMCD_CONSULTATION_DATE\":null,\"CHECK_RESULT_DATE\":null,\"CDU_CHECK_DATE\":null,\"CDU_ARRIVE_DATE\":null,\"IS_CDU\":false,\"CT_REPORT_DATE\":null,\"CT_SCAN_DATE\":null,\"CT_ARRIVE_DATE\":null,\"USER_ARRIVE_DATE\":null,\"CT_FINISH_DATE\":null,\"CT_NOTICE_DATE\":null,\"IS_ECT\":false,\"ANTI_TREATMENT_DATE\":null,\"NSTEMI_TYPE\":null,\"THROM_CHECK\":null,\"INTENSIFY_STATINS_TREAT\":null,\"RECEPTOR_RETARDANT_USING\":null,\"NOTICE_CDU_TIME\":null,\"THROM_START_AGREE_TIME\":null,\"THROM_SIGN_AGREE_TIME\":null,\"TIME_INTERVAL\":null,\"ACTUAL_INTERVENTION_DATE\":null,\"PERFUSION_MEASURE_OTHER\":null,\"IS_DIRECT\":null,\"IS_MRI\":false} },\"TotalCount\":0,\"ErrorMessage\":null}";

            GetInformationByID(list[0], strPat);

            Console.ReadKey();

        }


        /// <summary>
        /// 根据JSON字符串获取用户ID存入b.txt文件中
        /// </summary>
        /// <param name="str"></param>
        public static List<string> GetAllPatientId(string str)
        {
            string fullPath2 = "D:\\b.txt";
            StreamWriter sw2 = new StreamWriter(fullPath2, false, Encoding.Default);
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();

            JObject obj = JObject.Parse(str);//将字符串转为JObject格式

            foreach (var x in obj)//遍历JObject,获取每个Key值
            {
                if (x.Key.Equals("Result"))//用户的信息存储在Result中
                {
                    foreach (var y in x.Value)//遍历Result的每一个Value值
                    {
                        list.Add(y.ToString());//将每个值以字符串形式写入list中
                    }
                }
            }

            foreach (string s in list)//遍历list，取出所有的ID
            {
                obj = JObject.Parse(s);
                foreach (var x in obj)
                {
                    if (x.Key.Equals("ID"))
                    {
                        sw2.WriteLine(x.Value + "\n");
                        list2.Add(x.Value.ToString());
                    }
                }
            }
            sw2.Close();
            return list2;
        }

        public static void GetInformationByID(string ID, string str)
        {
            StreamWriter sw = new StreamWriter("D:\\a.txt", false, Encoding.Default);

            JObject obj = JObject.Parse(str);

            foreach (var x in obj)
            {
                if (x.Key.Equals("Result"))
                {
                    str = x.Value.ToString();
                }
            }
            obj = JObject.Parse(str);
            foreach (var x in obj)
            {
                StreamWriter ssw = new StreamWriter($"D:\\{x.Key}.txt", false, Encoding.Default);
                foreach (var y in (JObject)x.Value)
                {
                    if (y.Value.ToString()=="")
                    {
                        ssw.WriteLine($"{y.Key}:null");
                    }
                    else
                    {
                        ssw.WriteLine($"{y.Key}:{y.Value}");
                    }
                }
                ssw.Close();
            }

            sw.Close();


            Console.WriteLine(ID);
        }
    }
}
