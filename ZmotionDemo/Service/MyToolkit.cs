using LitJson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ZmotionDemo
{
    /// <summary>
    /// 静态Json管理类
    /// </summary>
    public class JsonManager
    {
        public static void SaveJsonString(string path, string fileName, object data)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "/" + fileName;
            string jsonString = JsonMapper.ToJson(data);
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonString);
            FileStream file = new FileStream(path, FileMode.Create);
            file.Write(jsonBytes, 0, jsonBytes.Length);//整块写入
            file.Flush();
            file.Close();
        }

        public static T ReadJsonString<T>(string path, string fileName)
        {
            try
            {
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                path += "/" + fileName;
                if (File.Exists(path))
                {
                    FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader stream = new StreamReader(file);
                    T jsonData = JsonMapper.ToObject<T>(stream.ReadToEnd());
                    file.Flush();
                    file.Close();
                    //T jsonData = JsonMapper.ToObject<T>(File.ReadAllText(path));
                    return jsonData;
                }
            }
            catch (Exception)
            {

            }
            return default;
        }

        public static JsonData ReadSimpleJsonString(string path)
        {
            JsonData jsonData = JsonMapper.ToObject(File.ReadAllText(path));
            return jsonData;
        }
    }
    /// <summary>
    /// 文件配置存储类
    /// </summary>
    public class KeyValueLoader
    {
        public string FileName;
        public string ConfigurationPath;
        public Dictionary<string, string> KeyValueList;

        public KeyValueLoader(string fileName, string path, params string[] keyValues)
        {
            FileName = fileName;
            ConfigurationPath = path;
            KeyValueList = JsonManager.ReadJsonString<Dictionary<string, string>>(ConfigurationPath, FileName);
            if (KeyValueList == null) KeyValueList = new Dictionary<string, string>();
            if (keyValues.Length % 2 == 0 && keyValues.Length != 0)
            {
                for (int i = 0; i < keyValues.Length; i += 2)
                {
                    if (!KeyValueList.ContainsKey(keyValues[i]))
                    {
                        KeyValueList.Add(keyValues[i], keyValues[i + 1]);
                        JsonManager.SaveJsonString(ConfigurationPath, FileName, KeyValueList);
                    }
                }
            }
        }

        public void Add(string key, string value)
        {
            KeyValueList.Add(key, value);
            JsonManager.SaveJsonString(ConfigurationPath, FileName, KeyValueList);
        }

        public void Remove(string key)
        {
            KeyValueList.Remove(key);
            JsonManager.SaveJsonString(ConfigurationPath, FileName, KeyValueList);
        }

        public void Change(string key, string value)
        {
            if (KeyValueList.ContainsKey(key))
            {
                KeyValueList[key] = value;
                JsonManager.SaveJsonString(ConfigurationPath, FileName, KeyValueList);
            }
            else
            {
                Add(key, value);
            }
        }

        public string Load(string key)
        {
            try
            {
                if (KeyValueList.ContainsKey(key))
                    return KeyValueList[key];
                else
                    return "0";
            }
            catch (Exception)
            {
                return "0";
            }
        }
    }
    /// <summary>
    /// 静态文件管理类
    /// </summary>
    public class FileManager
    {
        public static string GetLocalAppPath(string fileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
        }

        public static byte[] GetFileBinary(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fileStream.Length];
            fileStream.Read(data, 0, data.Length);
            fileStream.Close();
            return data;
        }

        public static Stream GetFileStream(string path, int cacheLength = 10240)
        {
            using (var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                var buffer = new byte[cacheLength];
                int bytesRead;
                Stream stream = new MemoryStream();
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
                stream.Seek(0, SeekOrigin.Begin);
                return stream;
            }
        }

        public static async Task WriteStreamAsync(string path, string fileName, Stream message, FileMode fileMode = FileMode.OpenOrCreate)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path += "/" + fileName;
            byte[] buffer = new byte[10240]; int length;
            using (FileStream file = new FileStream(path, fileMode))
            {
                while ((length = await message.ReadAsync(buffer, 0, buffer.Length)) != 0)
                    await file.WriteAsync(buffer, 0, length);
            }
        }

        public static async Task WriteStreamProgressAsync(string path, string fileName, int fileSize, Stream message, IProgress<string> progress, FileMode fileMode = FileMode.OpenOrCreate)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path += "/" + fileName;
            byte[] buffer = new byte[10240]; int length; int progressLength = 0;
            using (FileStream file = new FileStream(path, fileMode))
            {
                while ((length = await message.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    await file.WriteAsync(buffer, 0, length);
                    progressLength += length;
                    progress.Report($"{length * 100 / fileSize}%");
                }
            }
        }

        public static void AppendFlieString(string path, string fileName, string message, FileMode fileMode)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            path += "/" + fileName;
            byte[] data = Encoding.UTF8.GetBytes(message);
            FileStream file = new FileStream(path, fileMode);
            file.Write(data, 0, data.Length);
            file.Flush();
            file.Close();
            file.Dispose();
        }

        public static void SetTableHeader(string path, string fileName, string tableHeader)
        {
            //using FileStream read = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            //using (StreamReader sr = new StreamReader(read))
            //{
            //    if (sr.ReadToEnd() == string.Empty)
            //    {

            //    }
            //}
            FileInfo fileInfo = new FileInfo(path + "/" + fileName);
            if (!fileInfo.Exists || fileInfo.Length == 0)
            {
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                path += "/" + fileName;
                byte[] data = Encoding.UTF8.GetBytes(tableHeader);
                FileStream file = new FileStream(path, FileMode.Append);
                file.Write(data, 0, data.Length);
                file.Flush();
                file.Close();
                file.Dispose();
            }
        }

        public static void AppendLog(string path, string fileName, string tableHeader, string message)
        {
            string log = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss") + "\t" + message + Environment.NewLine;
            SetTableHeader(path, fileName, tableHeader);
            AppendFlieString(path, fileName, log, FileMode.Append);
        }

    }
    /// <summary>
    /// 静态日志纪录类
    /// </summary>
    public class MessageRecorder
    {
        //public static readonly Java.IO.File Storage = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDocuments);
        public static readonly string DocumentPath = "/storage/emulated/0/Documents";
        public static readonly string ConfigurationPath = "/storage/emulated/0/Configuration";

        public static void RecordError(string error, string solution)
        {
            string rowstr = error;
            if (rowstr.IndexOf("\n") > 0)
                rowstr = rowstr.Replace("\n", " ");
            if (rowstr.IndexOf("\r\n") > 0)
                rowstr = rowstr.Replace("\r\n", " ");
            if (rowstr.IndexOf("\t") > 0)
                rowstr = rowstr.Replace("\t", " ");
            FileManager.AppendLog(DocumentPath + "/" + "错误记录", DateTime.Now.ToString("yyy-MM-dd") + "错误记录.xls",
                "日期\t错误信息\t处理方法" + Environment.NewLine,
                string.Format("{0}\t{1}", rowstr, solution));
        }

        public static void RecordProduction(string productionMessage)
        {
            FileManager.AppendLog(DocumentPath + "/" + "生产日志", DateTime.Now.ToString("yyy-MM-dd") + "生产日志.xls",
                "日期\t设备ID\t设备名称\t设备编码\t零件ID\t零件代号\t目标数量\t完成数量" + Environment.NewLine,
                productionMessage);
        }
    }

}
