using Newtonsoft.Json;
using OneBuck.Models;
using OneBuck.Models.WX;
using System;
using System.Net;
using System.Text;

namespace OneBuck
{
    public abstract class Invoker
    {
        protected static T RequestFor<T>(string url) where T : AbstractResp
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                // call wechat api
                var json = string.Empty;
                try
                {
                    json = client.DownloadString(url);
                }
                catch (Exception ex)
                {
                    throw new OneBuckException("Error communicating with remote server", ex);
                }

                // deserialization
                T ret;
                try
                {
                    ret = JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception ex)
                {
                    throw new OneBuckException("Error deserializing response", ex);
                }

                if (typeof(T) == typeof(PlainResp))
                {
                    return ret;
                }

                if (ret.ErrorCode != 0)
                {
                    throw new OneBuckException(ret.ErrorCode.ToString(), ret.ErrorMessage);
                }

                return ret;
            }
        }

        protected static T RequestFor<T>(string url, object payload) where T : AbstractResp
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;

                // call wechat api
                var json = string.Empty;
                try
                {
                    var data = JsonConvert.SerializeObject(payload);
                    json = client.UploadString(url, null, data);
                }
                catch (Exception ex)
                {
                    throw new OneBuckException("Error communicating with remote server", ex);
                }

                // deserialization
                T ret;
                try
                {
                    ret = JsonConvert.DeserializeObject<T>(json);
                }
                catch (Exception ex)
                {
                    throw new OneBuckException("Error deserializing response", ex);
                }

                if (typeof(T) == typeof(PlainResp))
                {
                    return ret;
                }

                if (ret.ErrorCode != 0)
                {
                    throw new OneBuckException(ret.ErrorCode.ToString(), ret.ErrorMessage);
                }

                return ret;
            }
        }
    }
}