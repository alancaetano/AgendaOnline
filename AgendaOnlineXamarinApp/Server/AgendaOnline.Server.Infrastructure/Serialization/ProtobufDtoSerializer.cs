﻿using System.IO;
using System.Linq;
using System.Reflection;
using AgendaOnline.Server.Application.DataTransferObjects.Messages;
using AgendaOnline.Server.Infrastructure.Protocol;
using ProtoBuf.Meta;

namespace AgendaOnline.Server.Infrastructure.Serialization
{
    public class ProtobufDtoSerializer : IDtoSerializer
    {
        protected readonly RuntimeTypeModel ProtobufModel;

        public ProtobufDtoSerializer()
        {     
            ProtobufModel = TypeModel.Create();
            var publicTypes = Assembly.GetAssembly(typeof (UserDto)).GetTypes().Where(i => i.IsPublic).ToList();
            foreach (var type in publicTypes)
            {
                var properties = type.GetProperties().Select(p => p.Name).OrderBy(name => name);
                var subClasses = publicTypes.Where(t => t.IsSubclassOf(type)).ToList();
                
                var meta = ProtobufModel.Add(type, true).Add(properties.ToArray());
                for (int i = 0; i < subClasses.Count; i++)
                {
                    var subClass = subClasses[i];
                    //NOTE: Think about backward compatibility in case of adding new subclasses
                    meta.AddSubType(10 + i, subClass);
                }
            }
        }

        public virtual byte[] Serialize<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                ProtobufModel.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public virtual T Deserialize<T>(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return (T)ProtobufModel.Deserialize(ms, null, typeof(T));
            }
        }
    }
}
